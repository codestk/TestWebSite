using System.Collections.Generic;
using System.Data;
public class EmployeesImageDb : DataAccess
 {
public IDataReader GetPicture(string id)
    {
        string sql = "SELECT Photo FROM Employees where EmployeeID = @EmployeeID;";
        var prset = new List<IDataParameter>();
        prset.Add(Db.CreateParameterDb("@EmployeeID", id));
        Db.OpenFbData();        return Db.FbExecuteReader(sql, prset, CommandType.Text);
    }
 public bool SavePicture(string id, byte[] Picture)
    {
        string sql = "UPDATE  Employees SET Photo = @Photo  WHERE EmployeeID = @EmployeeID";

        var prset = new List<IDataParameter>();
        prset.Add(Db.CreateParameterDb("@EmployeeID", id));
        prset.Add(Db.CreateParameterDb("@Photo", Picture));


        int output = Db.FbExecuteNonQuery(sql, prset);
        if (output != 1)
        {
            throw new System.Exception("Update" + this.ToString());
        }
        return true;

    }
  public bool DeletePicture(string id)
    {
        string sql = "UPDATE Employees SET  Photo =null  WHERE EmployeeID=@EmployeeID";

        var prset = new List<IDataParameter>();
        prset.Add(Db.CreateParameterDb("@EmployeeID", id));


        int output = Db.FbExecuteNonQuery(sql, prset);
        if (output != 1)
        {
            throw new System.Exception("Update" + this.ToString());
        }
        return true;

    }
}

