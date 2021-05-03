using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;
using Bondora.Services;
using System.Threading;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace Bondora
{
    class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("bondora.program"); 
        static void Main(string[] args)
        {
            log.Debug("Main: Starting");
            CartInfoReceiver cartInfo = new CartInfoReceiver("tobackend");
            try
            {
                Thread.Sleep(Timeout.Infinite);
            } catch (Exception ex)
            {
                log.Error("Main: Error.", ex);
            }
        }
    }
}
