using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
public class  STK_USERDb: DataAccess
{
public string _SortDirection { get; set; }
public string _SortExpression { get; set; }
  public STK_USER _STK_USER;
public const string DataKey = "EM_ID";
public const string DataText = "EM_PASS";
public const string DataValue = "EM_ID";
public List<SelectInputProperties> Select()
 { string sql = "SELECT EM_ID,EM_PASS,EM_NAME,EM_SURNAME,EM_TEL,EM_ADDRESS,EM_FLAG,EM_ROLE_ADMIN,EM_ROLE_USER,0 AS RecordCount FROM STK_USER";
 DataSet ds = Db.GetDataSet(sql);  
  return SelectInputProperties.DataSetToList(ds);} 
public STK_USER Select(string EM_ID) 
{ 
 string sql = "SELECT EM_ID,EM_PASS,EM_NAME,EM_SURNAME,EM_TEL,EM_ADDRESS,EM_FLAG,EM_ROLE_ADMIN,EM_ROLE_USER,0 AS RecordCount FROM STK_USER where EM_ID = @EM_ID; "; 
  var prset = new List<IDataParameter>();
  prset.Add(Db.CreateParameterDb("@EM_ID", EM_ID));
  DataSet ds = Db.GetDataSet(sql,prset);
return DataSetToList(ds).FirstOrDefault(); 
}public List<STK_USER> GetWithFilter(bool sortAscending, string sortExpression){
throw new Exception("Not implement");
string sql = "SELECT * FROM STK_USER "; 
sql += string.Format("  where ((''='{0}')or(EM_ID='{0}'))", _STK_USER.EM_ID);
sql += string.Format("  and ((''='{0}')or(EM_PASS='{0}'))", _STK_USER.EM_PASS);
sql += string.Format("  and ((''='{0}')or(EM_NAME='{0}'))", _STK_USER.EM_NAME);
sql += string.Format("  and ((''='{0}')or(EM_SURNAME='{0}'))", _STK_USER.EM_SURNAME);
sql += string.Format("  and ((''='{0}')or(EM_TEL='{0}'))", _STK_USER.EM_TEL);
sql += string.Format("  and ((''='{0}')or(EM_ADDRESS='{0}'))", _STK_USER.EM_ADDRESS);
sql += string.Format("  and ((''='{0}')or(EM_FLAG='{0}'))", _STK_USER.EM_FLAG);
sql += string.Format("  and ((''='{0}')or(EM_ROLE_ADMIN='{0}'))", _STK_USER.EM_ROLE_ADMIN);
sql += string.Format("  and ((''='{0}')or(EM_ROLE_USER='{0}'))", _STK_USER.EM_ROLE_USER);
  if (sortExpression == null){
sql += string.Format(" order by EM_ID ", sortExpression);}
else
{
}

DataSet ds = Db.GetDataSet(sql);return DataSetToList(ds);}
  public List< STK_USER> GetPageWise(int pageIndex, int PageSize, string wordFullText = "") 
    { 
        string sql = ""; 
 
        //Set @Command = 'insert into  #Results   SELECT ROW_NUMBER() OVER (ORDER BY [EM_ID] desc )AS RowNumber ,*  FROM [ STK_USER]' + @CommandFilter; 
        string ColumnSort = ""; 
        if (_SortExpression == null) 
        { 
            ColumnSort = DataKey; 
        } 
        else 
        { 
            ColumnSort = _SortExpression; 
        } 
        string sortCommnad = GenSort(_SortDirection, ColumnSort); 
 
// Non implemnet full text Search
        string whereCommnad = GenWhereformProperties(); 
 
        int startRow = ((pageIndex - 1) * PageSize) + 1; 
        int toRow = (startRow + PageSize) - 1; 
        sql = string.Format("SELECT  {4},EM_ID,EM_PASS,EM_NAME,EM_SURNAME,EM_TEL,EM_ADDRESS,EM_FLAG,EM_ROLE_ADMIN,EM_ROLE_USER,  (SELECT count(*) FROM  STK_USER  {1}) as RecordCount FROM  STK_USER A {1} {0} ROWS {2} TO {3}; ", sortCommnad, whereCommnad, startRow, toRow, Get_row_number_command()); 
 
        DataSet ds = Db.GetDataSet(sql); 
        return DataSetToList(ds); 
    }
public object Insert() {
var prset = new List<IDataParameter>();var sql = "INSERT INTO STK_USER(EM_ID,EM_PASS,EM_NAME,EM_SURNAME,EM_TEL,EM_ADDRESS,EM_FLAG,EM_ROLE_ADMIN,EM_ROLE_USER) VALUES (@EM_ID,@EM_PASS,@EM_NAME,@EM_SURNAME,@EM_TEL,@EM_ADDRESS,@EM_FLAG,@EM_ROLE_ADMIN,@EM_ROLE_USER) returning EM_ID";

 prset.Add(Db.CreateParameterDb("@EM_ID",_STK_USER.EM_ID));
 prset.Add(Db.CreateParameterDb("@EM_PASS",_STK_USER.EM_PASS));
 prset.Add(Db.CreateParameterDb("@EM_NAME",_STK_USER.EM_NAME));
 prset.Add(Db.CreateParameterDb("@EM_SURNAME",_STK_USER.EM_SURNAME));
 prset.Add(Db.CreateParameterDb("@EM_TEL",_STK_USER.EM_TEL));
 prset.Add(Db.CreateParameterDb("@EM_ADDRESS",_STK_USER.EM_ADDRESS));
 prset.Add(Db.CreateParameterDb("@EM_FLAG",_STK_USER.EM_FLAG));
 prset.Add(Db.CreateParameterDb("@EM_ROLE_ADMIN",_STK_USER.EM_ROLE_ADMIN));
 prset.Add(Db.CreateParameterDb("@EM_ROLE_USER",_STK_USER.EM_ROLE_USER));


object output = Db.FbExecuteScalar(sql, prset);return output;  }

public void Update() {
var prset = new List<IDataParameter>();
 prset.Add(Db.CreateParameterDb("@EM_ID",_STK_USER.EM_ID)); prset.Add(Db.CreateParameterDb("@EM_PASS",_STK_USER.EM_PASS)); prset.Add(Db.CreateParameterDb("@EM_NAME",_STK_USER.EM_NAME)); prset.Add(Db.CreateParameterDb("@EM_SURNAME",_STK_USER.EM_SURNAME)); prset.Add(Db.CreateParameterDb("@EM_TEL",_STK_USER.EM_TEL)); prset.Add(Db.CreateParameterDb("@EM_ADDRESS",_STK_USER.EM_ADDRESS)); prset.Add(Db.CreateParameterDb("@EM_FLAG",_STK_USER.EM_FLAG)); prset.Add(Db.CreateParameterDb("@EM_ROLE_ADMIN",_STK_USER.EM_ROLE_ADMIN)); prset.Add(Db.CreateParameterDb("@EM_ROLE_USER",_STK_USER.EM_ROLE_USER));
var sql = @"UPDATE   STK_USER SET  EM_PASS=@EM_PASS,EM_NAME=@EM_NAME,EM_SURNAME=@EM_SURNAME,EM_TEL=@EM_TEL,EM_ADDRESS=@EM_ADDRESS,EM_FLAG=@EM_FLAG,EM_ROLE_ADMIN=@EM_ROLE_ADMIN,EM_ROLE_USER=@EM_ROLE_USER where EM_ID = @EM_ID";

int output = Db.FbExecuteNonQuery(sql, prset);
if (output != 1){
 throw new System.Exception("Update" + this.ToString());}   }

public void Delete() {
var prset = new List<IDataParameter>();
 prset.Add(Db.CreateParameterDb("@EM_ID",_STK_USER.EM_ID));
var sql =@"DELETE FROM STK_USER where EM_ID=@EM_ID";

int output = Db.FbExecuteNonQuery(sql, prset);
if (output != 1){
 throw new System.Exception("Delete" + this.ToString());}   }

private List<STK_USER> DataSetToList(DataSet ds) 
{
 EnumerableRowCollection<STK_USER> q = (from temp in ds.Tables[0].AsEnumerable()
 select new STK_USER
{
RecordCount = temp.Field<Int32>("RecordCount"),EM_ID= temp.Field<String>("EM_ID"), 
 EM_PASS= temp.Field<String>("EM_PASS"), 
 EM_NAME= temp.Field<String>("EM_NAME"), 
 EM_SURNAME= temp.Field<String>("EM_SURNAME"), 
 EM_TEL= temp.Field<String>("EM_TEL"), 
 EM_ADDRESS= temp.Field<String>("EM_ADDRESS"), 
 EM_FLAG= temp.Field<String>("EM_FLAG"), 
 EM_ROLE_ADMIN= temp.Field<Int16?>("EM_ROLE_ADMIN"), 
 EM_ROLE_USER= temp.Field<Int16?>("EM_ROLE_USER"), 
  });
  return q.ToList();
}
   public Boolean UpdateColumn(string id, string column,string value) 
        { 
            var prset = new List<IDataParameter>(); 
            prset.Add(Db.CreateParameterDb("@EM_ID", id)); 
            prset.Add(Db.CreateParameterDb("@Data", value)); 
             var sql = @"UPDATE   STK_USER SET "+column+ "=@Data where EM_ID = @EM_ID"; 
 
            int output = Db.FbExecuteNonQuery(sql, prset); 
            if (output == 1) 
            { 
                return true; 
            } 
 
            return false;   
        } 
 public List<string> GetKeyWordsAllColumn(string Keyword) 
    { 
        
        string sql = "Sp_GetSTK_USER_Autocomplete"; 
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
          
 
  string sql = "SELECT  " + column + " FROM STK_USER where lower(" + column + ") like '" + keyword.ToLower() + "%'   group by " + column + " order by count(*) desc;"; 
         
         
  List<string> dataArray = new List<string>(); 
 
 
  DataSet ds = Db.GetDataSet(sql); 
  foreach (DataRow row in ds.Tables[0].Rows) 
        { 
            dataArray.Add(row[0].ToString()); 
        } 
 
        return dataArray; 
    } 
  public string GenSql() 
        { 
            string sql = ""; 
 
            //Set @Command = 'insert into  #Results   SELECT ROW_NUMBER() OVER (ORDER BY [EM_ID] desc )AS RowNumber ,*  FROM [STK_USER]' + @CommandFilter; 
            string ColumnSort = ""; 
            if (_SortExpression == null) 
            { 
                ColumnSort = DataKey; 
            } 
            else 
            { 
                ColumnSort = _SortExpression; 
            } 
            string sortCommnad = GenSort(_SortDirection, ColumnSort); 
            sql = string.Format("insert into  #Results   SELECT ROW_NUMBER() OVER (  {0} )AS RowNumber ,*  FROM [STK_USER] ", sortCommnad); 
 
            sql += GenWhereformProperties(); 
            return sql; 
        }
public string GenWhereformProperties() 
{
  String sql="";
   sql += "WHERE (1=1) "; 
            if (( _STK_USER.EM_ID!= null) )
            { 
                sql += string.Format(" AND ((''='{0}') or (EM_ID='{0}') )", _STK_USER.EM_ID); 
            } 
            if (( _STK_USER.EM_PASS!= null) )
            { 
                sql += string.Format(" AND ((''='{0}') or (EM_PASS='{0}') )", _STK_USER.EM_PASS); 
            } 
            if (( _STK_USER.EM_NAME!= null) )
            { 
                sql += string.Format(" AND ((''='{0}') or (EM_NAME='{0}') )", _STK_USER.EM_NAME); 
            } 
            if (( _STK_USER.EM_SURNAME!= null) )
            { 
                sql += string.Format(" AND ((''='{0}') or (EM_SURNAME='{0}') )", _STK_USER.EM_SURNAME); 
            } 
            if (( _STK_USER.EM_TEL!= null) )
            { 
                sql += string.Format(" AND ((''='{0}') or (EM_TEL='{0}') )", _STK_USER.EM_TEL); 
            } 
            if (( _STK_USER.EM_ADDRESS!= null) )
            { 
                sql += string.Format(" AND ((''='{0}') or (EM_ADDRESS='{0}') )", _STK_USER.EM_ADDRESS); 
            } 
            if (( _STK_USER.EM_FLAG!= null) )
            { 
                sql += string.Format(" AND ((''='{0}') or (EM_FLAG='{0}') )", _STK_USER.EM_FLAG); 
            } 
            if (( _STK_USER.EM_ROLE_ADMIN!= null) )
            { 
                sql += string.Format(" AND ((''='{0}') or (EM_ROLE_ADMIN='{0}') )", _STK_USER.EM_ROLE_ADMIN); 
            } 
            if (( _STK_USER.EM_ROLE_USER!= null) )
            { 
                sql += string.Format(" AND ((''='{0}') or (EM_ROLE_USER='{0}') )", _STK_USER.EM_ROLE_USER); 
            } 
return sql;
}
    public string Get_row_number_command() 
    { 
        return "rdb$get_context('USER_TRANSACTION', 'row#') as row_number,rdb$set_context('USER_TRANSACTION', 'row#', coalesce(cast(rdb$get_context('USER_TRANSACTION', 'row#') as integer), 0) + 1)"; 
    }
}

