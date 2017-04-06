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
 
public class MPO_PRODUCT_LINEService : System.Web.Services.WebService 
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
            MPO_PRODUCT_LINEDb _MPO_PRODUCT_LINEDb = new MPO_PRODUCT_LINEDb(); 
 
 
            bool isUpdate = _MPO_PRODUCT_LINEDb.UpdateColumn(id, column, value); 
            return isUpdate; 
        }
[WebMethod] 
       public List<string> GetKeyWordsAllColumn(string keyword) 
       { 
           MPO_PRODUCT_LINEDb _MPO_PRODUCT_LINEDb = new MPO_PRODUCT_LINEDb(); 
           List<string> keywords = _MPO_PRODUCT_LINEDb.GetKeyWordsAllColumn(keyword); 
           return keywords; 
       }

[WebMethod] 
       public List<string> GetKeyWordsOneColumn(string column, string keyword) 
       { 
           MPO_PRODUCT_LINEDb _MPO_PRODUCT_LINEDb = new MPO_PRODUCT_LINEDb(); 
           List<string> keywords = _MPO_PRODUCT_LINEDb.GetKeyWordsOneColumn(column,keyword); 
           return keywords; 
       }


    [WebMethod]
public List<MPO_PRODUCT_LINE> Search(string PageIndex,string PageSize,string SortExpression,string SortDirection,string PR_PRODUCT_LINE,string PRODUCT_LINE_DEC)
    {
 MPO_PRODUCT_LINE _MPO_PRODUCT_LINE = new MPO_PRODUCT_LINE(); 
  MPO_PRODUCT_LINEDb _MPO_PRODUCT_LINEDb = new MPO_PRODUCT_LINEDb(); 
if (PR_PRODUCT_LINE!= "") _MPO_PRODUCT_LINE.PR_PRODUCT_LINE =  PR_PRODUCT_LINE; 


if (PRODUCT_LINE_DEC!= "") _MPO_PRODUCT_LINE.PRODUCT_LINE_DEC =  PRODUCT_LINE_DEC; 


  _MPO_PRODUCT_LINEDb._MPO_PRODUCT_LINE = _MPO_PRODUCT_LINE;
int _PageIndex = Convert.ToInt32(PageIndex);
int _PageSize = Convert.ToInt32(PageSize);

 if (SortExpression.Trim() != "")
        {
            _MPO_PRODUCT_LINEDb._SortDirection = SortDirection;

            _MPO_PRODUCT_LINEDb._SortExpression = SortExpression;
        }
return _MPO_PRODUCT_LINEDb.GetPageWise(_PageIndex, _PageSize);
   }

    [WebMethod]
public string Save(string PR_PRODUCT_LINE,string PRODUCT_LINE_DEC)
    {
 MPO_PRODUCT_LINE _MPO_PRODUCT_LINE = new MPO_PRODUCT_LINE(); 
  MPO_PRODUCT_LINEDb _MPO_PRODUCT_LINEDb = new MPO_PRODUCT_LINEDb(); 
if (PR_PRODUCT_LINE!= "") _MPO_PRODUCT_LINE.PR_PRODUCT_LINE =  PR_PRODUCT_LINE; 


if (PRODUCT_LINE_DEC!= "") _MPO_PRODUCT_LINE.PRODUCT_LINE_DEC =  PRODUCT_LINE_DEC; 


  _MPO_PRODUCT_LINEDb._MPO_PRODUCT_LINE = _MPO_PRODUCT_LINE;
  object result= _MPO_PRODUCT_LINEDb.Insert(); 
   return result.ToString();
   }

    [WebMethod]
public string Update(string PR_PRODUCT_LINE,string PRODUCT_LINE_DEC)
    {
 MPO_PRODUCT_LINE _MPO_PRODUCT_LINE = new MPO_PRODUCT_LINE(); 
  MPO_PRODUCT_LINEDb _MPO_PRODUCT_LINEDb = new MPO_PRODUCT_LINEDb(); 
if (PR_PRODUCT_LINE!= "") _MPO_PRODUCT_LINE.PR_PRODUCT_LINE =  PR_PRODUCT_LINE; 


if (PRODUCT_LINE_DEC!= "") _MPO_PRODUCT_LINE.PRODUCT_LINE_DEC =  PRODUCT_LINE_DEC; 


  _MPO_PRODUCT_LINEDb._MPO_PRODUCT_LINE = _MPO_PRODUCT_LINE;
    _MPO_PRODUCT_LINEDb.Update(); 
   return "";
   }

    [WebMethod]
public string Delete(string PR_PRODUCT_LINE,string PRODUCT_LINE_DEC)
    {
 MPO_PRODUCT_LINE _MPO_PRODUCT_LINE = new MPO_PRODUCT_LINE(); 
  MPO_PRODUCT_LINEDb _MPO_PRODUCT_LINEDb = new MPO_PRODUCT_LINEDb(); 
if (PR_PRODUCT_LINE!= "") _MPO_PRODUCT_LINE.PR_PRODUCT_LINE =  PR_PRODUCT_LINE; 


if (PRODUCT_LINE_DEC!= "") _MPO_PRODUCT_LINE.PRODUCT_LINE_DEC =  PRODUCT_LINE_DEC; 


  _MPO_PRODUCT_LINEDb._MPO_PRODUCT_LINE = _MPO_PRODUCT_LINE;
    _MPO_PRODUCT_LINEDb.Delete(); 
   return "";
   }
  [WebMethod]
    public List<SelectInputProperties> SelectAll()
    {
        MPO_PRODUCT_LINEDb _MPO_PRODUCT_LINEDb = new MPO_PRODUCT_LINEDb();
        return _MPO_PRODUCT_LINEDb.Select();
    }
 [WebMethod] 
   public MPO_PRODUCT_LINE Select(string PR_PRODUCT_LINE)
    {
        MPO_PRODUCT_LINEDb _MPO_PRODUCT_LINEDb = new MPO_PRODUCT_LINEDb();
        return _MPO_PRODUCT_LINEDb.Select(PR_PRODUCT_LINE);
    }
}
