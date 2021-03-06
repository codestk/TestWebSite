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
 
public class LineService : System.Web.Services.WebService 
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
            LineDb _LineDb = new LineDb(); 
 
 
            bool isUpdate = _LineDb.UpdateColumn(id, column, value); 
            return isUpdate; 
        }
[WebMethod] 
       public List<string> GetKeyWordsAllColumn(string keyword) 
       { 
           LineDb _LineDb = new LineDb(); 
           List<string> keywords = _LineDb.GetKeyWordsAllColumn(keyword); 
           return keywords; 
       }

[WebMethod] 
       public List<string> GetKeyWordsOneColumn(string column, string keyword) 
       { 
           LineDb _LineDb = new LineDb(); 
           List<string> keywords = _LineDb.GetKeyWordsOneColumn(column,keyword); 
           return keywords; 
       }


    [WebMethod]
public List<Line> Search(string PageIndex,string PageSize,string SortExpression,string SortDirection,string LineID,string LineName,string LineDetail)
    {
 Line _Line = new Line(); 
  LineDb _LineDb = new LineDb(); 
if (LineID!= "") _Line.LineID =  LineID; 


if (LineName!= "") _Line.LineName =  LineName; 


if (LineDetail!= "") _Line.LineDetail =  LineDetail; 


  _LineDb._Line = _Line;
int _PageIndex = Convert.ToInt32(PageIndex);
int _PageSize = Convert.ToInt32(PageSize);

 if (SortExpression.Trim() != "")
        {
            _LineDb._SortDirection = SortDirection;

            _LineDb._SortExpression = SortExpression;
        }
return _LineDb.GetPageWise(_PageIndex, _PageSize);
   }

    [WebMethod]
public string Save(string LineID,string LineName,string LineDetail)
    {
 Line _Line = new Line(); 
  LineDb _LineDb = new LineDb(); 
if (LineID!= "") _Line.LineID =  LineID; 


if (LineName!= "") _Line.LineName =  LineName; 


if (LineDetail!= "") _Line.LineDetail =  LineDetail; 


  _LineDb._Line = _Line;
  object result= _LineDb.Insert(); 
   return result.ToString();
   }

    [WebMethod]
public string Update(string LineID,string LineName,string LineDetail)
    {
 Line _Line = new Line(); 
  LineDb _LineDb = new LineDb(); 
if (LineID!= "") _Line.LineID =  LineID; 


if (LineName!= "") _Line.LineName =  LineName; 


if (LineDetail!= "") _Line.LineDetail =  LineDetail; 


  _LineDb._Line = _Line;
    _LineDb.Update(); 
   return "";
   }

    [WebMethod]
public string Delete(string LineID,string LineName,string LineDetail)
    {
 Line _Line = new Line(); 
  LineDb _LineDb = new LineDb(); 
if (LineID!= "") _Line.LineID =  LineID; 


if (LineName!= "") _Line.LineName =  LineName; 


if (LineDetail!= "") _Line.LineDetail =  LineDetail; 


  _LineDb._Line = _Line;
    _LineDb.Delete(); 
   return "";
   }
  [WebMethod]
    public List<SelectInputProperties> SelectAll()
    {
        LineDb _LineDb = new LineDb();
        return _LineDb.Select();
    }
 [WebMethod] 
   public Line Select(string LineID)
    {
        LineDb _LineDb = new LineDb();
        return _LineDb.Select(LineID);
    }
}}