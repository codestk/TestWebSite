using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
public class  AccountStatusDb: DataAccess
{
 public string _SortDirection { get; set; }
 public string _SortExpression { get; set; }
  public AccountStatus _AccountStatus;
public const string DataKey = "Status";
public const string DataText = "StatusName";
public const string DataValue = "Status";
 public List<SelectInputProperties> Select()
    {
 string sql = "SELECT * FROM AccountStatus";
        DataSet ds = Db.GetDataSet(sql);

        return SelectInputProperties.DataSetToList(ds);
		
    }
	
public AccountStatus Select(string Status) 
{ 
 string _sql1 = "SELECT *,0 AS RecordCount FROM AccountStatus where Status = @Status; "; 
   var prset = new List<IDataParameter>();
  prset.Add(Db.CreateParameterDb("@Status", Status));
  DataSet ds = Db.GetDataSet(_sql1,prset);
return DataSetToList(ds).FirstOrDefault(); 
}public List<AccountStatus> GetWithFilter(bool sortAscending, string sortExpression){
throw new Exception("Not implement");
string sql = "SELECT * FROM AccountStatus "; 
sql += string.Format("  where ((''='{0}')or(Status='{0}'))", _AccountStatus.Status);
sql += string.Format("  and ((''='{0}')or(StatusName='{0}'))", _AccountStatus.StatusName);
if (sortExpression == null){
sql += string.Format(" order by Status ", sortExpression);}
else
{
}

DataSet ds = Db.GetDataSet(sql);return DataSetToList(ds);}
public List<AccountStatus> GetPageWise(int pageIndex, int PageSize, string  wordFullText="") 
{ 
string store = "Sp_GetAccountStatusPageWise"; 
 
 
var dbParameter = GetParameter(pageIndex,PageSize);

 
 
DataSet ds = Db.GetDataSet(store, dbParameter, CommandType.StoredProcedure); 
return DataSetToList(ds); 
}
public object Insert() {
var prset = new List<IDataParameter>();var sql = "INSERT INTO AccountStatus(Status,StatusName) VALUES (@Status,@StatusName) ;Select @Status";
 prset.Add(Db.CreateParameterDb("@Status",_AccountStatus.Status)); prset.Add(Db.CreateParameterDb("@StatusName",_AccountStatus.StatusName));

object output = Db.FbExecuteScalar(sql, prset);return output;  }

public void Update() {
var prset = new List<IDataParameter>();
 prset.Add(Db.CreateParameterDb("@Status",_AccountStatus.Status)); prset.Add(Db.CreateParameterDb("@StatusName",_AccountStatus.StatusName));
var sql = @"UPDATE   AccountStatus SET  StatusName=@StatusName where Status = @Status";

int output = Db.FbExecuteNonQuery(sql, prset);
if (output != 1){
 throw new System.Exception("Update" + this.ToString());}   }

public void Delete() {
var prset = new List<IDataParameter>();
 prset.Add(Db.CreateParameterDb("@Status",_AccountStatus.Status));
var sql =@"DELETE FROM AccountStatus where Status=@Status";

int output = Db.FbExecuteNonQuery(sql, prset);
if (output != 1){
 throw new System.Exception("Delete" + this.ToString());}   }

private List<AccountStatus> DataSetToList(DataSet ds) 
{
 EnumerableRowCollection<AccountStatus> q = (from temp in ds.Tables[0].AsEnumerable()
 select new AccountStatus
{
RecordCount = temp.Field<Int32>("RecordCount"),Status= temp.Field<String>("Status"), 
 StatusName= temp.Field<String>("StatusName"), 
  });
  return q.ToList();
}
   public Boolean UpdateColumn(string id, string column,string value) 
        { 
            var prset = new List<IDataParameter>(); 
            prset.Add(Db.CreateParameterDb("@Status", id)); 
prset.Add(Db.CreateParameterDb("@Column", column));
            prset.Add(Db.CreateParameterDb("@Data", value)); 
   var sql = @"Sp_GetAccountStatus_UpdateColumn";
            int output = Db.FbExecuteNonQuery(sql, prset, CommandType.StoredProcedure); 
            if (output == 1) 
            { 
                return true; 
            } 
 
            return false;   
        } 
 public List<string> GetKeyWordsAllColumn(string Keyword) 
    { 
        
        string sql = "Sp_GetAccountStatus_Autocomplete"; 
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
          
 
  string sql = "SELECT  " + column + " FROM AccountStatus where lower(" + column + ") like '" + keyword.ToLower() + "%'   group by " + column + " order by count(*) desc;"; 
         
         
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
            if ( _AccountStatus.Status!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (Status='{0}') )", _AccountStatus.Status); 
            } 
            if ( _AccountStatus.StatusName!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (StatusName='{0}') )", _AccountStatus.StatusName); 
            } 
return sql;
}
      public List<IDataParameter> GetParameter(int pageIndex, int PageSize)
        {
            var sqlStorePamameters = new List<IDataParameter>();
            sqlStorePamameters.Add(Db.CreateParameterDb("@PageIndex", pageIndex));
            sqlStorePamameters.Add(Db.CreateParameterDb("@PageSize", PageSize));
if (_AccountStatus.Status != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@Status", _AccountStatus.Status));

            }
if (_AccountStatus.StatusName != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@StatusName", _AccountStatus.StatusName));

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

