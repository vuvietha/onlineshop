using AutoMapper;
using OnlineShop.Model.Models;
using OnlineShop.Service;
using OnlineShop.Web.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Web.Controllers
{
    public class HomeController : Controller
    {
        IProductCategoryService _productCategoryService;
        ICommonService _commonService;
        public HomeController(IProductCategoryService productCategoryService, ICommonService commonService)
        {
            this._productCategoryService = productCategoryService;
            this._commonService = commonService;

        }
        public ActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();
            var slideList = _commonService.GetSlide();
            var slideListVM = Mapper.Map<IEnumerable<SlideViewModel>>(slideList);
            List<Product> lastestProductList = _commonService.GetLastestProducts().ToList();
            var hotProductList = _commonService.GetHotProducts();
            List<ProductViewModel> lastestProductListVM = Mapper.Map<List<ProductViewModel>>(lastestProductList);
            var hotProductListVM = Mapper.Map<IEnumerable<ProductViewModel>>(hotProductList);
            model.slideViewModel = slideListVM;
            model.lastestProductList = lastestProductListVM;
            model.hotProductList = hotProductListVM;
            
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [ChildActionOnly]
        public ActionResult Header()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            Footer data = _commonService.GetFooter();
            FooterViewModel model = Mapper.Map<FooterViewModel>(data);
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult Category()
        {
            var data = _productCategoryService.GetAll();
            IEnumerable model = Mapper.Map<IEnumerable<ProductCategoryViewModel>>(data);
            return PartialView(model);
        }
    }
}