using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;

public class CategoriesDb : DataAccess
{
    public string _SortDirection { get; set; }
    public string _SortExpression { get; set; }
    public Categories _Categories;
    public const string DataKey = "CategoryID";
    public const string DataText = "CategoryName";
    public const string DataValue = "CategoryID";

    public List<SelectInputProperties> Select()
    {
        string sql = "SELECT * FROM Categories";
        DataSet ds = Db.GetDataSet(sql);

        return SelectInputProperties.DataSetToList(ds);
    }

    public Categories Select(string CategoryID)
    {
        string _sql1 = "SELECT *,0 AS RecordCount FROM Categories where CategoryID = @CategoryID; ";
        var prset = new List<IDataParameter>();
        prset.Add(Db.CreateParameterDb("@CategoryID", CategoryID));
        DataSet ds = Db.GetDataSet(_sql1, prset);
        return DataSetToList(ds).FirstOrDefault();
    }

    public List<Categories> GetWithFilter(bool sortAscending, string sortExpression)
    {
        throw new Exception("Not implement");
        string sql = "SELECT * FROM Categories ";
        sql += string.Format("  where ((''='{0}')or(CategoryID='{0}'))", _Categories.CategoryID);
        sql += string.Format("  and ((''='{0}')or(CategoryName='{0}'))", _Categories.CategoryName);
        sql += string.Format("  and ((''='{0}')or(Picture='{0}'))", _Categories.Picture);
        if (sortExpression == null)
        {
            sql += string.Format(" order by CategoryID ", sortExpression);
        }
        else
        {
        }

        DataSet ds = Db.GetDataSet(sql); return DataSetToList(ds);
    }

    public List<Categories> GetPageWise(int pageIndex, int PageSize, string wordFullText = "")
    {
        string store = "Sp_GetCategoriesPageWise";

        var dbParameter = GetParameter(pageIndex, PageSize);

        DataSet ds = Db.GetDataSet(store, dbParameter, CommandType.StoredProcedure);
        return DataSetToList(ds);
    }

    public object Insert()
    {
        var prset = new List<IDataParameter>(); var sql = "INSERT INTO Categories(CategoryName) VALUES (@CategoryName) ;SELECT SCOPE_IDENTITY();";
        prset.Add(Db.CreateParameterDb("@CategoryName", _Categories.CategoryName));

        object output = Db.FbExecuteScalar(sql, prset); return output;
    }

    public void Update()
    {
        var prset = new List<IDataParameter>();
        prset.Add(Db.CreateParameterDb("@CategoryID", _Categories.CategoryID)); prset.Add(Db.CreateParameterDb("@CategoryName", _Categories.CategoryName));
        var sql = @"UPDATE   Categories SET  CategoryName=@CategoryName where CategoryID = @CategoryID";

        int output = Db.FbExecuteNonQuery(sql, prset);
        if (output != 1)
        {
            throw new System.Exception("Update" + this.ToString());
        }
    }

    public void Delete()
    {
        var prset = new List<IDataParameter>();
        prset.Add(Db.CreateParameterDb("@CategoryID", _Categories.CategoryID));
        var sql = @"DELETE FROM Categories where CategoryID=@CategoryID";

        int output = Db.FbExecuteNonQuery(sql, prset);
        if (output != 1)
        {
            throw new System.Exception("Delete" + this.ToString());
        }
    }

    private List<Categories> DataSetToList(DataSet ds)
    {
        EnumerableRowCollection<Categories> q = (from temp in ds.Tables[0].AsEnumerable()
                                                 select new Categories
                                                 {
                                                     RecordCount = temp.Field<Int32>("RecordCount"),
                                                     CategoryID = temp.Field<Int32?>("CategoryID"),
                                                     CategoryName = temp.Field<String>("CategoryName"),
                                                 });
        return q.ToList();
    }

    public Boolean UpdateColumn(string id, string column, string value)
    {
        var prset = new List<IDataParameter>();
        prset.Add(Db.CreateParameterDb("@CategoryID", id));
        prset.Add(Db.CreateParameterDb("@Column", column));
        prset.Add(Db.CreateParameterDb("@Data", value));
        var sql = @"Sp_GetCategories_UpdateColumn";
        int output = Db.FbExecuteNonQuery(sql, prset, CommandType.StoredProcedure);
        if (output == 1)
        {
            return true;
        }

        return false;
    }

    public List<string> GetKeyWordsAllColumn(string Keyword)
    {
        string sql = "Sp_GetCategories_Autocomplete";
        var prset = new List<IDataParameter>();
        prset.Add(Db.CreateParameterDb("@Key_word", Keyword));

        List<string> dataArray = new List<string>();

        DataSet ds = Db.GetDataSet(sql, prset, CommandType.StoredProcedure);
        foreach (DataRow row in ds.Tables[0].Rows)
        {
            dataArray.Add(row[0].ToString());
        }

        return dataArray;
    }

    public List<string> GetKeyWordsOneColumn(string column, string keyword)
    {
        string sql = "SELECT  " + column + " FROM Categories where lower(" + column + ") like '" + keyword.ToLower() + "%'   group by " + column + " order by count(*) desc;";

        List<string> dataArray = new List<string>();

        DataSet ds = Db.GetDataSet(sql);
        foreach (DataRow row in ds.Tables[0].Rows)
        {
            dataArray.Add(row[0].ToString());
        }

        return dataArray;
    }

    public string GenWhereformProperties()
    {
        String sql = "";
        sql += "WHERE (1=1) ";
        if (_Categories.CategoryID != null)
        {
            sql += string.Format(" AND ((''='{0}') or (CategoryID='{0}') )", _Categories.CategoryID);
        }
        if (_Categories.CategoryName != null)
        {
            sql += string.Format(" AND ((''='{0}') or (CategoryName='{0}') )", _Categories.CategoryName);
        }
        if (_Categories.Picture != null)
        {
            sql += string.Format(" AND ((''='{0}') or (Picture='{0}') )", _Categories.Picture);
        }
        return sql;
    }

    public List<IDataParameter> GetParameter(int pageIndex, int PageSize)
    {
        var sqlStorePamameters = new List<IDataParameter>();
        sqlStorePamameters.Add(Db.CreateParameterDb("@PageIndex", pageIndex));
        sqlStorePamameters.Add(Db.CreateParameterDb("@PageSize", PageSize));
        if (_Categories.CategoryID != null)
        {
            sqlStorePamameters.Add(Db.CreateParameterDb("@CategoryID", _Categories.CategoryID));
        }
        if (_Categories.CategoryName != null)
        {
            sqlStorePamameters.Add(Db.CreateParameterDb("@CategoryName", _Categories.CategoryName));
        }
        if (_Categories.Picture != null)
        {
            sqlStorePamameters.Add(Db.CreateParameterDb("@Picture", _Categories.Picture));
        }
        /*Sort Order*/
        if (_SortExpression != null)
        {
            sqlStorePamameters.Add(Db.CreateParameterDb("@SortColumn", _SortExpression));
            sqlStorePamameters.Add(Db.CreateParameterDb("@SortOrder", _SortDirection));
        }

        return sqlStorePamameters;
    }
}

//Trasaction User
//bool output = false;
//    try
//    {
//        Db.OpenFbData();
//        Db.BeginTransaction();
//        MPO_ORDERS o1 = new MPO_ORDERS();
//o1 = _MPO_ORDERS;
//        int orid = o1.Save();
//MPO_ODERDETAILS o2 = new MPO_ODERDETAILS();
//o2.Save(orid, ODERDETAILS);
//        Db.CommitTransaction();
//        OR_ID = orid;
//        output = true;
//    }
//    catch (System.Exception ex)
//    {
//        Db.RollBackTransaction();
//        ErrorLogging.LogErrorToLogFile(ex, "");
//        throw ex;
//    }
//    return output;