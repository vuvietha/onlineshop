using OnlineShop.Data.Infrastructure;
using OnlineShop.Data.Repositories;
using OnlineShop.Model.Models;
using System.Collections.Generic;
using System;
using OnlineShop.Common;
using System.Linq;

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

        IEnumerable<Product> GetAllProductsPagingByCatId(int catId, int page, int pageSize, out int totalRow);

        Product GetById(int id);

        void SaveChanges();
    }

    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private IProductTagRepository _productTagRepository;
        private ITagRepository _tagRepository;
        private IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository, IProductTagRepository productTagRepository, ITagRepository tagRepository, IUnitOfWork unitOfWork)
        {
            this._productRepository = productRepository;
            this._productTagRepository = productTagRepository;
            this._tagRepository = tagRepository;
            this._unitOfWork = unitOfWork;
        }

        public Product Add(Product product)
        {
            string tags = product.Tags;
            Product productAdd = _productRepository.Add(product);
            if (!string.IsNullOrEmpty(tags))
            {
                string[] tagList = tags.Split(',');
                foreach (string tag in tagList)
                {
                    string tagID = StringHelper.ToUnSignString(tag);
                    if(_tagRepository.Count(x => x.ID == tagID) == 0)
                    {
                        Tag tagAdd = new Tag
                        {
                            ID = tagID,
                            Name = tag,
                            Type = CommonConstants.ProductTag
                        };
                        _tagRepository.Add(tagAdd);
                    }
                    ProductTag productTagAdd = new ProductTag
                    {
                        ProductID = productAdd.ID,
                        TagID = tagID
                    };
                    _productTagRepository.Add(productTagAdd);
                }
                
            }
            return productAdd;
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

        public IEnumerable<Product> GetAllProductsPagingByCatId(int catId, int page, int pageSize, out int totalRow)
        {
            var query = _productRepository.GetMulti(x => x.Status && x.CategoryID == catId);
            totalRow = query.Count();
            return query.Skip((page - 1) * pageSize).Take(pageSize);       
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
            string tags = product.Tags;
            _productTagRepository.DeleteMulti(x => x.ProductID == product.ID);
            if (!string.IsNullOrEmpty(tags))
            {
                string[] tagList = tags.Split(',');
                foreach (string tag in tagList)
                {
                    string tagID = StringHelper.ToUnSignString(tag);
                    if (_tagRepository.Count(x => x.ID == tagID) == 0)
                    {
                        Tag tagAdd = new Tag
                        {
                            ID = tagID,
                            Name = tag,
                            Type = CommonConstants.ProductTag
                        };
                        _tagRepository.Add(tagAdd);
                    }
                    ProductTag productTagEdit = new ProductTag
                    {
                        ProductID = product.ID,
                        TagID = tagID
                    };
                    _productTagRepository.Add(productTagEdit);
                }

            }
            _productRepository.Update(product);
        }
    }
}