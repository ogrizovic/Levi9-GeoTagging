using System;
using Microsoft.Owin.Hosting;

namespace SignalRSelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            //IoCKernel.Init(new DependencyResolver());
            ServerHub hub = new ServerHub();
            // This will *ONLY* bind to localhost, if you want to bind to all addresses
            // use http://*:8080 to bind to all addresses. 
            // See http://msdn.microsoft.com/en-us/library/system.net.httplistener.aspx 
            // for more information.
            string url = "http://10.1.100.33:8081";
            using (WebApp.Start(url))
            {
                Console.WriteLine("Server running on {0}", url);
                Console.ReadLine();
            }
        }
    }
}