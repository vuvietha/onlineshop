using OnlineShop.Web.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OnlineShop.Service;

namespace OnlineShop.Web.Api
{
    [RoutePrefix("api/home")]
    [Authorize]
    public class HomeController : ApiControllerBase
    {
        IErrorService _errorSerive;
        public HomeController(IErrorService errorService) : base(errorService)
        {
            this._errorSerive = errorService;
        }
        [HttpGet]
        [Route("testmethod")]
        public string TestMethod()
        {
            return "Hello world";
        }
    }

    
}
