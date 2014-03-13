
using RazApp.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RazApp.Web.Extensions;
using RazApp.Web.Filters;

namespace RazApp.Web.Controllers
{
    public class HomeController : BaseController
    {

        #region Dependency Injection

        private readonly IUserService userService;
        public HomeController(IUserService _userService)
        {
            this.userService = _userService;
        }
        #endregion


        [OutputCache(Duration = 10, VaryByParam = "none")]       
        public ActionResult Index()
        {
          
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
