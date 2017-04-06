using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
public class  MPO_PRODUCT_P2Db: DataAccess
{
public string _SortDirection { get; set; }
public string _SortExpression { get; set; }
  public MPO_PRODUCT_P2 _MPO_PRODUCT_P2;
public const string DataKey = "PR_LOT";
public const string DataText = "PR_SOURCE";
public const string DataValue = "PR_LOT";
public List<SelectInputProperties> Select()
 { string sql = "SELECT PR_LOT,PR_SOURCE,PR_PRODUCT_LINE,PR_FORMULA_AND_TEST,PR_SIZE,0 AS RecordCount FROM MPO_PRODUCT_P2";
 DataSet ds = Db.GetDataSet(sql);  
  return SelectInputProperties.DataSetToList(ds);} 
public MPO_PRODUCT_P2 Select(string PR_LOT) 
{ 
 string sql = "SELECT PR_LOT,PR_SOURCE,PR_PRODUCT_LINE,PR_FORMULA_AND_TEST,PR_SIZE,0 AS RecordCount FROM MPO_PRODUCT_P2 where PR_LOT = @PR_LOT; "; 
  var prset = new List<IDataParameter>();
  prset.Add(Db.CreateParameterDb("@PR_LOT", PR_LOT));
  DataSet ds = Db.GetDataSet(sql,prset);
return DataSetToList(ds).FirstOrDefault(); 
}public List<MPO_PRODUCT_P2> GetWithFilter(bool sortAscending, string sortExpression){
throw new Exception("Not implement");
string sql = "SELECT * FROM MPO_PRODUCT_P2 "; 
sql += string.Format("  where ((''='{0}')or(PR_LOT='{0}'))", _MPO_PRODUCT_P2.PR_LOT);
sql += string.Format("  and ((''='{0}')or(PR_SOURCE='{0}'))", _MPO_PRODUCT_P2.PR_SOURCE);
sql += string.Format("  and ((''='{0}')or(PR_PRODUCT_LINE='{0}'))", _MPO_PRODUCT_P2.PR_PRODUCT_LINE);
sql += string.Format("  and ((''='{0}')or(PR_FORMULA_AND_TEST='{0}'))", _MPO_PRODUCT_P2.PR_FORMULA_AND_TEST);
sql += string.Format("  and ((''='{0}')or(PR_SIZE='{0}'))", _MPO_PRODUCT_P2.PR_SIZE);
  if (sortExpression == null){
sql += string.Format(" order by PR_LOT ", sortExpression);}
else
{
}

DataSet ds = Db.GetDataSet(sql);return DataSetToList(ds);}
  public List< MPO_PRODUCT_P2> GetPageWise(int pageIndex, int PageSize, string wordFullText = "") 
    { 
        string sql = ""; 
 
        //Set @Command = 'insert into  #Results   SELECT ROW_NUMBER() OVER (ORDER BY [EM_ID] desc )AS RowNumber ,*  FROM [ MPO_PRODUCT_P2]' + @CommandFilter; 
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
        sql = string.Format("SELECT  {4},PR_LOT,PR_SOURCE,PR_PRODUCT_LINE,PR_FORMULA_AND_TEST,PR_SIZE,  (SELECT count(*) FROM  MPO_PRODUCT_P2  {1}) as RecordCount FROM  MPO_PRODUCT_P2 A {1} {0} ROWS {2} TO {3}; ", sortCommnad, whereCommnad, startRow, toRow, Get_row_number_command()); 
 
        DataSet ds = Db.GetDataSet(sql); 
        return DataSetToList(ds); 
    }
public object Insert() {
var prset = new List<IDataParameter>();var sql = "INSERT INTO MPO_PRODUCT_P2(PR_LOT,PR_SOURCE,PR_PRODUCT_LINE,PR_FORMULA_AND_TEST,PR_SIZE) VALUES (@PR_LOT,@PR_SOURCE,@PR_PRODUCT_LINE,@PR_FORMULA_AND_TEST,@PR_SIZE) returning PR_LOT";

 prset.Add(Db.CreateParameterDb("@PR_LOT",_MPO_PRODUCT_P2.PR_LOT));
 prset.Add(Db.CreateParameterDb("@PR_SOURCE",_MPO_PRODUCT_P2.PR_SOURCE));
 prset.Add(Db.CreateParameterDb("@PR_PRODUCT_LINE",_MPO_PRODUCT_P2.PR_PRODUCT_LINE));
 prset.Add(Db.CreateParameterDb("@PR_FORMULA_AND_TEST",_MPO_PRODUCT_P2.PR_FORMULA_AND_TEST));
 prset.Add(Db.CreateParameterDb("@PR_SIZE",_MPO_PRODUCT_P2.PR_SIZE));


object output = Db.FbExecuteScalar(sql, prset);return output;  }

public void Update() {
var prset = new List<IDataParameter>();
 prset.Add(Db.CreateParameterDb("@PR_LOT",_MPO_PRODUCT_P2.PR_LOT)); prset.Add(Db.CreateParameterDb("@PR_SOURCE",_MPO_PRODUCT_P2.PR_SOURCE)); prset.Add(Db.CreateParameterDb("@PR_PRODUCT_LINE",_MPO_PRODUCT_P2.PR_PRODUCT_LINE)); prset.Add(Db.CreateParameterDb("@PR_FORMULA_AND_TEST",_MPO_PRODUCT_P2.PR_FORMULA_AND_TEST)); prset.Add(Db.CreateParameterDb("@PR_SIZE",_MPO_PRODUCT_P2.PR_SIZE));
var sql = @"UPDATE   MPO_PRODUCT_P2 SET  PR_SOURCE=@PR_SOURCE,PR_PRODUCT_LINE=@PR_PRODUCT_LINE,PR_FORMULA_AND_TEST=@PR_FORMULA_AND_TEST,PR_SIZE=@PR_SIZE where PR_LOT = @PR_LOT";

int output = Db.FbExecuteNonQuery(sql, prset);
if (output != 1){
 throw new System.Exception("Update" + this.ToString());}   }

public void Delete() {
var prset = new List<IDataParameter>();
 prset.Add(Db.CreateParameterDb("@PR_LOT",_MPO_PRODUCT_P2.PR_LOT));
var sql =@"DELETE FROM MPO_PRODUCT_P2 where PR_LOT=@PR_LOT";

int output = Db.FbExecuteNonQuery(sql, prset);
if (output != 1){
 throw new System.Exception("Delete" + this.ToString());}   }

private List<MPO_PRODUCT_P2> DataSetToList(DataSet ds) 
{
 EnumerableRowCollection<MPO_PRODUCT_P2> q = (from temp in ds.Tables[0].AsEnumerable()
 select new MPO_PRODUCT_P2
{
RecordCount = temp.Field<Int32>("RecordCount"),PR_LOT= temp.Field<Int32?>("PR_LOT"), 
 PR_SOURCE= temp.Field<String>("PR_SOURCE"), 
 PR_PRODUCT_LINE= temp.Field<String>("PR_PRODUCT_LINE"), 
 PR_FORMULA_AND_TEST= temp.Field<String>("PR_FORMULA_AND_TEST"), 
 PR_SIZE= temp.Field<String>("PR_SIZE"), 
  });
  return q.ToList();
}
   public Boolean UpdateColumn(string id, string column,string value) 
        { 
            var prset = new List<IDataParameter>(); 
            prset.Add(Db.CreateParameterDb("@PR_LOT", id)); 
            prset.Add(Db.CreateParameterDb("@Data", value)); 
             var sql = @"UPDATE   MPO_PRODUCT_P2 SET "+column+ "=@Data where PR_LOT = @PR_LOT"; 
 
            int output = Db.FbExecuteNonQuery(sql, prset); 
            if (output == 1) 
            { 
                return true; 
            } 
 
            return false;   
        } 
 public List<string> GetKeyWordsAllColumn(string Keyword) 
    { 
        
        string sql = "Sp_GetMPO_PRODUCT_P2_Autocomplete"; 
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
          
 
  string sql = "SELECT  " + column + " FROM MPO_PRODUCT_P2 where lower(" + column + ") like '" + keyword.ToLower() + "%'   group by " + column + " order by count(*) desc;"; 
         
         
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
 
            //Set @Command = 'insert into  #Results   SELECT ROW_NUMBER() OVER (ORDER BY [EM_ID] desc )AS RowNumber ,*  FROM [MPO_PRODUCT_P2]' + @CommandFilter; 
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
            sql = string.Format("insert into  #Results   SELECT ROW_NUMBER() OVER (  {0} )AS RowNumber ,*  FROM [MPO_PRODUCT_P2] ", sortCommnad); 
 
            sql += GenWhereformProperties(); 
            return sql; 
        }
public string GenWhereformProperties() 
{
  String sql="";
   sql += "WHERE (1=1) "; 
            if (( _MPO_PRODUCT_P2.PR_LOT!= null) )
            { 
                sql += string.Format(" AND ((''='{0}') or (PR_LOT='{0}') )", _MPO_PRODUCT_P2.PR_LOT); 
            } 
            if (( _MPO_PRODUCT_P2.PR_SOURCE!= null) )
            { 
                sql += string.Format(" AND ((''='{0}') or (PR_SOURCE='{0}') )", _MPO_PRODUCT_P2.PR_SOURCE); 
            } 
            if (( _MPO_PRODUCT_P2.PR_PRODUCT_LINE!= null) )
            { 
                sql += string.Format(" AND ((''='{0}') or (PR_PRODUCT_LINE='{0}') )", _MPO_PRODUCT_P2.PR_PRODUCT_LINE); 
            } 
            if (( _MPO_PRODUCT_P2.PR_FORMULA_AND_TEST!= null) )
            { 
                sql += string.Format(" AND ((''='{0}') or (PR_FORMULA_AND_TEST='{0}') )", _MPO_PRODUCT_P2.PR_FORMULA_AND_TEST); 
            } 
            if (( _MPO_PRODUCT_P2.PR_SIZE!= null) )
            { 
                sql += string.Format(" AND ((''='{0}') or (PR_SIZE='{0}') )", _MPO_PRODUCT_P2.PR_SIZE); 
            } 
return sql;
}
    public string Get_row_number_command() 
    { 
        return "rdb$get_context('USER_TRANSACTION', 'row#') as row_number,rdb$set_context('USER_TRANSACTION', 'row#', coalesce(cast(rdb$get_context('USER_TRANSACTION', 'row#') as integer), 0) + 1)"; 
    }
}

