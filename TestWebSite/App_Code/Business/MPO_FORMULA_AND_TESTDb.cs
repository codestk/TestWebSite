using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
public class  MPO_FORMULA_AND_TESTDb: DataAccess
{
public string _SortDirection { get; set; }
public string _SortExpression { get; set; }
  public MPO_FORMULA_AND_TEST _MPO_FORMULA_AND_TEST;
public const string DataKey = "PR_FORMULA_AND_TEST";
public const string DataText = "FORMULA_AND_TEST_DEC";
public const string DataValue = "PR_FORMULA_AND_TEST";
public List<SelectInputProperties> Select()
 { string sql = "SELECT PR_FORMULA_AND_TEST,FORMULA_AND_TEST_DEC,0 AS RecordCount FROM MPO_FORMULA_AND_TEST";
 DataSet ds = Db.GetDataSet(sql);  
  return SelectInputProperties.DataSetToList(ds);} 
public MPO_FORMULA_AND_TEST Select(string PR_FORMULA_AND_TEST) 
{ 
 string sql = "SELECT PR_FORMULA_AND_TEST,FORMULA_AND_TEST_DEC,0 AS RecordCount FROM MPO_FORMULA_AND_TEST where PR_FORMULA_AND_TEST = @PR_FORMULA_AND_TEST; "; 
  var prset = new List<IDataParameter>();
  prset.Add(Db.CreateParameterDb("@PR_FORMULA_AND_TEST", PR_FORMULA_AND_TEST));
  DataSet ds = Db.GetDataSet(sql,prset);
return DataSetToList(ds).FirstOrDefault(); 
}public List<MPO_FORMULA_AND_TEST> GetWithFilter(bool sortAscending, string sortExpression){
throw new Exception("Not implement");
string sql = "SELECT * FROM MPO_FORMULA_AND_TEST "; 
sql += string.Format("  where ((''='{0}')or(PR_FORMULA_AND_TEST='{0}'))", _MPO_FORMULA_AND_TEST.PR_FORMULA_AND_TEST);
sql += string.Format("  and ((''='{0}')or(FORMULA_AND_TEST_DEC='{0}'))", _MPO_FORMULA_AND_TEST.FORMULA_AND_TEST_DEC);
  if (sortExpression == null){
sql += string.Format(" order by PR_FORMULA_AND_TEST ", sortExpression);}
else
{
}

DataSet ds = Db.GetDataSet(sql);return DataSetToList(ds);}
  public List< MPO_FORMULA_AND_TEST> GetPageWise(int pageIndex, int PageSize, string wordFullText = "") 
    { 
        string sql = ""; 
 
        //Set @Command = 'insert into  #Results   SELECT ROW_NUMBER() OVER (ORDER BY [EM_ID] desc )AS RowNumber ,*  FROM [ MPO_FORMULA_AND_TEST]' + @CommandFilter; 
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
        sql = string.Format("SELECT  {4},PR_FORMULA_AND_TEST,FORMULA_AND_TEST_DEC,  (SELECT count(*) FROM  MPO_FORMULA_AND_TEST  {1}) as RecordCount FROM  MPO_FORMULA_AND_TEST A {1} {0} ROWS {2} TO {3}; ", sortCommnad, whereCommnad, startRow, toRow, Get_row_number_command()); 
 
        DataSet ds = Db.GetDataSet(sql); 
        return DataSetToList(ds); 
    }
public object Insert() {
var prset = new List<IDataParameter>();var sql = "INSERT INTO MPO_FORMULA_AND_TEST(PR_FORMULA_AND_TEST,FORMULA_AND_TEST_DEC) VALUES (@PR_FORMULA_AND_TEST,@FORMULA_AND_TEST_DEC) returning PR_FORMULA_AND_TEST";

 prset.Add(Db.CreateParameterDb("@PR_FORMULA_AND_TEST",_MPO_FORMULA_AND_TEST.PR_FORMULA_AND_TEST));
 prset.Add(Db.CreateParameterDb("@FORMULA_AND_TEST_DEC",_MPO_FORMULA_AND_TEST.FORMULA_AND_TEST_DEC));


object output = Db.FbExecuteScalar(sql, prset);return output;  }

public void Update() {
var prset = new List<IDataParameter>();
 prset.Add(Db.CreateParameterDb("@PR_FORMULA_AND_TEST",_MPO_FORMULA_AND_TEST.PR_FORMULA_AND_TEST)); prset.Add(Db.CreateParameterDb("@FORMULA_AND_TEST_DEC",_MPO_FORMULA_AND_TEST.FORMULA_AND_TEST_DEC));
var sql = @"UPDATE   MPO_FORMULA_AND_TEST SET  FORMULA_AND_TEST_DEC=@FORMULA_AND_TEST_DEC where PR_FORMULA_AND_TEST = @PR_FORMULA_AND_TEST";

int output = Db.FbExecuteNonQuery(sql, prset);
if (output != 1){
 throw new System.Exception("Update" + this.ToString());}   }

public void Delete() {
var prset = new List<IDataParameter>();
 prset.Add(Db.CreateParameterDb("@PR_FORMULA_AND_TEST",_MPO_FORMULA_AND_TEST.PR_FORMULA_AND_TEST));
var sql =@"DELETE FROM MPO_FORMULA_AND_TEST where PR_FORMULA_AND_TEST=@PR_FORMULA_AND_TEST";

int output = Db.FbExecuteNonQuery(sql, prset);
if (output != 1){
 throw new System.Exception("Delete" + this.ToString());}   }

private List<MPO_FORMULA_AND_TEST> DataSetToList(DataSet ds) 
{
 EnumerableRowCollection<MPO_FORMULA_AND_TEST> q = (from temp in ds.Tables[0].AsEnumerable()
 select new MPO_FORMULA_AND_TEST
{
RecordCount = temp.Field<Int32>("RecordCount"),PR_FORMULA_AND_TEST= temp.Field<String>("PR_FORMULA_AND_TEST"), 
 FORMULA_AND_TEST_DEC= temp.Field<String>("FORMULA_AND_TEST_DEC"), 
  });
  return q.ToList();
}
   public Boolean UpdateColumn(string id, string column,string value) 
        { 
            var prset = new List<IDataParameter>(); 
            prset.Add(Db.CreateParameterDb("@PR_FORMULA_AND_TEST", id)); 
            prset.Add(Db.CreateParameterDb("@Data", value)); 
             var sql = @"UPDATE   MPO_FORMULA_AND_TEST SET "+column+ "=@Data where PR_FORMULA_AND_TEST = @PR_FORMULA_AND_TEST"; 
 
            int output = Db.FbExecuteNonQuery(sql, prset); 
            if (output == 1) 
            { 
                return true; 
            } 
 
            return false;   
        } 
 public List<string> GetKeyWordsAllColumn(string Keyword) 
    { 
        
        string sql = "Sp_GetMPO_FORMULA_AND_TEST_Autocomplete"; 
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
          
 
  string sql = "SELECT  " + column + " FROM MPO_FORMULA_AND_TEST where lower(" + column + ") like '" + keyword.ToLower() + "%'   group by " + column + " order by count(*) desc;"; 
         
         
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
 
            //Set @Command = 'insert into  #Results   SELECT ROW_NUMBER() OVER (ORDER BY [EM_ID] desc )AS RowNumber ,*  FROM [MPO_FORMULA_AND_TEST]' + @CommandFilter; 
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
            sql = string.Format("insert into  #Results   SELECT ROW_NUMBER() OVER (  {0} )AS RowNumber ,*  FROM [MPO_FORMULA_AND_TEST] ", sortCommnad); 
 
            sql += GenWhereformProperties(); 
            return sql; 
        }
public string GenWhereformProperties() 
{
  String sql="";
   sql += "WHERE (1=1) "; 
            if (( _MPO_FORMULA_AND_TEST.PR_FORMULA_AND_TEST!= null) )
            { 
                sql += string.Format(" AND ((''='{0}') or (PR_FORMULA_AND_TEST='{0}') )", _MPO_FORMULA_AND_TEST.PR_FORMULA_AND_TEST); 
            } 
            if (( _MPO_FORMULA_AND_TEST.FORMULA_AND_TEST_DEC!= null) )
            { 
                sql += string.Format(" AND ((''='{0}') or (FORMULA_AND_TEST_DEC='{0}') )", _MPO_FORMULA_AND_TEST.FORMULA_AND_TEST_DEC); 
            } 
return sql;
}
    public string Get_row_number_command() 
    { 
        return "rdb$get_context('USER_TRANSACTION', 'row#') as row_number,rdb$set_context('USER_TRANSACTION', 'row#', coalesce(cast(rdb$get_context('USER_TRANSACTION', 'row#') as integer), 0) + 1)"; 
    }
}

