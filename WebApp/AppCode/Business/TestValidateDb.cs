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
public class  TestValidateDb: DataAccess
{
 public string _SortDirection { get; set; }
 public string _SortExpression { get; set; }
  public TestValidate _TestValidate;
public const string DataKey = "Id";
public const string DataText = "Name";
public const string DataValue = "Id";
 public List<SelectInputProperties> Select()
    {
 string sql = "SELECT * FROM TestValidate";
        DataSet ds = Db.GetDataSet(sql);

        return SelectInputProperties.DataSetToList(ds);
		
    }
	
public TestValidate Select(string Id) 
{ 
 string _sql1 = "SELECT *,0 AS RecordCount FROM TestValidate where Id = @Id; "; 
   var prset = new List<IDataParameter>();
  prset.Add(Db.CreateParameterDb("@Id", Id));
  DataSet ds = Db.GetDataSet(_sql1,prset);
return DataSetToList(ds).FirstOrDefault(); 
}public List<TestValidate> GetWithFilter(bool sortAscending, string sortExpression){
throw new Exception("Not implement");
string sql = "SELECT * FROM TestValidate "; 
sql += string.Format("  where ((''='{0}')or(Id='{0}'))", _TestValidate.Id);
sql += string.Format("  and ((''='{0}')or(Name='{0}'))", _TestValidate.Name);
sql += string.Format("  and ((''='{0}')or(NickName='{0}'))", _TestValidate.NickName);
sql += string.Format("  and ((''='{0}')or(Max='{0}'))", _TestValidate.Max);
sql += string.Format("  and ((''='{0}')or(Item='{0}'))", _TestValidate.Item);
sql += string.Format("  and ((''='{0}')or(CreateItme='{0}'))", _TestValidate.CreateItme);
if (sortExpression == null){
sql += string.Format(" order by Id ", sortExpression);}
else
{
}

DataSet ds = Db.GetDataSet(sql);return DataSetToList(ds);}
public List<TestValidate> GetPageWise(int pageIndex, int PageSize, string  wordFullText="") 
{ 
string store = "Sp_GetTestValidatePageWise"; 
 
 
var dbParameter = GetParameter(pageIndex,PageSize);

 
 
DataSet ds = Db.GetDataSet(store, dbParameter, CommandType.StoredProcedure); 
return DataSetToList(ds); 
}
public object Insert() {
var prset = new List<IDataParameter>();var sql = "INSERT INTO TestValidate(Id,Name,NickName,Max,Item,CreateItme) VALUES (@Id,@Name,@NickName,@Max,@Item,@CreateItme) ;Select @Id";
 prset.Add(Db.CreateParameterDb("@Id",_TestValidate.Id)); prset.Add(Db.CreateParameterDb("@Name",_TestValidate.Name)); prset.Add(Db.CreateParameterDb("@NickName",_TestValidate.NickName)); prset.Add(Db.CreateParameterDb("@Max",_TestValidate.Max)); prset.Add(Db.CreateParameterDb("@Item",_TestValidate.Item)); prset.Add(Db.CreateParameterDb("@CreateItme",_TestValidate.CreateItme));

object output = Db.FbExecuteScalar(sql, prset);return output;  }

public void Update() {
var prset = new List<IDataParameter>();
 prset.Add(Db.CreateParameterDb("@Id",_TestValidate.Id)); prset.Add(Db.CreateParameterDb("@Name",_TestValidate.Name)); prset.Add(Db.CreateParameterDb("@NickName",_TestValidate.NickName)); prset.Add(Db.CreateParameterDb("@Max",_TestValidate.Max)); prset.Add(Db.CreateParameterDb("@Item",_TestValidate.Item)); prset.Add(Db.CreateParameterDb("@CreateItme",_TestValidate.CreateItme));
var sql = @"UPDATE   TestValidate SET  Name=@Name,NickName=@NickName,Max=@Max,Item=@Item,CreateItme=@CreateItme where Id = @Id";

int output = Db.FbExecuteNonQuery(sql, prset);
if (output != 1){
 throw new System.Exception("Update" + this.ToString());}   }

public void Delete() {
var prset = new List<IDataParameter>();
 prset.Add(Db.CreateParameterDb("@Id",_TestValidate.Id));
var sql =@"DELETE FROM TestValidate where Id=@Id";

int output = Db.FbExecuteNonQuery(sql, prset);
if (output != 1){
 throw new System.Exception("Delete" + this.ToString());}   }

private List<TestValidate> DataSetToList(DataSet ds) 
{
 EnumerableRowCollection<TestValidate> q = (from temp in ds.Tables[0].AsEnumerable()
 select new TestValidate
{
RecordCount = temp.Field<Int32>("RecordCount"),Id= temp.Field<Int32?>("Id"), 
 Name= temp.Field<String>("Name"), 
 NickName= temp.Field<String>("NickName"), 
 Max= temp.Field<String>("Max"), 
 Item= temp.Field<Int32?>("Item"), 
 CreateItme= temp.Field<DateTime?>("CreateItme"), 
  });
  return q.ToList();
}
   public Boolean UpdateColumn(string id, string column,string value) 
        { 
            var prset = new List<IDataParameter>(); 
            prset.Add(Db.CreateParameterDb("@Id", id)); 
prset.Add(Db.CreateParameterDb("@Column", column));
            prset.Add(Db.CreateParameterDb("@Data", value)); 
   var sql = @"Sp_GetTestValidate_UpdateColumn";
            int output = Db.FbExecuteNonQuery(sql, prset, CommandType.StoredProcedure); 
            if (output == 1) 
            { 
                return true; 
            } 
 
            return false;   
        } 
 public List<string> GetKeyWordsAllColumn(string Keyword) 
    { 
        
        string sql = "Sp_GetTestValidate_Autocomplete"; 
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
          
 
  string sql = "SELECT  " + column + " FROM TestValidate where lower(" + column + ") like '" + keyword.ToLower() + "%'   group by " + column + " order by count(*) desc;"; 
         
         
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
            if ( _TestValidate.Id!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (Id='{0}') )", _TestValidate.Id); 
            } 
            if ( _TestValidate.Name!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (Name='{0}') )", _TestValidate.Name); 
            } 
            if ( _TestValidate.NickName!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (NickName='{0}') )", _TestValidate.NickName); 
            } 
            if ( _TestValidate.Max!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (Max='{0}') )", _TestValidate.Max); 
            } 
            if ( _TestValidate.Item!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (Item='{0}') )", _TestValidate.Item); 
            } 
            if ( _TestValidate.CreateItme!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (CreateItme='{0}') )", _TestValidate.CreateItme); 
            } 
return sql;
}
      public List<IDataParameter> GetParameter(int pageIndex, int PageSize)
        {
            var sqlStorePamameters = new List<IDataParameter>();
            sqlStorePamameters.Add(Db.CreateParameterDb("@PageIndex", pageIndex));
            sqlStorePamameters.Add(Db.CreateParameterDb("@PageSize", PageSize));
if (_TestValidate.Id != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@Id", _TestValidate.Id));

            }
if (_TestValidate.Name != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@Name", _TestValidate.Name));

            }
if (_TestValidate.NickName != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@NickName", _TestValidate.NickName));

            }
if (_TestValidate.Max != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@Max", _TestValidate.Max));

            }
if (_TestValidate.Item != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@Item", _TestValidate.Item));

            }
if (_TestValidate.CreateItme != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@CreateItme", _TestValidate.CreateItme));

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
