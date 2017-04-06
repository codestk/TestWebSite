using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
public class  OrdersDb: DataAccess
{
 public string _SortDirection { get; set; }
 public string _SortExpression { get; set; }
  public Orders _Orders;
public const string DataKey = "OrderID";
public const string DataText = "CustomerID";
public const string DataValue = "OrderID";
 public List<SelectInputProperties> Select()
    {
 string sql = "SELECT * FROM Orders";
        DataSet ds = Db.GetDataSet(sql);

        return SelectInputProperties.DataSetToList(ds);
		
    }
	
public Orders Select(string OrderID) 
{ 
 string _sql1 = "SELECT *,0 AS RecordCount FROM Orders where OrderID = @OrderID; "; 
   var prset = new List<IDataParameter>();
  prset.Add(Db.CreateParameterDb("@OrderID", OrderID));
  DataSet ds = Db.GetDataSet(_sql1,prset);
return DataSetToList(ds).FirstOrDefault(); 
}public List<Orders> GetWithFilter(bool sortAscending, string sortExpression){
throw new Exception("Not implement");
string sql = "SELECT * FROM Orders "; 
sql += string.Format("  where ((''='{0}')or(OrderID='{0}'))", _Orders.OrderID);
sql += string.Format("  and ((''='{0}')or(CustomerID='{0}'))", _Orders.CustomerID);
sql += string.Format("  and ((''='{0}')or(EmployeeID='{0}'))", _Orders.EmployeeID);
sql += string.Format("  and ((''='{0}')or(OrderDate='{0}'))", _Orders.OrderDate);
sql += string.Format("  and ((''='{0}')or(RequiredDate='{0}'))", _Orders.RequiredDate);
sql += string.Format("  and ((''='{0}')or(ShippedDate='{0}'))", _Orders.ShippedDate);
sql += string.Format("  and ((''='{0}')or(ShipVia='{0}'))", _Orders.ShipVia);
sql += string.Format("  and ((''='{0}')or(Freight='{0}'))", _Orders.Freight);
sql += string.Format("  and ((''='{0}')or(ShipName='{0}'))", _Orders.ShipName);
sql += string.Format("  and ((''='{0}')or(ShipAddress='{0}'))", _Orders.ShipAddress);
sql += string.Format("  and ((''='{0}')or(ShipCity='{0}'))", _Orders.ShipCity);
sql += string.Format("  and ((''='{0}')or(ShipRegion='{0}'))", _Orders.ShipRegion);
sql += string.Format("  and ((''='{0}')or(ShipPostalCode='{0}'))", _Orders.ShipPostalCode);
sql += string.Format("  and ((''='{0}')or(ShipCountry='{0}'))", _Orders.ShipCountry);
if (sortExpression == null){
sql += string.Format(" order by OrderID ", sortExpression);}
else
{
}

DataSet ds = Db.GetDataSet(sql);return DataSetToList(ds);}
public List<Orders> GetPageWise(int pageIndex, int PageSize, string  wordFullText="") 
{ 
string store = "Sp_GetOrdersPageWise"; 
 
 
var dbParameter = GetParameter(pageIndex,PageSize);

 
 
DataSet ds = Db.GetDataSet(store, dbParameter, CommandType.StoredProcedure); 
return DataSetToList(ds); 
}
public object Insert() {
var prset = new List<IDataParameter>();var sql = "INSERT INTO Orders(CustomerID,EmployeeID,OrderDate,RequiredDate,ShippedDate,ShipVia,Freight,ShipName,ShipAddress,ShipCity,ShipRegion,ShipPostalCode,ShipCountry) VALUES (@CustomerID,@EmployeeID,@OrderDate,@RequiredDate,@ShippedDate,@ShipVia,@Freight,@ShipName,@ShipAddress,@ShipCity,@ShipRegion,@ShipPostalCode,@ShipCountry) ;SELECT SCOPE_IDENTITY();";
 prset.Add(Db.CreateParameterDb("@CustomerID",_Orders.CustomerID)); prset.Add(Db.CreateParameterDb("@EmployeeID",_Orders.EmployeeID)); prset.Add(Db.CreateParameterDb("@OrderDate",_Orders.OrderDate)); prset.Add(Db.CreateParameterDb("@RequiredDate",_Orders.RequiredDate)); prset.Add(Db.CreateParameterDb("@ShippedDate",_Orders.ShippedDate)); prset.Add(Db.CreateParameterDb("@ShipVia",_Orders.ShipVia)); prset.Add(Db.CreateParameterDb("@Freight",_Orders.Freight)); prset.Add(Db.CreateParameterDb("@ShipName",_Orders.ShipName)); prset.Add(Db.CreateParameterDb("@ShipAddress",_Orders.ShipAddress)); prset.Add(Db.CreateParameterDb("@ShipCity",_Orders.ShipCity)); prset.Add(Db.CreateParameterDb("@ShipRegion",_Orders.ShipRegion)); prset.Add(Db.CreateParameterDb("@ShipPostalCode",_Orders.ShipPostalCode)); prset.Add(Db.CreateParameterDb("@ShipCountry",_Orders.ShipCountry));

object output = Db.FbExecuteScalar(sql, prset);return output;  }

public void Update() {
var prset = new List<IDataParameter>();
 prset.Add(Db.CreateParameterDb("@OrderID",_Orders.OrderID)); prset.Add(Db.CreateParameterDb("@CustomerID",_Orders.CustomerID)); prset.Add(Db.CreateParameterDb("@EmployeeID",_Orders.EmployeeID)); prset.Add(Db.CreateParameterDb("@OrderDate",_Orders.OrderDate)); prset.Add(Db.CreateParameterDb("@RequiredDate",_Orders.RequiredDate)); prset.Add(Db.CreateParameterDb("@ShippedDate",_Orders.ShippedDate)); prset.Add(Db.CreateParameterDb("@ShipVia",_Orders.ShipVia)); prset.Add(Db.CreateParameterDb("@Freight",_Orders.Freight)); prset.Add(Db.CreateParameterDb("@ShipName",_Orders.ShipName)); prset.Add(Db.CreateParameterDb("@ShipAddress",_Orders.ShipAddress)); prset.Add(Db.CreateParameterDb("@ShipCity",_Orders.ShipCity)); prset.Add(Db.CreateParameterDb("@ShipRegion",_Orders.ShipRegion)); prset.Add(Db.CreateParameterDb("@ShipPostalCode",_Orders.ShipPostalCode)); prset.Add(Db.CreateParameterDb("@ShipCountry",_Orders.ShipCountry));
var sql = @"UPDATE   Orders SET  CustomerID=@CustomerID,EmployeeID=@EmployeeID,OrderDate=@OrderDate,RequiredDate=@RequiredDate,ShippedDate=@ShippedDate,ShipVia=@ShipVia,Freight=@Freight,ShipName=@ShipName,ShipAddress=@ShipAddress,ShipCity=@ShipCity,ShipRegion=@ShipRegion,ShipPostalCode=@ShipPostalCode,ShipCountry=@ShipCountry where OrderID = @OrderID";

int output = Db.FbExecuteNonQuery(sql, prset);
if (output != 1){
 throw new System.Exception("Update" + this.ToString());}   }

public void Delete() {
var prset = new List<IDataParameter>();
 prset.Add(Db.CreateParameterDb("@OrderID",_Orders.OrderID));
var sql =@"DELETE FROM Orders where OrderID=@OrderID";

int output = Db.FbExecuteNonQuery(sql, prset);
if (output != 1){
 throw new System.Exception("Delete" + this.ToString());}   }

private List<Orders> DataSetToList(DataSet ds) 
{
 EnumerableRowCollection<Orders> q = (from temp in ds.Tables[0].AsEnumerable()
 select new Orders
{
RecordCount = temp.Field<Int32>("RecordCount"),OrderID= temp.Field<Int32?>("OrderID"), 
 CustomerID= temp.Field<String>("CustomerID"), 
 EmployeeID= temp.Field<Int32?>("EmployeeID"), 
 OrderDate= temp.Field<DateTime?>("OrderDate"), 
 RequiredDate= temp.Field<DateTime?>("RequiredDate"), 
 ShippedDate= temp.Field<DateTime?>("ShippedDate"), 
 ShipVia= temp.Field<Int32?>("ShipVia"), 
 Freight= Convert.ToDecimal (temp.Field<Object>("Freight")), 
 ShipName= temp.Field<String>("ShipName"), 
 ShipAddress= temp.Field<String>("ShipAddress"), 
 ShipCity= temp.Field<String>("ShipCity"), 
 ShipRegion= temp.Field<String>("ShipRegion"), 
 ShipPostalCode= temp.Field<String>("ShipPostalCode"), 
 ShipCountry= temp.Field<String>("ShipCountry"), 
  });
  return q.ToList();
}
   public Boolean UpdateColumn(string id, string column,string value) 
        { 
            var prset = new List<IDataParameter>(); 
            prset.Add(Db.CreateParameterDb("@OrderID", id)); 
prset.Add(Db.CreateParameterDb("@Column", column));
            prset.Add(Db.CreateParameterDb("@Data", value)); 
   var sql = @"Sp_GetOrders_UpdateColumn";
            int output = Db.FbExecuteNonQuery(sql, prset, CommandType.StoredProcedure); 
            if (output == 1) 
            { 
                return true; 
            } 
 
            return false;   
        } 
 public List<string> GetKeyWordsAllColumn(string Keyword) 
    { 
        
        string sql = "Sp_GetOrders_Autocomplete"; 
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
          
 
  string sql = "SELECT  " + column + " FROM Orders where lower(" + column + ") like '" + keyword.ToLower() + "%'   group by " + column + " order by count(*) desc;"; 
         
         
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
            if ( _Orders.OrderID!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (OrderID='{0}') )", _Orders.OrderID); 
            } 
            if ( _Orders.CustomerID!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (CustomerID='{0}') )", _Orders.CustomerID); 
            } 
            if ( _Orders.EmployeeID!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (EmployeeID='{0}') )", _Orders.EmployeeID); 
            } 
            if ( _Orders.OrderDate!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (OrderDate='{0}') )", _Orders.OrderDate); 
            } 
            if ( _Orders.RequiredDate!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (RequiredDate='{0}') )", _Orders.RequiredDate); 
            } 
            if ( _Orders.ShippedDate!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (ShippedDate='{0}') )", _Orders.ShippedDate); 
            } 
            if ( _Orders.ShipVia!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (ShipVia='{0}') )", _Orders.ShipVia); 
            } 
            if ( _Orders.Freight!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (Freight='{0}') )", _Orders.Freight); 
            } 
            if ( _Orders.ShipName!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (ShipName='{0}') )", _Orders.ShipName); 
            } 
            if ( _Orders.ShipAddress!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (ShipAddress='{0}') )", _Orders.ShipAddress); 
            } 
            if ( _Orders.ShipCity!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (ShipCity='{0}') )", _Orders.ShipCity); 
            } 
            if ( _Orders.ShipRegion!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (ShipRegion='{0}') )", _Orders.ShipRegion); 
            } 
            if ( _Orders.ShipPostalCode!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (ShipPostalCode='{0}') )", _Orders.ShipPostalCode); 
            } 
            if ( _Orders.ShipCountry!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (ShipCountry='{0}') )", _Orders.ShipCountry); 
            } 
return sql;
}
      public List<IDataParameter> GetParameter(int pageIndex, int PageSize)
        {
            var sqlStorePamameters = new List<IDataParameter>();
            sqlStorePamameters.Add(Db.CreateParameterDb("@PageIndex", pageIndex));
            sqlStorePamameters.Add(Db.CreateParameterDb("@PageSize", PageSize));
if (_Orders.OrderID != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@OrderID", _Orders.OrderID));

            }
if (_Orders.CustomerID != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@CustomerID", _Orders.CustomerID));

            }
if (_Orders.EmployeeID != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@EmployeeID", _Orders.EmployeeID));

            }
if (_Orders.OrderDate != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@OrderDate", _Orders.OrderDate));

            }
if (_Orders.RequiredDate != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@RequiredDate", _Orders.RequiredDate));

            }
if (_Orders.ShippedDate != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@ShippedDate", _Orders.ShippedDate));

            }
if (_Orders.ShipVia != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@ShipVia", _Orders.ShipVia));

            }
if (_Orders.Freight != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@Freight", _Orders.Freight));

            }
if (_Orders.ShipName != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@ShipName", _Orders.ShipName));

            }
if (_Orders.ShipAddress != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@ShipAddress", _Orders.ShipAddress));

            }
if (_Orders.ShipCity != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@ShipCity", _Orders.ShipCity));

            }
if (_Orders.ShipRegion != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@ShipRegion", _Orders.ShipRegion));

            }
if (_Orders.ShipPostalCode != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@ShipPostalCode", _Orders.ShipPostalCode));

            }
if (_Orders.ShipCountry != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@ShipCountry", _Orders.ShipCountry));

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

