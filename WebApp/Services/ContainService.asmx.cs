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
 
public class ContainService : System.Web.Services.WebService 
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
            ContainDb _ContainDb = new ContainDb(); 
 
 
            bool isUpdate = _ContainDb.UpdateColumn(id, column, value); 
            return isUpdate; 
        }
[WebMethod] 
       public List<string> GetKeyWordsAllColumn(string keyword) 
       { 
           ContainDb _ContainDb = new ContainDb(); 
           List<string> keywords = _ContainDb.GetKeyWordsAllColumn(keyword); 
           return keywords; 
       }

[WebMethod] 
       public List<string> GetKeyWordsOneColumn(string column, string keyword) 
       { 
           ContainDb _ContainDb = new ContainDb(); 
           List<string> keywords = _ContainDb.GetKeyWordsOneColumn(column,keyword); 
           return keywords; 
       }


    [WebMethod]
public List<Contain> Search(string PageIndex,string PageSize,string SortExpression,string SortDirection,string ContainID,string ContainName,string ContainDetail)
    {
 Contain _Contain = new Contain(); 
  ContainDb _ContainDb = new ContainDb(); 
if (ContainID!= "") _Contain.ContainID =  ContainID; 


if (ContainName!= "") _Contain.ContainName =  ContainName; 


if (ContainDetail!= "") _Contain.ContainDetail =  ContainDetail; 


  _ContainDb._Contain = _Contain;
int _PageIndex = Convert.ToInt32(PageIndex);
int _PageSize = Convert.ToInt32(PageSize);

 if (SortExpression.Trim() != "")
        {
            _ContainDb._SortDirection = SortDirection;

            _ContainDb._SortExpression = SortExpression;
        }
return _ContainDb.GetPageWise(_PageIndex, _PageSize);
   }

    [WebMethod]
public string Save(string ContainID,string ContainName,string ContainDetail)
    {
 Contain _Contain = new Contain(); 
  ContainDb _ContainDb = new ContainDb(); 
if (ContainID!= "") _Contain.ContainID =  ContainID; 


if (ContainName!= "") _Contain.ContainName =  ContainName; 


if (ContainDetail!= "") _Contain.ContainDetail =  ContainDetail; 


  _ContainDb._Contain = _Contain;
  object result= _ContainDb.Insert(); 
   return result.ToString();
   }

    [WebMethod]
public string Update(string ContainID,string ContainName,string ContainDetail)
    {
 Contain _Contain = new Contain(); 
  ContainDb _ContainDb = new ContainDb(); 
if (ContainID!= "") _Contain.ContainID =  ContainID; 


if (ContainName!= "") _Contain.ContainName =  ContainName; 


if (ContainDetail!= "") _Contain.ContainDetail =  ContainDetail; 


  _ContainDb._Contain = _Contain;
    _ContainDb.Update(); 
   return "";
   }

    [WebMethod]
public string Delete(string ContainID,string ContainName,string ContainDetail)
    {
 Contain _Contain = new Contain(); 
  ContainDb _ContainDb = new ContainDb(); 
if (ContainID!= "") _Contain.ContainID =  ContainID; 


if (ContainName!= "") _Contain.ContainName =  ContainName; 


if (ContainDetail!= "") _Contain.ContainDetail =  ContainDetail; 


  _ContainDb._Contain = _Contain;
    _ContainDb.Delete(); 
   return "";
   }
  [WebMethod]
    public List<SelectInputProperties> SelectAll()
    {
        ContainDb _ContainDb = new ContainDb();
        return _ContainDb.Select();
    }
 [WebMethod] 
   public Contain Select(string ContainID)
    {
        ContainDb _ContainDb = new ContainDb();
        return _ContainDb.Select(ContainID);
    }
}}