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
 
public class ShippersService : System.Web.Services.WebService 
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
            ShippersDb _ShippersDb = new ShippersDb(); 
 
 
            bool isUpdate = _ShippersDb.UpdateColumn(id, column, value); 
            return isUpdate; 
        }
[WebMethod] 
       public List<string> GetKeyWordsAllColumn(string keyword) 
       { 
           ShippersDb _ShippersDb = new ShippersDb(); 
           List<string> keywords = _ShippersDb.GetKeyWordsAllColumn(keyword); 
           return keywords; 
       }

[WebMethod] 
       public List<string> GetKeyWordsOneColumn(string column, string keyword) 
       { 
           ShippersDb _ShippersDb = new ShippersDb(); 
           List<string> keywords = _ShippersDb.GetKeyWordsOneColumn(column,keyword); 
           return keywords; 
       }


    [WebMethod]
public List<Shippers> Search(string PageIndex,string PageSize,string SortExpression,string SortDirection,string ShipperID,string CompanyName,string Phone)
    {
 Shippers _Shippers = new Shippers(); 
  ShippersDb _ShippersDb = new ShippersDb(); 
if (ShipperID!= "") _Shippers.ShipperID = Convert.ToInt32(ShipperID);

if (CompanyName!= "") _Shippers.CompanyName =  CompanyName; 


if (Phone!= "") _Shippers.Phone =  Phone; 


  _ShippersDb._Shippers = _Shippers;
int _PageIndex = Convert.ToInt32(PageIndex);
int _PageSize = Convert.ToInt32(PageSize);

 if (SortExpression.Trim() != "")
        {
            _ShippersDb._SortDirection = SortDirection;

            _ShippersDb._SortExpression = SortExpression;
        }
return _ShippersDb.GetPageWise(_PageIndex, _PageSize);
   }

    [WebMethod]
public string Save(string ShipperID,string CompanyName,string Phone)
    {
 Shippers _Shippers = new Shippers(); 
  ShippersDb _ShippersDb = new ShippersDb(); 
// if (ShipperID!= "") _Shippers.ShipperID = Convert.ToInt32(ShipperID);

if (CompanyName!= "") _Shippers.CompanyName =  CompanyName; 


if (Phone!= "") _Shippers.Phone =  Phone; 


  _ShippersDb._Shippers = _Shippers;
  object result= _ShippersDb.Insert(); 
   return result.ToString();
   }

    [WebMethod]
public string Update(string ShipperID,string CompanyName,string Phone)
    {
 Shippers _Shippers = new Shippers(); 
  ShippersDb _ShippersDb = new ShippersDb(); 
if (ShipperID!= "") _Shippers.ShipperID = Convert.ToInt32(ShipperID);

if (CompanyName!= "") _Shippers.CompanyName =  CompanyName; 


if (Phone!= "") _Shippers.Phone =  Phone; 


  _ShippersDb._Shippers = _Shippers;
    _ShippersDb.Update(); 
   return "";
   }

    [WebMethod]
public string Delete(string ShipperID,string CompanyName,string Phone)
    {
 Shippers _Shippers = new Shippers(); 
  ShippersDb _ShippersDb = new ShippersDb(); 
if (ShipperID!= "") _Shippers.ShipperID = Convert.ToInt32(ShipperID);

if (CompanyName!= "") _Shippers.CompanyName =  CompanyName; 


if (Phone!= "") _Shippers.Phone =  Phone; 


  _ShippersDb._Shippers = _Shippers;
    _ShippersDb.Delete(); 
   return "";
   }
  [WebMethod]
    public List<SelectInputProperties> SelectAll()
    {
        ShippersDb _ShippersDb = new ShippersDb();
        return _ShippersDb.Select();
    }
 [WebMethod] 
   public Shippers Select(string ShipperID)
    {
        ShippersDb _ShippersDb = new ShippersDb();
        return _ShippersDb.Select(ShipperID);
    }
}
