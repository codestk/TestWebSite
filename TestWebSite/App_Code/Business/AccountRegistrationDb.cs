using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
public class  AccountRegistrationDb: DataAccess
{
 public string _SortDirection { get; set; }
 public string _SortExpression { get; set; }
  public AccountRegistration _AccountRegistration;
public const string DataKey = "RequestId";
public const string DataText = "UserName";
public const string DataValue = "RequestId";
 public List<SelectInputProperties> Select()
    {
 string sql = "SELECT * FROM AccountRegistration";
        DataSet ds = Db.GetDataSet(sql);

        return SelectInputProperties.DataSetToList(ds);
		
    }
	
public AccountRegistration Select(string RequestId) 
{ 
 string _sql1 = "SELECT *,0 AS RecordCount FROM AccountRegistration where RequestId = @RequestId; "; 
   var prset = new List<IDataParameter>();
  prset.Add(Db.CreateParameterDb("@RequestId", RequestId));
  DataSet ds = Db.GetDataSet(_sql1,prset);
return DataSetToList(ds).FirstOrDefault(); 
}public List<AccountRegistration> GetWithFilter(bool sortAscending, string sortExpression){
throw new Exception("Not implement");
string sql = "SELECT * FROM AccountRegistration "; 
sql += string.Format("  where ((''='{0}')or(RequestId='{0}'))", _AccountRegistration.RequestId);
sql += string.Format("  and ((''='{0}')or(UserName='{0}'))", _AccountRegistration.UserName);
sql += string.Format("  and ((''='{0}')or(Password='{0}'))", _AccountRegistration.Password);
sql += string.Format("  and ((''='{0}')or(FirstName='{0}'))", _AccountRegistration.FirstName);
sql += string.Format("  and ((''='{0}')or(LastName='{0}'))", _AccountRegistration.LastName);
sql += string.Format("  and ((''='{0}')or(Department='{0}'))", _AccountRegistration.Department);
sql += string.Format("  and ((''='{0}')or(Phone='{0}'))", _AccountRegistration.Phone);
sql += string.Format("  and ((''='{0}')or(Fax='{0}'))", _AccountRegistration.Fax);
sql += string.Format("  and ((''='{0}')or(Status='{0}'))", _AccountRegistration.Status);
sql += string.Format("  and ((''='{0}')or(CreateDate='{0}'))", _AccountRegistration.CreateDate);
sql += string.Format("  and ((''='{0}')or(DeleteDate='{0}'))", _AccountRegistration.DeleteDate);
sql += string.Format("  and ((''='{0}')or(CancelDate='{0}'))", _AccountRegistration.CancelDate);
sql += string.Format("  and ((''='{0}')or(ApprovedDate='{0}'))", _AccountRegistration.ApprovedDate);
sql += string.Format("  and ((''='{0}')or(LastUpdate='{0}'))", _AccountRegistration.LastUpdate);
if (sortExpression == null){
sql += string.Format(" order by RequestId ", sortExpression);}
else
{
}

DataSet ds = Db.GetDataSet(sql);return DataSetToList(ds);}
public List<AccountRegistration> GetPageWise(int pageIndex, int PageSize, string  wordFullText="") 
{ 
string store = "Sp_GetAccountRegistrationPageWise"; 
 
 
var dbParameter = GetParameter(pageIndex,PageSize);

 
 
DataSet ds = Db.GetDataSet(store, dbParameter, CommandType.StoredProcedure); 
return DataSetToList(ds); 
}
public object Insert() {
var prset = new List<IDataParameter>();var sql = "INSERT INTO AccountRegistration(UserName,Password,FirstName,LastName,Department,Phone,Fax,Status,CreateDate,DeleteDate,CancelDate,ApprovedDate,LastUpdate) VALUES (@UserName,@Password,@FirstName,@LastName,@Department,@Phone,@Fax,@Status,@CreateDate,@DeleteDate,@CancelDate,@ApprovedDate,@LastUpdate) ;SELECT SCOPE_IDENTITY();";
 prset.Add(Db.CreateParameterDb("@UserName",_AccountRegistration.UserName)); prset.Add(Db.CreateParameterDb("@Password",_AccountRegistration.Password)); prset.Add(Db.CreateParameterDb("@FirstName",_AccountRegistration.FirstName)); prset.Add(Db.CreateParameterDb("@LastName",_AccountRegistration.LastName)); prset.Add(Db.CreateParameterDb("@Department",_AccountRegistration.Department)); prset.Add(Db.CreateParameterDb("@Phone",_AccountRegistration.Phone)); prset.Add(Db.CreateParameterDb("@Fax",_AccountRegistration.Fax)); prset.Add(Db.CreateParameterDb("@Status",_AccountRegistration.Status)); prset.Add(Db.CreateParameterDb("@CreateDate",_AccountRegistration.CreateDate)); prset.Add(Db.CreateParameterDb("@DeleteDate",_AccountRegistration.DeleteDate)); prset.Add(Db.CreateParameterDb("@CancelDate",_AccountRegistration.CancelDate)); prset.Add(Db.CreateParameterDb("@ApprovedDate",_AccountRegistration.ApprovedDate)); prset.Add(Db.CreateParameterDb("@LastUpdate",_AccountRegistration.LastUpdate));

object output = Db.FbExecuteScalar(sql, prset);return output;  }

public void Update() {
var prset = new List<IDataParameter>();
 prset.Add(Db.CreateParameterDb("@RequestId",_AccountRegistration.RequestId)); prset.Add(Db.CreateParameterDb("@UserName",_AccountRegistration.UserName)); prset.Add(Db.CreateParameterDb("@Password",_AccountRegistration.Password)); prset.Add(Db.CreateParameterDb("@FirstName",_AccountRegistration.FirstName)); prset.Add(Db.CreateParameterDb("@LastName",_AccountRegistration.LastName)); prset.Add(Db.CreateParameterDb("@Department",_AccountRegistration.Department)); prset.Add(Db.CreateParameterDb("@Phone",_AccountRegistration.Phone)); prset.Add(Db.CreateParameterDb("@Fax",_AccountRegistration.Fax)); prset.Add(Db.CreateParameterDb("@Status",_AccountRegistration.Status)); prset.Add(Db.CreateParameterDb("@CreateDate",_AccountRegistration.CreateDate)); prset.Add(Db.CreateParameterDb("@DeleteDate",_AccountRegistration.DeleteDate)); prset.Add(Db.CreateParameterDb("@CancelDate",_AccountRegistration.CancelDate)); prset.Add(Db.CreateParameterDb("@ApprovedDate",_AccountRegistration.ApprovedDate)); prset.Add(Db.CreateParameterDb("@LastUpdate",_AccountRegistration.LastUpdate));
var sql = @"UPDATE   AccountRegistration SET  UserName=@UserName,Password=@Password,FirstName=@FirstName,LastName=@LastName,Department=@Department,Phone=@Phone,Fax=@Fax,Status=@Status,CreateDate=@CreateDate,DeleteDate=@DeleteDate,CancelDate=@CancelDate,ApprovedDate=@ApprovedDate,LastUpdate=@LastUpdate where RequestId = @RequestId";

int output = Db.FbExecuteNonQuery(sql, prset);
if (output != 1){
 throw new System.Exception("Update" + this.ToString());}   }

public void Delete() {
var prset = new List<IDataParameter>();
 prset.Add(Db.CreateParameterDb("@RequestId",_AccountRegistration.RequestId));
var sql =@"DELETE FROM AccountRegistration where RequestId=@RequestId";

int output = Db.FbExecuteNonQuery(sql, prset);
if (output != 1){
 throw new System.Exception("Delete" + this.ToString());}   }

private List<AccountRegistration> DataSetToList(DataSet ds) 
{
 EnumerableRowCollection<AccountRegistration> q = (from temp in ds.Tables[0].AsEnumerable()
 select new AccountRegistration
{
RecordCount = temp.Field<Int32>("RecordCount"),RequestId= temp.Field<Int32?>("RequestId"), 
 UserName= temp.Field<String>("UserName"), 
 Password= temp.Field<String>("Password"), 
 FirstName= temp.Field<String>("FirstName"), 
 LastName= temp.Field<String>("LastName"), 
 Department= temp.Field<String>("Department"), 
 Phone= temp.Field<String>("Phone"), 
 Fax= temp.Field<String>("Fax"), 
 Status= temp.Field<String>("Status"), 
 CreateDate= temp.Field<DateTime?>("CreateDate"), 
 DeleteDate= temp.Field<DateTime?>("DeleteDate"), 
 CancelDate= temp.Field<DateTime?>("CancelDate"), 
 ApprovedDate= temp.Field<DateTime?>("ApprovedDate"), 
 LastUpdate= temp.Field<DateTime?>("LastUpdate"), 
  });
  return q.ToList();
}
   public Boolean UpdateColumn(string id, string column,string value) 
        { 
            var prset = new List<IDataParameter>(); 
            prset.Add(Db.CreateParameterDb("@RequestId", id)); 
prset.Add(Db.CreateParameterDb("@Column", column));
            prset.Add(Db.CreateParameterDb("@Data", value)); 
   var sql = @"Sp_GetAccountRegistration_UpdateColumn";
            int output = Db.FbExecuteNonQuery(sql, prset, CommandType.StoredProcedure); 
            if (output == 1) 
            { 
                return true; 
            } 
 
            return false;   
        } 
 public List<string> GetKeyWordsAllColumn(string Keyword) 
    { 
        
        string sql = "Sp_GetAccountRegistration_Autocomplete"; 
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
          
 
  string sql = "SELECT  " + column + " FROM AccountRegistration where lower(" + column + ") like '" + keyword.ToLower() + "%'   group by " + column + " order by count(*) desc;"; 
         
         
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
            if ( _AccountRegistration.RequestId!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (RequestId='{0}') )", _AccountRegistration.RequestId); 
            } 
            if ( _AccountRegistration.UserName!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (UserName='{0}') )", _AccountRegistration.UserName); 
            } 
            if ( _AccountRegistration.Password!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (Password='{0}') )", _AccountRegistration.Password); 
            } 
            if ( _AccountRegistration.FirstName!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (FirstName='{0}') )", _AccountRegistration.FirstName); 
            } 
            if ( _AccountRegistration.LastName!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (LastName='{0}') )", _AccountRegistration.LastName); 
            } 
            if ( _AccountRegistration.Department!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (Department='{0}') )", _AccountRegistration.Department); 
            } 
            if ( _AccountRegistration.Phone!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (Phone='{0}') )", _AccountRegistration.Phone); 
            } 
            if ( _AccountRegistration.Fax!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (Fax='{0}') )", _AccountRegistration.Fax); 
            } 
            if ( _AccountRegistration.Status!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (Status='{0}') )", _AccountRegistration.Status); 
            } 
            if ( _AccountRegistration.CreateDate!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (CreateDate='{0}') )", _AccountRegistration.CreateDate); 
            } 
            if ( _AccountRegistration.DeleteDate!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (DeleteDate='{0}') )", _AccountRegistration.DeleteDate); 
            } 
            if ( _AccountRegistration.CancelDate!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (CancelDate='{0}') )", _AccountRegistration.CancelDate); 
            } 
            if ( _AccountRegistration.ApprovedDate!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (ApprovedDate='{0}') )", _AccountRegistration.ApprovedDate); 
            } 
            if ( _AccountRegistration.LastUpdate!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (LastUpdate='{0}') )", _AccountRegistration.LastUpdate); 
            } 
return sql;
}
      public List<IDataParameter> GetParameter(int pageIndex, int PageSize)
        {
            var sqlStorePamameters = new List<IDataParameter>();
            sqlStorePamameters.Add(Db.CreateParameterDb("@PageIndex", pageIndex));
            sqlStorePamameters.Add(Db.CreateParameterDb("@PageSize", PageSize));
if (_AccountRegistration.RequestId != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@RequestId", _AccountRegistration.RequestId));

            }
if (_AccountRegistration.UserName != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@UserName", _AccountRegistration.UserName));

            }
if (_AccountRegistration.Password != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@Password", _AccountRegistration.Password));

            }
if (_AccountRegistration.FirstName != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@FirstName", _AccountRegistration.FirstName));

            }
if (_AccountRegistration.LastName != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@LastName", _AccountRegistration.LastName));

            }
if (_AccountRegistration.Department != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@Department", _AccountRegistration.Department));

            }
if (_AccountRegistration.Phone != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@Phone", _AccountRegistration.Phone));

            }
if (_AccountRegistration.Fax != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@Fax", _AccountRegistration.Fax));

            }
if (_AccountRegistration.Status != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@Status", _AccountRegistration.Status));

            }
if (_AccountRegistration.CreateDate != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@CreateDate", _AccountRegistration.CreateDate));

            }
if (_AccountRegistration.DeleteDate != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@DeleteDate", _AccountRegistration.DeleteDate));

            }
if (_AccountRegistration.CancelDate != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@CancelDate", _AccountRegistration.CancelDate));

            }
if (_AccountRegistration.ApprovedDate != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@ApprovedDate", _AccountRegistration.ApprovedDate));

            }
if (_AccountRegistration.LastUpdate != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@LastUpdate", _AccountRegistration.LastUpdate));

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

