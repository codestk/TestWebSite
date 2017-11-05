using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StkLib.Captcha;

namespace WebApp.Areas.Captcha.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Captcha/Default
        public ActionResult Index()
        {
            return View();
        }

        //Captcha/Default/ CaptchaImage()
        [HttpGet]
        public ActionResult CaptchaImage()
        {
            // Create a random code and store it in the Session object.
            this.Session["CaptchaImageText"] = RandomImage.GenerateRandomCode();
            // Create a CAPTCHA image using the text stored in the Session object.
            RandomImage ci = new RandomImage(this.Session
                ["CaptchaImageText"].ToString(), 300, 75);
            // Change the response headers to output a JPEG image.
            //this.Response.Clear();
            //this.Response.ContentType = "image/jpeg";
            // Write the image to the response stream in JPEG format.
            //ci.Image.Save(this.Response.OutputStream, ImageFormat.Jpeg);
            // Dispose of the CAPTCHA image object.
            //ci.Dispose();
            //ci.Image.Save(this.Response.OutputStream, ImageFormat.Jpeg);

            ci.Image.Save(this.Response.OutputStream, ImageFormat.Jpeg);
            //FileStreamResult result = new FileStreamResult(Response.OutputStream, "image/jpg");
            //result.FileDownloadName = "image.jpeg";
            //FileStreamResult result = new FileStreamResult(Response.OutputStream, "image/jpeg");
            // result.FileDownloadName = "image.jpeg";

            using (var ms = new MemoryStream())
            {
                ci.Image.Save(ms, ImageFormat.Jpeg);

                return File(ms.ToArray(), "image/jpeg");
            }

            //return result;
        }

        // Function to generate random string with Random class.

        [HttpPost]
        public ActionResult CaptchaText()
        {
            string textCap = this.Session["CaptchaImageText"].ToString();
            return Json(textCap, JsonRequestBehavior.AllowGet);
        }



    }
}