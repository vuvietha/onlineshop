using AutoMapper;
using OnlineShop.Common;
using OnlineShop.Model.Models;
using OnlineShop.Service;
using OnlineShop.Web.Infrastructure.Core;
using OnlineShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OnlineShop.Web.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }

        // GET: Product
        public ActionResult Detail(int id)
        {
            return View();
        }

        public ActionResult Category(int id, int page=1)
        {
            int pageSize = int.Parse(ConfigHelper.GetByKey("PageSize"));
            int maxPage = int.Parse(ConfigHelper.GetByKey("MaxPage"));
            int totalRow = 0;
            IEnumerable<Product> ListProduct = _productService.GetAllProductsPagingByCatId(id, page, pageSize, out totalRow);
            IEnumerable<ProductViewModel> ListProductVM = Mapper.Map<IEnumerable<ProductViewModel>>(ListProduct);
            int totalPage = (int) (Math.Ceiling((double)totalRow / pageSize));
            PaginationSet<ProductViewModel> pagination = new PaginationSet<ProductViewModel>()
            {
                Items = ListProductVM,
                Page = page,
                TotalCount = totalRow,
                MaxPage = maxPage,
                TotalPages = totalPage
            };
            return View(pagination);
        }
    }
}