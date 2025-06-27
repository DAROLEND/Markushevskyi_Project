namespace WebApplication1.Migrations
{
    using JewelryStore.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<JewelryStore.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(JewelryStore.Models.ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleManager.RoleExists("Admin"))
                roleManager.Create(new IdentityRole("Admin"));

            if (!roleManager.RoleExists("User"))
                roleManager.Create(new IdentityRole("User"));

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (userManager.FindByName("admin@test.com") == null)
            {
                var adminUser = new ApplicationUser
                {
                    UserName = "admin@test.com",
                    Email = "admin@test.com",
                    EmailConfirmed = true
                };

                var result = userManager.Create(adminUser, "Admin123!");

                if (result.Succeeded)
                {
                    userManager.AddToRole(adminUser.Id, "Admin");
                }
            }

            if (!context.Jewelries.Any())
            {
                var jewelries = new List<Jewelry>
        {
            new Jewelry { Name = "Обручка", Material = "Жовте золото", Description = "Традиційна обручка", Price = 5500 },
        new Jewelry { Name = "Перстень з сапфіром", Material = "Платина", Description = "Рідкісний сапфір", Price = 22000 },
        new Jewelry { Name = "Підвіска з рубіном", Material = "Срібло", Description = "Елегантна підвіска", Price = 8700 },
        new Jewelry { Name = "Сережки з діамантами", Material = "Золото", Description = "Вишукані сережки", Price = 18000 },
        new Jewelry { Name = "Срібний браслет", Material = "Срібло", Description = "Класичний браслет", Price = 3500 },
        new Jewelry { Name = "Чоловічий браслет", Material = "Сталь", Description = "Сучасний дизайн", Price = 4300 },
        new Jewelry { Name = "Брошка з перлами", Material = "Срібло", Description = "Вишукана брошка з натуральними перлами", Price = 7900 },
        new Jewelry { Name = "Кулон із сапфіром", Material = "Біле золото", Description = "Елегантний кулон", Price = 9500 },
        new Jewelry { Name = "Дитячий браслет", Material = "Срібло", Description = "Браслет для дітей", Price = 1200 },
        new Jewelry { Name = "Годинник з діамантами", Material = "Платина", Description = "Розкішний годинник", Price = 48000 },
        new Jewelry { Name = "Сережки з перлами", Material = "Золото", Description = "Класичні сережки", Price = 6700 },
        new Jewelry { Name = "Браслет із червоного золота", Material = "Червоне золото", Description = "Модний браслет", Price = 15300 },
        new Jewelry { Name = "Ланцюжок для підвіски", Material = "Срібло", Description = "Універсальний ланцюжок", Price = 2100 },
        new Jewelry { Name = "Підвіска у формі серця", Material = "Жовте золото", Description = "Подарунок для коханої", Price = 7200 },
        new Jewelry { Name = "Кільце з оніксом", Material = "Срібло", Description = "Стильне кільце", Price = 5900 }
        };

                context.Jewelries.AddRange(jewelries);
                context.SaveChanges();
            }
        }

    }
}
