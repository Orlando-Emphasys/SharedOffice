using SharedOffice.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SharedOffice.Controllers
{
    public class HomeController : Controller
    {
        SharedOfficeContext db = new SharedOfficeContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadChannels()
        {
            var channels = from x in db.Channel select x;
            return Json(channels);

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

        public ActionResult loadtop5Posts()
        {
            var popularposts = from x in db.Posts select x;
            return Json(popularposts);
        }

        public ActionResult OldPosts()
        {
            buildViewbag();
            return View();
        }
    }
}