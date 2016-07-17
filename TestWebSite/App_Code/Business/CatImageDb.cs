using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CatImageDb
/// </summary>
public class CatImageDb:CategoriesDb
{
    public CatImageDb()
    {
       
    }

  public  bool SavePicture(string id ,byte[] Picture)
    {
        string sql = "UPDATE[dbo].[Categories] SET[Picture] = @Picture  WHERE[CategoryID] = @CategoryID";
   
        var prset = new List<IDataParameter>();
        prset.Add(Db.CreateParameterDb("@CategoryID", id));
        prset.Add(Db.CreateParameterDb("@Picture", Picture));
      

        int output = Db.FbExecuteNonQuery(sql, prset);
        if (output != 1)
        {
            throw new System.Exception("Update" + this.ToString());
        }
        return true;

}


    public bool DeletePicture(string id, byte[] Picture)
    {
        string sql = "UPDATE [dbo].[Categories] SET  [Picture] =null  WHERE [CategoryID]=@CategoryID";

        var prset = new List<IDataParameter>();
        prset.Add(Db.CreateParameterDb("@CategoryID", id));
      


        int output = Db.FbExecuteNonQuery(sql, prset);
        if (output != 1)
        {
            throw new System.Exception("Update" + this.ToString());
        }
        return true;

    }


}