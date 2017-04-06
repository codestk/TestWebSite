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
 
public class MPO_SIZEService : System.Web.Services.WebService 
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
            MPO_SIZEDb _MPO_SIZEDb = new MPO_SIZEDb(); 
 
 
            bool isUpdate = _MPO_SIZEDb.UpdateColumn(id, column, value); 
            return isUpdate; 
        }
[WebMethod] 
       public List<string> GetKeyWordsAllColumn(string keyword) 
       { 
           MPO_SIZEDb _MPO_SIZEDb = new MPO_SIZEDb(); 
           List<string> keywords = _MPO_SIZEDb.GetKeyWordsAllColumn(keyword); 
           return keywords; 
       }

[WebMethod] 
       public List<string> GetKeyWordsOneColumn(string column, string keyword) 
       { 
           MPO_SIZEDb _MPO_SIZEDb = new MPO_SIZEDb(); 
           List<string> keywords = _MPO_SIZEDb.GetKeyWordsOneColumn(column,keyword); 
           return keywords; 
       }


    [WebMethod]
public List<MPO_SIZE> Search(string PageIndex,string PageSize,string SortExpression,string SortDirection,string PR_SIZE,string SIZE_DEC)
    {
 MPO_SIZE _MPO_SIZE = new MPO_SIZE(); 
  MPO_SIZEDb _MPO_SIZEDb = new MPO_SIZEDb(); 
if (PR_SIZE!= "") _MPO_SIZE.PR_SIZE =  PR_SIZE; 


if (SIZE_DEC!= "") _MPO_SIZE.SIZE_DEC =  SIZE_DEC; 


  _MPO_SIZEDb._MPO_SIZE = _MPO_SIZE;
int _PageIndex = Convert.ToInt32(PageIndex);
int _PageSize = Convert.ToInt32(PageSize);

 if (SortExpression.Trim() != "")
        {
            _MPO_SIZEDb._SortDirection = SortDirection;

            _MPO_SIZEDb._SortExpression = SortExpression;
        }
return _MPO_SIZEDb.GetPageWise(_PageIndex, _PageSize);
   }

    [WebMethod]
public string Save(string PR_SIZE,string SIZE_DEC)
    {
 MPO_SIZE _MPO_SIZE = new MPO_SIZE(); 
  MPO_SIZEDb _MPO_SIZEDb = new MPO_SIZEDb(); 
if (PR_SIZE!= "") _MPO_SIZE.PR_SIZE =  PR_SIZE; 


if (SIZE_DEC!= "") _MPO_SIZE.SIZE_DEC =  SIZE_DEC; 


  _MPO_SIZEDb._MPO_SIZE = _MPO_SIZE;
  object result= _MPO_SIZEDb.Insert(); 
   return result.ToString();
   }

    [WebMethod]
public string Update(string PR_SIZE,string SIZE_DEC)
    {
 MPO_SIZE _MPO_SIZE = new MPO_SIZE(); 
  MPO_SIZEDb _MPO_SIZEDb = new MPO_SIZEDb(); 
if (PR_SIZE!= "") _MPO_SIZE.PR_SIZE =  PR_SIZE; 


if (SIZE_DEC!= "") _MPO_SIZE.SIZE_DEC =  SIZE_DEC; 


  _MPO_SIZEDb._MPO_SIZE = _MPO_SIZE;
    _MPO_SIZEDb.Update(); 
   return "";
   }

    [WebMethod]
public string Delete(string PR_SIZE,string SIZE_DEC)
    {
 MPO_SIZE _MPO_SIZE = new MPO_SIZE(); 
  MPO_SIZEDb _MPO_SIZEDb = new MPO_SIZEDb(); 
if (PR_SIZE!= "") _MPO_SIZE.PR_SIZE =  PR_SIZE; 


if (SIZE_DEC!= "") _MPO_SIZE.SIZE_DEC =  SIZE_DEC; 


  _MPO_SIZEDb._MPO_SIZE = _MPO_SIZE;
    _MPO_SIZEDb.Delete(); 
   return "";
   }
  [WebMethod]
    public List<SelectInputProperties> SelectAll()
    {
        MPO_SIZEDb _MPO_SIZEDb = new MPO_SIZEDb();
        return _MPO_SIZEDb.Select();
    }
 [WebMethod] 
   public MPO_SIZE Select(string PR_SIZE)
    {
        MPO_SIZEDb _MPO_SIZEDb = new MPO_SIZEDb();
        return _MPO_SIZEDb.Select(PR_SIZE);
    }
}
