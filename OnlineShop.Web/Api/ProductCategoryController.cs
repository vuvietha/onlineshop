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
namespace OnlineShop.Web.Api
{
    [RoutePrefix("api/productcategory")]
    public class ProductCategoryController : ApiControllerBase
    {
        #region initilize
        IProductCategoryService _productCategoryService;
        public ProductCategoryController(IErrorService errorService, IProductCategoryService productCategoryService) 
            : base(errorService)
        {
            this._productCategoryService = productCategoryService;
        }
        #endregion
        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage Get(HttpRequestMessage request,string keyword, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _productCategoryService.GetAll(keyword);
                var totalRow = model.Count();
                var query = model.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);
                var responseData = Mapper.Map<List<ProductCategoryViewModel>>(query);
                PaginationSet<ProductCategoryViewModel> pagenationSet = new PaginationSet<ProductCategoryViewModel>()
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
        [Route("getallparents")]
        [HttpGet]
        public HttpResponseMessage GetParents(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _productCategoryService.GetAll();
                var responseData = Mapper.Map<List<ProductCategoryViewModel>>(model);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
        [Route("edit/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetProductCategoryDetail(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var productCategory = _productCategoryService.GetById(id);
                var responseData = Mapper.Map<ProductCategoryViewModel>(productCategory);
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
                var oldProductCategory = _productCategoryService.Delete(id);
                _productCategoryService.SaveChanges();
                var responseData = Mapper.Map<ProductCategoryViewModel>(oldProductCategory);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
        [Route("create")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request,ProductCategoryViewModel productCategoryViewModel)
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
                    ProductCategory productCategory = new ProductCategory();
                    productCategory.UpdateProductCategory(productCategoryViewModel);
                    _productCategoryService.Add(productCategory);
                    _productCategoryService.SaveChanges();
                    var responseData = Mapper.Map<ProductCategoryViewModel>(productCategory);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
               
                
                return response;
            });

        }
        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, ProductCategoryViewModel productCategoryViewModel)
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
                    ProductCategory productCategory = _productCategoryService.GetById(productCategoryViewModel.ID);
                    productCategory.UpdateProductCategory(productCategoryViewModel);
                    _productCategoryService.Update(productCategory);
                    _productCategoryService.SaveChanges();
                    var responseData = Mapper.Map<ProductCategoryViewModel>(productCategory);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });

        }
    }
}
