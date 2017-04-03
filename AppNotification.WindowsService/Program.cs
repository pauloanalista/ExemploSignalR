using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppNotification.WindowsService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {

#if (!DEBUG)
      
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new NotificationService()
            };
            ServiceBase.Run(ServicesToRun);
#else

            new NotificationService().InitializeSelfHosting();

            while (true)
            {
                Console.WriteLine("Teste " + DateTime.Now);

                Thread.Sleep(20000);
            }

            
            //Console.ReadKey();
#endif
        }
    }
}
