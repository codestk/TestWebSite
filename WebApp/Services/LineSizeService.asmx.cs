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
 
public class LineSizeService : System.Web.Services.WebService 
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
            LineSizeDb _LineSizeDb = new LineSizeDb(); 
 
 
            bool isUpdate = _LineSizeDb.UpdateColumn(id, column, value); 
            return isUpdate; 
        }
[WebMethod] 
       public List<string> GetKeyWordsAllColumn(string keyword) 
       { 
           LineSizeDb _LineSizeDb = new LineSizeDb(); 
           List<string> keywords = _LineSizeDb.GetKeyWordsAllColumn(keyword); 
           return keywords; 
       }

[WebMethod] 
       public List<string> GetKeyWordsOneColumn(string column, string keyword) 
       { 
           LineSizeDb _LineSizeDb = new LineSizeDb(); 
           List<string> keywords = _LineSizeDb.GetKeyWordsOneColumn(column,keyword); 
           return keywords; 
       }


    [WebMethod]
public List<LineSize> Search(string PageIndex,string PageSize,string SortExpression,string SortDirection,string LineSizeID,string LineSizeName,string LineSizeDetail)
    {
 LineSize _LineSize = new LineSize(); 
  LineSizeDb _LineSizeDb = new LineSizeDb(); 
if (LineSizeID!= "") _LineSize.LineSizeID =  LineSizeID; 


if (LineSizeName!= "") _LineSize.LineSizeName =  LineSizeName; 


if (LineSizeDetail!= "") _LineSize.LineSizeDetail =  LineSizeDetail; 


  _LineSizeDb._LineSize = _LineSize;
int _PageIndex = Convert.ToInt32(PageIndex);
int _PageSize = Convert.ToInt32(PageSize);

 if (SortExpression.Trim() != "")
        {
            _LineSizeDb._SortDirection = SortDirection;

            _LineSizeDb._SortExpression = SortExpression;
        }
return _LineSizeDb.GetPageWise(_PageIndex, _PageSize);
   }

    [WebMethod]
public string Save(string LineSizeID,string LineSizeName,string LineSizeDetail)
    {
 LineSize _LineSize = new LineSize(); 
  LineSizeDb _LineSizeDb = new LineSizeDb(); 
if (LineSizeID!= "") _LineSize.LineSizeID =  LineSizeID; 


if (LineSizeName!= "") _LineSize.LineSizeName =  LineSizeName; 


if (LineSizeDetail!= "") _LineSize.LineSizeDetail =  LineSizeDetail; 


  _LineSizeDb._LineSize = _LineSize;
  object result= _LineSizeDb.Insert(); 
   return result.ToString();
   }

    [WebMethod]
public string Update(string LineSizeID,string LineSizeName,string LineSizeDetail)
    {
 LineSize _LineSize = new LineSize(); 
  LineSizeDb _LineSizeDb = new LineSizeDb(); 
if (LineSizeID!= "") _LineSize.LineSizeID =  LineSizeID; 


if (LineSizeName!= "") _LineSize.LineSizeName =  LineSizeName; 


if (LineSizeDetail!= "") _LineSize.LineSizeDetail =  LineSizeDetail; 


  _LineSizeDb._LineSize = _LineSize;
    _LineSizeDb.Update(); 
   return "";
   }

    [WebMethod]
public string Delete(string LineSizeID,string LineSizeName,string LineSizeDetail)
    {
 LineSize _LineSize = new LineSize(); 
  LineSizeDb _LineSizeDb = new LineSizeDb(); 
if (LineSizeID!= "") _LineSize.LineSizeID =  LineSizeID; 


if (LineSizeName!= "") _LineSize.LineSizeName =  LineSizeName; 


if (LineSizeDetail!= "") _LineSize.LineSizeDetail =  LineSizeDetail; 


  _LineSizeDb._LineSize = _LineSize;
    _LineSizeDb.Delete(); 
   return "";
   }
  [WebMethod]
    public List<SelectInputProperties> SelectAll()
    {
        LineSizeDb _LineSizeDb = new LineSizeDb();
        return _LineSizeDb.Select();
    }
 [WebMethod] 
   public LineSize Select(string LineSizeID)
    {
        LineSizeDb _LineSizeDb = new LineSizeDb();
        return _LineSizeDb.Select(LineSizeID);
    }
}}