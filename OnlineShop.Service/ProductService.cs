using OnlineShop.Data.Infrastructure;
using OnlineShop.Data.Repositories;
using OnlineShop.Model.Models;
using System.Collections.Generic;
using System;

namespace OnlineShop.Service
{
    public interface IProductService
    {
        Product Add(Product product);

        void Update(Product Product);

        Product Delete(int id);

        IEnumerable<Product> GetAll();

        IEnumerable<Product> GetAll(string keywork);

        IEnumerable<Product> GetAllPaging(int page, int pageSize, out int totalRow);

        Product GetById(int id);

        void SaveChanges();
    }

    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            this._productRepository = productRepository;
            this._unitOfWork = unitOfWork;
        }

        public Product Add(Product productCategoy)
        {
            return _productRepository.Add(productCategoy);
        }

        public Product Delete(int id)
        {
            return _productRepository.Delete(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public IEnumerable<Product> GetAll(string keywork)
        {
            if (string.IsNullOrEmpty(keywork))
                return _productRepository.GetAll();
            return _productRepository.GetMulti(x => x.Name.ToLower().Contains(keywork.ToLower()) || x.Description.ToLower().Contains(keywork.ToLower()));
        }

        public IEnumerable<Product> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _productRepository.GetMultiPaging(x => x.HomeFlag ?? false, out totalRow, page, pageSize);
        }

        public Product GetById(int id)
        {
            return _productRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Product product)
        {
            _productRepository.Update(product);
        }
    }
}