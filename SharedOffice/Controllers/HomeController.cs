using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SharedOffice.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            buildViewbag();
            return View();
        }
        
        private void buildViewbag()
        {
            var selectList = new SelectList(new List<SelectListItem>()
            {
                new SelectListItem() {Text="Full", Value="1" },
                new SelectListItem() {Text="Half", Value="2" },
                new SelectListItem() {Text="Low", Value="3" },
                new SelectListItem() {Text="None", Value="4" }
            }, "Value", "Text", 1);

            ViewBag.Inventory = selectList;
        }

        public ActionResult OldPosts()
        {
            buildViewbag();
            return View();
        }
    }
}