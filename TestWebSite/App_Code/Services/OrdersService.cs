using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Web; 
using System.Web.Services; 
    /// <summary> 
    /// Summary description for AutoCompleteService 
    /// </summary> 
    [WebService(Namespace = "http://tempuri.org/")] 
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)] 
    [System.ComponentModel.ToolboxItem(false)] 
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.  
     [System.Web.Script.Services.ScriptService] 
 
public class OrdersService : System.Web.Services.WebService 
{
 
        [WebMethod] 
        public string Service()
        { 
            return "1.0.0.1";
        } 
 //For Jquery  ---------------------------------------------------------------------------------------------- 
        [WebMethod] 
        public   Boolean SaveColumn(string id, string column, string value) 
        { 
            OrdersDb _OrdersDb = new OrdersDb(); 
 
 
            bool isUpdate = _OrdersDb.UpdateColumn(id, column, value); 
            return isUpdate; 
        }
[WebMethod] 
       public List<string> GetKeyWordsAllColumn(string keyword) 
       { 
           OrdersDb _OrdersDb = new OrdersDb(); 
           List<string> keywords = _OrdersDb.GetKeyWordsAllColumn(keyword); 
           return keywords; 
       }

[WebMethod] 
       public List<string> GetKeyWordsOneColumn(string column, string keyword) 
       { 
           OrdersDb _OrdersDb = new OrdersDb(); 
           List<string> keywords = _OrdersDb.GetKeyWordsOneColumn(column,keyword); 
           return keywords; 
       }


    [WebMethod]
public List<Orders> Search(string PageIndex,string PageSize,string SortExpression,string SortDirection,string OrderID,string CustomerID,string EmployeeID,string OrderDate,string RequiredDate,string ShippedDate,string ShipVia,string Freight,string ShipName,string ShipAddress,string ShipCity,string ShipRegion,string ShipPostalCode,string ShipCountry)
    {
 Orders _Orders = new Orders(); 
  OrdersDb _OrdersDb = new OrdersDb(); 
if (OrderID!= "") _Orders.OrderID = Convert.ToInt32(OrderID);

if (CustomerID!= "") _Orders.CustomerID =  CustomerID; 


if (EmployeeID!= "") _Orders.EmployeeID = Convert.ToInt32(EmployeeID);

if (OrderDate!= "") _Orders.OrderDate =StkGlobalDate.TextEnToDate(OrderDate);

if (RequiredDate!= "") _Orders.RequiredDate =StkGlobalDate.TextEnToDate(RequiredDate);

if (ShippedDate!= "") _Orders.ShippedDate =StkGlobalDate.TextEnToDate(ShippedDate);

if (ShipVia!= "") _Orders.ShipVia = Convert.ToInt32(ShipVia);

if (Freight!= "") _Orders.Freight =  Convert.ToDecimal (Freight);

if (ShipName!= "") _Orders.ShipName =  ShipName; 


if (ShipAddress!= "") _Orders.ShipAddress =  ShipAddress; 


if (ShipCity!= "") _Orders.ShipCity =  ShipCity; 


if (ShipRegion!= "") _Orders.ShipRegion =  ShipRegion; 


if (ShipPostalCode!= "") _Orders.ShipPostalCode =  ShipPostalCode; 


if (ShipCountry!= "") _Orders.ShipCountry =  ShipCountry; 


  _OrdersDb._Orders = _Orders;
int _PageIndex = Convert.ToInt32(PageIndex);
int _PageSize = Convert.ToInt32(PageSize);

 if (SortExpression.Trim() != "")
        {
            _OrdersDb._SortDirection = SortDirection;

            _OrdersDb._SortExpression = SortExpression;
        }
return _OrdersDb.GetPageWise(_PageIndex, _PageSize);
   }

    [WebMethod]
public string Save(string OrderID,string CustomerID,string EmployeeID,string OrderDate,string RequiredDate,string ShippedDate,string ShipVia,string Freight,string ShipName,string ShipAddress,string ShipCity,string ShipRegion,string ShipPostalCode,string ShipCountry)
    {
 Orders _Orders = new Orders(); 
  OrdersDb _OrdersDb = new OrdersDb(); 
// if (OrderID!= "") _Orders.OrderID = Convert.ToInt32(OrderID);

if (CustomerID!= "") _Orders.CustomerID =  CustomerID; 


if (EmployeeID!= "") _Orders.EmployeeID = Convert.ToInt32(EmployeeID);

if (OrderDate!= "") _Orders.OrderDate =StkGlobalDate.TextEnToDate(OrderDate);

if (RequiredDate!= "") _Orders.RequiredDate =StkGlobalDate.TextEnToDate(RequiredDate);

if (ShippedDate!= "") _Orders.ShippedDate =StkGlobalDate.TextEnToDate(ShippedDate);

if (ShipVia!= "") _Orders.ShipVia = Convert.ToInt32(ShipVia);

if (Freight!= "") _Orders.Freight =  Convert.ToDecimal (Freight);

if (ShipName!= "") _Orders.ShipName =  ShipName; 


if (ShipAddress!= "") _Orders.ShipAddress =  ShipAddress; 


if (ShipCity!= "") _Orders.ShipCity =  ShipCity; 


if (ShipRegion!= "") _Orders.ShipRegion =  ShipRegion; 


if (ShipPostalCode!= "") _Orders.ShipPostalCode =  ShipPostalCode; 


if (ShipCountry!= "") _Orders.ShipCountry =  ShipCountry; 


  _OrdersDb._Orders = _Orders;
  object result= _OrdersDb.Insert(); 
   return result.ToString();
   }

    [WebMethod]
public string Update(string OrderID,string CustomerID,string EmployeeID,string OrderDate,string RequiredDate,string ShippedDate,string ShipVia,string Freight,string ShipName,string ShipAddress,string ShipCity,string ShipRegion,string ShipPostalCode,string ShipCountry)
    {
 Orders _Orders = new Orders(); 
  OrdersDb _OrdersDb = new OrdersDb(); 
if (OrderID!= "") _Orders.OrderID = Convert.ToInt32(OrderID);

if (CustomerID!= "") _Orders.CustomerID =  CustomerID; 


if (EmployeeID!= "") _Orders.EmployeeID = Convert.ToInt32(EmployeeID);

if (OrderDate!= "") _Orders.OrderDate =StkGlobalDate.TextEnToDate(OrderDate);

if (RequiredDate!= "") _Orders.RequiredDate =StkGlobalDate.TextEnToDate(RequiredDate);

if (ShippedDate!= "") _Orders.ShippedDate =StkGlobalDate.TextEnToDate(ShippedDate);

if (ShipVia!= "") _Orders.ShipVia = Convert.ToInt32(ShipVia);

if (Freight!= "") _Orders.Freight =  Convert.ToDecimal (Freight);

if (ShipName!= "") _Orders.ShipName =  ShipName; 


if (ShipAddress!= "") _Orders.ShipAddress =  ShipAddress; 


if (ShipCity!= "") _Orders.ShipCity =  ShipCity; 


if (ShipRegion!= "") _Orders.ShipRegion =  ShipRegion; 


if (ShipPostalCode!= "") _Orders.ShipPostalCode =  ShipPostalCode; 


if (ShipCountry!= "") _Orders.ShipCountry =  ShipCountry; 


  _OrdersDb._Orders = _Orders;
    _OrdersDb.Update(); 
   return "";
   }

    [WebMethod]
public string Delete(string OrderID,string CustomerID,string EmployeeID,string OrderDate,string RequiredDate,string ShippedDate,string ShipVia,string Freight,string ShipName,string ShipAddress,string ShipCity,string ShipRegion,string ShipPostalCode,string ShipCountry)
    {
 Orders _Orders = new Orders(); 
  OrdersDb _OrdersDb = new OrdersDb(); 
if (OrderID!= "") _Orders.OrderID = Convert.ToInt32(OrderID);

if (CustomerID!= "") _Orders.CustomerID =  CustomerID; 


if (EmployeeID!= "") _Orders.EmployeeID = Convert.ToInt32(EmployeeID);

if (OrderDate!= "") _Orders.OrderDate =StkGlobalDate.TextEnToDate(OrderDate);

if (RequiredDate!= "") _Orders.RequiredDate =StkGlobalDate.TextEnToDate(RequiredDate);

if (ShippedDate!= "") _Orders.ShippedDate =StkGlobalDate.TextEnToDate(ShippedDate);

if (ShipVia!= "") _Orders.ShipVia = Convert.ToInt32(ShipVia);

if (Freight!= "") _Orders.Freight =  Convert.ToDecimal (Freight);

if (ShipName!= "") _Orders.ShipName =  ShipName; 


if (ShipAddress!= "") _Orders.ShipAddress =  ShipAddress; 


if (ShipCity!= "") _Orders.ShipCity =  ShipCity; 


if (ShipRegion!= "") _Orders.ShipRegion =  ShipRegion; 


if (ShipPostalCode!= "") _Orders.ShipPostalCode =  ShipPostalCode; 


if (ShipCountry!= "") _Orders.ShipCountry =  ShipCountry; 


  _OrdersDb._Orders = _Orders;
    _OrdersDb.Delete(); 
   return "";
   }
  [WebMethod]
    public List<SelectInputProperties> SelectAll()
    {
        OrdersDb _OrdersDb = new OrdersDb();
        return _OrdersDb.Select();
    }
 [WebMethod] 
   public Orders Select(string OrderID)
    {
        OrdersDb _OrdersDb = new OrdersDb();
        return _OrdersDb.Select(OrderID);
    }
}
