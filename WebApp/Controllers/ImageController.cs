using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{

    public class ImageController : Controller
    {
        // GET: Image
        [HttpGet]
        [HttpPost]
        [Route("api")]
        public ActionResult Index()
        {
            return View();
        }
    }
}