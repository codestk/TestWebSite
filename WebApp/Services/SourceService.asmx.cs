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
 
public class SourceService : System.Web.Services.WebService 
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
            SourceDb _SourceDb = new SourceDb(); 
 
 
            bool isUpdate = _SourceDb.UpdateColumn(id, column, value); 
            return isUpdate; 
        }
[WebMethod] 
       public List<string> GetKeyWordsAllColumn(string keyword) 
       { 
           SourceDb _SourceDb = new SourceDb(); 
           List<string> keywords = _SourceDb.GetKeyWordsAllColumn(keyword); 
           return keywords; 
       }

[WebMethod] 
       public List<string> GetKeyWordsOneColumn(string column, string keyword) 
       { 
           SourceDb _SourceDb = new SourceDb(); 
           List<string> keywords = _SourceDb.GetKeyWordsOneColumn(column,keyword); 
           return keywords; 
       }


    [WebMethod]
public List<Source> Search(string PageIndex,string PageSize,string SortExpression,string SortDirection,string SourceID,string SourceName,string SourceDetail)
    {
 Source _Source = new Source(); 
  SourceDb _SourceDb = new SourceDb(); 
if (SourceID!= "") _Source.SourceID =  SourceID; 


if (SourceName!= "") _Source.SourceName =  SourceName; 


if (SourceDetail!= "") _Source.SourceDetail =  SourceDetail; 


  _SourceDb._Source = _Source;
int _PageIndex = Convert.ToInt32(PageIndex);
int _PageSize = Convert.ToInt32(PageSize);

 if (SortExpression.Trim() != "")
        {
            _SourceDb._SortDirection = SortDirection;

            _SourceDb._SortExpression = SortExpression;
        }
return _SourceDb.GetPageWise(_PageIndex, _PageSize);
   }

    [WebMethod]
public string Save(string SourceID,string SourceName,string SourceDetail)
    {
 Source _Source = new Source(); 
  SourceDb _SourceDb = new SourceDb(); 
if (SourceID!= "") _Source.SourceID =  SourceID; 


if (SourceName!= "") _Source.SourceName =  SourceName; 


if (SourceDetail!= "") _Source.SourceDetail =  SourceDetail; 


  _SourceDb._Source = _Source;
  object result= _SourceDb.Insert(); 
   return result.ToString();
   }

    [WebMethod]
public string Update(string SourceID,string SourceName,string SourceDetail)
    {
 Source _Source = new Source(); 
  SourceDb _SourceDb = new SourceDb(); 
if (SourceID!= "") _Source.SourceID =  SourceID; 


if (SourceName!= "") _Source.SourceName =  SourceName; 


if (SourceDetail!= "") _Source.SourceDetail =  SourceDetail; 


  _SourceDb._Source = _Source;
    _SourceDb.Update(); 
   return "";
   }

    [WebMethod]
public string Delete(string SourceID,string SourceName,string SourceDetail)
    {
 Source _Source = new Source(); 
  SourceDb _SourceDb = new SourceDb(); 
if (SourceID!= "") _Source.SourceID =  SourceID; 


if (SourceName!= "") _Source.SourceName =  SourceName; 


if (SourceDetail!= "") _Source.SourceDetail =  SourceDetail; 


  _SourceDb._Source = _Source;
    _SourceDb.Delete(); 
   return "";
   }
  [WebMethod]
    public List<SelectInputProperties> SelectAll()
    {
        SourceDb _SourceDb = new SourceDb();
        return _SourceDb.Select();
    }
 [WebMethod] 
   public Source Select(string SourceID)
    {
        SourceDb _SourceDb = new SourceDb();
        return _SourceDb.Select(SourceID);
    }
}}