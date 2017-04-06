using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
public class  MPO_BRANDDb: DataAccess
{
public string _SortDirection { get; set; }
public string _SortExpression { get; set; }
  public MPO_BRAND _MPO_BRAND;
public const string DataKey = "PR_BRAND";
public const string DataText = "BRAND_DEC";
public const string DataValue = "PR_BRAND";
public List<SelectInputProperties> Select()
 { string sql = "SELECT PR_BRAND,BRAND_DEC,0 AS RecordCount FROM MPO_BRAND";
 DataSet ds = Db.GetDataSet(sql);  
  return SelectInputProperties.DataSetToList(ds);} 
public MPO_BRAND Select(string PR_BRAND) 
{ 
 string sql = "SELECT PR_BRAND,BRAND_DEC,0 AS RecordCount FROM MPO_BRAND where PR_BRAND = @PR_BRAND; "; 
  var prset = new List<IDataParameter>();
  prset.Add(Db.CreateParameterDb("@PR_BRAND", PR_BRAND));
  DataSet ds = Db.GetDataSet(sql,prset);
return DataSetToList(ds).FirstOrDefault(); 
}public List<MPO_BRAND> GetWithFilter(bool sortAscending, string sortExpression){
throw new Exception("Not implement");
string sql = "SELECT * FROM MPO_BRAND "; 
sql += string.Format("  where ((''='{0}')or(PR_BRAND='{0}'))", _MPO_BRAND.PR_BRAND);
sql += string.Format("  and ((''='{0}')or(BRAND_DEC='{0}'))", _MPO_BRAND.BRAND_DEC);
  if (sortExpression == null){
sql += string.Format(" order by PR_BRAND ", sortExpression);}
else
{
}

DataSet ds = Db.GetDataSet(sql);return DataSetToList(ds);}
  public List< MPO_BRAND> GetPageWise(int pageIndex, int PageSize, string wordFullText = "") 
    { 
        string sql = ""; 
 
        //Set @Command = 'insert into  #Results   SELECT ROW_NUMBER() OVER (ORDER BY [EM_ID] desc )AS RowNumber ,*  FROM [ MPO_BRAND]' + @CommandFilter; 
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
        sql = string.Format("SELECT  {4},PR_BRAND,BRAND_DEC,  (SELECT count(*) FROM  MPO_BRAND  {1}) as RecordCount FROM  MPO_BRAND A {1} {0} ROWS {2} TO {3}; ", sortCommnad, whereCommnad, startRow, toRow, Get_row_number_command()); 
 
        DataSet ds = Db.GetDataSet(sql); 
        return DataSetToList(ds); 
    }
public object Insert() {
var prset = new List<IDataParameter>();var sql = "INSERT INTO MPO_BRAND(PR_BRAND,BRAND_DEC) VALUES (@PR_BRAND,@BRAND_DEC) returning PR_BRAND";

 prset.Add(Db.CreateParameterDb("@PR_BRAND",_MPO_BRAND.PR_BRAND));
 prset.Add(Db.CreateParameterDb("@BRAND_DEC",_MPO_BRAND.BRAND_DEC));


object output = Db.FbExecuteScalar(sql, prset);return output;  }

public void Update() {
var prset = new List<IDataParameter>();
 prset.Add(Db.CreateParameterDb("@PR_BRAND",_MPO_BRAND.PR_BRAND)); prset.Add(Db.CreateParameterDb("@BRAND_DEC",_MPO_BRAND.BRAND_DEC));
var sql = @"UPDATE   MPO_BRAND SET  BRAND_DEC=@BRAND_DEC where PR_BRAND = @PR_BRAND";

int output = Db.FbExecuteNonQuery(sql, prset);
if (output != 1){
 throw new System.Exception("Update" + this.ToString());}   }

public void Delete() {
var prset = new List<IDataParameter>();
 prset.Add(Db.CreateParameterDb("@PR_BRAND",_MPO_BRAND.PR_BRAND));
var sql =@"DELETE FROM MPO_BRAND where PR_BRAND=@PR_BRAND";

int output = Db.FbExecuteNonQuery(sql, prset);
if (output != 1){
 throw new System.Exception("Delete" + this.ToString());}   }

private List<MPO_BRAND> DataSetToList(DataSet ds) 
{
 EnumerableRowCollection<MPO_BRAND> q = (from temp in ds.Tables[0].AsEnumerable()
 select new MPO_BRAND
{
RecordCount = temp.Field<Int32>("RecordCount"),PR_BRAND= temp.Field<String>("PR_BRAND"), 
 BRAND_DEC= temp.Field<String>("BRAND_DEC"), 
  });
  return q.ToList();
}
   public Boolean UpdateColumn(string id, string column,string value) 
        { 
            var prset = new List<IDataParameter>(); 
            prset.Add(Db.CreateParameterDb("@PR_BRAND", id)); 
            prset.Add(Db.CreateParameterDb("@Data", value)); 
             var sql = @"UPDATE   MPO_BRAND SET "+column+ "=@Data where PR_BRAND = @PR_BRAND"; 
 
            int output = Db.FbExecuteNonQuery(sql, prset); 
            if (output == 1) 
            { 
                return true; 
            } 
 
            return false;   
        } 
 public List<string> GetKeyWordsAllColumn(string Keyword) 
    { 
        
        string sql = "Sp_GetMPO_BRAND_Autocomplete"; 
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
          
 
  string sql = "SELECT  " + column + " FROM MPO_BRAND where lower(" + column + ") like '" + keyword.ToLower() + "%'   group by " + column + " order by count(*) desc;"; 
         
         
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
 
            //Set @Command = 'insert into  #Results   SELECT ROW_NUMBER() OVER (ORDER BY [EM_ID] desc )AS RowNumber ,*  FROM [MPO_BRAND]' + @CommandFilter; 
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
            sql = string.Format("insert into  #Results   SELECT ROW_NUMBER() OVER (  {0} )AS RowNumber ,*  FROM [MPO_BRAND] ", sortCommnad); 
 
            sql += GenWhereformProperties(); 
            return sql; 
        }
public string GenWhereformProperties() 
{
  String sql="";
   sql += "WHERE (1=1) "; 
            if (( _MPO_BRAND.PR_BRAND!= null) )
            { 
                sql += string.Format(" AND ((''='{0}') or (PR_BRAND='{0}') )", _MPO_BRAND.PR_BRAND); 
            } 
            if (( _MPO_BRAND.BRAND_DEC!= null) )
            { 
                sql += string.Format(" AND ((''='{0}') or (BRAND_DEC='{0}') )", _MPO_BRAND.BRAND_DEC); 
            } 
return sql;
}
    public string Get_row_number_command() 
    { 
        return "rdb$get_context('USER_TRANSACTION', 'row#') as row_number,rdb$set_context('USER_TRANSACTION', 'row#', coalesce(cast(rdb$get_context('USER_TRANSACTION', 'row#') as integer), 0) + 1)"; 
    }
}

