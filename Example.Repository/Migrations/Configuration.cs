using Example.Domain.Models;

namespace Example.Repository.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Example.Repository.DBContext.ExampleDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Example.Repository.DBContext.ExampleDBContext context)
        {
            //Enable-Migrations
            //Add-Migration
            //Update-Database
            context.Users.AddOrUpdate(i => i.Name,
                new User
                {
                    Name = "Jamie",
                    RealName = "Jamie Munro",
                    Email = "a@aaa.com",
                    CreationTime = DateTime.Now,
                    State = 1,
                    Password = "aaaaaa"
                },
                new User
                {
                    Name = "aaa",
                    RealName = "dsd dsds",
                    Email = "333@errr.rrr",
                    CreationTime = DateTime.Now,
                    State = 1,
                    Password = "fdsfdsfsdf"
                }
                );
            context.Roles.AddOrUpdate(i => i.RoleName,
                new Role { RoleName = "admin",CreationTime = DateTime.Now },
                new Role { RoleName = "user", CreationTime = DateTime.Now }
                );
        }
    }
}
