using OnlineShop.Common;
using OnlineShop.Data.Infrastructure;
using OnlineShop.Data.Repositories;
using OnlineShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Service
{
    public interface ICommonService
    {
        Footer GetFooter();
        IEnumerable<Slide> GetSlide();
        IEnumerable<Product> GetLastestProducts();
        IEnumerable<Product> GetHotProducts();
        void SaveChanges();
    }
    public class CommonService : ICommonService
    {
        private IFooterRepository _footerRepository;
        private IUnitOfWork _unitOfWork;
        private ISlideRepository _slideRepository;
        private IProductRepository _productRepository;
        public CommonService(IFooterRepository footerRepository, IUnitOfWork unitOfWork, ISlideRepository slideRepository, IProductRepository productRepository)
        {
            this._footerRepository = footerRepository;
            this._unitOfWork = unitOfWork;
            this._slideRepository = slideRepository;
            this._productRepository = productRepository;

        }
        public Footer GetFooter()
        {
            return _footerRepository.GetSingleByCondition(x => x.ID == CommonConstants.DefaultFooterId);
        }

        public IEnumerable<Slide> GetSlide()
        {
            return _slideRepository.GetAll().OrderBy(x => x.DisplayOrder);
           
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<Product> GetLastestProducts()
        {
            IEnumerable<Product> list = _productRepository.GetAll().OrderBy(x => x.CreatedDate).Take(3);
            return list;
        }

        public IEnumerable<Product> GetHotProducts()
        {
            return _productRepository.GetAll().Where(x => x.HotFlag ?? false).Take(4);
        }
    }
}
