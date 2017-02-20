using Adomicilio.Models;
using Microsoft.Owin;
using Owin;
using System.Web.Services.Description;

[assembly: OwinStartupAttribute(typeof(Adomicilio.Startup))]
namespace Adomicilio
{
    public partial class Startup
    {
       
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
          
        }
        public void ConfigureServices(ServiceCollection services)
        {
       

         
        }
    }
}
