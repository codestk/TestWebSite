using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.AppCode.Business;

namespace WebApp.Areas.BCC.Controllers
{
    public class DefaultController : Controller
    {
        // GET: BCC/Default
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        // GET: /BCC/Default/Get
        public ActionResult Get(string id)
        {
            byte[] buffer = null;
            IDataReader reader = null;
            APP_USERImageDb ImageDb = new APP_USERImageDb();
            try
            {
                using (reader = ImageDb.GetPicture(id))
                {
                    //get the extension name of image
                    while (reader.Read())
                    {
                        byte[] picData = reader["Picture"] as byte[] ?? null;

                        if (picData != null)
                        {
                            using (MemoryStream ms = new MemoryStream(picData))
                            {
                                // Load the image from the memory stream. How you do it depends
                                // on whether you're using Windows Forms or WPF.
                                // For Windows Forms you could write:
                               // System.Drawing.Bitmap Image = new System.Drawing.Bitmap(ms);

                                //Image.Save(ms, ImageFormat.Jpeg);

                                return File(ms.ToArray(), "image/jpeg");


                                // return new FileContentResult(ms.ToArray(), "image/jpeg");
                            }
                        }


                    }
                }
                reader.Close();
            }
            finally
            {
                ImageDb.Db.CloseFbData();
            }
            return null;
        }


        /// BCC/Default/Test
        [HttpGet]
        public ActionResult Test()
        {
          
            return Json("cdjsncjd", JsonRequestBehavior.AllowGet);
        }

    }
}