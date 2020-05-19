using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System;
using tyrone_hoare.Models;

[assembly: OwinStartupAttribute(typeof(tyrone_hoare.Startup))]
namespace tyrone_hoare
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //createRolesAndDefaultUsers();
        }
       

    }
}

