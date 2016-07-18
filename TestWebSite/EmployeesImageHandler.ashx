<%@ WebHandler Language ="C#" Class="EmployeesImageHandler" %>
using System.Web;
  using System.Data;
public class EmployeesImageHandler : IHttpHandler{
  public void ProcessRequest(HttpContext context)
    {
        byte[] buffer = null;

        string id = "";
        if (context.Request.QueryString["Q"] != null)
        {            id = context.Request.QueryString["Q"];
        }
        else
        {
            return;
        }

        IDataReader reader = null;
        EmployeesImageDb ImageDb = new EmployeesImageDb();
        try
        {
            using (reader = ImageDb.GetPicture(id))
            {

                //get the extension name of image
                while (reader.Read())
                {

                    string extensionName = "jpg";
                    if (reader["Picture"] != System.DBNull.Value)
                    {
                        buffer = (byte[])reader["Photo"];

                        context.Response.Clear();
                        context.Response.ContentType = "image/" + extensionName;

                        //context.Response.OutputStream.Write(buffer, 78, buffer.Length - 78);
                        context.Response.OutputStream.Write(buffer, 0, buffer.Length);
                    }                    context.Response.Flush();
                    context.Response.Close();

                    //context.Response.OutputStream.Write(buffer, 78, buffer.Length - 78);
                    //ctx.Response.ContentType = "image/bmp";
                    //ctx.Response.OutputStream.Write(pict, 78, pict.Length - 78);

                }
                reader.Close();
            }

        }        finally        {
            ImageDb.Db.CloseFbData();
        }
    }
  public bool IsReusable
    {
        get        {
            return false;
        }
    }
}

