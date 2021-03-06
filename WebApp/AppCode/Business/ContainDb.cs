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
public class  ContainDb: DataAccess
{
 public string _SortDirection { get; set; }
 public string _SortExpression { get; set; }
  public Contain _Contain;
public const string DataKey = "ContainID";
public const string DataText = "ContainName";
public const string DataValue = "ContainID";
 public List<SelectInputProperties> Select()
    {
 string sql = "SELECT * FROM Contain";
        DataSet ds = Db.GetDataSet(sql);

        return SelectInputProperties.DataSetToList(ds);
		
    }
	
public Contain Select(string ContainID) 
{ 
 string _sql1 = "SELECT *,0 AS RecordCount FROM Contain where ContainID = @ContainID; "; 
   var prset = new List<IDataParameter>();
  prset.Add(Db.CreateParameterDb("@ContainID", ContainID));
  DataSet ds = Db.GetDataSet(_sql1,prset);
return DataSetToList(ds).FirstOrDefault(); 
}public List<Contain> GetWithFilter(bool sortAscending, string sortExpression){
throw new Exception("Not implement");
string sql = "SELECT * FROM Contain "; 
sql += string.Format("  where ((''='{0}')or(ContainID='{0}'))", _Contain.ContainID);
sql += string.Format("  and ((''='{0}')or(ContainName='{0}'))", _Contain.ContainName);
sql += string.Format("  and ((''='{0}')or(ContainDetail='{0}'))", _Contain.ContainDetail);
if (sortExpression == null){
sql += string.Format(" order by ContainID ", sortExpression);}
else
{
}

DataSet ds = Db.GetDataSet(sql);return DataSetToList(ds);}
public List<Contain> GetPageWise(int pageIndex, int PageSize, string  wordFullText="") 
{ 
string store = "Sp_GetContainPageWise"; 
 
 
var dbParameter = GetParameter(pageIndex,PageSize);

 
 
DataSet ds = Db.GetDataSet(store, dbParameter, CommandType.StoredProcedure); 
return DataSetToList(ds); 
}
public object Insert() {
var prset = new List<IDataParameter>();var sql = "INSERT INTO Contain(ContainID,ContainName,ContainDetail) VALUES (@ContainID,@ContainName,@ContainDetail) ;Select @ContainID";
 prset.Add(Db.CreateParameterDb("@ContainID",_Contain.ContainID)); prset.Add(Db.CreateParameterDb("@ContainName",_Contain.ContainName)); prset.Add(Db.CreateParameterDb("@ContainDetail",_Contain.ContainDetail));

object output = Db.FbExecuteScalar(sql, prset);return output;  }

public void Update() {
var prset = new List<IDataParameter>();
 prset.Add(Db.CreateParameterDb("@ContainID",_Contain.ContainID)); prset.Add(Db.CreateParameterDb("@ContainName",_Contain.ContainName)); prset.Add(Db.CreateParameterDb("@ContainDetail",_Contain.ContainDetail));
var sql = @"UPDATE   Contain SET  ContainName=@ContainName,ContainDetail=@ContainDetail where ContainID = @ContainID";

int output = Db.FbExecuteNonQuery(sql, prset);
if (output != 1){
 throw new System.Exception("Update" + this.ToString());}   }

public void Delete() {
var prset = new List<IDataParameter>();
 prset.Add(Db.CreateParameterDb("@ContainID",_Contain.ContainID));
var sql =@"DELETE FROM Contain where ContainID=@ContainID";

int output = Db.FbExecuteNonQuery(sql, prset);
if (output != 1){
 throw new System.Exception("Delete" + this.ToString());}   }

private List<Contain> DataSetToList(DataSet ds) 
{
 EnumerableRowCollection<Contain> q = (from temp in ds.Tables[0].AsEnumerable()
 select new Contain
{
RecordCount = temp.Field<Int32>("RecordCount"),ContainID= temp.Field<String>("ContainID"), 
 ContainName= temp.Field<String>("ContainName"), 
 ContainDetail= temp.Field<String>("ContainDetail"), 
  });
  return q.ToList();
}
   public Boolean UpdateColumn(string id, string column,string value) 
        { 
            var prset = new List<IDataParameter>(); 
            prset.Add(Db.CreateParameterDb("@ContainID", id)); 
prset.Add(Db.CreateParameterDb("@Column", column));
            prset.Add(Db.CreateParameterDb("@Data", value)); 
   var sql = @"Sp_GetContain_UpdateColumn";
            int output = Db.FbExecuteNonQuery(sql, prset, CommandType.StoredProcedure); 
            if (output == 1) 
            { 
                return true; 
            } 
 
            return false;   
        } 
 public List<string> GetKeyWordsAllColumn(string Keyword) 
    { 
        
        string sql = "Sp_GetContain_Autocomplete"; 
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
          
 
  string sql = "SELECT  " + column + " FROM Contain where lower(" + column + ") like '" + keyword.ToLower() + "%'   group by " + column + " order by count(*) desc;"; 
         
         
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
            if ( _Contain.ContainID!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (ContainID='{0}') )", _Contain.ContainID); 
            } 
            if ( _Contain.ContainName!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (ContainName='{0}') )", _Contain.ContainName); 
            } 
            if ( _Contain.ContainDetail!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (ContainDetail='{0}') )", _Contain.ContainDetail); 
            } 
return sql;
}
      public List<IDataParameter> GetParameter(int pageIndex, int PageSize)
        {
            var sqlStorePamameters = new List<IDataParameter>();
            sqlStorePamameters.Add(Db.CreateParameterDb("@PageIndex", pageIndex));
            sqlStorePamameters.Add(Db.CreateParameterDb("@PageSize", PageSize));
if (_Contain.ContainID != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@ContainID", _Contain.ContainID));

            }
if (_Contain.ContainName != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@ContainName", _Contain.ContainName));

            }
if (_Contain.ContainDetail != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@ContainDetail", _Contain.ContainDetail));

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
