using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Web.Models
{
    public class HomeViewModel
    {
        public IEnumerable<SlideViewModel> slideViewModel { get; set; }
        public IEnumerable<ProductViewModel> lastestProductList { get; set; }
        public IEnumerable<ProductViewModel> hotProductList { get; set; }
    }
}