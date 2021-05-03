using System;
using Bondora.Models;
using Newtonsoft.Json;
using System.Messaging;
using System.Threading;
using Bondora.Helpers;

namespace Bondora.Services
{
    public class CartInfoReceiver
    {
		private Thread receiver;
		private MessageQueue toBackend;
		private delegate void ProcessMessageDelegate(Message message);
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger("bondora.services.cartinforcvr");
		public CartInfoReceiver(string queueName)
		{
			toBackend = new MessageQueue();
			toBackend.Path = @".\private$\tobackend";
			receiver = new Thread(ListenToQueue);
			receiver.IsBackground = true;
			receiver.Name = "CartInfoListener";
			receiver.Start();
		}

		private void ListenToQueue()
		{
			while (true)
			{
				using (Message msg = toBackend.Receive())
				{
					log.Info("ListenToQueue: New message received.");
					ProcessMessageDelegate process = ProcessMessage;
					process.Invoke(msg);
				}
			}
		}

		public void ProcessMessage(Message message)
		{
			message.Formatter = new XmlMessageFormatter(
                            new string[] { "System.String,mscorlib" }
                        );
            string json = message.Body.ToString();
			log.Debug("ProcessMessage: Received msg: " + json);
			Cart cart = JsonConvert.DeserializeObject<Cart>(json);
			string invoiceText = "Bondara Equipment Rental Service\n\n";
			RentalCalculator rc = new RentalCalculator();
			Loyalty loyalty = new Loyalty();
			float total = 0;
			float points = 0;
			foreach (CartItem item in cart.getCartItems())
			{
				invoiceText += "Name: " + item.equipment.name;
				invoiceText += "\t\t\t\t Type: " + item.equipment.type;
				float price = rc.getRentalPrice(item.equipment.type, item.days);
				invoiceText += ", \t\t\t\t Rental Price: " + price + "\n\n\n";
				total += price;
				points += loyalty.getPoints(item.equipment.type);
				log.Debug("ProcessMessage: Eq Name:" + item.equipment.name + "|Type:" + item.equipment.type + "|Price:" + price);
            }
			invoiceText += "Total Price: " + total + "\n\n\n";
			invoiceText += "Loyalty Points earned: " + points + "\n";
			log.Debug("ProcessMessage: Total price: " + total + "|Points:" + points);
			FileWriter fw = new FileWriter();
			fw.WriteInvoice("Invoice.txt", invoiceText);
			log.Debug("ProcessMessage: Invoice generated at C:\\Bondora\\Invoices\\Invoice.txt");
		}
	}
}
