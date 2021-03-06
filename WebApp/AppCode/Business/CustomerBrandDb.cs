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
public class  CustomerBrandDb: DataAccess
{
 public string _SortDirection { get; set; }
 public string _SortExpression { get; set; }
  public CustomerBrand _CustomerBrand;
public const string DataKey = "CustomerBrandID";
public const string DataText = "CustomerBrandName";
public const string DataValue = "CustomerBrandID";
 public List<SelectInputProperties> Select()
    {
 string sql = "SELECT * FROM CustomerBrand";
        DataSet ds = Db.GetDataSet(sql);

        return SelectInputProperties.DataSetToList(ds);
		
    }
	
public CustomerBrand Select(string CustomerBrandID) 
{ 
 string _sql1 = "SELECT *,0 AS RecordCount FROM CustomerBrand where CustomerBrandID = @CustomerBrandID; "; 
   var prset = new List<IDataParameter>();
  prset.Add(Db.CreateParameterDb("@CustomerBrandID", CustomerBrandID));
  DataSet ds = Db.GetDataSet(_sql1,prset);
return DataSetToList(ds).FirstOrDefault(); 
}public List<CustomerBrand> GetWithFilter(bool sortAscending, string sortExpression){
throw new Exception("Not implement");
string sql = "SELECT * FROM CustomerBrand "; 
sql += string.Format("  where ((''='{0}')or(CustomerBrandID='{0}'))", _CustomerBrand.CustomerBrandID);
sql += string.Format("  and ((''='{0}')or(CustomerBrandName='{0}'))", _CustomerBrand.CustomerBrandName);
sql += string.Format("  and ((''='{0}')or(CustomerBrandDetail='{0}'))", _CustomerBrand.CustomerBrandDetail);
if (sortExpression == null){
sql += string.Format(" order by CustomerBrandID ", sortExpression);}
else
{
}

DataSet ds = Db.GetDataSet(sql);return DataSetToList(ds);}
public List<CustomerBrand> GetPageWise(int pageIndex, int PageSize, string  wordFullText="") 
{ 
string store = "Sp_GetCustomerBrandPageWise"; 
 
 
var dbParameter = GetParameter(pageIndex,PageSize);

 
 
DataSet ds = Db.GetDataSet(store, dbParameter, CommandType.StoredProcedure); 
return DataSetToList(ds); 
}
public object Insert() {
var prset = new List<IDataParameter>();var sql = "INSERT INTO CustomerBrand(CustomerBrandID,CustomerBrandName,CustomerBrandDetail) VALUES (@CustomerBrandID,@CustomerBrandName,@CustomerBrandDetail) ;Select @CustomerBrandID";
 prset.Add(Db.CreateParameterDb("@CustomerBrandID",_CustomerBrand.CustomerBrandID)); prset.Add(Db.CreateParameterDb("@CustomerBrandName",_CustomerBrand.CustomerBrandName)); prset.Add(Db.CreateParameterDb("@CustomerBrandDetail",_CustomerBrand.CustomerBrandDetail));

object output = Db.FbExecuteScalar(sql, prset);return output;  }

public void Update() {
var prset = new List<IDataParameter>();
 prset.Add(Db.CreateParameterDb("@CustomerBrandID",_CustomerBrand.CustomerBrandID)); prset.Add(Db.CreateParameterDb("@CustomerBrandName",_CustomerBrand.CustomerBrandName)); prset.Add(Db.CreateParameterDb("@CustomerBrandDetail",_CustomerBrand.CustomerBrandDetail));
var sql = @"UPDATE   CustomerBrand SET  CustomerBrandName=@CustomerBrandName,CustomerBrandDetail=@CustomerBrandDetail where CustomerBrandID = @CustomerBrandID";

int output = Db.FbExecuteNonQuery(sql, prset);
if (output != 1){
 throw new System.Exception("Update" + this.ToString());}   }

public void Delete() {
var prset = new List<IDataParameter>();
 prset.Add(Db.CreateParameterDb("@CustomerBrandID",_CustomerBrand.CustomerBrandID));
var sql =@"DELETE FROM CustomerBrand where CustomerBrandID=@CustomerBrandID";

int output = Db.FbExecuteNonQuery(sql, prset);
if (output != 1){
 throw new System.Exception("Delete" + this.ToString());}   }

private List<CustomerBrand> DataSetToList(DataSet ds) 
{
 EnumerableRowCollection<CustomerBrand> q = (from temp in ds.Tables[0].AsEnumerable()
 select new CustomerBrand
{
RecordCount = temp.Field<Int32>("RecordCount"),CustomerBrandID= temp.Field<String>("CustomerBrandID"), 
 CustomerBrandName= temp.Field<String>("CustomerBrandName"), 
 CustomerBrandDetail= temp.Field<String>("CustomerBrandDetail"), 
  });
  return q.ToList();
}
   public Boolean UpdateColumn(string id, string column,string value) 
        { 
            var prset = new List<IDataParameter>(); 
            prset.Add(Db.CreateParameterDb("@CustomerBrandID", id)); 
prset.Add(Db.CreateParameterDb("@Column", column));
            prset.Add(Db.CreateParameterDb("@Data", value)); 
   var sql = @"Sp_GetCustomerBrand_UpdateColumn";
            int output = Db.FbExecuteNonQuery(sql, prset, CommandType.StoredProcedure); 
            if (output == 1) 
            { 
                return true; 
            } 
 
            return false;   
        } 
 public List<string> GetKeyWordsAllColumn(string Keyword) 
    { 
        
        string sql = "Sp_GetCustomerBrand_Autocomplete"; 
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
          
 
  string sql = "SELECT  " + column + " FROM CustomerBrand where lower(" + column + ") like '" + keyword.ToLower() + "%'   group by " + column + " order by count(*) desc;"; 
         
         
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
            if ( _CustomerBrand.CustomerBrandID!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (CustomerBrandID='{0}') )", _CustomerBrand.CustomerBrandID); 
            } 
            if ( _CustomerBrand.CustomerBrandName!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (CustomerBrandName='{0}') )", _CustomerBrand.CustomerBrandName); 
            } 
            if ( _CustomerBrand.CustomerBrandDetail!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (CustomerBrandDetail='{0}') )", _CustomerBrand.CustomerBrandDetail); 
            } 
return sql;
}
      public List<IDataParameter> GetParameter(int pageIndex, int PageSize)
        {
            var sqlStorePamameters = new List<IDataParameter>();
            sqlStorePamameters.Add(Db.CreateParameterDb("@PageIndex", pageIndex));
            sqlStorePamameters.Add(Db.CreateParameterDb("@PageSize", PageSize));
if (_CustomerBrand.CustomerBrandID != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@CustomerBrandID", _CustomerBrand.CustomerBrandID));

            }
if (_CustomerBrand.CustomerBrandName != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@CustomerBrandName", _CustomerBrand.CustomerBrandName));

            }
if (_CustomerBrand.CustomerBrandDetail != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@CustomerBrandDetail", _CustomerBrand.CustomerBrandDetail));

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
