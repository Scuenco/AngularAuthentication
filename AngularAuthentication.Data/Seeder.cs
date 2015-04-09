using AngularAuthentication.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularAuthentication.Data
{
    public static class Seeder
    {
        public static void Seed(ApplicationDbContext db, bool seedRoles = false, bool seedUsers = false, bool seedTasks = false)
        {
            if (seedRoles) SeedRoles(db);
            if (seedUsers) SeedUsers(db);
            if (seedTasks) SeedTasks(db);
        }

        private static void SeedRoles(ApplicationDbContext db)
        {
            var manager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            if (!manager.RoleExists("User"))
            {
                manager.Create(new IdentityRole() { Name = "User" });
            }
        }

        private static void SeedUsers(ApplicationDbContext db)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            if (!db.Users.Any(x => x.UserName == "test"))
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = "test",
                    Email = "test@test.com"
                };
                manager.Create(user, "123123");
                manager.AddToRole(user.Id, "User");
            }
            if (!db.Users.Any(x => x.UserName == "test2"))
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = "test2",
                    Email = "test2@test.com"
                };
                manager.Create(user, "123123");
                manager.AddToRole(user.Id, "User");
            }
        }

        private static void SeedTasks(ApplicationDbContext db)
        {
            string test = db.Users.FirstOrDefault(x => x.UserName == "test").Id;
            string test2 = db.Users.FirstOrDefault(x => x.UserName == "test2").Id;

            db.ToDos.AddOrUpdate(x => x.ToDoId,
                new ToDo() { ToDoId = 1, Description = "This is a test Task", UserId = test },
                new ToDo() { ToDoId = 2, Description = "Learn Angular", UserId = test },
                new ToDo() { ToDoId = 3, Description = "Learn C#", UserId = test },
                new ToDo() { ToDoId = 4, Description = "Learn SQL", UserId = test2 },
                new ToDo() { ToDoId = 5, Description = "Learn Bootstrap", UserId = test2 },
                new ToDo() { ToDoId = 6, Description = "Learn Async Methods", UserId = test2 }
                );
        }
    }
}