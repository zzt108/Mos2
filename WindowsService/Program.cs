using System;
using System.ServiceProcess;

namespace WindowsService
{
    static class Program
    {
        static void Main()
        {

            //Debug code
            if (!Environment.UserInteractive)
            {
                var servicesToRun = new ServiceBase[]
                {
                    new Service1()
                };
                ServiceBase.Run(servicesToRun);
            }
            else
            {
                var service = new Service1();
                service.Start();

                // forces debug to keep VS running while we debug the service
                System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
            }
        }    }
}
