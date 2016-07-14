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

        }

        public ActionResult loadtop5Posts()
        {
            var popularposts = from x in db.Posts select x;
            return Json(popularposts);
        }
    }
}