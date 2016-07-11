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
 
public class STK_USER_FLAGService : System.Web.Services.WebService 
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
            STK_USER_FLAGDb _STK_USER_FLAGDb = new STK_USER_FLAGDb(); 
 
 
            bool isUpdate = _STK_USER_FLAGDb.UpdateColumn(id, column, value); 
            return isUpdate; 
        }
[WebMethod] 
       public List<string> GetKeyWordsAllColumn(string keyword) 
       { 
           STK_USER_FLAGDb _STK_USER_FLAGDb = new STK_USER_FLAGDb(); 
           List<string> keywords = _STK_USER_FLAGDb.GetKeyWordsAllColumn(keyword); 
           return keywords; 
       }

[WebMethod] 
       public List<string> GetKeyWordsOneColumn(string column, string keyword) 
       { 
           STK_USER_FLAGDb _STK_USER_FLAGDb = new STK_USER_FLAGDb(); 
           List<string> keywords = _STK_USER_FLAGDb.GetKeyWordsOneColumn(column,keyword); 
           return keywords; 
       }


    [WebMethod]
public List<STK_USER_FLAG> Search(string PageIndex,string PageSize,string SortExpression,string SortDirection,string EM_FLAG,string EM_DES)
    {
 STK_USER_FLAG _STK_USER_FLAG = new STK_USER_FLAG(); 
  STK_USER_FLAGDb _STK_USER_FLAGDb = new STK_USER_FLAGDb(); 
if (EM_FLAG!= "") _STK_USER_FLAG.EM_FLAG =  EM_FLAG; 


if (EM_DES!= "") _STK_USER_FLAG.EM_DES =  EM_DES; 


  _STK_USER_FLAGDb._STK_USER_FLAG = _STK_USER_FLAG;
int _PageIndex = Convert.ToInt32(PageIndex);
int _PageSize = Convert.ToInt32(PageSize);

 if (SortExpression.Trim() != "")
        {
            _STK_USER_FLAGDb._SortDirection = SortDirection;

            _STK_USER_FLAGDb._SortExpression = SortExpression;
        }
return _STK_USER_FLAGDb.GetPageWise(_PageIndex, _PageSize);
   }

    [WebMethod]
public string Save(string EM_FLAG,string EM_DES)
    {
 STK_USER_FLAG _STK_USER_FLAG = new STK_USER_FLAG(); 
  STK_USER_FLAGDb _STK_USER_FLAGDb = new STK_USER_FLAGDb(); 
if (EM_FLAG!= "") _STK_USER_FLAG.EM_FLAG =  EM_FLAG; 


if (EM_DES!= "") _STK_USER_FLAG.EM_DES =  EM_DES; 


  _STK_USER_FLAGDb._STK_USER_FLAG = _STK_USER_FLAG;
  object result= _STK_USER_FLAGDb.Insert(); 
   return result.ToString();
   }

    [WebMethod]
public string Update(string EM_FLAG,string EM_DES)
    {
 STK_USER_FLAG _STK_USER_FLAG = new STK_USER_FLAG(); 
  STK_USER_FLAGDb _STK_USER_FLAGDb = new STK_USER_FLAGDb(); 
if (EM_FLAG!= "") _STK_USER_FLAG.EM_FLAG =  EM_FLAG; 


if (EM_DES!= "") _STK_USER_FLAG.EM_DES =  EM_DES; 


  _STK_USER_FLAGDb._STK_USER_FLAG = _STK_USER_FLAG;
    _STK_USER_FLAGDb.Update(); 
   return "";
   }

    [WebMethod]
public string Delete(string EM_FLAG,string EM_DES)
    {
 STK_USER_FLAG _STK_USER_FLAG = new STK_USER_FLAG(); 
  STK_USER_FLAGDb _STK_USER_FLAGDb = new STK_USER_FLAGDb(); 
if (EM_FLAG!= "") _STK_USER_FLAG.EM_FLAG =  EM_FLAG; 


if (EM_DES!= "") _STK_USER_FLAG.EM_DES =  EM_DES; 


  _STK_USER_FLAGDb._STK_USER_FLAG = _STK_USER_FLAG;
    _STK_USER_FLAGDb.Delete(); 
   return "";
   }
  [WebMethod]
    public List<SelectInputProperties> SelectAll()
    {
        STK_USER_FLAGDb _STK_USER_FLAGDb = new STK_USER_FLAGDb();
        return _STK_USER_FLAGDb.Select();
    }
 [WebMethod] 
   public STK_USER_FLAG Select(string EM_FLAG)
    {
        STK_USER_FLAGDb _STK_USER_FLAGDb = new STK_USER_FLAGDb();
        return _STK_USER_FLAGDb.Select(EM_FLAG);
    }
}
