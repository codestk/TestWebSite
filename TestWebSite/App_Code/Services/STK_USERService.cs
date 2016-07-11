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
 
public class STK_USERService : System.Web.Services.WebService 
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
            STK_USERDb _STK_USERDb = new STK_USERDb(); 
 
 
            bool isUpdate = _STK_USERDb.UpdateColumn(id, column, value); 
            return isUpdate; 
        }
[WebMethod] 
       public List<string> GetKeyWordsAllColumn(string keyword) 
       { 
           STK_USERDb _STK_USERDb = new STK_USERDb(); 
           List<string> keywords = _STK_USERDb.GetKeyWordsAllColumn(keyword); 
           return keywords; 
       }

[WebMethod] 
       public List<string> GetKeyWordsOneColumn(string column, string keyword) 
       { 
           STK_USERDb _STK_USERDb = new STK_USERDb(); 
           List<string> keywords = _STK_USERDb.GetKeyWordsOneColumn(column,keyword); 
           return keywords; 
       }


    [WebMethod]
public List<STK_USER> Search(string PageIndex,string PageSize,string SortExpression,string SortDirection,string EM_ID,string EM_PASS,string EM_NAME,string EM_SURNAME,string EM_TEL,string EM_ADDRESS,string EM_FLAG,string EM_ROLE_ADMIN,string EM_ROLE_USER)
    {
 STK_USER _STK_USER = new STK_USER(); 
  STK_USERDb _STK_USERDb = new STK_USERDb(); 
if (EM_ID!= "") _STK_USER.EM_ID =  EM_ID; 


if (EM_PASS!= "") _STK_USER.EM_PASS =  EM_PASS; 


if (EM_NAME!= "") _STK_USER.EM_NAME =  EM_NAME; 


if (EM_SURNAME!= "") _STK_USER.EM_SURNAME =  EM_SURNAME; 


if (EM_TEL!= "") _STK_USER.EM_TEL =  EM_TEL; 


if (EM_ADDRESS!= "") _STK_USER.EM_ADDRESS =  EM_ADDRESS; 


if (EM_FLAG!= "") _STK_USER.EM_FLAG =  EM_FLAG; 


if (EM_ROLE_ADMIN!= "") {string bit = (EM_ROLE_ADMIN == "true" ? "1" : "0");
_STK_USER.EM_ROLE_ADMIN =Convert.ToInt16(bit);}


if (EM_ROLE_USER!= "") {string bit = (EM_ROLE_USER == "true" ? "1" : "0");
_STK_USER.EM_ROLE_USER =Convert.ToInt16(bit);}


  _STK_USERDb._STK_USER = _STK_USER;
int _PageIndex = Convert.ToInt32(PageIndex);
int _PageSize = Convert.ToInt32(PageSize);

 if (SortExpression.Trim() != "")
        {
            _STK_USERDb._SortDirection = SortDirection;

            _STK_USERDb._SortExpression = SortExpression;
        }
return _STK_USERDb.GetPageWise(_PageIndex, _PageSize);
   }

    [WebMethod]
public string Save(string EM_ID,string EM_PASS,string EM_NAME,string EM_SURNAME,string EM_TEL,string EM_ADDRESS,string EM_FLAG,string EM_ROLE_ADMIN,string EM_ROLE_USER)
    {
 STK_USER _STK_USER = new STK_USER(); 
  STK_USERDb _STK_USERDb = new STK_USERDb(); 
if (EM_ID!= "") _STK_USER.EM_ID =  EM_ID; 


if (EM_PASS!= "") _STK_USER.EM_PASS =  EM_PASS; 


if (EM_NAME!= "") _STK_USER.EM_NAME =  EM_NAME; 


if (EM_SURNAME!= "") _STK_USER.EM_SURNAME =  EM_SURNAME; 


if (EM_TEL!= "") _STK_USER.EM_TEL =  EM_TEL; 


if (EM_ADDRESS!= "") _STK_USER.EM_ADDRESS =  EM_ADDRESS; 


if (EM_FLAG!= "") _STK_USER.EM_FLAG =  EM_FLAG; 


if (EM_ROLE_ADMIN!= "") {string bit = (EM_ROLE_ADMIN == "true" ? "1" : "0");
_STK_USER.EM_ROLE_ADMIN =Convert.ToInt16(bit);}


if (EM_ROLE_USER!= "") {string bit = (EM_ROLE_USER == "true" ? "1" : "0");
_STK_USER.EM_ROLE_USER =Convert.ToInt16(bit);}


  _STK_USERDb._STK_USER = _STK_USER;
  object result= _STK_USERDb.Insert(); 
   return result.ToString();
   }

    [WebMethod]
public string Update(string EM_ID,string EM_PASS,string EM_NAME,string EM_SURNAME,string EM_TEL,string EM_ADDRESS,string EM_FLAG,string EM_ROLE_ADMIN,string EM_ROLE_USER)
    {
 STK_USER _STK_USER = new STK_USER(); 
  STK_USERDb _STK_USERDb = new STK_USERDb(); 
if (EM_ID!= "") _STK_USER.EM_ID =  EM_ID; 


if (EM_PASS!= "") _STK_USER.EM_PASS =  EM_PASS; 


if (EM_NAME!= "") _STK_USER.EM_NAME =  EM_NAME; 


if (EM_SURNAME!= "") _STK_USER.EM_SURNAME =  EM_SURNAME; 


if (EM_TEL!= "") _STK_USER.EM_TEL =  EM_TEL; 


if (EM_ADDRESS!= "") _STK_USER.EM_ADDRESS =  EM_ADDRESS; 


if (EM_FLAG!= "") _STK_USER.EM_FLAG =  EM_FLAG; 


if (EM_ROLE_ADMIN!= "") {string bit = (EM_ROLE_ADMIN == "true" ? "1" : "0");
_STK_USER.EM_ROLE_ADMIN =Convert.ToInt16(bit);}


if (EM_ROLE_USER!= "") {string bit = (EM_ROLE_USER == "true" ? "1" : "0");
_STK_USER.EM_ROLE_USER =Convert.ToInt16(bit);}


  _STK_USERDb._STK_USER = _STK_USER;
    _STK_USERDb.Update(); 
   return "";
   }

    [WebMethod]
public string Delete(string EM_ID,string EM_PASS,string EM_NAME,string EM_SURNAME,string EM_TEL,string EM_ADDRESS,string EM_FLAG,string EM_ROLE_ADMIN,string EM_ROLE_USER)
    {
 STK_USER _STK_USER = new STK_USER(); 
  STK_USERDb _STK_USERDb = new STK_USERDb(); 
if (EM_ID!= "") _STK_USER.EM_ID =  EM_ID; 


if (EM_PASS!= "") _STK_USER.EM_PASS =  EM_PASS; 


if (EM_NAME!= "") _STK_USER.EM_NAME =  EM_NAME; 


if (EM_SURNAME!= "") _STK_USER.EM_SURNAME =  EM_SURNAME; 


if (EM_TEL!= "") _STK_USER.EM_TEL =  EM_TEL; 


if (EM_ADDRESS!= "") _STK_USER.EM_ADDRESS =  EM_ADDRESS; 


if (EM_FLAG!= "") _STK_USER.EM_FLAG =  EM_FLAG; 


if (EM_ROLE_ADMIN!= "") {string bit = (EM_ROLE_ADMIN == "true" ? "1" : "0");
_STK_USER.EM_ROLE_ADMIN =Convert.ToInt16(bit);}


if (EM_ROLE_USER!= "") {string bit = (EM_ROLE_USER == "true" ? "1" : "0");
_STK_USER.EM_ROLE_USER =Convert.ToInt16(bit);}


  _STK_USERDb._STK_USER = _STK_USER;
    _STK_USERDb.Delete(); 
   return "";
   }
  [WebMethod]
    public List<SelectInputProperties> SelectAll()
    {
        STK_USERDb _STK_USERDb = new STK_USERDb();
        return _STK_USERDb.Select();
    }
 [WebMethod] 
   public STK_USER Select(string EM_ID)
    {
        STK_USERDb _STK_USERDb = new STK_USERDb();
        return _STK_USERDb.Select(EM_ID);
    }
}
