using Owin;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;

namespace SignalRSelfHost
{
    // Owin Startup class
    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var configuration = new HubConfiguration();
            configuration.EnableDetailedErrors = true;
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR(configuration);
        }
    }
}