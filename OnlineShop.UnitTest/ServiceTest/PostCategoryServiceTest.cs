using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineShop.Data.Infrastructure;
using OnlineShop.Data.Repositories;
using OnlineShop.Model.Models;
using OnlineShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.UnitTest.ServiceTest
{
    [TestClass]
    public class PostCategoryServiceTest
    {
        private Mock<IPostCategoryRepository> _mockRepository;
        private Mock<IUnitOfWork> _unitOfWork;
        private PostCategoryService _categoryService;
        private List<PostCategory> _listCategory;

        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<IPostCategoryRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _categoryService = new PostCategoryService(_mockRepository.Object, _unitOfWork.Object);
            _listCategory = new List<PostCategory>()
            {
                new PostCategory() {Name="DM1",Alias="dm1" },
                new PostCategory() {Name="DM2",Alias="dm2" },
                new PostCategory() {Name="DM3",Alias="dm3" }
            };

        }

        [TestMethod]
        public void PostCategory_Service_GetAll()
        {
            //Set up method
            _mockRepository.Setup(m => m.GetAll(null)).Returns(_listCategory);

            //call action
            var result = _categoryService.GetAll() as List<PostCategory>;

            //compare
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count());
            
        }
        [TestMethod]
        public void PostCategory_Service_Create()
        {
            //Create PostCategory object
            PostCategory category = new PostCategory();
            int id = 1;
            category.Name = "Test";
            category.Alias = "test";

            //Set up method
            _mockRepository.Setup(m => m.Add(category)).Returns((PostCategory p) =>
            {
                p.ID = 1;
                return p;
            });
            var result = _categoryService.Add(category);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.ID);
        }
    }
}
