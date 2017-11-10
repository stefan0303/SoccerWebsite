using Microsoft.Owin;
using Owin;
using System;

[assembly: OwinStartupAttribute(typeof(SoccerWebsite.Startup))]
namespace SoccerWebsite
{
    public partial class Startup {
        public void Configuration(IAppBuilder app)
        {
            
            ConfigureAuth(app);
         
        }

       
    }
}
