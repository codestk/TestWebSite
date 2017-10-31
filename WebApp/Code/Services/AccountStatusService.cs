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
 
public class AccountStatusService : System.Web.Services.WebService 
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
            AccountStatusDb _AccountStatusDb = new AccountStatusDb(); 
 
 
            bool isUpdate = _AccountStatusDb.UpdateColumn(id, column, value); 
            return isUpdate; 
        }
[WebMethod] 
       public List<string> GetKeyWordsAllColumn(string keyword) 
       { 
           AccountStatusDb _AccountStatusDb = new AccountStatusDb(); 
           List<string> keywords = _AccountStatusDb.GetKeyWordsAllColumn(keyword); 
           return keywords; 
       }

[WebMethod] 
       public List<string> GetKeyWordsOneColumn(string column, string keyword) 
       { 
           AccountStatusDb _AccountStatusDb = new AccountStatusDb(); 
           List<string> keywords = _AccountStatusDb.GetKeyWordsOneColumn(column,keyword); 
           return keywords; 
       }


    [WebMethod]
public List<AccountStatus> Search(string PageIndex,string PageSize,string SortExpression,string SortDirection,string Status,string StatusName)
    {
 AccountStatus _AccountStatus = new AccountStatus(); 
  AccountStatusDb _AccountStatusDb = new AccountStatusDb(); 
if (Status!= "") _AccountStatus.Status =  Status; 


if (StatusName!= "") _AccountStatus.StatusName =  StatusName; 


  _AccountStatusDb._AccountStatus = _AccountStatus;
int _PageIndex = Convert.ToInt32(PageIndex);
int _PageSize = Convert.ToInt32(PageSize);

 if (SortExpression.Trim() != "")
        {
            _AccountStatusDb._SortDirection = SortDirection;

            _AccountStatusDb._SortExpression = SortExpression;
        }
return _AccountStatusDb.GetPageWise(_PageIndex, _PageSize);
   }

    [WebMethod]
public string Save(string Status,string StatusName)
    {
 AccountStatus _AccountStatus = new AccountStatus(); 
  AccountStatusDb _AccountStatusDb = new AccountStatusDb(); 
if (Status!= "") _AccountStatus.Status =  Status; 


if (StatusName!= "") _AccountStatus.StatusName =  StatusName; 


  _AccountStatusDb._AccountStatus = _AccountStatus;
  object result= _AccountStatusDb.Insert(); 
   return result.ToString();
   }

    [WebMethod]
public string Update(string Status,string StatusName)
    {
 AccountStatus _AccountStatus = new AccountStatus(); 
  AccountStatusDb _AccountStatusDb = new AccountStatusDb(); 
if (Status!= "") _AccountStatus.Status =  Status; 


if (StatusName!= "") _AccountStatus.StatusName =  StatusName; 


  _AccountStatusDb._AccountStatus = _AccountStatus;
    _AccountStatusDb.Update(); 
   return "";
   }

    [WebMethod]
public string Delete(string Status,string StatusName)
    {
 AccountStatus _AccountStatus = new AccountStatus(); 
  AccountStatusDb _AccountStatusDb = new AccountStatusDb(); 
if (Status!= "") _AccountStatus.Status =  Status; 


if (StatusName!= "") _AccountStatus.StatusName =  StatusName; 


  _AccountStatusDb._AccountStatus = _AccountStatus;
    _AccountStatusDb.Delete(); 
   return "";
   }
  [WebMethod]
    public List<SelectInputProperties> SelectAll()
    {
        AccountStatusDb _AccountStatusDb = new AccountStatusDb();
        return _AccountStatusDb.Select();
    }
 [WebMethod] 
   public AccountStatus Select(string Status)
    {
        AccountStatusDb _AccountStatusDb = new AccountStatusDb();
        return _AccountStatusDb.Select(Status);
    }
}
