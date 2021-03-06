using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Web; 
using System.Web.Services; 
using WebApp.Business;
using StkLib.Common;
using WebApp.Code.Utility.Properties.Controls;
namespace WebApp.Services  
{
    /// <summary> 
    /// Summary description for AutoCompleteService 
    /// </summary> 
    [WebService(Namespace = "http://tempuri.org/")] 
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)] 
    [System.ComponentModel.ToolboxItem(false)] 
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.  
     [System.Web.Script.Services.ScriptService] 
 
public class CustomerBrandService : System.Web.Services.WebService 
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
            CustomerBrandDb _CustomerBrandDb = new CustomerBrandDb(); 
 
 
            bool isUpdate = _CustomerBrandDb.UpdateColumn(id, column, value); 
            return isUpdate; 
        }
[WebMethod] 
       public List<string> GetKeyWordsAllColumn(string keyword) 
       { 
           CustomerBrandDb _CustomerBrandDb = new CustomerBrandDb(); 
           List<string> keywords = _CustomerBrandDb.GetKeyWordsAllColumn(keyword); 
           return keywords; 
       }

[WebMethod] 
       public List<string> GetKeyWordsOneColumn(string column, string keyword) 
       { 
           CustomerBrandDb _CustomerBrandDb = new CustomerBrandDb(); 
           List<string> keywords = _CustomerBrandDb.GetKeyWordsOneColumn(column,keyword); 
           return keywords; 
       }


    [WebMethod]
public List<CustomerBrand> Search(string PageIndex,string PageSize,string SortExpression,string SortDirection,string CustomerBrandID,string CustomerBrandName,string CustomerBrandDetail)
    {
 CustomerBrand _CustomerBrand = new CustomerBrand(); 
  CustomerBrandDb _CustomerBrandDb = new CustomerBrandDb(); 
if (CustomerBrandID!= "") _CustomerBrand.CustomerBrandID =  CustomerBrandID; 


if (CustomerBrandName!= "") _CustomerBrand.CustomerBrandName =  CustomerBrandName; 


if (CustomerBrandDetail!= "") _CustomerBrand.CustomerBrandDetail =  CustomerBrandDetail; 


  _CustomerBrandDb._CustomerBrand = _CustomerBrand;
int _PageIndex = Convert.ToInt32(PageIndex);
int _PageSize = Convert.ToInt32(PageSize);

 if (SortExpression.Trim() != "")
        {
            _CustomerBrandDb._SortDirection = SortDirection;

            _CustomerBrandDb._SortExpression = SortExpression;
        }
return _CustomerBrandDb.GetPageWise(_PageIndex, _PageSize);
   }

    [WebMethod]
public string Save(string CustomerBrandID,string CustomerBrandName,string CustomerBrandDetail)
    {
 CustomerBrand _CustomerBrand = new CustomerBrand(); 
  CustomerBrandDb _CustomerBrandDb = new CustomerBrandDb(); 
if (CustomerBrandID!= "") _CustomerBrand.CustomerBrandID =  CustomerBrandID; 


if (CustomerBrandName!= "") _CustomerBrand.CustomerBrandName =  CustomerBrandName; 


if (CustomerBrandDetail!= "") _CustomerBrand.CustomerBrandDetail =  CustomerBrandDetail; 


  _CustomerBrandDb._CustomerBrand = _CustomerBrand;
  object result= _CustomerBrandDb.Insert(); 
   return result.ToString();
   }

    [WebMethod]
public string Update(string CustomerBrandID,string CustomerBrandName,string CustomerBrandDetail)
    {
 CustomerBrand _CustomerBrand = new CustomerBrand(); 
  CustomerBrandDb _CustomerBrandDb = new CustomerBrandDb(); 
if (CustomerBrandID!= "") _CustomerBrand.CustomerBrandID =  CustomerBrandID; 


if (CustomerBrandName!= "") _CustomerBrand.CustomerBrandName =  CustomerBrandName; 


if (CustomerBrandDetail!= "") _CustomerBrand.CustomerBrandDetail =  CustomerBrandDetail; 


  _CustomerBrandDb._CustomerBrand = _CustomerBrand;
    _CustomerBrandDb.Update(); 
   return "";
   }

    [WebMethod]
public string Delete(string CustomerBrandID,string CustomerBrandName,string CustomerBrandDetail)
    {
 CustomerBrand _CustomerBrand = new CustomerBrand(); 
  CustomerBrandDb _CustomerBrandDb = new CustomerBrandDb(); 
if (CustomerBrandID!= "") _CustomerBrand.CustomerBrandID =  CustomerBrandID; 


if (CustomerBrandName!= "") _CustomerBrand.CustomerBrandName =  CustomerBrandName; 


if (CustomerBrandDetail!= "") _CustomerBrand.CustomerBrandDetail =  CustomerBrandDetail; 


  _CustomerBrandDb._CustomerBrand = _CustomerBrand;
    _CustomerBrandDb.Delete(); 
   return "";
   }
  [WebMethod]
    public List<SelectInputProperties> SelectAll()
    {
        CustomerBrandDb _CustomerBrandDb = new CustomerBrandDb();
        return _CustomerBrandDb.Select();
    }
 [WebMethod] 
   public CustomerBrand Select(string CustomerBrandID)
    {
        CustomerBrandDb _CustomerBrandDb = new CustomerBrandDb();
        return _CustomerBrandDb.Select(CustomerBrandID);
    }
}}