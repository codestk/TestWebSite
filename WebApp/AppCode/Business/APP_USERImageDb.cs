using System.Collections.Generic;
using System.Data;
using WebApp.Code.Utility;
namespace WebApp.AppCode.Business
{
public class APP_USERImageDb : DataAccess
 {
public IDataReader GetPicture(string id)
    {
        string sql = "SELECT Picture FROM APP_USER where UserID = @UserID;";
        var prset = new List<IDataParameter>();
        prset.Add(Db.CreateParameterDb("@UserID", id));
        Db.OpenFbData();        return Db.FbExecuteReader(sql, prset, CommandType.Text);
    }
 public bool SavePicture(string id, byte[] Picture)
    {
        string sql = "UPDATE  APP_USER SET Picture = @Picture  WHERE UserID = @UserID";

        var prset = new List<IDataParameter>();
        prset.Add(Db.CreateParameterDb("@UserID", id));
        prset.Add(Db.CreateParameterDb("@Picture", Picture));


        int output = Db.FbExecuteNonQuery(sql, prset);
        if (output != 1)
        {
            throw new System.Exception("Update" + this.ToString());
        }
        return true;

    }
  public bool DeletePicture(string id)
    {
        string sql = "UPDATE APP_USER SET  Picture =null  WHERE UserID=@UserID";

        var prset = new List<IDataParameter>();
        prset.Add(Db.CreateParameterDb("@UserID", id));


        int output = Db.FbExecuteNonQuery(sql, prset);
        if (output != 1)
        {
            throw new System.Exception("Update" + this.ToString());
        }
        return true;

    }
}
}
