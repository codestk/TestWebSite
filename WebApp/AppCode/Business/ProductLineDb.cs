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
public class  ProductLineDb: DataAccess
{
 public string _SortDirection { get; set; }
 public string _SortExpression { get; set; }
  public ProductLine _ProductLine;
public const string DataKey = "ProductLineId";
public const string DataText = "SourceID";
public const string DataValue = "ProductLineId";
 public List<SelectInputProperties> Select()
    {
 string sql = "SELECT * FROM ProductLine";
        DataSet ds = Db.GetDataSet(sql);

        return SelectInputProperties.DataSetToList(ds);
		
    }
	
public ProductLine Select(string ProductLineId) 
{ 
 string _sql1 = "SELECT *,0 AS RecordCount FROM ProductLine where ProductLineId = @ProductLineId; "; 
   var prset = new List<IDataParameter>();
  prset.Add(Db.CreateParameterDb("@ProductLineId", ProductLineId));
  DataSet ds = Db.GetDataSet(_sql1,prset);
return DataSetToList(ds).FirstOrDefault(); 
}public List<ProductLine> GetWithFilter(bool sortAscending, string sortExpression){
throw new Exception("Not implement");
string sql = "SELECT * FROM ProductLine "; 
sql += string.Format("  where ((''='{0}')or(ProductLineId='{0}'))", _ProductLine.ProductLineId);
sql += string.Format("  and ((''='{0}')or(SourceID='{0}'))", _ProductLine.SourceID);
sql += string.Format("  and ((''='{0}')or(LineID='{0}'))", _ProductLine.LineID);
sql += string.Format("  and ((''='{0}')or(TestFormulaID='{0}'))", _ProductLine.TestFormulaID);
sql += string.Format("  and ((''='{0}')or(ContainID='{0}'))", _ProductLine.ContainID);
sql += string.Format("  and ((''='{0}')or(LineSizeID='{0}'))", _ProductLine.LineSizeID);
sql += string.Format("  and ((''='{0}')or(CustomerBrandID='{0}'))", _ProductLine.CustomerBrandID);
sql += string.Format("  and ((''='{0}')or(ManufacturingDate='{0}'))", _ProductLine.ManufacturingDate);
sql += string.Format("  and ((''='{0}')or(ExpectItems='{0}'))", _ProductLine.ExpectItems);
sql += string.Format("  and ((''='{0}')or(ProcessItems='{0}'))", _ProductLine.ProcessItems);
sql += string.Format("  and ((''='{0}')or(CreateDate='{0}'))", _ProductLine.CreateDate);
if (sortExpression == null){
sql += string.Format(" order by ProductLineId ", sortExpression);}
else
{
}

DataSet ds = Db.GetDataSet(sql);return DataSetToList(ds);}
public List<ProductLine> GetPageWise(int pageIndex, int PageSize, string  wordFullText="") 
{ 
string store = "Sp_GetProductLinePageWise"; 
 
 
var dbParameter = GetParameter(pageIndex,PageSize);

 
 
DataSet ds = Db.GetDataSet(store, dbParameter, CommandType.StoredProcedure); 
return DataSetToList(ds); 
}
public object Insert() {
var prset = new List<IDataParameter>();var sql = "INSERT INTO ProductLine(SourceID,LineID,TestFormulaID,ContainID,LineSizeID,CustomerBrandID,ManufacturingDate,ExpectItems,ProcessItems) VALUES (@SourceID,@LineID,@TestFormulaID,@ContainID,@LineSizeID,@CustomerBrandID,@ManufacturingDate,@ExpectItems,@ProcessItems) ;SELECT SCOPE_IDENTITY();";
 prset.Add(Db.CreateParameterDb("@SourceID",_ProductLine.SourceID)); prset.Add(Db.CreateParameterDb("@LineID",_ProductLine.LineID)); prset.Add(Db.CreateParameterDb("@TestFormulaID",_ProductLine.TestFormulaID)); prset.Add(Db.CreateParameterDb("@ContainID",_ProductLine.ContainID)); prset.Add(Db.CreateParameterDb("@LineSizeID",_ProductLine.LineSizeID)); prset.Add(Db.CreateParameterDb("@CustomerBrandID",_ProductLine.CustomerBrandID)); prset.Add(Db.CreateParameterDb("@ManufacturingDate",_ProductLine.ManufacturingDate)); prset.Add(Db.CreateParameterDb("@ExpectItems",_ProductLine.ExpectItems)); prset.Add(Db.CreateParameterDb("@ProcessItems",_ProductLine.ProcessItems));

object output = Db.FbExecuteScalar(sql, prset);return output;  }

public void Update() {
var prset = new List<IDataParameter>();
 prset.Add(Db.CreateParameterDb("@ProductLineId",_ProductLine.ProductLineId)); prset.Add(Db.CreateParameterDb("@SourceID",_ProductLine.SourceID)); prset.Add(Db.CreateParameterDb("@LineID",_ProductLine.LineID)); prset.Add(Db.CreateParameterDb("@TestFormulaID",_ProductLine.TestFormulaID)); prset.Add(Db.CreateParameterDb("@ContainID",_ProductLine.ContainID)); prset.Add(Db.CreateParameterDb("@LineSizeID",_ProductLine.LineSizeID)); prset.Add(Db.CreateParameterDb("@CustomerBrandID",_ProductLine.CustomerBrandID)); prset.Add(Db.CreateParameterDb("@ManufacturingDate",_ProductLine.ManufacturingDate)); prset.Add(Db.CreateParameterDb("@ExpectItems",_ProductLine.ExpectItems)); prset.Add(Db.CreateParameterDb("@ProcessItems",_ProductLine.ProcessItems));
var sql = @"UPDATE   ProductLine SET  SourceID=@SourceID,LineID=@LineID,TestFormulaID=@TestFormulaID,ContainID=@ContainID,LineSizeID=@LineSizeID,CustomerBrandID=@CustomerBrandID,ManufacturingDate=@ManufacturingDate,ExpectItems=@ExpectItems,ProcessItems=@ProcessItems where ProductLineId = @ProductLineId";

int output = Db.FbExecuteNonQuery(sql, prset);
if (output != 1){
 throw new System.Exception("Update" + this.ToString());}   }

public void Delete() {
var prset = new List<IDataParameter>();
 prset.Add(Db.CreateParameterDb("@ProductLineId",_ProductLine.ProductLineId));
var sql =@"DELETE FROM ProductLine where ProductLineId=@ProductLineId";

int output = Db.FbExecuteNonQuery(sql, prset);
if (output != 1){
 throw new System.Exception("Delete" + this.ToString());}   }

private List<ProductLine> DataSetToList(DataSet ds) 
{
 EnumerableRowCollection<ProductLine> q = (from temp in ds.Tables[0].AsEnumerable()
 select new ProductLine
{
RecordCount = temp.Field<Int32>("RecordCount"),ProductLineId= Convert.ToDecimal (temp.Field<Object>("ProductLineId")), 
 SourceID= temp.Field<String>("SourceID"), 
 LineID= temp.Field<String>("LineID"), 
 TestFormulaID= temp.Field<String>("TestFormulaID"), 
 ContainID= temp.Field<String>("ContainID"), 
 LineSizeID= temp.Field<String>("LineSizeID"), 
 CustomerBrandID= temp.Field<String>("CustomerBrandID"), 
 ManufacturingDate= temp.Field<DateTime?>("ManufacturingDate"), 
 ExpectItems= temp.Field<Int32?>("ExpectItems"), 
 ProcessItems= temp.Field<Int32?>("ProcessItems"), 
 CreateDate= temp.Field<DateTime?>("CreateDate"), 
  });
  return q.ToList();
}
   public Boolean UpdateColumn(string id, string column,string value) 
        { 
            var prset = new List<IDataParameter>(); 
            prset.Add(Db.CreateParameterDb("@ProductLineId", id)); 
prset.Add(Db.CreateParameterDb("@Column", column));
            prset.Add(Db.CreateParameterDb("@Data", value)); 
   var sql = @"Sp_GetProductLine_UpdateColumn";
            int output = Db.FbExecuteNonQuery(sql, prset, CommandType.StoredProcedure); 
            if (output == 1) 
            { 
                return true; 
            } 
 
            return false;   
        } 
 public List<string> GetKeyWordsAllColumn(string Keyword) 
    { 
        
        string sql = "Sp_GetProductLine_Autocomplete"; 
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
          
 
  string sql = "SELECT  " + column + " FROM ProductLine where lower(" + column + ") like '" + keyword.ToLower() + "%'   group by " + column + " order by count(*) desc;"; 
         
         
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
            if ( _ProductLine.ProductLineId!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (ProductLineId='{0}') )", _ProductLine.ProductLineId); 
            } 
            if ( _ProductLine.SourceID!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (SourceID='{0}') )", _ProductLine.SourceID); 
            } 
            if ( _ProductLine.LineID!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (LineID='{0}') )", _ProductLine.LineID); 
            } 
            if ( _ProductLine.TestFormulaID!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (TestFormulaID='{0}') )", _ProductLine.TestFormulaID); 
            } 
            if ( _ProductLine.ContainID!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (ContainID='{0}') )", _ProductLine.ContainID); 
            } 
            if ( _ProductLine.LineSizeID!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (LineSizeID='{0}') )", _ProductLine.LineSizeID); 
            } 
            if ( _ProductLine.CustomerBrandID!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (CustomerBrandID='{0}') )", _ProductLine.CustomerBrandID); 
            } 
            if ( _ProductLine.ManufacturingDate!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (ManufacturingDate='{0}') )", _ProductLine.ManufacturingDate); 
            } 
            if ( _ProductLine.ExpectItems!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (ExpectItems='{0}') )", _ProductLine.ExpectItems); 
            } 
            if ( _ProductLine.ProcessItems!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (ProcessItems='{0}') )", _ProductLine.ProcessItems); 
            } 
            if ( _ProductLine.CreateDate!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (CreateDate='{0}') )", _ProductLine.CreateDate); 
            } 
return sql;
}
      public List<IDataParameter> GetParameter(int pageIndex, int PageSize)
        {
            var sqlStorePamameters = new List<IDataParameter>();
            sqlStorePamameters.Add(Db.CreateParameterDb("@PageIndex", pageIndex));
            sqlStorePamameters.Add(Db.CreateParameterDb("@PageSize", PageSize));
if (_ProductLine.ProductLineId != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@ProductLineId", _ProductLine.ProductLineId));

            }
if (_ProductLine.SourceID != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@SourceID", _ProductLine.SourceID));

            }
if (_ProductLine.LineID != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@LineID", _ProductLine.LineID));

            }
if (_ProductLine.TestFormulaID != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@TestFormulaID", _ProductLine.TestFormulaID));

            }
if (_ProductLine.ContainID != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@ContainID", _ProductLine.ContainID));

            }
if (_ProductLine.LineSizeID != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@LineSizeID", _ProductLine.LineSizeID));

            }
if (_ProductLine.CustomerBrandID != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@CustomerBrandID", _ProductLine.CustomerBrandID));

            }
if (_ProductLine.ManufacturingDate != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@ManufacturingDate", _ProductLine.ManufacturingDate));

            }
if (_ProductLine.ExpectItems != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@ExpectItems", _ProductLine.ExpectItems));

            }
if (_ProductLine.ProcessItems != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@ProcessItems", _ProductLine.ProcessItems));

            }
if (_ProductLine.CreateDate != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@CreateDate", _ProductLine.CreateDate));

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
