using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
public class  STK_USER_FLAGDb: DataAccess
{
public string _SortDirection { get; set; }
public string _SortExpression { get; set; }
  public STK_USER_FLAG _STK_USER_FLAG;
public const string DataKey = "EM_FLAG";
public const string DataText = "EM_DES";
public const string DataValue = "EM_FLAG";
public List<SelectInputProperties> Select()
 { string sql = "SELECT EM_FLAG,EM_DES,0 AS RecordCount FROM STK_USER_FLAG";
 DataSet ds = Db.GetDataSet(sql);  
  return SelectInputProperties.DataSetToList(ds);} 
public STK_USER_FLAG Select(string EM_FLAG) 
{ 
 string sql = "SELECT EM_FLAG,EM_DES,0 AS RecordCount FROM STK_USER_FLAG where EM_FLAG = @EM_FLAG; "; 
  var prset = new List<IDataParameter>();
  prset.Add(Db.CreateParameterDb("@EM_FLAG", EM_FLAG));
  DataSet ds = Db.GetDataSet(sql,prset);
return DataSetToList(ds).FirstOrDefault(); 
}public List<STK_USER_FLAG> GetWithFilter(bool sortAscending, string sortExpression){
throw new Exception("Not implement");
string sql = "SELECT * FROM STK_USER_FLAG "; 
sql += string.Format("  where ((''='{0}')or(EM_FLAG='{0}'))", _STK_USER_FLAG.EM_FLAG);
sql += string.Format("  and ((''='{0}')or(EM_DES='{0}'))", _STK_USER_FLAG.EM_DES);
  if (sortExpression == null){
sql += string.Format(" order by EM_FLAG ", sortExpression);}
else
{
}

DataSet ds = Db.GetDataSet(sql);return DataSetToList(ds);}
  public List< STK_USER_FLAG> GetPageWise(int pageIndex, int PageSize, string wordFullText = "") 
    { 
        string sql = ""; 
 
        //Set @Command = 'insert into  #Results   SELECT ROW_NUMBER() OVER (ORDER BY [EM_ID] desc )AS RowNumber ,*  FROM [ STK_USER_FLAG]' + @CommandFilter; 
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
        sql = string.Format("SELECT  {4},EM_FLAG,EM_DES,  (SELECT count(*) FROM  STK_USER_FLAG  {1}) as RecordCount FROM  STK_USER_FLAG A {1} {0} ROWS {2} TO {3}; ", sortCommnad, whereCommnad, startRow, toRow, Get_row_number_command()); 
 
        DataSet ds = Db.GetDataSet(sql); 
        return DataSetToList(ds); 
    }
public object Insert() {
var prset = new List<IDataParameter>();var sql = "INSERT INTO STK_USER_FLAG(EM_FLAG,EM_DES) VALUES (@EM_FLAG,@EM_DES) returning EM_FLAG";

 prset.Add(Db.CreateParameterDb("@EM_FLAG",_STK_USER_FLAG.EM_FLAG));
 prset.Add(Db.CreateParameterDb("@EM_DES",_STK_USER_FLAG.EM_DES));


object output = Db.FbExecuteScalar(sql, prset);return output;  }

public void Update() {
var prset = new List<IDataParameter>();
 prset.Add(Db.CreateParameterDb("@EM_FLAG",_STK_USER_FLAG.EM_FLAG)); prset.Add(Db.CreateParameterDb("@EM_DES",_STK_USER_FLAG.EM_DES));
var sql = @"UPDATE   STK_USER_FLAG SET  EM_DES=@EM_DES where EM_FLAG = @EM_FLAG";

int output = Db.FbExecuteNonQuery(sql, prset);
if (output != 1){
 throw new System.Exception("Update" + this.ToString());}   }

public void Delete() {
var prset = new List<IDataParameter>();
 prset.Add(Db.CreateParameterDb("@EM_FLAG",_STK_USER_FLAG.EM_FLAG));
var sql =@"DELETE FROM STK_USER_FLAG where EM_FLAG=@EM_FLAG";

int output = Db.FbExecuteNonQuery(sql, prset);
if (output != 1){
 throw new System.Exception("Delete" + this.ToString());}   }

private List<STK_USER_FLAG> DataSetToList(DataSet ds) 
{
 EnumerableRowCollection<STK_USER_FLAG> q = (from temp in ds.Tables[0].AsEnumerable()
 select new STK_USER_FLAG
{
RecordCount = temp.Field<Int32>("RecordCount"),EM_FLAG= temp.Field<String>("EM_FLAG"), 
 EM_DES= temp.Field<String>("EM_DES"), 
  });
  return q.ToList();
}
   public Boolean UpdateColumn(string id, string column,string value) 
        { 
            var prset = new List<IDataParameter>(); 
            prset.Add(Db.CreateParameterDb("@EM_FLAG", id)); 
            prset.Add(Db.CreateParameterDb("@Data", value)); 
             var sql = @"UPDATE   STK_USER_FLAG SET "+column+ "=@Data where EM_FLAG = @EM_FLAG"; 
 
            int output = Db.FbExecuteNonQuery(sql, prset); 
            if (output == 1) 
            { 
                return true; 
            } 
 
            return false;   
        } 
 public List<string> GetKeyWordsAllColumn(string Keyword) 
    { 
        
        string sql = "Sp_GetSTK_USER_FLAG_Autocomplete"; 
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
          
 
  string sql = "SELECT  " + column + " FROM STK_USER_FLAG where lower(" + column + ") like '" + keyword.ToLower() + "%'   group by " + column + " order by count(*) desc;"; 
         
         
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
 
            //Set @Command = 'insert into  #Results   SELECT ROW_NUMBER() OVER (ORDER BY [EM_ID] desc )AS RowNumber ,*  FROM [STK_USER_FLAG]' + @CommandFilter; 
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
            sql = string.Format("insert into  #Results   SELECT ROW_NUMBER() OVER (  {0} )AS RowNumber ,*  FROM [STK_USER_FLAG] ", sortCommnad); 
 
            sql += GenWhereformProperties(); 
            return sql; 
        }
public string GenWhereformProperties() 
{
  String sql="";
   sql += "WHERE (1=1) "; 
            if (( _STK_USER_FLAG.EM_FLAG!= null) )
            { 
                sql += string.Format(" AND ((''='{0}') or (EM_FLAG='{0}') )", _STK_USER_FLAG.EM_FLAG); 
            } 
            if (( _STK_USER_FLAG.EM_DES!= null) )
            { 
                sql += string.Format(" AND ((''='{0}') or (EM_DES='{0}') )", _STK_USER_FLAG.EM_DES); 
            } 
return sql;
}
    public string Get_row_number_command() 
    { 
        return "rdb$get_context('USER_TRANSACTION', 'row#') as row_number,rdb$set_context('USER_TRANSACTION', 'row#', coalesce(cast(rdb$get_context('USER_TRANSACTION', 'row#') as integer), 0) + 1)"; 
    }
}

