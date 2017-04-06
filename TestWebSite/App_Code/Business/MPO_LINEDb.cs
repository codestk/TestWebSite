using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
public class  MPO_LINEDb: DataAccess
{
public string _SortDirection { get; set; }
public string _SortExpression { get; set; }
  public MPO_LINE _MPO_LINE;
public const string DataKey = "PR_LINE";
public const string DataText = "LINE_DEC";
public const string DataValue = "PR_LINE";
public List<SelectInputProperties> Select()
 { string sql = "SELECT PR_LINE,LINE_DEC,0 AS RecordCount FROM MPO_LINE";
 DataSet ds = Db.GetDataSet(sql);  
  return SelectInputProperties.DataSetToList(ds);} 
public MPO_LINE Select(string PR_LINE) 
{ 
 string sql = "SELECT PR_LINE,LINE_DEC,0 AS RecordCount FROM MPO_LINE where PR_LINE = @PR_LINE; "; 
  var prset = new List<IDataParameter>();
  prset.Add(Db.CreateParameterDb("@PR_LINE", PR_LINE));
  DataSet ds = Db.GetDataSet(sql,prset);
return DataSetToList(ds).FirstOrDefault(); 
}public List<MPO_LINE> GetWithFilter(bool sortAscending, string sortExpression){
throw new Exception("Not implement");
string sql = "SELECT * FROM MPO_LINE "; 
sql += string.Format("  where ((''='{0}')or(PR_LINE='{0}'))", _MPO_LINE.PR_LINE);
sql += string.Format("  and ((''='{0}')or(LINE_DEC='{0}'))", _MPO_LINE.LINE_DEC);
  if (sortExpression == null){
sql += string.Format(" order by PR_LINE ", sortExpression);}
else
{
}

DataSet ds = Db.GetDataSet(sql);return DataSetToList(ds);}
  public List< MPO_LINE> GetPageWise(int pageIndex, int PageSize, string wordFullText = "") 
    { 
        string sql = ""; 
 
        //Set @Command = 'insert into  #Results   SELECT ROW_NUMBER() OVER (ORDER BY [EM_ID] desc )AS RowNumber ,*  FROM [ MPO_LINE]' + @CommandFilter; 
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
        sql = string.Format("SELECT  {4},PR_LINE,LINE_DEC,  (SELECT count(*) FROM  MPO_LINE  {1}) as RecordCount FROM  MPO_LINE A {1} {0} ROWS {2} TO {3}; ", sortCommnad, whereCommnad, startRow, toRow, Get_row_number_command()); 
 
        DataSet ds = Db.GetDataSet(sql); 
        return DataSetToList(ds); 
    }
public object Insert() {
var prset = new List<IDataParameter>();var sql = "INSERT INTO MPO_LINE(PR_LINE,LINE_DEC) VALUES (@PR_LINE,@LINE_DEC) returning PR_LINE";

 prset.Add(Db.CreateParameterDb("@PR_LINE",_MPO_LINE.PR_LINE));
 prset.Add(Db.CreateParameterDb("@LINE_DEC",_MPO_LINE.LINE_DEC));


object output = Db.FbExecuteScalar(sql, prset);return output;  }

public void Update() {
var prset = new List<IDataParameter>();
 prset.Add(Db.CreateParameterDb("@PR_LINE",_MPO_LINE.PR_LINE)); prset.Add(Db.CreateParameterDb("@LINE_DEC",_MPO_LINE.LINE_DEC));
var sql = @"UPDATE   MPO_LINE SET  LINE_DEC=@LINE_DEC where PR_LINE = @PR_LINE";

int output = Db.FbExecuteNonQuery(sql, prset);
if (output != 1){
 throw new System.Exception("Update" + this.ToString());}   }

public void Delete() {
var prset = new List<IDataParameter>();
 prset.Add(Db.CreateParameterDb("@PR_LINE",_MPO_LINE.PR_LINE));
var sql =@"DELETE FROM MPO_LINE where PR_LINE=@PR_LINE";

int output = Db.FbExecuteNonQuery(sql, prset);
if (output != 1){
 throw new System.Exception("Delete" + this.ToString());}   }

private List<MPO_LINE> DataSetToList(DataSet ds) 
{
 EnumerableRowCollection<MPO_LINE> q = (from temp in ds.Tables[0].AsEnumerable()
 select new MPO_LINE
{
RecordCount = temp.Field<Int32>("RecordCount"),PR_LINE= temp.Field<String>("PR_LINE"), 
 LINE_DEC= temp.Field<String>("LINE_DEC"), 
  });
  return q.ToList();
}
   public Boolean UpdateColumn(string id, string column,string value) 
        { 
            var prset = new List<IDataParameter>(); 
            prset.Add(Db.CreateParameterDb("@PR_LINE", id)); 
            prset.Add(Db.CreateParameterDb("@Data", value)); 
             var sql = @"UPDATE   MPO_LINE SET "+column+ "=@Data where PR_LINE = @PR_LINE"; 
 
            int output = Db.FbExecuteNonQuery(sql, prset); 
            if (output == 1) 
            { 
                return true; 
            } 
 
            return false;   
        } 
 public List<string> GetKeyWordsAllColumn(string Keyword) 
    { 
        
        string sql = "Sp_GetMPO_LINE_Autocomplete"; 
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
          
 
  string sql = "SELECT  " + column + " FROM MPO_LINE where lower(" + column + ") like '" + keyword.ToLower() + "%'   group by " + column + " order by count(*) desc;"; 
         
         
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
 
            //Set @Command = 'insert into  #Results   SELECT ROW_NUMBER() OVER (ORDER BY [EM_ID] desc )AS RowNumber ,*  FROM [MPO_LINE]' + @CommandFilter; 
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
            sql = string.Format("insert into  #Results   SELECT ROW_NUMBER() OVER (  {0} )AS RowNumber ,*  FROM [MPO_LINE] ", sortCommnad); 
 
            sql += GenWhereformProperties(); 
            return sql; 
        }
public string GenWhereformProperties() 
{
  String sql="";
   sql += "WHERE (1=1) "; 
            if (( _MPO_LINE.PR_LINE!= null) )
            { 
                sql += string.Format(" AND ((''='{0}') or (PR_LINE='{0}') )", _MPO_LINE.PR_LINE); 
            } 
            if (( _MPO_LINE.LINE_DEC!= null) )
            { 
                sql += string.Format(" AND ((''='{0}') or (LINE_DEC='{0}') )", _MPO_LINE.LINE_DEC); 
            } 
return sql;
}
    public string Get_row_number_command() 
    { 
        return "rdb$get_context('USER_TRANSACTION', 'row#') as row_number,rdb$set_context('USER_TRANSACTION', 'row#', coalesce(cast(rdb$get_context('USER_TRANSACTION', 'row#') as integer), 0) + 1)"; 
    }
}

