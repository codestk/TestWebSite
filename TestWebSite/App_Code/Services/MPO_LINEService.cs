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
 
public class MPO_LINEService : System.Web.Services.WebService 
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
            MPO_LINEDb _MPO_LINEDb = new MPO_LINEDb(); 
 
 
            bool isUpdate = _MPO_LINEDb.UpdateColumn(id, column, value); 
            return isUpdate; 
        }
[WebMethod] 
       public List<string> GetKeyWordsAllColumn(string keyword) 
       { 
           MPO_LINEDb _MPO_LINEDb = new MPO_LINEDb(); 
           List<string> keywords = _MPO_LINEDb.GetKeyWordsAllColumn(keyword); 
           return keywords; 
       }

[WebMethod] 
       public List<string> GetKeyWordsOneColumn(string column, string keyword) 
       { 
           MPO_LINEDb _MPO_LINEDb = new MPO_LINEDb(); 
           List<string> keywords = _MPO_LINEDb.GetKeyWordsOneColumn(column,keyword); 
           return keywords; 
       }


    [WebMethod]
public List<MPO_LINE> Search(string PageIndex,string PageSize,string SortExpression,string SortDirection,string PR_LINE,string LINE_DEC)
    {
 MPO_LINE _MPO_LINE = new MPO_LINE(); 
  MPO_LINEDb _MPO_LINEDb = new MPO_LINEDb(); 
if (PR_LINE!= "") _MPO_LINE.PR_LINE =  PR_LINE; 


if (LINE_DEC!= "") _MPO_LINE.LINE_DEC =  LINE_DEC; 


  _MPO_LINEDb._MPO_LINE = _MPO_LINE;
int _PageIndex = Convert.ToInt32(PageIndex);
int _PageSize = Convert.ToInt32(PageSize);

 if (SortExpression.Trim() != "")
        {
            _MPO_LINEDb._SortDirection = SortDirection;

            _MPO_LINEDb._SortExpression = SortExpression;
        }
return _MPO_LINEDb.GetPageWise(_PageIndex, _PageSize);
   }

    [WebMethod]
public string Save(string PR_LINE,string LINE_DEC)
    {
 MPO_LINE _MPO_LINE = new MPO_LINE(); 
  MPO_LINEDb _MPO_LINEDb = new MPO_LINEDb(); 
if (PR_LINE!= "") _MPO_LINE.PR_LINE =  PR_LINE; 


if (LINE_DEC!= "") _MPO_LINE.LINE_DEC =  LINE_DEC; 


  _MPO_LINEDb._MPO_LINE = _MPO_LINE;
  object result= _MPO_LINEDb.Insert(); 
   return result.ToString();
   }

    [WebMethod]
public string Update(string PR_LINE,string LINE_DEC)
    {
 MPO_LINE _MPO_LINE = new MPO_LINE(); 
  MPO_LINEDb _MPO_LINEDb = new MPO_LINEDb(); 
if (PR_LINE!= "") _MPO_LINE.PR_LINE =  PR_LINE; 


if (LINE_DEC!= "") _MPO_LINE.LINE_DEC =  LINE_DEC; 


  _MPO_LINEDb._MPO_LINE = _MPO_LINE;
    _MPO_LINEDb.Update(); 
   return "";
   }

    [WebMethod]
public string Delete(string PR_LINE,string LINE_DEC)
    {
 MPO_LINE _MPO_LINE = new MPO_LINE(); 
  MPO_LINEDb _MPO_LINEDb = new MPO_LINEDb(); 
if (PR_LINE!= "") _MPO_LINE.PR_LINE =  PR_LINE; 


if (LINE_DEC!= "") _MPO_LINE.LINE_DEC =  LINE_DEC; 


  _MPO_LINEDb._MPO_LINE = _MPO_LINE;
    _MPO_LINEDb.Delete(); 
   return "";
   }
  [WebMethod]
    public List<SelectInputProperties> SelectAll()
    {
        MPO_LINEDb _MPO_LINEDb = new MPO_LINEDb();
        return _MPO_LINEDb.Select();
    }
 [WebMethod] 
   public MPO_LINE Select(string PR_LINE)
    {
        MPO_LINEDb _MPO_LINEDb = new MPO_LINEDb();
        return _MPO_LINEDb.Select(PR_LINE);
    }
}
