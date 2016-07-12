using System.Collections.Generic;
using System.Data;

/// <summary>
/// Summary description for CategoriesImageDb
/// </summary>
public class CategoriesImageDb : DataAccess
{
    public CategoriesImageDb()
    {
      
    }

    public IDataReader GetImage(string id)
    {
        string _sql1 = "SELECT Picture FROM Categories where CategoryID = @CategoryID;";
        var prset = new List<IDataParameter>();
        prset.Add(Db.CreateParameterDb("@CategoryID", id));
        Db.OpenFbData();
        return Db.FbExecuteReader(_sql1, prset, CommandType.Text);
    }

    public bool Save()
    {
        return true;
    }
}