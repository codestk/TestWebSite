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
 
public class MPO_SOURCEService : System.Web.Services.WebService 
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
            MPO_SOURCEDb _MPO_SOURCEDb = new MPO_SOURCEDb(); 
 
 
            bool isUpdate = _MPO_SOURCEDb.UpdateColumn(id, column, value); 
            return isUpdate; 
        }
[WebMethod] 
       public List<string> GetKeyWordsAllColumn(string keyword) 
       { 
           MPO_SOURCEDb _MPO_SOURCEDb = new MPO_SOURCEDb(); 
           List<string> keywords = _MPO_SOURCEDb.GetKeyWordsAllColumn(keyword); 
           return keywords; 
       }

[WebMethod] 
       public List<string> GetKeyWordsOneColumn(string column, string keyword) 
       { 
           MPO_SOURCEDb _MPO_SOURCEDb = new MPO_SOURCEDb(); 
           List<string> keywords = _MPO_SOURCEDb.GetKeyWordsOneColumn(column,keyword); 
           return keywords; 
       }


    [WebMethod]
public List<MPO_SOURCE> Search(string PageIndex,string PageSize,string SortExpression,string SortDirection,string PR_SOURCE,string PR_DEC)
    {
 MPO_SOURCE _MPO_SOURCE = new MPO_SOURCE(); 
  MPO_SOURCEDb _MPO_SOURCEDb = new MPO_SOURCEDb(); 
if (PR_SOURCE!= "") _MPO_SOURCE.PR_SOURCE =  PR_SOURCE; 


if (PR_DEC!= "") _MPO_SOURCE.PR_DEC =  PR_DEC; 


  _MPO_SOURCEDb._MPO_SOURCE = _MPO_SOURCE;
int _PageIndex = Convert.ToInt32(PageIndex);
int _PageSize = Convert.ToInt32(PageSize);

 if (SortExpression.Trim() != "")
        {
            _MPO_SOURCEDb._SortDirection = SortDirection;

            _MPO_SOURCEDb._SortExpression = SortExpression;
        }
return _MPO_SOURCEDb.GetPageWise(_PageIndex, _PageSize);
   }

    [WebMethod]
public string Save(string PR_SOURCE,string PR_DEC)
    {
 MPO_SOURCE _MPO_SOURCE = new MPO_SOURCE(); 
  MPO_SOURCEDb _MPO_SOURCEDb = new MPO_SOURCEDb(); 
if (PR_SOURCE!= "") _MPO_SOURCE.PR_SOURCE =  PR_SOURCE; 


if (PR_DEC!= "") _MPO_SOURCE.PR_DEC =  PR_DEC; 


  _MPO_SOURCEDb._MPO_SOURCE = _MPO_SOURCE;
  object result= _MPO_SOURCEDb.Insert(); 
   return result.ToString();
   }

    [WebMethod]
public string Update(string PR_SOURCE,string PR_DEC)
    {
 MPO_SOURCE _MPO_SOURCE = new MPO_SOURCE(); 
  MPO_SOURCEDb _MPO_SOURCEDb = new MPO_SOURCEDb(); 
if (PR_SOURCE!= "") _MPO_SOURCE.PR_SOURCE =  PR_SOURCE; 


if (PR_DEC!= "") _MPO_SOURCE.PR_DEC =  PR_DEC; 


  _MPO_SOURCEDb._MPO_SOURCE = _MPO_SOURCE;
    _MPO_SOURCEDb.Update(); 
   return "";
   }

    [WebMethod]
public string Delete(string PR_SOURCE,string PR_DEC)
    {
 MPO_SOURCE _MPO_SOURCE = new MPO_SOURCE(); 
  MPO_SOURCEDb _MPO_SOURCEDb = new MPO_SOURCEDb(); 
if (PR_SOURCE!= "") _MPO_SOURCE.PR_SOURCE =  PR_SOURCE; 


if (PR_DEC!= "") _MPO_SOURCE.PR_DEC =  PR_DEC; 


  _MPO_SOURCEDb._MPO_SOURCE = _MPO_SOURCE;
    _MPO_SOURCEDb.Delete(); 
   return "";
   }
  [WebMethod]
    public List<SelectInputProperties> SelectAll()
    {
        MPO_SOURCEDb _MPO_SOURCEDb = new MPO_SOURCEDb();
        return _MPO_SOURCEDb.Select();
    }
 [WebMethod] 
   public MPO_SOURCE Select(string PR_SOURCE)
    {
        MPO_SOURCEDb _MPO_SOURCEDb = new MPO_SOURCEDb();
        return _MPO_SOURCEDb.Select(PR_SOURCE);
    }
}
