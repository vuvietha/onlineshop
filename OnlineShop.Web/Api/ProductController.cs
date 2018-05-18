using OnlineShop.Web.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OnlineShop.Service;
using AutoMapper;
using OnlineShop.Model.Models;
using OnlineShop.Web.Models;
using OnlineShop.Web.Infrastructure.Extensions;
using System.Web.Script.Serialization;

namespace OnlineShop.Web.Api
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiControllerBase
    {
        #region initilize
        IProductService _productService;
       
        public ProductController(IErrorService errorService, IProductService productService)
            : base(errorService)
        {
            this._productService = productService;
        
        }
        #endregion
        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage Get(HttpRequestMessage request, string keyword, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _productService.GetAll(keyword);
                var totalRow = model.Count();
                var query = model.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);
                var responseData = Mapper.Map<List<ProductViewModel>>(query);
                PaginationSet<ProductViewModel> pagenationSet = new PaginationSet<ProductViewModel>()
                {
                    Items = responseData,
                    Page = page,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize),
                    TotalCount = totalRow


                };
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, pagenationSet);
                return response;
            });
        }
      
        [Route("edit/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetProductDetail(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var Product = _productService.GetById(id);
                var responseData = Mapper.Map<ProductViewModel>(Product);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
        [Route("delete")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var oldProduct = _productService.Delete(id);
                _productService.SaveChanges();
                var responseData = Mapper.Map<ProductViewModel>(oldProduct);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
        [Route("deletemultiple")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage DeleteMultiple(HttpRequestMessage request, string checkedProduct)
        {
            return CreateHttpResponse(request, () =>
            {
                var listProductId = new JavaScriptSerializer().Deserialize<List<int>>(checkedProduct);
                foreach (var item in listProductId)
                {
                    _productService.Delete(item);
                }
                _productService.SaveChanges();
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listProductId.Count);
                return response;
            });
        }
        [Route("create")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, ProductViewModel productViewModel)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    Product product = new Product();
                    product.UpdateProduct(productViewModel);
                    _productService.Add(product);
                    _productService.SaveChanges();
                    var responseData = Mapper.Map<ProductViewModel>(product);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }


                return response;
            });

        }
        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, ProductViewModel productViewModel)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    Product product = _productService.GetById(productViewModel.ID);
                    product.UpdatedDate = DateTime.Now;
                    product.UpdateProduct(productViewModel);
                    _productService.Update(product);
                    _productService.SaveChanges();
                    var responseData = Mapper.Map<ProductViewModel>(product);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });

        }
    }
}
