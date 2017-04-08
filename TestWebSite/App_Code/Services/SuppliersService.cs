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
 
public class SuppliersService : System.Web.Services.WebService 
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
            SuppliersDb _SuppliersDb = new SuppliersDb(); 
 
 
            bool isUpdate = _SuppliersDb.UpdateColumn(id, column, value); 
            return isUpdate; 
        }
[WebMethod] 
       public List<string> GetKeyWordsAllColumn(string keyword) 
       { 
           SuppliersDb _SuppliersDb = new SuppliersDb(); 
           List<string> keywords = _SuppliersDb.GetKeyWordsAllColumn(keyword); 
           return keywords; 
       }

[WebMethod] 
       public List<string> GetKeyWordsOneColumn(string column, string keyword) 
       { 
           SuppliersDb _SuppliersDb = new SuppliersDb(); 
           List<string> keywords = _SuppliersDb.GetKeyWordsOneColumn(column,keyword); 
           return keywords; 
       }


    [WebMethod]
public List<Suppliers> Search(string PageIndex,string PageSize,string SortExpression,string SortDirection,string SupplierID,string CompanyName,string ContactName,string ContactTitle,string Address,string City,string Region,string PostalCode,string Country,string Phone,string Fax,string HomePage)
    {
 Suppliers _Suppliers = new Suppliers(); 
  SuppliersDb _SuppliersDb = new SuppliersDb(); 
if (SupplierID!= "") _Suppliers.SupplierID = Convert.ToInt32(SupplierID);

if (CompanyName!= "") _Suppliers.CompanyName =  CompanyName; 


if (ContactName!= "") _Suppliers.ContactName =  ContactName; 


if (ContactTitle!= "") _Suppliers.ContactTitle =  ContactTitle; 


if (Address!= "") _Suppliers.Address =  Address; 


if (City!= "") _Suppliers.City =  City; 


if (Region!= "") _Suppliers.Region =  Region; 


if (PostalCode!= "") _Suppliers.PostalCode =  PostalCode; 


if (Country!= "") _Suppliers.Country =  Country; 


if (Phone!= "") _Suppliers.Phone =  Phone; 


if (Fax!= "") _Suppliers.Fax =  Fax; 


if (HomePage!= "") _Suppliers.HomePage =  HomePage; 


  _SuppliersDb._Suppliers = _Suppliers;
int _PageIndex = Convert.ToInt32(PageIndex);
int _PageSize = Convert.ToInt32(PageSize);

 if (SortExpression.Trim() != "")
        {
            _SuppliersDb._SortDirection = SortDirection;

            _SuppliersDb._SortExpression = SortExpression;
        }
return _SuppliersDb.GetPageWise(_PageIndex, _PageSize);
   }

    [WebMethod]
public string Save(string SupplierID,string CompanyName,string ContactName,string ContactTitle,string Address,string City,string Region,string PostalCode,string Country,string Phone,string Fax,string HomePage)
    {
 Suppliers _Suppliers = new Suppliers(); 
  SuppliersDb _SuppliersDb = new SuppliersDb(); 
// if (SupplierID!= "") _Suppliers.SupplierID = Convert.ToInt32(SupplierID);

if (CompanyName!= "") _Suppliers.CompanyName =  CompanyName; 


if (ContactName!= "") _Suppliers.ContactName =  ContactName; 


if (ContactTitle!= "") _Suppliers.ContactTitle =  ContactTitle; 


if (Address!= "") _Suppliers.Address =  Address; 


if (City!= "") _Suppliers.City =  City; 


if (Region!= "") _Suppliers.Region =  Region; 


if (PostalCode!= "") _Suppliers.PostalCode =  PostalCode; 


if (Country!= "") _Suppliers.Country =  Country; 


if (Phone!= "") _Suppliers.Phone =  Phone; 


if (Fax!= "") _Suppliers.Fax =  Fax; 


if (HomePage!= "") _Suppliers.HomePage =  HomePage; 


  _SuppliersDb._Suppliers = _Suppliers;
  object result= _SuppliersDb.Insert(); 
   return result.ToString();
   }

    [WebMethod]
public string Update(string SupplierID,string CompanyName,string ContactName,string ContactTitle,string Address,string City,string Region,string PostalCode,string Country,string Phone,string Fax,string HomePage)
    {
 Suppliers _Suppliers = new Suppliers(); 
  SuppliersDb _SuppliersDb = new SuppliersDb(); 
if (SupplierID!= "") _Suppliers.SupplierID = Convert.ToInt32(SupplierID);

if (CompanyName!= "") _Suppliers.CompanyName =  CompanyName; 


if (ContactName!= "") _Suppliers.ContactName =  ContactName; 


if (ContactTitle!= "") _Suppliers.ContactTitle =  ContactTitle; 


if (Address!= "") _Suppliers.Address =  Address; 


if (City!= "") _Suppliers.City =  City; 


if (Region!= "") _Suppliers.Region =  Region; 


if (PostalCode!= "") _Suppliers.PostalCode =  PostalCode; 


if (Country!= "") _Suppliers.Country =  Country; 


if (Phone!= "") _Suppliers.Phone =  Phone; 


if (Fax!= "") _Suppliers.Fax =  Fax; 


if (HomePage!= "") _Suppliers.HomePage =  HomePage; 


  _SuppliersDb._Suppliers = _Suppliers;
    _SuppliersDb.Update(); 
   return "";
   }

    [WebMethod]
public string Delete(string SupplierID,string CompanyName,string ContactName,string ContactTitle,string Address,string City,string Region,string PostalCode,string Country,string Phone,string Fax,string HomePage)
    {
 Suppliers _Suppliers = new Suppliers(); 
  SuppliersDb _SuppliersDb = new SuppliersDb(); 
if (SupplierID!= "") _Suppliers.SupplierID = Convert.ToInt32(SupplierID);

if (CompanyName!= "") _Suppliers.CompanyName =  CompanyName; 


if (ContactName!= "") _Suppliers.ContactName =  ContactName; 


if (ContactTitle!= "") _Suppliers.ContactTitle =  ContactTitle; 


if (Address!= "") _Suppliers.Address =  Address; 


if (City!= "") _Suppliers.City =  City; 


if (Region!= "") _Suppliers.Region =  Region; 


if (PostalCode!= "") _Suppliers.PostalCode =  PostalCode; 


if (Country!= "") _Suppliers.Country =  Country; 


if (Phone!= "") _Suppliers.Phone =  Phone; 


if (Fax!= "") _Suppliers.Fax =  Fax; 


if (HomePage!= "") _Suppliers.HomePage =  HomePage; 


  _SuppliersDb._Suppliers = _Suppliers;
    _SuppliersDb.Delete(); 
   return "";
   }
  [WebMethod]
    public List<SelectInputProperties> SelectAll()
    {
        SuppliersDb _SuppliersDb = new SuppliersDb();
        return _SuppliersDb.Select();
    }
 [WebMethod] 
   public Suppliers Select(string SupplierID)
    {
        SuppliersDb _SuppliersDb = new SuppliersDb();
        return _SuppliersDb.Select(SupplierID);
    }
}
