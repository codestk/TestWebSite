using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
public class  ProductsDb: DataAccess
{
 public string _SortDirection { get; set; }
 public string _SortExpression { get; set; }
  public Products _Products;
public const string DataKey = "ProductID";
public const string DataText = "ProductName";
public const string DataValue = "ProductID";
 public List<SelectInputProperties> Select()
    {
 string sql = "SELECT * FROM Products";
        DataSet ds = Db.GetDataSet(sql);

        return SelectInputProperties.DataSetToList(ds);
		
    }
	
public Products Select(string ProductID) 
{ 
 string _sql1 = "SELECT *,0 AS RecordCount FROM Products where ProductID = @ProductID; "; 
   var prset = new List<IDataParameter>();
  prset.Add(Db.CreateParameterDb("@ProductID", ProductID));
  DataSet ds = Db.GetDataSet(_sql1,prset);
return DataSetToList(ds).FirstOrDefault(); 
}public List<Products> GetWithFilter(bool sortAscending, string sortExpression){
throw new Exception("Not implement");
string sql = "SELECT * FROM Products "; 
sql += string.Format("  where ((''='{0}')or(ProductID='{0}'))", _Products.ProductID);
sql += string.Format("  and ((''='{0}')or(ProductName='{0}'))", _Products.ProductName);
sql += string.Format("  and ((''='{0}')or(SupplierID='{0}'))", _Products.SupplierID);
sql += string.Format("  and ((''='{0}')or(CategoryID='{0}'))", _Products.CategoryID);
sql += string.Format("  and ((''='{0}')or(QuantityPerUnit='{0}'))", _Products.QuantityPerUnit);
sql += string.Format("  and ((''='{0}')or(UnitPrice='{0}'))", _Products.UnitPrice);
sql += string.Format("  and ((''='{0}')or(UnitsInStock='{0}'))", _Products.UnitsInStock);
sql += string.Format("  and ((''='{0}')or(UnitsOnOrder='{0}'))", _Products.UnitsOnOrder);
sql += string.Format("  and ((''='{0}')or(ReorderLevel='{0}'))", _Products.ReorderLevel);
sql += string.Format("  and ((''='{0}')or(Discontinued='{0}'))", _Products.Discontinued);
if (sortExpression == null){
sql += string.Format(" order by ProductID ", sortExpression);}
else
{
}

DataSet ds = Db.GetDataSet(sql);return DataSetToList(ds);}
public List<Products> GetPageWise(int pageIndex, int PageSize, string  wordFullText="") 
{ 
string store = "Sp_GetProductsPageWise"; 
 
 
var dbParameter = GetParameter(pageIndex,PageSize);

 
 
DataSet ds = Db.GetDataSet(store, dbParameter, CommandType.StoredProcedure); 
return DataSetToList(ds); 
}
public object Insert() {
var prset = new List<IDataParameter>();var sql = "INSERT INTO Products(ProductName,SupplierID,CategoryID,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued) VALUES (@ProductName,@SupplierID,@CategoryID,@QuantityPerUnit,@UnitPrice,@UnitsInStock,@UnitsOnOrder,@ReorderLevel,@Discontinued) ;SELECT SCOPE_IDENTITY();";
 prset.Add(Db.CreateParameterDb("@ProductName",_Products.ProductName)); prset.Add(Db.CreateParameterDb("@SupplierID",_Products.SupplierID)); prset.Add(Db.CreateParameterDb("@CategoryID",_Products.CategoryID)); prset.Add(Db.CreateParameterDb("@QuantityPerUnit",_Products.QuantityPerUnit)); prset.Add(Db.CreateParameterDb("@UnitPrice",_Products.UnitPrice)); prset.Add(Db.CreateParameterDb("@UnitsInStock",_Products.UnitsInStock)); prset.Add(Db.CreateParameterDb("@UnitsOnOrder",_Products.UnitsOnOrder)); prset.Add(Db.CreateParameterDb("@ReorderLevel",_Products.ReorderLevel)); prset.Add(Db.CreateParameterDb("@Discontinued",_Products.Discontinued));

object output = Db.FbExecuteScalar(sql, prset);return output;  }

public void Update() {
var prset = new List<IDataParameter>();
 prset.Add(Db.CreateParameterDb("@ProductID",_Products.ProductID)); prset.Add(Db.CreateParameterDb("@ProductName",_Products.ProductName)); prset.Add(Db.CreateParameterDb("@SupplierID",_Products.SupplierID)); prset.Add(Db.CreateParameterDb("@CategoryID",_Products.CategoryID)); prset.Add(Db.CreateParameterDb("@QuantityPerUnit",_Products.QuantityPerUnit)); prset.Add(Db.CreateParameterDb("@UnitPrice",_Products.UnitPrice)); prset.Add(Db.CreateParameterDb("@UnitsInStock",_Products.UnitsInStock)); prset.Add(Db.CreateParameterDb("@UnitsOnOrder",_Products.UnitsOnOrder)); prset.Add(Db.CreateParameterDb("@ReorderLevel",_Products.ReorderLevel)); prset.Add(Db.CreateParameterDb("@Discontinued",_Products.Discontinued));
var sql = @"UPDATE   Products SET  ProductName=@ProductName,SupplierID=@SupplierID,CategoryID=@CategoryID,QuantityPerUnit=@QuantityPerUnit,UnitPrice=@UnitPrice,UnitsInStock=@UnitsInStock,UnitsOnOrder=@UnitsOnOrder,ReorderLevel=@ReorderLevel,Discontinued=@Discontinued where ProductID = @ProductID";

int output = Db.FbExecuteNonQuery(sql, prset);
if (output != 1){
 throw new System.Exception("Update" + this.ToString());}   }

public void Delete() {
var prset = new List<IDataParameter>();
 prset.Add(Db.CreateParameterDb("@ProductID",_Products.ProductID));
var sql =@"DELETE FROM Products where ProductID=@ProductID";

int output = Db.FbExecuteNonQuery(sql, prset);
if (output != 1){
 throw new System.Exception("Delete" + this.ToString());}   }

private List<Products> DataSetToList(DataSet ds) 
{
 EnumerableRowCollection<Products> q = (from temp in ds.Tables[0].AsEnumerable()
 select new Products
{
RecordCount = temp.Field<Int32>("RecordCount"),ProductID= temp.Field<Int32?>("ProductID"), 
 ProductName= temp.Field<String>("ProductName"), 
 SupplierID= temp.Field<Int32?>("SupplierID"), 
 CategoryID= temp.Field<Int32?>("CategoryID"), 
 QuantityPerUnit= temp.Field<String>("QuantityPerUnit"), 
 UnitPrice= Convert.ToDecimal (temp.Field<Object>("UnitPrice")), 
 UnitsInStock= temp.Field<Int16?>("UnitsInStock"), 
 UnitsOnOrder= temp.Field<Int16?>("UnitsOnOrder"), 
 ReorderLevel= temp.Field<Int16?>("ReorderLevel"), 
 Discontinued= temp.Field<Boolean?>("Discontinued"), 
  });
  return q.ToList();
}
   public Boolean UpdateColumn(string id, string column,string value) 
        { 
            var prset = new List<IDataParameter>(); 
            prset.Add(Db.CreateParameterDb("@ProductID", id)); 
prset.Add(Db.CreateParameterDb("@Column", column));
            prset.Add(Db.CreateParameterDb("@Data", value)); 
   var sql = @"Sp_GetProducts_UpdateColumn";
            int output = Db.FbExecuteNonQuery(sql, prset, CommandType.StoredProcedure); 
            if (output == 1) 
            { 
                return true; 
            } 
 
            return false;   
        } 
 public List<string> GetKeyWordsAllColumn(string Keyword) 
    { 
        
        string sql = "Sp_GetProducts_Autocomplete"; 
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
          
 
  string sql = "SELECT  " + column + " FROM Products where lower(" + column + ") like '" + keyword.ToLower() + "%'   group by " + column + " order by count(*) desc;"; 
         
         
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
            if ( _Products.ProductID!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (ProductID='{0}') )", _Products.ProductID); 
            } 
            if ( _Products.ProductName!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (ProductName='{0}') )", _Products.ProductName); 
            } 
            if ( _Products.SupplierID!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (SupplierID='{0}') )", _Products.SupplierID); 
            } 
            if ( _Products.CategoryID!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (CategoryID='{0}') )", _Products.CategoryID); 
            } 
            if ( _Products.QuantityPerUnit!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (QuantityPerUnit='{0}') )", _Products.QuantityPerUnit); 
            } 
            if ( _Products.UnitPrice!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (UnitPrice='{0}') )", _Products.UnitPrice); 
            } 
            if ( _Products.UnitsInStock!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (UnitsInStock='{0}') )", _Products.UnitsInStock); 
            } 
            if ( _Products.UnitsOnOrder!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (UnitsOnOrder='{0}') )", _Products.UnitsOnOrder); 
            } 
            if ( _Products.ReorderLevel!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (ReorderLevel='{0}') )", _Products.ReorderLevel); 
            } 
            if ( _Products.Discontinued!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (Discontinued='{0}') )", _Products.Discontinued); 
            } 
return sql;
}
      public List<IDataParameter> GetParameter(int pageIndex, int PageSize)
        {
            var sqlStorePamameters = new List<IDataParameter>();
            sqlStorePamameters.Add(Db.CreateParameterDb("@PageIndex", pageIndex));
            sqlStorePamameters.Add(Db.CreateParameterDb("@PageSize", PageSize));
if (_Products.ProductID != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@ProductID", _Products.ProductID));

            }
if (_Products.ProductName != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@ProductName", _Products.ProductName));

            }
if (_Products.SupplierID != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@SupplierID", _Products.SupplierID));

            }
if (_Products.CategoryID != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@CategoryID", _Products.CategoryID));

            }
if (_Products.QuantityPerUnit != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@QuantityPerUnit", _Products.QuantityPerUnit));

            }
if (_Products.UnitPrice != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@UnitPrice", _Products.UnitPrice));

            }
if (_Products.UnitsInStock != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@UnitsInStock", _Products.UnitsInStock));

            }
if (_Products.UnitsOnOrder != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@UnitsOnOrder", _Products.UnitsOnOrder));

            }
if (_Products.ReorderLevel != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@ReorderLevel", _Products.ReorderLevel));

            }
if (_Products.Discontinued != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@Discontinued", _Products.Discontinued));

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

