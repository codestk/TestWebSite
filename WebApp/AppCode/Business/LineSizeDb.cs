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
public class  LineSizeDb: DataAccess
{
 public string _SortDirection { get; set; }
 public string _SortExpression { get; set; }
  public LineSize _LineSize;
public const string DataKey = "LineSizeID";
public const string DataText = "LineSizeName";
public const string DataValue = "LineSizeID";
 public List<SelectInputProperties> Select()
    {
 string sql = "SELECT * FROM LineSize";
        DataSet ds = Db.GetDataSet(sql);

        return SelectInputProperties.DataSetToList(ds);
		
    }
	
public LineSize Select(string LineSizeID) 
{ 
 string _sql1 = "SELECT *,0 AS RecordCount FROM LineSize where LineSizeID = @LineSizeID; "; 
   var prset = new List<IDataParameter>();
  prset.Add(Db.CreateParameterDb("@LineSizeID", LineSizeID));
  DataSet ds = Db.GetDataSet(_sql1,prset);
return DataSetToList(ds).FirstOrDefault(); 
}public List<LineSize> GetWithFilter(bool sortAscending, string sortExpression){
throw new Exception("Not implement");
string sql = "SELECT * FROM LineSize "; 
sql += string.Format("  where ((''='{0}')or(LineSizeID='{0}'))", _LineSize.LineSizeID);
sql += string.Format("  and ((''='{0}')or(LineSizeName='{0}'))", _LineSize.LineSizeName);
sql += string.Format("  and ((''='{0}')or(LineSizeDetail='{0}'))", _LineSize.LineSizeDetail);
if (sortExpression == null){
sql += string.Format(" order by LineSizeID ", sortExpression);}
else
{
}

DataSet ds = Db.GetDataSet(sql);return DataSetToList(ds);}
public List<LineSize> GetPageWise(int pageIndex, int PageSize, string  wordFullText="") 
{ 
string store = "Sp_GetLineSizePageWise"; 
 
 
var dbParameter = GetParameter(pageIndex,PageSize);

 
 
DataSet ds = Db.GetDataSet(store, dbParameter, CommandType.StoredProcedure); 
return DataSetToList(ds); 
}
public object Insert() {
var prset = new List<IDataParameter>();var sql = "INSERT INTO LineSize(LineSizeID,LineSizeName,LineSizeDetail) VALUES (@LineSizeID,@LineSizeName,@LineSizeDetail) ;Select @LineSizeID";
 prset.Add(Db.CreateParameterDb("@LineSizeID",_LineSize.LineSizeID)); prset.Add(Db.CreateParameterDb("@LineSizeName",_LineSize.LineSizeName)); prset.Add(Db.CreateParameterDb("@LineSizeDetail",_LineSize.LineSizeDetail));

object output = Db.FbExecuteScalar(sql, prset);return output;  }

public void Update() {
var prset = new List<IDataParameter>();
 prset.Add(Db.CreateParameterDb("@LineSizeID",_LineSize.LineSizeID)); prset.Add(Db.CreateParameterDb("@LineSizeName",_LineSize.LineSizeName)); prset.Add(Db.CreateParameterDb("@LineSizeDetail",_LineSize.LineSizeDetail));
var sql = @"UPDATE   LineSize SET  LineSizeName=@LineSizeName,LineSizeDetail=@LineSizeDetail where LineSizeID = @LineSizeID";

int output = Db.FbExecuteNonQuery(sql, prset);
if (output != 1){
 throw new System.Exception("Update" + this.ToString());}   }

public void Delete() {
var prset = new List<IDataParameter>();
 prset.Add(Db.CreateParameterDb("@LineSizeID",_LineSize.LineSizeID));
var sql =@"DELETE FROM LineSize where LineSizeID=@LineSizeID";

int output = Db.FbExecuteNonQuery(sql, prset);
if (output != 1){
 throw new System.Exception("Delete" + this.ToString());}   }

private List<LineSize> DataSetToList(DataSet ds) 
{
 EnumerableRowCollection<LineSize> q = (from temp in ds.Tables[0].AsEnumerable()
 select new LineSize
{
RecordCount = temp.Field<Int32>("RecordCount"),LineSizeID= temp.Field<String>("LineSizeID"), 
 LineSizeName= temp.Field<String>("LineSizeName"), 
 LineSizeDetail= temp.Field<String>("LineSizeDetail"), 
  });
  return q.ToList();
}
   public Boolean UpdateColumn(string id, string column,string value) 
        { 
            var prset = new List<IDataParameter>(); 
            prset.Add(Db.CreateParameterDb("@LineSizeID", id)); 
prset.Add(Db.CreateParameterDb("@Column", column));
            prset.Add(Db.CreateParameterDb("@Data", value)); 
   var sql = @"Sp_GetLineSize_UpdateColumn";
            int output = Db.FbExecuteNonQuery(sql, prset, CommandType.StoredProcedure); 
            if (output == 1) 
            { 
                return true; 
            } 
 
            return false;   
        } 
 public List<string> GetKeyWordsAllColumn(string Keyword) 
    { 
        
        string sql = "Sp_GetLineSize_Autocomplete"; 
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
          
 
  string sql = "SELECT  " + column + " FROM LineSize where lower(" + column + ") like '" + keyword.ToLower() + "%'   group by " + column + " order by count(*) desc;"; 
         
         
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
            if ( _LineSize.LineSizeID!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (LineSizeID='{0}') )", _LineSize.LineSizeID); 
            } 
            if ( _LineSize.LineSizeName!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (LineSizeName='{0}') )", _LineSize.LineSizeName); 
            } 
            if ( _LineSize.LineSizeDetail!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (LineSizeDetail='{0}') )", _LineSize.LineSizeDetail); 
            } 
return sql;
}
      public List<IDataParameter> GetParameter(int pageIndex, int PageSize)
        {
            var sqlStorePamameters = new List<IDataParameter>();
            sqlStorePamameters.Add(Db.CreateParameterDb("@PageIndex", pageIndex));
            sqlStorePamameters.Add(Db.CreateParameterDb("@PageSize", PageSize));
if (_LineSize.LineSizeID != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@LineSizeID", _LineSize.LineSizeID));

            }
if (_LineSize.LineSizeName != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@LineSizeName", _LineSize.LineSizeName));

            }
if (_LineSize.LineSizeDetail != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@LineSizeDetail", _LineSize.LineSizeDetail));

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
