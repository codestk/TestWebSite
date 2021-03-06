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
public class  LineDb: DataAccess
{
 public string _SortDirection { get; set; }
 public string _SortExpression { get; set; }
  public Line _Line;
public const string DataKey = "LineID";
public const string DataText = "LineName";
public const string DataValue = "LineID";
 public List<SelectInputProperties> Select()
    {
 string sql = "SELECT * FROM Line";
        DataSet ds = Db.GetDataSet(sql);

        return SelectInputProperties.DataSetToList(ds);
		
    }
	
public Line Select(string LineID) 
{ 
 string _sql1 = "SELECT *,0 AS RecordCount FROM Line where LineID = @LineID; "; 
   var prset = new List<IDataParameter>();
  prset.Add(Db.CreateParameterDb("@LineID", LineID));
  DataSet ds = Db.GetDataSet(_sql1,prset);
return DataSetToList(ds).FirstOrDefault(); 
}public List<Line> GetWithFilter(bool sortAscending, string sortExpression){
throw new Exception("Not implement");
string sql = "SELECT * FROM Line "; 
sql += string.Format("  where ((''='{0}')or(LineID='{0}'))", _Line.LineID);
sql += string.Format("  and ((''='{0}')or(LineName='{0}'))", _Line.LineName);
sql += string.Format("  and ((''='{0}')or(LineDetail='{0}'))", _Line.LineDetail);
if (sortExpression == null){
sql += string.Format(" order by LineID ", sortExpression);}
else
{
}

DataSet ds = Db.GetDataSet(sql);return DataSetToList(ds);}
public List<Line> GetPageWise(int pageIndex, int PageSize, string  wordFullText="") 
{ 
string store = "Sp_GetLinePageWise"; 
 
 
var dbParameter = GetParameter(pageIndex,PageSize);

 
 
DataSet ds = Db.GetDataSet(store, dbParameter, CommandType.StoredProcedure); 
return DataSetToList(ds); 
}
public object Insert() {
var prset = new List<IDataParameter>();var sql = "INSERT INTO Line(LineID,LineName,LineDetail) VALUES (@LineID,@LineName,@LineDetail) ;Select @LineID";
 prset.Add(Db.CreateParameterDb("@LineID",_Line.LineID)); prset.Add(Db.CreateParameterDb("@LineName",_Line.LineName)); prset.Add(Db.CreateParameterDb("@LineDetail",_Line.LineDetail));

object output = Db.FbExecuteScalar(sql, prset);return output;  }

public void Update() {
var prset = new List<IDataParameter>();
 prset.Add(Db.CreateParameterDb("@LineID",_Line.LineID)); prset.Add(Db.CreateParameterDb("@LineName",_Line.LineName)); prset.Add(Db.CreateParameterDb("@LineDetail",_Line.LineDetail));
var sql = @"UPDATE   Line SET  LineName=@LineName,LineDetail=@LineDetail where LineID = @LineID";

int output = Db.FbExecuteNonQuery(sql, prset);
if (output != 1){
 throw new System.Exception("Update" + this.ToString());}   }

public void Delete() {
var prset = new List<IDataParameter>();
 prset.Add(Db.CreateParameterDb("@LineID",_Line.LineID));
var sql =@"DELETE FROM Line where LineID=@LineID";

int output = Db.FbExecuteNonQuery(sql, prset);
if (output != 1){
 throw new System.Exception("Delete" + this.ToString());}   }

private List<Line> DataSetToList(DataSet ds) 
{
 EnumerableRowCollection<Line> q = (from temp in ds.Tables[0].AsEnumerable()
 select new Line
{
RecordCount = temp.Field<Int32>("RecordCount"),LineID= temp.Field<String>("LineID"), 
 LineName= temp.Field<String>("LineName"), 
 LineDetail= temp.Field<String>("LineDetail"), 
  });
  return q.ToList();
}
   public Boolean UpdateColumn(string id, string column,string value) 
        { 
            var prset = new List<IDataParameter>(); 
            prset.Add(Db.CreateParameterDb("@LineID", id)); 
prset.Add(Db.CreateParameterDb("@Column", column));
            prset.Add(Db.CreateParameterDb("@Data", value)); 
   var sql = @"Sp_GetLine_UpdateColumn";
            int output = Db.FbExecuteNonQuery(sql, prset, CommandType.StoredProcedure); 
            if (output == 1) 
            { 
                return true; 
            } 
 
            return false;   
        } 
 public List<string> GetKeyWordsAllColumn(string Keyword) 
    { 
        
        string sql = "Sp_GetLine_Autocomplete"; 
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
          
 
  string sql = "SELECT  " + column + " FROM Line where lower(" + column + ") like '" + keyword.ToLower() + "%'   group by " + column + " order by count(*) desc;"; 
         
         
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
            if ( _Line.LineID!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (LineID='{0}') )", _Line.LineID); 
            } 
            if ( _Line.LineName!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (LineName='{0}') )", _Line.LineName); 
            } 
            if ( _Line.LineDetail!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (LineDetail='{0}') )", _Line.LineDetail); 
            } 
return sql;
}
      public List<IDataParameter> GetParameter(int pageIndex, int PageSize)
        {
            var sqlStorePamameters = new List<IDataParameter>();
            sqlStorePamameters.Add(Db.CreateParameterDb("@PageIndex", pageIndex));
            sqlStorePamameters.Add(Db.CreateParameterDb("@PageSize", PageSize));
if (_Line.LineID != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@LineID", _Line.LineID));

            }
if (_Line.LineName != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@LineName", _Line.LineName));

            }
if (_Line.LineDetail != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@LineDetail", _Line.LineDetail));

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
