using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bondora.Services
{
    public class FileWriter
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("bondora.services.filewriter");
        public FileWriter() { }
        public void WriteInvoice(string filename, string body)
        {
            var path = System.IO.Path.Combine("C:\\Bondora\\Invoices\\", filename);
            FileInfo fi = new FileInfo(path);
            try
            {
                if (fi.Exists)
                {
                    fi.Delete();
                }
                using (StreamWriter sw = fi.CreateText())
                {
                    sw.Write(body);
                    log.Debug("WriteInvoice: Written to file");
                }
            }
            catch (Exception ex)
            {
                log.Error("WriteInvoice: Error.", ex);
            }
        }
    }
}
