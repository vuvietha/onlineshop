using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineShop.Data.Infrastructure;
using OnlineShop.Data.Repositories;
using OnlineShop.Model.Models;
using System.Linq;

namespace OnlineShop.UnitTest.RepositoryTest
{
    [TestClass]
    public class PostCategoryRepositoryTest
    {
        private IDbFactory dbFactory;
        private IPostCategoryRepository objRepository;
        private IUnitOfWork unitOfWork;

        [TestInitialize]
        public void Initialize()
        {
            dbFactory = new DbFactory();
            objRepository = new PostCategoryRepository(dbFactory);
            unitOfWork = new UnitOfWork(dbFactory);
        }

        [TestMethod]
        public void PostCategory_Repository_GetAll()
        {
            var list = objRepository.GetAll().ToList();
            Assert.AreEqual(2, list.Count());
        }

        [TestMethod]
        public void PostCategory_Repository_Create()
        {
            PostCategory category = new PostCategory();
            category.Name = "Test Category";
            category.Alias = "test-category";
            var result = objRepository.Add(category);
            unitOfWork.Commit();
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.ID);
        }
    }
}