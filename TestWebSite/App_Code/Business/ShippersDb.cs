using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
public class  ShippersDb: DataAccess
{
 public string _SortDirection { get; set; }
 public string _SortExpression { get; set; }
  public Shippers _Shippers;
public const string DataKey = "ShipperID";
public const string DataText = "CompanyName";
public const string DataValue = "ShipperID";
 public List<SelectInputProperties> Select()
    {
 string sql = "SELECT * FROM Shippers";
        DataSet ds = Db.GetDataSet(sql);

        return SelectInputProperties.DataSetToList(ds);
		
    }
	
public Shippers Select(string ShipperID) 
{ 
 string _sql1 = "SELECT *,0 AS RecordCount FROM Shippers where ShipperID = @ShipperID; "; 
   var prset = new List<IDataParameter>();
  prset.Add(Db.CreateParameterDb("@ShipperID", ShipperID));
  DataSet ds = Db.GetDataSet(_sql1,prset);
return DataSetToList(ds).FirstOrDefault(); 
}public List<Shippers> GetWithFilter(bool sortAscending, string sortExpression){
throw new Exception("Not implement");
string sql = "SELECT * FROM Shippers "; 
sql += string.Format("  where ((''='{0}')or(ShipperID='{0}'))", _Shippers.ShipperID);
sql += string.Format("  and ((''='{0}')or(CompanyName='{0}'))", _Shippers.CompanyName);
sql += string.Format("  and ((''='{0}')or(Phone='{0}'))", _Shippers.Phone);
if (sortExpression == null){
sql += string.Format(" order by ShipperID ", sortExpression);}
else
{
}

DataSet ds = Db.GetDataSet(sql);return DataSetToList(ds);}
public List<Shippers> GetPageWise(int pageIndex, int PageSize, string  wordFullText="") 
{ 
string store = "Sp_GetShippersPageWise"; 
 
 
var dbParameter = GetParameter(pageIndex,PageSize);

 
 
DataSet ds = Db.GetDataSet(store, dbParameter, CommandType.StoredProcedure); 
return DataSetToList(ds); 
}
public object Insert() {
var prset = new List<IDataParameter>();var sql = "INSERT INTO Shippers(CompanyName,Phone) VALUES (@CompanyName,@Phone) ;SELECT SCOPE_IDENTITY();";
 prset.Add(Db.CreateParameterDb("@CompanyName",_Shippers.CompanyName)); prset.Add(Db.CreateParameterDb("@Phone",_Shippers.Phone));

object output = Db.FbExecuteScalar(sql, prset);return output;  }

public void Update() {
var prset = new List<IDataParameter>();
 prset.Add(Db.CreateParameterDb("@ShipperID",_Shippers.ShipperID)); prset.Add(Db.CreateParameterDb("@CompanyName",_Shippers.CompanyName)); prset.Add(Db.CreateParameterDb("@Phone",_Shippers.Phone));
var sql = @"UPDATE   Shippers SET  CompanyName=@CompanyName,Phone=@Phone where ShipperID = @ShipperID";

int output = Db.FbExecuteNonQuery(sql, prset);
if (output != 1){
 throw new System.Exception("Update" + this.ToString());}   }

public void Delete() {
var prset = new List<IDataParameter>();
 prset.Add(Db.CreateParameterDb("@ShipperID",_Shippers.ShipperID));
var sql =@"DELETE FROM Shippers where ShipperID=@ShipperID";

int output = Db.FbExecuteNonQuery(sql, prset);
if (output != 1){
 throw new System.Exception("Delete" + this.ToString());}   }

private List<Shippers> DataSetToList(DataSet ds) 
{
 EnumerableRowCollection<Shippers> q = (from temp in ds.Tables[0].AsEnumerable()
 select new Shippers
{
RecordCount = temp.Field<Int32>("RecordCount"),ShipperID= temp.Field<Int32?>("ShipperID"), 
 CompanyName= temp.Field<String>("CompanyName"), 
 Phone= temp.Field<String>("Phone"), 
  });
  return q.ToList();
}
   public Boolean UpdateColumn(string id, string column,string value) 
        { 
            var prset = new List<IDataParameter>(); 
            prset.Add(Db.CreateParameterDb("@ShipperID", id)); 
prset.Add(Db.CreateParameterDb("@Column", column));
            prset.Add(Db.CreateParameterDb("@Data", value)); 
   var sql = @"Sp_GetShippers_UpdateColumn";
            int output = Db.FbExecuteNonQuery(sql, prset, CommandType.StoredProcedure); 
            if (output == 1) 
            { 
                return true; 
            } 
 
            return false;   
        } 
 public List<string> GetKeyWordsAllColumn(string Keyword) 
    { 
        
        string sql = "Sp_GetShippers_Autocomplete"; 
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
          
 
  string sql = "SELECT  " + column + " FROM Shippers where lower(" + column + ") like '" + keyword.ToLower() + "%'   group by " + column + " order by count(*) desc;"; 
         
         
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
            if ( _Shippers.ShipperID!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (ShipperID='{0}') )", _Shippers.ShipperID); 
            } 
            if ( _Shippers.CompanyName!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (CompanyName='{0}') )", _Shippers.CompanyName); 
            } 
            if ( _Shippers.Phone!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (Phone='{0}') )", _Shippers.Phone); 
            } 
return sql;
}
      public List<IDataParameter> GetParameter(int pageIndex, int PageSize)
        {
            var sqlStorePamameters = new List<IDataParameter>();
            sqlStorePamameters.Add(Db.CreateParameterDb("@PageIndex", pageIndex));
            sqlStorePamameters.Add(Db.CreateParameterDb("@PageSize", PageSize));
if (_Shippers.ShipperID != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@ShipperID", _Shippers.ShipperID));

            }
if (_Shippers.CompanyName != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@CompanyName", _Shippers.CompanyName));

            }
if (_Shippers.Phone != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@Phone", _Shippers.Phone));

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

