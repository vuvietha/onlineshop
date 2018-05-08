namespace OnlineShop.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Model.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OnlineShop.Data.OnlineShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(OnlineShop.Data.OnlineShopDbContext context)
        {
            CreateProductCategory(context);
            //  This method will be called after migrating to the latest version.

            //var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new OnlineShopDbContext()));
            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new OnlineShopDbContext()));
            //var user = new ApplicationUser()
            //{
            //    UserName = "havv",
            //    Email = "havv56@gmail.com",
            //    EmailConfirmed = true,
            //    Birthday = DateTime.Now,
            //    FullName = "Vu Viet Ha"
            //};
            //manager.Create(user, "123456$");

            //if (roleManager.Roles.ToList().Count == 0)
            //{
            //    roleManager.Create(new IdentityRole { Name = "Admin" });
            //    roleManager.Create(new IdentityRole { Name = "User" });
            //}
            //var adminUser = manager.FindByEmail("havv56@gmail.com");
            //manager.AddToRole(adminUser.Id, "Admin");
            //manager.AddToRole(adminUser.Id, "User");
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }

        private void CreateProductCategory(OnlineShop.Data.OnlineShopDbContext context)
        {
            if (context.ProductCategories.Count() == 0)
            {
                List<ProductCategory> list = new List<ProductCategory>()
                {
                    new ProductCategory() {Name = "Điện lạnh", Alias="dien-lanh",Status=true },
                    new ProductCategory() {Name = "Viễn thông", Alias="vien-thong",Status=true },
                    new ProductCategory() {Name = "Đồ gia dụng", Alias="do-gia-dung",Status=true },
                    new ProductCategory() {Name = "Mỹ phẩm", Alias="my-pham",Status=true },
                };
                context.ProductCategories.AddRange(list);
                context.SaveChanges();
            }
        }
    }
}