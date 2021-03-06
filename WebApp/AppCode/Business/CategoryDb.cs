using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using WebApp.Business;
using WebApp.Code.Utility;
using WebApp.Code.Utility.Properties.Controls;
namespace WebApp.Business
{
public class  CategoryDb: DataAccess
{
 public string _SortDirection { get; set; }
 public string _SortExpression { get; set; }
  public Category _Category;
public const string DataKey = "CategoryID";
public const string DataText = "CategoryName";
public const string DataValue = "CategoryID";
 public List<SelectInputProperties> Select()
    {
 string sql = "SELECT * FROM Category";
        DataSet ds = Db.GetDataSet(sql);

        return SelectInputProperties.DataSetToList(ds);
		
    }
	
public Category Select(string CategoryID) 
{ 
 string _sql1 = "SELECT *,0 AS RecordCount FROM Category where CategoryID = @CategoryID; "; 
   var prset = new List<IDataParameter>();
  prset.Add(Db.CreateParameterDb("@CategoryID", CategoryID));
  DataSet ds = Db.GetDataSet(_sql1,prset);
return DataSetToList(ds).FirstOrDefault(); 
}public List<Category> GetWithFilter(bool sortAscending, string sortExpression){
throw new Exception("Not implement");
string sql = "SELECT * FROM Category "; 
sql += string.Format("  where ((''='{0}')or(CategoryID='{0}'))", _Category.CategoryID);
sql += string.Format("  and ((''='{0}')or(CategoryName='{0}'))", _Category.CategoryName);
sql += string.Format("  and ((''='{0}')or(CategoryDetail='{0}'))", _Category.CategoryDetail);
if (sortExpression == null){
sql += string.Format(" order by CategoryID ", sortExpression);}
else
{
}

DataSet ds = Db.GetDataSet(sql);return DataSetToList(ds);}
public List<Category> GetPageWise(int pageIndex, int PageSize, string  wordFullText="") 
{ 
string store = "Sp_GetCategoryPageWise"; 
 
 
var dbParameter = GetParameter(pageIndex,PageSize);

 
 
DataSet ds = Db.GetDataSet(store, dbParameter, CommandType.StoredProcedure); 
return DataSetToList(ds); 
}
public object Insert() {
var prset = new List<IDataParameter>();var sql = "INSERT INTO Category(CategoryID,CategoryName,CategoryDetail) VALUES (@CategoryID,@CategoryName,@CategoryDetail) ;Select @CategoryID";
 prset.Add(Db.CreateParameterDb("@CategoryID",_Category.CategoryID)); prset.Add(Db.CreateParameterDb("@CategoryName",_Category.CategoryName)); prset.Add(Db.CreateParameterDb("@CategoryDetail",_Category.CategoryDetail));

object output = Db.FbExecuteScalar(sql, prset);return output;  }

public void Update() {
var prset = new List<IDataParameter>();
 prset.Add(Db.CreateParameterDb("@CategoryID",_Category.CategoryID)); prset.Add(Db.CreateParameterDb("@CategoryName",_Category.CategoryName)); prset.Add(Db.CreateParameterDb("@CategoryDetail",_Category.CategoryDetail));
var sql = @"UPDATE   Category SET  CategoryName=@CategoryName,CategoryDetail=@CategoryDetail where CategoryID = @CategoryID";

int output = Db.FbExecuteNonQuery(sql, prset);
if (output != 1){
 throw new System.Exception("Update" + this.ToString());}   }

public void Delete() {
var prset = new List<IDataParameter>();
 prset.Add(Db.CreateParameterDb("@CategoryID",_Category.CategoryID));
var sql =@"DELETE FROM Category where CategoryID=@CategoryID";

int output = Db.FbExecuteNonQuery(sql, prset);
if (output != 1){
 throw new System.Exception("Delete" + this.ToString());}   }

private List<Category> DataSetToList(DataSet ds) 
{
 EnumerableRowCollection<Category> q = (from temp in ds.Tables[0].AsEnumerable()
 select new Category
{
RecordCount = temp.Field<Int32>("RecordCount"),CategoryID= temp.Field<String>("CategoryID"), 
 CategoryName= temp.Field<String>("CategoryName"), 
 CategoryDetail= temp.Field<String>("CategoryDetail"), 
  });
  return q.ToList();
}
   public Boolean UpdateColumn(string id, string column,string value) 
        { 
            var prset = new List<IDataParameter>(); 
            prset.Add(Db.CreateParameterDb("@CategoryID", id)); 
prset.Add(Db.CreateParameterDb("@Column", column));
            prset.Add(Db.CreateParameterDb("@Data", value)); 
   var sql = @"Sp_GetCategory_UpdateColumn";
            int output = Db.FbExecuteNonQuery(sql, prset, CommandType.StoredProcedure); 
            if (output == 1) 
            { 
                return true; 
            } 
 
            return false;   
        } 
 public List<string> GetKeyWordsAllColumn(string Keyword) 
    { 
        
        string sql = "Sp_GetCategory_Autocomplete"; 
        var prset = new List<IDataParameter>(); 
        prset.Add(Db.CreateParameterDb("@Key_word", Keyword)); 
 
        List<string> dataArray = new List<string>(); 
 
        DataSet ds = Db.GetDataSet(sql, prset,CommandType.StoredProcedure); 
        foreach (DataRow row in ds.Tables[0].Rows) 
        { 
            dataArray.Add(row[0].ToString()); 
        } 
 
        return dataArray; 
    }
  public List<string> GetKeyWordsOneColumn(string column, string keyword) 
  { 
          
 
  string sql = "SELECT  " + column + " FROM Category where lower(" + column + ") like '" + keyword.ToLower() + "%'   group by " + column + " order by count(*) desc;"; 
         
         
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
  String sql="";
   sql += "WHERE (1=1) "; 
            if ( _Category.CategoryID!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (CategoryID='{0}') )", _Category.CategoryID); 
            } 
            if ( _Category.CategoryName!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (CategoryName='{0}') )", _Category.CategoryName); 
            } 
            if ( _Category.CategoryDetail!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (CategoryDetail='{0}') )", _Category.CategoryDetail); 
            } 
return sql;
}
      public List<IDataParameter> GetParameter(int pageIndex, int PageSize)
        {
            var sqlStorePamameters = new List<IDataParameter>();
            sqlStorePamameters.Add(Db.CreateParameterDb("@PageIndex", pageIndex));
            sqlStorePamameters.Add(Db.CreateParameterDb("@PageSize", PageSize));
if (_Category.CategoryID != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@CategoryID", _Category.CategoryID));

            }
if (_Category.CategoryName != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@CategoryName", _Category.CategoryName));

            }
if (_Category.CategoryDetail != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@CategoryDetail", _Category.CategoryDetail));

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
