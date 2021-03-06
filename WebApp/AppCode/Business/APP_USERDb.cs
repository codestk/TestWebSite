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
public class  APP_USERDb: DataAccess
{
 public string _SortDirection { get; set; }
 public string _SortExpression { get; set; }
  public APP_USER _APP_USER;
public const string DataKey = "UserID";
public const string DataText = "Password";
public const string DataValue = "UserID";
 public List<SelectInputProperties> Select()
    {
 string sql = "SELECT * FROM APP_USER";
        DataSet ds = Db.GetDataSet(sql);

        return SelectInputProperties.DataSetToList(ds);
		
    }
	
public APP_USER Select(string UserID) 
{ 
 string _sql1 = "SELECT *,0 AS RecordCount FROM APP_USER where UserID = @UserID; "; 
   var prset = new List<IDataParameter>();
  prset.Add(Db.CreateParameterDb("@UserID", UserID));
  DataSet ds = Db.GetDataSet(_sql1,prset);
return DataSetToList(ds).FirstOrDefault(); 
}public List<APP_USER> GetWithFilter(bool sortAscending, string sortExpression){
throw new Exception("Not implement");
string sql = "SELECT * FROM APP_USER "; 
sql += string.Format("  where ((''='{0}')or(UserID='{0}'))", _APP_USER.UserID);
sql += string.Format("  and ((''='{0}')or(Password='{0}'))", _APP_USER.Password);
sql += string.Format("  and ((''='{0}')or(FirstName='{0}'))", _APP_USER.FirstName);
sql += string.Format("  and ((''='{0}')or(LastName='{0}'))", _APP_USER.LastName);
sql += string.Format("  and ((''='{0}')or(Tel='{0}'))", _APP_USER.Tel);
sql += string.Format("  and ((''='{0}')or(FLAG='{0}'))", _APP_USER.FLAG);
sql += string.Format("  and ((''='{0}')or(RoleAdmin='{0}'))", _APP_USER.RoleAdmin);
sql += string.Format("  and ((''='{0}')or(RoleUser='{0}'))", _APP_USER.RoleUser);
sql += string.Format("  and ((''='{0}')or(Picture='{0}'))", _APP_USER.Picture);
sql += string.Format("  and ((''='{0}')or(Created='{0}'))", _APP_USER.Created);
if (sortExpression == null){
sql += string.Format(" order by UserID ", sortExpression);}
else
{
}

DataSet ds = Db.GetDataSet(sql);return DataSetToList(ds);}
public List<APP_USER> GetPageWise(int pageIndex, int PageSize, string  wordFullText="") 
{ 
string store = "Sp_GetAPP_USERPageWise"; 
 
 
var dbParameter = GetParameter(pageIndex,PageSize);

 
 
DataSet ds = Db.GetDataSet(store, dbParameter, CommandType.StoredProcedure); 
return DataSetToList(ds); 
}
public object Insert() {
var prset = new List<IDataParameter>();var sql = "INSERT INTO APP_USER(UserID,Password,FirstName,LastName,Tel,FLAG,RoleAdmin,RoleUser,Created) VALUES (@UserID,@Password,@FirstName,@LastName,@Tel,@FLAG,@RoleAdmin,@RoleUser,@Created) ;Select @UserID";
 prset.Add(Db.CreateParameterDb("@UserID",_APP_USER.UserID)); prset.Add(Db.CreateParameterDb("@Password",_APP_USER.Password)); prset.Add(Db.CreateParameterDb("@FirstName",_APP_USER.FirstName)); prset.Add(Db.CreateParameterDb("@LastName",_APP_USER.LastName)); prset.Add(Db.CreateParameterDb("@Tel",_APP_USER.Tel)); prset.Add(Db.CreateParameterDb("@FLAG",_APP_USER.FLAG)); prset.Add(Db.CreateParameterDb("@RoleAdmin",_APP_USER.RoleAdmin)); prset.Add(Db.CreateParameterDb("@RoleUser",_APP_USER.RoleUser)); prset.Add(Db.CreateParameterDb("@Created",_APP_USER.Created));

object output = Db.FbExecuteScalar(sql, prset);return output;  }

public void Update() {
var prset = new List<IDataParameter>();
 prset.Add(Db.CreateParameterDb("@UserID",_APP_USER.UserID)); prset.Add(Db.CreateParameterDb("@Password",_APP_USER.Password)); prset.Add(Db.CreateParameterDb("@FirstName",_APP_USER.FirstName)); prset.Add(Db.CreateParameterDb("@LastName",_APP_USER.LastName)); prset.Add(Db.CreateParameterDb("@Tel",_APP_USER.Tel)); prset.Add(Db.CreateParameterDb("@FLAG",_APP_USER.FLAG)); prset.Add(Db.CreateParameterDb("@RoleAdmin",_APP_USER.RoleAdmin)); prset.Add(Db.CreateParameterDb("@RoleUser",_APP_USER.RoleUser)); prset.Add(Db.CreateParameterDb("@Created",_APP_USER.Created));
var sql = @"UPDATE   APP_USER SET  Password=@Password,FirstName=@FirstName,LastName=@LastName,Tel=@Tel,FLAG=@FLAG,RoleAdmin=@RoleAdmin,RoleUser=@RoleUser,Created=@Created where UserID = @UserID";

int output = Db.FbExecuteNonQuery(sql, prset);
if (output != 1){
 throw new System.Exception("Update" + this.ToString());}   }

public void Delete() {
var prset = new List<IDataParameter>();
 prset.Add(Db.CreateParameterDb("@UserID",_APP_USER.UserID));
var sql =@"DELETE FROM APP_USER where UserID=@UserID";

int output = Db.FbExecuteNonQuery(sql, prset);
if (output != 1){
 throw new System.Exception("Delete" + this.ToString());}   }

private List<APP_USER> DataSetToList(DataSet ds) 
{
 EnumerableRowCollection<APP_USER> q = (from temp in ds.Tables[0].AsEnumerable()
 select new APP_USER
{
RecordCount = temp.Field<Int32>("RecordCount"),UserID= temp.Field<String>("UserID"), 
 Password= temp.Field<String>("Password"), 
 FirstName= temp.Field<String>("FirstName"), 
 LastName= temp.Field<String>("LastName"), 
 Tel= temp.Field<String>("Tel"), 
 FLAG= temp.Field<Boolean?>("FLAG"), 
 RoleAdmin= temp.Field<Boolean?>("RoleAdmin"), 
 RoleUser= temp.Field<Boolean?>("RoleUser"), 
 Created= temp.Field<DateTime?>("Created"), 
  });
  return q.ToList();
}
   public Boolean UpdateColumn(string id, string column,string value) 
        { 
            var prset = new List<IDataParameter>(); 
            prset.Add(Db.CreateParameterDb("@UserID", id)); 
prset.Add(Db.CreateParameterDb("@Column", column));
            prset.Add(Db.CreateParameterDb("@Data", value)); 
   var sql = @"Sp_GetAPP_USER_UpdateColumn";
            int output = Db.FbExecuteNonQuery(sql, prset, CommandType.StoredProcedure); 
            if (output == 1) 
            { 
                return true; 
            } 
 
            return false;   
        } 
 public List<string> GetKeyWordsAllColumn(string Keyword) 
    { 
        
        string sql = "Sp_GetAPP_USER_Autocomplete"; 
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
          
 
  string sql = "SELECT  " + column + " FROM APP_USER where lower(" + column + ") like '" + keyword.ToLower() + "%'   group by " + column + " order by count(*) desc;"; 
         
         
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
            if ( _APP_USER.UserID!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (UserID='{0}') )", _APP_USER.UserID); 
            } 
            if ( _APP_USER.Password!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (Password='{0}') )", _APP_USER.Password); 
            } 
            if ( _APP_USER.FirstName!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (FirstName='{0}') )", _APP_USER.FirstName); 
            } 
            if ( _APP_USER.LastName!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (LastName='{0}') )", _APP_USER.LastName); 
            } 
            if ( _APP_USER.Tel!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (Tel='{0}') )", _APP_USER.Tel); 
            } 
            if ( _APP_USER.FLAG!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (FLAG='{0}') )", _APP_USER.FLAG); 
            } 
            if ( _APP_USER.RoleAdmin!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (RoleAdmin='{0}') )", _APP_USER.RoleAdmin); 
            } 
            if ( _APP_USER.RoleUser!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (RoleUser='{0}') )", _APP_USER.RoleUser); 
            } 
            if ( _APP_USER.Picture!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (Picture='{0}') )", _APP_USER.Picture); 
            } 
            if ( _APP_USER.Created!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (Created='{0}') )", _APP_USER.Created); 
            } 
return sql;
}
      public List<IDataParameter> GetParameter(int pageIndex, int PageSize)
        {
            var sqlStorePamameters = new List<IDataParameter>();
            sqlStorePamameters.Add(Db.CreateParameterDb("@PageIndex", pageIndex));
            sqlStorePamameters.Add(Db.CreateParameterDb("@PageSize", PageSize));
if (_APP_USER.UserID != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@UserID", _APP_USER.UserID));

            }
if (_APP_USER.Password != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@Password", _APP_USER.Password));

            }
if (_APP_USER.FirstName != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@FirstName", _APP_USER.FirstName));

            }
if (_APP_USER.LastName != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@LastName", _APP_USER.LastName));

            }
if (_APP_USER.Tel != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@Tel", _APP_USER.Tel));

            }
if (_APP_USER.FLAG != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@FLAG", _APP_USER.FLAG));

            }
if (_APP_USER.RoleAdmin != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@RoleAdmin", _APP_USER.RoleAdmin));

            }
if (_APP_USER.RoleUser != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@RoleUser", _APP_USER.RoleUser));

            }
if (_APP_USER.Picture != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@Picture", _APP_USER.Picture));

            }
if (_APP_USER.Created != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@Created", _APP_USER.Created));

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
