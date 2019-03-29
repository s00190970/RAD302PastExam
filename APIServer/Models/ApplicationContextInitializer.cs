using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace APIServer.Models
{
    public class ApplicationContextInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        public ApplicationContextInitializer()
        {
            // Will Fire when App starts up for the first time
        }
        protected override void Seed(ApplicationDbContext context)
        {
            Random r = new Random();
            PasswordHasher hasher = new PasswordHasher();

            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            context.Roles.AddOrUpdate(rl => rl.Name, new IdentityRole { Name = "Admin" });
            context.SaveChanges();

            context.Users.AddOrUpdate(u => u.UserName,
                new ApplicationUser
                {

                    UserName = "powell.paul@itsligo.ie",
                    Email = "powell.paul@itsligo.ie",
                    EmailConfirmed = true,
                    FirstName = "Paul",
                    LastName = "Powell",
                    PasswordHash = hasher.HashPassword("itsPaul$1"),
                    SecurityStamp = Guid.NewGuid().ToString(),

                });
            context.SaveChanges();

            ApplicationUser admin = manager.FindByEmail("powell.paul@itsligo.ie");
            manager.AddToRoles(admin.Id, "Admin");
            context.SaveChanges();

            base.Seed(context);
        }

    }
}