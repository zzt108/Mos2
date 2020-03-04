using System;
using Nancy;
using Nancy.Hosting.Self;

namespace Api
{
    public class Server
    {
        private static  NancyHost _host;

        public Server()
        {
            const string url = "http://localhost:8080";
            var hostConfigs = new HostConfiguration {UrlReservations = {CreateAutomatically = true}};
            _host = new NancyHost(new Uri(url), new DefaultNancyBootstrapper(), hostConfigs);
  
        }

        public void Start()
        {
            _host.Start();
        }

        public void Stop()
        {
            _host.Stop();
        }
    }
}
