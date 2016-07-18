using System.Linq;
using System.Web;
using System.Web.Http;
  public partial class EmployeesImageController:ApiController
{
   [HttpGet]
    [HttpPost]
    [Route("api/EmployeesImageController/UploadFile/{id}")]
    public bool UploadFile(string id)
    {        bool result = false;        if (HttpContext.Current.Request.Files.AllKeys.Any())
        {// Get the uploaded image from the Files collection
var httpPostedFile = HttpContext.Current.Request.Files["UploadedImage"];
if (httpPostedFile != null)
{    // Validate the uploaded image(optional)
    int lengths = httpPostedFile.ContentLength;
    byte[] imgbytes = new byte[lengths];
    httpPostedFile.InputStream.Read(imgbytes, 0, lengths);


    EmployeesImageDb  ImageDb = new  EmployeesImageDb();


    result = ImageDb.SavePicture(id, imgbytes);

}
        }

        return result;
    }
 [HttpGet]
    [HttpPost]
    [Route("api/EmployeesImageController/Delete/{id}")]
    public bool Delete(string id)
    {
        EmployeesImageDb ImageDb = new EmployeesImageDb();


        var result = ImageDb.DeletePicture(id);
        return result;
    }
}
