using System.Linq;
using System.Web;
using System.Web.Http;
using WebApp.AppCode.Business;
  public partial class APP_USERImageController:ApiController
{
   [HttpGet]
    [HttpPost]
    [Route("api/APP_USERImageController/UploadFile/{id}")]
    public bool UploadFile(string id)
    {        bool result = false;        if (HttpContext.Current.Request.Files.AllKeys.Any())
        {// Get the uploaded image from the Files collection
var httpPostedFile = HttpContext.Current.Request.Files["UploadedImage"];
if (httpPostedFile != null)
{    // Validate the uploaded image(optional)
    int lengths = httpPostedFile.ContentLength;
    byte[] imgbytes = new byte[lengths];
    httpPostedFile.InputStream.Read(imgbytes, 0, lengths);


    APP_USERImageDb  ImageDb = new  APP_USERImageDb();


    result = ImageDb.SavePicture(id, imgbytes);

}
        }

        return result;
    }
 [HttpGet]
    [HttpPost]
    [Route("api/APP_USERImageController/Delete/{id}")]
    public bool Delete(string id)
    {
        APP_USERImageDb ImageDb = new APP_USERImageDb();


        var result = ImageDb.DeletePicture(id);
        return result;
    }
}