using Experimental.System.Messaging;
using System;

namespace Frontend.Services
{
    public class CartInfoSender
    {
        public static MessageQueue queue { get; private set; }
        public static bool isInitialized { get; private set; }
        public CartInfoSender()
        {
            isInitialized = false;
        }
        public void initializeQueue()
        {
            if (isInitialized) return;

            try
            {
                queue = new MessageQueue();
                queue.Path = @".\private$\tobackend";
                if (!MessageQueue.Exists(queue.Path))
                {
                    MessageQueue.Create(queue.Path);
                }
                isInitialized = true;
            } 
            catch (Exception ex)
            {
                isInitialized = false;
            }
        }
        public void SendMessage(string body)
        {
            if (!isInitialized)
            {
                initializeQueue();
            }
            
            if (isInitialized)
            {
                Message cart = new Message();
                cart.Body = body;
                queue.Send(cart);
            }
        }
    }
}
