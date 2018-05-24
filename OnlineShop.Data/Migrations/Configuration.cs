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
            //CreateProductCategory(context);
            CreateSlides(context);
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

        private void CreateSlides(OnlineShopDbContext context)
        {
            if (context.Slides.Count() == 0)
            {
                List<Slide> list = new List<Slide>()
                {
                    new Slide() {Name="slide1",
                        DisplayOrder = 1,URL="#",
                        Image ="/Assets/client/images/1.jpg",
                        Content =@"<div class='contentSlide w3l_banner_nav_right_banner'>
                                    <h3>Make your <span>food</span> with Spicy.</h3>
                                    <div class='more'>
                                        <a href = 'products.html' class='button--saqui button--round-l button--text-thick' data-text='Shop now'>Shop now</a>
                                    </div>
                                    </div>" },
                    new Slide() {Name="slide2",
                        DisplayOrder = 2,
                        URL ="#",
                        Image ="/Assets/client/images/2.jpg",
                        Content =@"<div class='contentSlide w3l_banner_nav_right_banner'>
                                    <h3>Make your <span>food</span> with Spicy.</h3>
                                    <div class='more'>
                                        <a href = 'products.html' class='button--saqui button--round-l button--text-thick' data-text='Shop now'>Shop now</a>
                                    </div>
                                    </div>" },
                     new Slide() {Name="slide3",
                        DisplayOrder = 3,
                        URL ="#",
                        Image ="/Assets/client/images/3.jpg",
                        Content =@"<div class='contentSlide w3l_banner_nav_right_banner'>
                                     <h3>upto <i>50%</i> off.</h3>
                                    <div class='more'>
                                        <a href = 'products.html' class='button--saqui button--round-l button--text-thick' data-text='Shop now'>Shop now</a>
                                    </div>
                                    </div>" }
                };
                context.Slides.AddRange(list);
                context.SaveChanges();
            }
           

        }
    }
}