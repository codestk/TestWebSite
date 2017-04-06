using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
public class  MPO_PRODUCT_LINEDb: DataAccess
{
public string _SortDirection { get; set; }
public string _SortExpression { get; set; }
  public MPO_PRODUCT_LINE _MPO_PRODUCT_LINE;
public const string DataKey = "PR_PRODUCT_LINE";
public const string DataText = "PRODUCT_LINE_DEC";
public const string DataValue = "PR_PRODUCT_LINE";
public List<SelectInputProperties> Select()
 { string sql = "SELECT PR_PRODUCT_LINE,PRODUCT_LINE_DEC,0 AS RecordCount FROM MPO_PRODUCT_LINE";
 DataSet ds = Db.GetDataSet(sql);  
  return SelectInputProperties.DataSetToList(ds);} 
public MPO_PRODUCT_LINE Select(string PR_PRODUCT_LINE) 
{ 
 string sql = "SELECT PR_PRODUCT_LINE,PRODUCT_LINE_DEC,0 AS RecordCount FROM MPO_PRODUCT_LINE where PR_PRODUCT_LINE = @PR_PRODUCT_LINE; "; 
  var prset = new List<IDataParameter>();
  prset.Add(Db.CreateParameterDb("@PR_PRODUCT_LINE", PR_PRODUCT_LINE));
  DataSet ds = Db.GetDataSet(sql,prset);
return DataSetToList(ds).FirstOrDefault(); 
}public List<MPO_PRODUCT_LINE> GetWithFilter(bool sortAscending, string sortExpression){
throw new Exception("Not implement");
string sql = "SELECT * FROM MPO_PRODUCT_LINE "; 
sql += string.Format("  where ((''='{0}')or(PR_PRODUCT_LINE='{0}'))", _MPO_PRODUCT_LINE.PR_PRODUCT_LINE);
sql += string.Format("  and ((''='{0}')or(PRODUCT_LINE_DEC='{0}'))", _MPO_PRODUCT_LINE.PRODUCT_LINE_DEC);
  if (sortExpression == null){
sql += string.Format(" order by PR_PRODUCT_LINE ", sortExpression);}
else
{
}

DataSet ds = Db.GetDataSet(sql);return DataSetToList(ds);}
  public List< MPO_PRODUCT_LINE> GetPageWise(int pageIndex, int PageSize, string wordFullText = "") 
    { 
        string sql = ""; 
 
        //Set @Command = 'insert into  #Results   SELECT ROW_NUMBER() OVER (ORDER BY [EM_ID] desc )AS RowNumber ,*  FROM [ MPO_PRODUCT_LINE]' + @CommandFilter; 
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
        sql = string.Format("SELECT  {4},PR_PRODUCT_LINE,PRODUCT_LINE_DEC,  (SELECT count(*) FROM  MPO_PRODUCT_LINE  {1}) as RecordCount FROM  MPO_PRODUCT_LINE A {1} {0} ROWS {2} TO {3}; ", sortCommnad, whereCommnad, startRow, toRow, Get_row_number_command()); 
 
        DataSet ds = Db.GetDataSet(sql); 
        return DataSetToList(ds); 
    }
public object Insert() {
var prset = new List<IDataParameter>();var sql = "INSERT INTO MPO_PRODUCT_LINE(PR_PRODUCT_LINE,PRODUCT_LINE_DEC) VALUES (@PR_PRODUCT_LINE,@PRODUCT_LINE_DEC) returning PR_PRODUCT_LINE";

 prset.Add(Db.CreateParameterDb("@PR_PRODUCT_LINE",_MPO_PRODUCT_LINE.PR_PRODUCT_LINE));
 prset.Add(Db.CreateParameterDb("@PRODUCT_LINE_DEC",_MPO_PRODUCT_LINE.PRODUCT_LINE_DEC));


object output = Db.FbExecuteScalar(sql, prset);return output;  }

public void Update() {
var prset = new List<IDataParameter>();
 prset.Add(Db.CreateParameterDb("@PR_PRODUCT_LINE",_MPO_PRODUCT_LINE.PR_PRODUCT_LINE)); prset.Add(Db.CreateParameterDb("@PRODUCT_LINE_DEC",_MPO_PRODUCT_LINE.PRODUCT_LINE_DEC));
var sql = @"UPDATE   MPO_PRODUCT_LINE SET  PRODUCT_LINE_DEC=@PRODUCT_LINE_DEC where PR_PRODUCT_LINE = @PR_PRODUCT_LINE";

int output = Db.FbExecuteNonQuery(sql, prset);
if (output != 1){
 throw new System.Exception("Update" + this.ToString());}   }

public void Delete() {
var prset = new List<IDataParameter>();
 prset.Add(Db.CreateParameterDb("@PR_PRODUCT_LINE",_MPO_PRODUCT_LINE.PR_PRODUCT_LINE));
var sql =@"DELETE FROM MPO_PRODUCT_LINE where PR_PRODUCT_LINE=@PR_PRODUCT_LINE";

int output = Db.FbExecuteNonQuery(sql, prset);
if (output != 1){
 throw new System.Exception("Delete" + this.ToString());}   }

private List<MPO_PRODUCT_LINE> DataSetToList(DataSet ds) 
{
 EnumerableRowCollection<MPO_PRODUCT_LINE> q = (from temp in ds.Tables[0].AsEnumerable()
 select new MPO_PRODUCT_LINE
{
RecordCount = temp.Field<Int32>("RecordCount"),PR_PRODUCT_LINE= temp.Field<String>("PR_PRODUCT_LINE"), 
 PRODUCT_LINE_DEC= temp.Field<String>("PRODUCT_LINE_DEC"), 
  });
  return q.ToList();
}
   public Boolean UpdateColumn(string id, string column,string value) 
        { 
            var prset = new List<IDataParameter>(); 
            prset.Add(Db.CreateParameterDb("@PR_PRODUCT_LINE", id)); 
            prset.Add(Db.CreateParameterDb("@Data", value)); 
             var sql = @"UPDATE   MPO_PRODUCT_LINE SET "+column+ "=@Data where PR_PRODUCT_LINE = @PR_PRODUCT_LINE"; 
 
            int output = Db.FbExecuteNonQuery(sql, prset); 
            if (output == 1) 
            { 
                return true; 
            } 
 
            return false;   
        } 
 public List<string> GetKeyWordsAllColumn(string Keyword) 
    { 
        
        string sql = "Sp_GetMPO_PRODUCT_LINE_Autocomplete"; 
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
          
 
  string sql = "SELECT  " + column + " FROM MPO_PRODUCT_LINE where lower(" + column + ") like '" + keyword.ToLower() + "%'   group by " + column + " order by count(*) desc;"; 
         
         
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
 
            //Set @Command = 'insert into  #Results   SELECT ROW_NUMBER() OVER (ORDER BY [EM_ID] desc )AS RowNumber ,*  FROM [MPO_PRODUCT_LINE]' + @CommandFilter; 
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
            sql = string.Format("insert into  #Results   SELECT ROW_NUMBER() OVER (  {0} )AS RowNumber ,*  FROM [MPO_PRODUCT_LINE] ", sortCommnad); 
 
            sql += GenWhereformProperties(); 
            return sql; 
        }
public string GenWhereformProperties() 
{
  String sql="";
   sql += "WHERE (1=1) "; 
            if (( _MPO_PRODUCT_LINE.PR_PRODUCT_LINE!= null) )
            { 
                sql += string.Format(" AND ((''='{0}') or (PR_PRODUCT_LINE='{0}') )", _MPO_PRODUCT_LINE.PR_PRODUCT_LINE); 
            } 
            if (( _MPO_PRODUCT_LINE.PRODUCT_LINE_DEC!= null) )
            { 
                sql += string.Format(" AND ((''='{0}') or (PRODUCT_LINE_DEC='{0}') )", _MPO_PRODUCT_LINE.PRODUCT_LINE_DEC); 
            } 
return sql;
}
    public string Get_row_number_command() 
    { 
        return "rdb$get_context('USER_TRANSACTION', 'row#') as row_number,rdb$set_context('USER_TRANSACTION', 'row#', coalesce(cast(rdb$get_context('USER_TRANSACTION', 'row#') as integer), 0) + 1)"; 
    }
}

