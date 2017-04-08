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
 
public class AccountRegistrationService : System.Web.Services.WebService 
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
            AccountRegistrationDb _AccountRegistrationDb = new AccountRegistrationDb(); 
 
 
            bool isUpdate = _AccountRegistrationDb.UpdateColumn(id, column, value); 
            return isUpdate; 
        }
[WebMethod] 
       public List<string> GetKeyWordsAllColumn(string keyword) 
       { 
           AccountRegistrationDb _AccountRegistrationDb = new AccountRegistrationDb(); 
           List<string> keywords = _AccountRegistrationDb.GetKeyWordsAllColumn(keyword); 
           return keywords; 
       }

[WebMethod] 
       public List<string> GetKeyWordsOneColumn(string column, string keyword) 
       { 
           AccountRegistrationDb _AccountRegistrationDb = new AccountRegistrationDb(); 
           List<string> keywords = _AccountRegistrationDb.GetKeyWordsOneColumn(column,keyword); 
           return keywords; 
       }


    [WebMethod]
public List<AccountRegistration> Search(string PageIndex,string PageSize,string SortExpression,string SortDirection,string RequestId,string UserName,string Password,string FirstName,string LastName,string Department,string Phone,string Fax,string Status,string CreateDate,string DeleteDate,string CancelDate,string ApprovedDate,string LastUpdate)
    {
 AccountRegistration _AccountRegistration = new AccountRegistration(); 
  AccountRegistrationDb _AccountRegistrationDb = new AccountRegistrationDb(); 
if (RequestId!= "") _AccountRegistration.RequestId = Convert.ToInt32(RequestId);

if (UserName!= "") _AccountRegistration.UserName =  UserName; 


if (Password!= "") _AccountRegistration.Password =  Password; 


if (FirstName!= "") _AccountRegistration.FirstName =  FirstName; 


if (LastName!= "") _AccountRegistration.LastName =  LastName; 


if (Department!= "") _AccountRegistration.Department =  Department; 


if (Phone!= "") _AccountRegistration.Phone =  Phone; 


if (Fax!= "") _AccountRegistration.Fax =  Fax; 


if (Status!= "") _AccountRegistration.Status =  Status; 


if (CreateDate!= "") _AccountRegistration.CreateDate =StkGlobalDate.TextEnToDate(CreateDate);

if (DeleteDate!= "") _AccountRegistration.DeleteDate =StkGlobalDate.TextEnToDate(DeleteDate);

if (CancelDate!= "") _AccountRegistration.CancelDate =StkGlobalDate.TextEnToDate(CancelDate);

if (ApprovedDate!= "") _AccountRegistration.ApprovedDate =StkGlobalDate.TextEnToDate(ApprovedDate);

if (LastUpdate!= "") _AccountRegistration.LastUpdate =StkGlobalDate.TextEnToDate(LastUpdate);

  _AccountRegistrationDb._AccountRegistration = _AccountRegistration;
int _PageIndex = Convert.ToInt32(PageIndex);
int _PageSize = Convert.ToInt32(PageSize);

 if (SortExpression.Trim() != "")
        {
            _AccountRegistrationDb._SortDirection = SortDirection;

            _AccountRegistrationDb._SortExpression = SortExpression;
        }
return _AccountRegistrationDb.GetPageWise(_PageIndex, _PageSize);
   }

    [WebMethod]
public string Save(string RequestId,string UserName,string Password,string FirstName,string LastName,string Department,string Phone,string Fax,string Status,string CreateDate,string DeleteDate,string CancelDate,string ApprovedDate,string LastUpdate)
    {
 AccountRegistration _AccountRegistration = new AccountRegistration(); 
  AccountRegistrationDb _AccountRegistrationDb = new AccountRegistrationDb(); 
// if (RequestId!= "") _AccountRegistration.RequestId = Convert.ToInt32(RequestId);

if (UserName!= "") _AccountRegistration.UserName =  UserName; 


if (Password!= "") _AccountRegistration.Password =  Password; 


if (FirstName!= "") _AccountRegistration.FirstName =  FirstName; 


if (LastName!= "") _AccountRegistration.LastName =  LastName; 


if (Department!= "") _AccountRegistration.Department =  Department; 


if (Phone!= "") _AccountRegistration.Phone =  Phone; 


if (Fax!= "") _AccountRegistration.Fax =  Fax; 


if (Status!= "") _AccountRegistration.Status =  Status; 


if (CreateDate!= "") _AccountRegistration.CreateDate =StkGlobalDate.TextEnToDate(CreateDate);

if (DeleteDate!= "") _AccountRegistration.DeleteDate =StkGlobalDate.TextEnToDate(DeleteDate);

if (CancelDate!= "") _AccountRegistration.CancelDate =StkGlobalDate.TextEnToDate(CancelDate);

if (ApprovedDate!= "") _AccountRegistration.ApprovedDate =StkGlobalDate.TextEnToDate(ApprovedDate);

if (LastUpdate!= "") _AccountRegistration.LastUpdate =StkGlobalDate.TextEnToDate(LastUpdate);

  _AccountRegistrationDb._AccountRegistration = _AccountRegistration;
  object result= _AccountRegistrationDb.Insert(); 
   return result.ToString();
   }

    [WebMethod]
public string Update(string RequestId,string UserName,string Password,string FirstName,string LastName,string Department,string Phone,string Fax,string Status,string CreateDate,string DeleteDate,string CancelDate,string ApprovedDate,string LastUpdate)
    {
 AccountRegistration _AccountRegistration = new AccountRegistration(); 
  AccountRegistrationDb _AccountRegistrationDb = new AccountRegistrationDb(); 
if (RequestId!= "") _AccountRegistration.RequestId = Convert.ToInt32(RequestId);

if (UserName!= "") _AccountRegistration.UserName =  UserName; 


if (Password!= "") _AccountRegistration.Password =  Password; 


if (FirstName!= "") _AccountRegistration.FirstName =  FirstName; 


if (LastName!= "") _AccountRegistration.LastName =  LastName; 


if (Department!= "") _AccountRegistration.Department =  Department; 


if (Phone!= "") _AccountRegistration.Phone =  Phone; 


if (Fax!= "") _AccountRegistration.Fax =  Fax; 


if (Status!= "") _AccountRegistration.Status =  Status; 


if (CreateDate!= "") _AccountRegistration.CreateDate =StkGlobalDate.TextEnToDate(CreateDate);

if (DeleteDate!= "") _AccountRegistration.DeleteDate =StkGlobalDate.TextEnToDate(DeleteDate);

if (CancelDate!= "") _AccountRegistration.CancelDate =StkGlobalDate.TextEnToDate(CancelDate);

if (ApprovedDate!= "") _AccountRegistration.ApprovedDate =StkGlobalDate.TextEnToDate(ApprovedDate);

if (LastUpdate!= "") _AccountRegistration.LastUpdate =StkGlobalDate.TextEnToDate(LastUpdate);

  _AccountRegistrationDb._AccountRegistration = _AccountRegistration;
    _AccountRegistrationDb.Update(); 
   return "";
   }

    [WebMethod]
public string Delete(string RequestId,string UserName,string Password,string FirstName,string LastName,string Department,string Phone,string Fax,string Status,string CreateDate,string DeleteDate,string CancelDate,string ApprovedDate,string LastUpdate)
    {
 AccountRegistration _AccountRegistration = new AccountRegistration(); 
  AccountRegistrationDb _AccountRegistrationDb = new AccountRegistrationDb(); 
if (RequestId!= "") _AccountRegistration.RequestId = Convert.ToInt32(RequestId);

if (UserName!= "") _AccountRegistration.UserName =  UserName; 


if (Password!= "") _AccountRegistration.Password =  Password; 


if (FirstName!= "") _AccountRegistration.FirstName =  FirstName; 


if (LastName!= "") _AccountRegistration.LastName =  LastName; 


if (Department!= "") _AccountRegistration.Department =  Department; 


if (Phone!= "") _AccountRegistration.Phone =  Phone; 


if (Fax!= "") _AccountRegistration.Fax =  Fax; 


if (Status!= "") _AccountRegistration.Status =  Status; 


if (CreateDate!= "") _AccountRegistration.CreateDate =StkGlobalDate.TextEnToDate(CreateDate);

if (DeleteDate!= "") _AccountRegistration.DeleteDate =StkGlobalDate.TextEnToDate(DeleteDate);

if (CancelDate!= "") _AccountRegistration.CancelDate =StkGlobalDate.TextEnToDate(CancelDate);

if (ApprovedDate!= "") _AccountRegistration.ApprovedDate =StkGlobalDate.TextEnToDate(ApprovedDate);

if (LastUpdate!= "") _AccountRegistration.LastUpdate =StkGlobalDate.TextEnToDate(LastUpdate);

  _AccountRegistrationDb._AccountRegistration = _AccountRegistration;
    _AccountRegistrationDb.Delete(); 
   return "";
   }
  [WebMethod]
    public List<SelectInputProperties> SelectAll()
    {
        AccountRegistrationDb _AccountRegistrationDb = new AccountRegistrationDb();
        return _AccountRegistrationDb.Select();
    }
 [WebMethod] 
   public AccountRegistration Select(string RequestId)
    {
        AccountRegistrationDb _AccountRegistrationDb = new AccountRegistrationDb();
        return _AccountRegistrationDb.Select(RequestId);
    }
}
