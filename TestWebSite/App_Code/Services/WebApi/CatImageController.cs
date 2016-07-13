using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;

/// <summary>
/// Summary description for CatImageController
/// </summary>
public class CatImageController : ApiController
{


    [HttpGet]
    [HttpPost]


    [Route("api/CatImageController/UploadFile")]
    public string  UploadFile()
    {

        if (HttpContext.Current.Request.Files.AllKeys.Any())
        {
            // Get the uploaded image from the Files collection
            var httpPostedFile = HttpContext.Current.Request.Files["UploadedImage"];

            if (httpPostedFile != null)
            {
                // Validate the uploaded image(optional)
                int lengths = httpPostedFile.ContentLength;
                      byte[] imgbytes = new byte[lengths];
                httpPostedFile.InputStream.Read(imgbytes, 0, lengths);
                // Get the complete file path
                //var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/UploadedFiles"), httpPostedFile.FileName);

                // Save the uploaded file to "UploadedFiles" folder
                // httpPostedFile.SaveAs(fileSavePath);

                System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection("Data Source=NODE-PC;Initial Catalog=Northwind;User ID=sa;Password=P@ssw0rd");
                con.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("UPDATE [dbo].[Categories] SET  [Picture] =@Picture  WHERE [CategoryID]=1", con);

                cmd.Parameters.AddWithValue("@Picture", imgbytes);
                int count = cmd.ExecuteNonQuery();
            }
        }
       
        return "FFFF";
    }
}