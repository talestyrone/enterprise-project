using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApplication1.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("TyronedbConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new webApp());
        }
        public class webApp : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
        {
            public override void InitializeDatabase(ApplicationDbContext context)
            {
                base.InitializeDatabase(context);
            }

            protected override void Seed(ApplicationDbContext context)
            {
                base.Seed(context);
                List<Quality> quality = new List<Quality>();
                quality.Add(new Quality() { type = "Excellent" });
                quality.Add(new Quality() { type = "Good" });
                quality.Add(new Quality() { type = "Poor" });
                quality.Add(new Quality() { type = "Bad" });
                context.Qualities.AddRange(quality);
                context.SaveChanges();
            }
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public System.Data.Entity.DbSet<WebApplication1.Models.Quality> Qualities { get; set; }

        public System.Data.Entity.DbSet<WebApplication1.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<WebApplication1.Models.ItemType> ItemTypes { get; set; }

        public System.Data.Entity.DbSet<WebApplication1.Models.Item> Items { get; set; }

    }
}