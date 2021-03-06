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
public class  TestFormulaDb: DataAccess
{
 public string _SortDirection { get; set; }
 public string _SortExpression { get; set; }
  public TestFormula _TestFormula;
public const string DataKey = "TestFormulaID";
public const string DataText = "TestFormulaName";
public const string DataValue = "TestFormulaID";
 public List<SelectInputProperties> Select()
    {
 string sql = "SELECT * FROM TestFormula";
        DataSet ds = Db.GetDataSet(sql);

        return SelectInputProperties.DataSetToList(ds);
		
    }
	
public TestFormula Select(string TestFormulaID) 
{ 
 string _sql1 = "SELECT *,0 AS RecordCount FROM TestFormula where TestFormulaID = @TestFormulaID; "; 
   var prset = new List<IDataParameter>();
  prset.Add(Db.CreateParameterDb("@TestFormulaID", TestFormulaID));
  DataSet ds = Db.GetDataSet(_sql1,prset);
return DataSetToList(ds).FirstOrDefault(); 
}public List<TestFormula> GetWithFilter(bool sortAscending, string sortExpression){
throw new Exception("Not implement");
string sql = "SELECT * FROM TestFormula "; 
sql += string.Format("  where ((''='{0}')or(TestFormulaID='{0}'))", _TestFormula.TestFormulaID);
sql += string.Format("  and ((''='{0}')or(TestFormulaName='{0}'))", _TestFormula.TestFormulaName);
sql += string.Format("  and ((''='{0}')or(TestFormulaDetail='{0}'))", _TestFormula.TestFormulaDetail);
if (sortExpression == null){
sql += string.Format(" order by TestFormulaID ", sortExpression);}
else
{
}

DataSet ds = Db.GetDataSet(sql);return DataSetToList(ds);}
public List<TestFormula> GetPageWise(int pageIndex, int PageSize, string  wordFullText="") 
{ 
string store = "Sp_GetTestFormulaPageWise"; 
 
 
var dbParameter = GetParameter(pageIndex,PageSize);

 
 
DataSet ds = Db.GetDataSet(store, dbParameter, CommandType.StoredProcedure); 
return DataSetToList(ds); 
}
public object Insert() {
var prset = new List<IDataParameter>();var sql = "INSERT INTO TestFormula(TestFormulaID,TestFormulaName,TestFormulaDetail) VALUES (@TestFormulaID,@TestFormulaName,@TestFormulaDetail) ;Select @TestFormulaID";
 prset.Add(Db.CreateParameterDb("@TestFormulaID",_TestFormula.TestFormulaID)); prset.Add(Db.CreateParameterDb("@TestFormulaName",_TestFormula.TestFormulaName)); prset.Add(Db.CreateParameterDb("@TestFormulaDetail",_TestFormula.TestFormulaDetail));

object output = Db.FbExecuteScalar(sql, prset);return output;  }

public void Update() {
var prset = new List<IDataParameter>();
 prset.Add(Db.CreateParameterDb("@TestFormulaID",_TestFormula.TestFormulaID)); prset.Add(Db.CreateParameterDb("@TestFormulaName",_TestFormula.TestFormulaName)); prset.Add(Db.CreateParameterDb("@TestFormulaDetail",_TestFormula.TestFormulaDetail));
var sql = @"UPDATE   TestFormula SET  TestFormulaName=@TestFormulaName,TestFormulaDetail=@TestFormulaDetail where TestFormulaID = @TestFormulaID";

int output = Db.FbExecuteNonQuery(sql, prset);
if (output != 1){
 throw new System.Exception("Update" + this.ToString());}   }

public void Delete() {
var prset = new List<IDataParameter>();
 prset.Add(Db.CreateParameterDb("@TestFormulaID",_TestFormula.TestFormulaID));
var sql =@"DELETE FROM TestFormula where TestFormulaID=@TestFormulaID";

int output = Db.FbExecuteNonQuery(sql, prset);
if (output != 1){
 throw new System.Exception("Delete" + this.ToString());}   }

private List<TestFormula> DataSetToList(DataSet ds) 
{
 EnumerableRowCollection<TestFormula> q = (from temp in ds.Tables[0].AsEnumerable()
 select new TestFormula
{
RecordCount = temp.Field<Int32>("RecordCount"),TestFormulaID= temp.Field<String>("TestFormulaID"), 
 TestFormulaName= temp.Field<String>("TestFormulaName"), 
 TestFormulaDetail= temp.Field<String>("TestFormulaDetail"), 
  });
  return q.ToList();
}
   public Boolean UpdateColumn(string id, string column,string value) 
        { 
            var prset = new List<IDataParameter>(); 
            prset.Add(Db.CreateParameterDb("@TestFormulaID", id)); 
prset.Add(Db.CreateParameterDb("@Column", column));
            prset.Add(Db.CreateParameterDb("@Data", value)); 
   var sql = @"Sp_GetTestFormula_UpdateColumn";
            int output = Db.FbExecuteNonQuery(sql, prset, CommandType.StoredProcedure); 
            if (output == 1) 
            { 
                return true; 
            } 
 
            return false;   
        } 
 public List<string> GetKeyWordsAllColumn(string Keyword) 
    { 
        
        string sql = "Sp_GetTestFormula_Autocomplete"; 
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
          
 
  string sql = "SELECT  " + column + " FROM TestFormula where lower(" + column + ") like '" + keyword.ToLower() + "%'   group by " + column + " order by count(*) desc;"; 
         
         
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
            if ( _TestFormula.TestFormulaID!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (TestFormulaID='{0}') )", _TestFormula.TestFormulaID); 
            } 
            if ( _TestFormula.TestFormulaName!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (TestFormulaName='{0}') )", _TestFormula.TestFormulaName); 
            } 
            if ( _TestFormula.TestFormulaDetail!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (TestFormulaDetail='{0}') )", _TestFormula.TestFormulaDetail); 
            } 
return sql;
}
      public List<IDataParameter> GetParameter(int pageIndex, int PageSize)
        {
            var sqlStorePamameters = new List<IDataParameter>();
            sqlStorePamameters.Add(Db.CreateParameterDb("@PageIndex", pageIndex));
            sqlStorePamameters.Add(Db.CreateParameterDb("@PageSize", PageSize));
if (_TestFormula.TestFormulaID != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@TestFormulaID", _TestFormula.TestFormulaID));

            }
if (_TestFormula.TestFormulaName != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@TestFormulaName", _TestFormula.TestFormulaName));

            }
if (_TestFormula.TestFormulaDetail != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@TestFormulaDetail", _TestFormula.TestFormulaDetail));

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
