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
public class  SourceDb: DataAccess
{
 public string _SortDirection { get; set; }
 public string _SortExpression { get; set; }
  public Source _Source;
public const string DataKey = "SourceID";
public const string DataText = "SourceName";
public const string DataValue = "SourceID";
 public List<SelectInputProperties> Select()
    {
 string sql = "SELECT * FROM Source";
        DataSet ds = Db.GetDataSet(sql);

        return SelectInputProperties.DataSetToList(ds);
		
    }
	
public Source Select(string SourceID) 
{ 
 string _sql1 = "SELECT *,0 AS RecordCount FROM Source where SourceID = @SourceID; "; 
   var prset = new List<IDataParameter>();
  prset.Add(Db.CreateParameterDb("@SourceID", SourceID));
  DataSet ds = Db.GetDataSet(_sql1,prset);
return DataSetToList(ds).FirstOrDefault(); 
}public List<Source> GetWithFilter(bool sortAscending, string sortExpression){
throw new Exception("Not implement");
string sql = "SELECT * FROM Source "; 
sql += string.Format("  where ((''='{0}')or(SourceID='{0}'))", _Source.SourceID);
sql += string.Format("  and ((''='{0}')or(SourceName='{0}'))", _Source.SourceName);
sql += string.Format("  and ((''='{0}')or(SourceDetail='{0}'))", _Source.SourceDetail);
if (sortExpression == null){
sql += string.Format(" order by SourceID ", sortExpression);}
else
{
}

DataSet ds = Db.GetDataSet(sql);return DataSetToList(ds);}
public List<Source> GetPageWise(int pageIndex, int PageSize, string  wordFullText="") 
{ 
string store = "Sp_GetSourcePageWise"; 
 
 
var dbParameter = GetParameter(pageIndex,PageSize);

 
 
DataSet ds = Db.GetDataSet(store, dbParameter, CommandType.StoredProcedure); 
return DataSetToList(ds); 
}
public object Insert() {
var prset = new List<IDataParameter>();var sql = "INSERT INTO Source(SourceID,SourceName,SourceDetail) VALUES (@SourceID,@SourceName,@SourceDetail) ;Select @SourceID";
 prset.Add(Db.CreateParameterDb("@SourceID",_Source.SourceID)); prset.Add(Db.CreateParameterDb("@SourceName",_Source.SourceName)); prset.Add(Db.CreateParameterDb("@SourceDetail",_Source.SourceDetail));

object output = Db.FbExecuteScalar(sql, prset);return output;  }

public void Update() {
var prset = new List<IDataParameter>();
 prset.Add(Db.CreateParameterDb("@SourceID",_Source.SourceID)); prset.Add(Db.CreateParameterDb("@SourceName",_Source.SourceName)); prset.Add(Db.CreateParameterDb("@SourceDetail",_Source.SourceDetail));
var sql = @"UPDATE   Source SET  SourceName=@SourceName,SourceDetail=@SourceDetail where SourceID = @SourceID";

int output = Db.FbExecuteNonQuery(sql, prset);
if (output != 1){
 throw new System.Exception("Update" + this.ToString());}   }

public void Delete() {
var prset = new List<IDataParameter>();
 prset.Add(Db.CreateParameterDb("@SourceID",_Source.SourceID));
var sql =@"DELETE FROM Source where SourceID=@SourceID";

int output = Db.FbExecuteNonQuery(sql, prset);
if (output != 1){
 throw new System.Exception("Delete" + this.ToString());}   }

private List<Source> DataSetToList(DataSet ds) 
{
 EnumerableRowCollection<Source> q = (from temp in ds.Tables[0].AsEnumerable()
 select new Source
{
RecordCount = temp.Field<Int32>("RecordCount"),SourceID= temp.Field<String>("SourceID"), 
 SourceName= temp.Field<String>("SourceName"), 
 SourceDetail= temp.Field<String>("SourceDetail"), 
  });
  return q.ToList();
}
   public Boolean UpdateColumn(string id, string column,string value) 
        { 
            var prset = new List<IDataParameter>(); 
            prset.Add(Db.CreateParameterDb("@SourceID", id)); 
prset.Add(Db.CreateParameterDb("@Column", column));
            prset.Add(Db.CreateParameterDb("@Data", value)); 
   var sql = @"Sp_GetSource_UpdateColumn";
            int output = Db.FbExecuteNonQuery(sql, prset, CommandType.StoredProcedure); 
            if (output == 1) 
            { 
                return true; 
            } 
 
            return false;   
        } 
 public List<string> GetKeyWordsAllColumn(string Keyword) 
    { 
        
        string sql = "Sp_GetSource_Autocomplete"; 
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
          
 
  string sql = "SELECT  " + column + " FROM Source where lower(" + column + ") like '" + keyword.ToLower() + "%'   group by " + column + " order by count(*) desc;"; 
         
         
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
            if ( _Source.SourceID!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (SourceID='{0}') )", _Source.SourceID); 
            } 
            if ( _Source.SourceName!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (SourceName='{0}') )", _Source.SourceName); 
            } 
            if ( _Source.SourceDetail!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (SourceDetail='{0}') )", _Source.SourceDetail); 
            } 
return sql;
}
      public List<IDataParameter> GetParameter(int pageIndex, int PageSize)
        {
            var sqlStorePamameters = new List<IDataParameter>();
            sqlStorePamameters.Add(Db.CreateParameterDb("@PageIndex", pageIndex));
            sqlStorePamameters.Add(Db.CreateParameterDb("@PageSize", PageSize));
if (_Source.SourceID != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@SourceID", _Source.SourceID));

            }
if (_Source.SourceName != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@SourceName", _Source.SourceName));

            }
if (_Source.SourceDetail != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@SourceDetail", _Source.SourceDetail));

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
