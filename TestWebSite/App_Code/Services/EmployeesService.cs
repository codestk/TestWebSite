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
 
public class EmployeesService : System.Web.Services.WebService 
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
            EmployeesDb _EmployeesDb = new EmployeesDb(); 
 
 
            bool isUpdate = _EmployeesDb.UpdateColumn(id, column, value); 
            return isUpdate; 
        }
[WebMethod] 
       public List<string> GetKeyWordsAllColumn(string keyword) 
       { 
           EmployeesDb _EmployeesDb = new EmployeesDb(); 
           List<string> keywords = _EmployeesDb.GetKeyWordsAllColumn(keyword); 
           return keywords; 
       }

[WebMethod] 
       public List<string> GetKeyWordsOneColumn(string column, string keyword) 
       { 
           EmployeesDb _EmployeesDb = new EmployeesDb(); 
           List<string> keywords = _EmployeesDb.GetKeyWordsOneColumn(column,keyword); 
           return keywords; 
       }


    [WebMethod]
public List<Employees> Search(string PageIndex,string PageSize,string SortExpression,string SortDirection,string EmployeeID,string LastName,string FirstName,string Title,string TitleOfCourtesy,string BirthDate,string HireDate,string Address,string City,string Region,string PostalCode,string Country,string HomePhone,string Extension,string ReportsTo,string PhotoPath)
    {
 Employees _Employees = new Employees(); 
  EmployeesDb _EmployeesDb = new EmployeesDb(); 
if (EmployeeID!= "") _Employees.EmployeeID = Convert.ToInt32(EmployeeID);

if (LastName!= "") _Employees.LastName =  LastName; 


if (FirstName!= "") _Employees.FirstName =  FirstName; 


if (Title!= "") _Employees.Title =  Title; 


if (TitleOfCourtesy!= "") _Employees.TitleOfCourtesy =  TitleOfCourtesy; 


if (BirthDate!= "") _Employees.BirthDate =StkGlobalDate.TextEnToDate(BirthDate);

if (HireDate!= "") _Employees.HireDate =StkGlobalDate.TextEnToDate(HireDate);

if (Address!= "") _Employees.Address =  Address; 


if (City!= "") _Employees.City =  City; 


if (Region!= "") _Employees.Region =  Region; 


if (PostalCode!= "") _Employees.PostalCode =  PostalCode; 


if (Country!= "") _Employees.Country =  Country; 


if (HomePhone!= "") _Employees.HomePhone =  HomePhone; 


if (Extension!= "") _Employees.Extension =  Extension; 


if (ReportsTo!= "") _Employees.ReportsTo = Convert.ToInt32(ReportsTo);

if (PhotoPath!= "") _Employees.PhotoPath =  PhotoPath; 


  _EmployeesDb._Employees = _Employees;
int _PageIndex = Convert.ToInt32(PageIndex);
int _PageSize = Convert.ToInt32(PageSize);

 if (SortExpression.Trim() != "")
        {
            _EmployeesDb._SortDirection = SortDirection;

            _EmployeesDb._SortExpression = SortExpression;
        }
return _EmployeesDb.GetPageWise(_PageIndex, _PageSize);
   }

    [WebMethod]
public string Save(string EmployeeID,string LastName,string FirstName,string Title,string TitleOfCourtesy,string BirthDate,string HireDate,string Address,string City,string Region,string PostalCode,string Country,string HomePhone,string Extension,string ReportsTo,string PhotoPath)
    {
 Employees _Employees = new Employees(); 
  EmployeesDb _EmployeesDb = new EmployeesDb(); 
// if (EmployeeID!= "") _Employees.EmployeeID = Convert.ToInt32(EmployeeID);

if (LastName!= "") _Employees.LastName =  LastName; 


if (FirstName!= "") _Employees.FirstName =  FirstName; 


if (Title!= "") _Employees.Title =  Title; 


if (TitleOfCourtesy!= "") _Employees.TitleOfCourtesy =  TitleOfCourtesy; 


if (BirthDate!= "") _Employees.BirthDate =StkGlobalDate.TextEnToDate(BirthDate);

if (HireDate!= "") _Employees.HireDate =StkGlobalDate.TextEnToDate(HireDate);

if (Address!= "") _Employees.Address =  Address; 


if (City!= "") _Employees.City =  City; 


if (Region!= "") _Employees.Region =  Region; 


if (PostalCode!= "") _Employees.PostalCode =  PostalCode; 


if (Country!= "") _Employees.Country =  Country; 


if (HomePhone!= "") _Employees.HomePhone =  HomePhone; 


if (Extension!= "") _Employees.Extension =  Extension; 


if (ReportsTo!= "") _Employees.ReportsTo = Convert.ToInt32(ReportsTo);

if (PhotoPath!= "") _Employees.PhotoPath =  PhotoPath; 


  _EmployeesDb._Employees = _Employees;
  object result= _EmployeesDb.Insert(); 
   return result.ToString();
   }

    [WebMethod]
public string Update(string EmployeeID,string LastName,string FirstName,string Title,string TitleOfCourtesy,string BirthDate,string HireDate,string Address,string City,string Region,string PostalCode,string Country,string HomePhone,string Extension,string ReportsTo,string PhotoPath)
    {
 Employees _Employees = new Employees(); 
  EmployeesDb _EmployeesDb = new EmployeesDb(); 
if (EmployeeID!= "") _Employees.EmployeeID = Convert.ToInt32(EmployeeID);

if (LastName!= "") _Employees.LastName =  LastName; 


if (FirstName!= "") _Employees.FirstName =  FirstName; 


if (Title!= "") _Employees.Title =  Title; 


if (TitleOfCourtesy!= "") _Employees.TitleOfCourtesy =  TitleOfCourtesy; 


if (BirthDate!= "") _Employees.BirthDate =StkGlobalDate.TextEnToDate(BirthDate);

if (HireDate!= "") _Employees.HireDate =StkGlobalDate.TextEnToDate(HireDate);

if (Address!= "") _Employees.Address =  Address; 


if (City!= "") _Employees.City =  City; 


if (Region!= "") _Employees.Region =  Region; 


if (PostalCode!= "") _Employees.PostalCode =  PostalCode; 


if (Country!= "") _Employees.Country =  Country; 


if (HomePhone!= "") _Employees.HomePhone =  HomePhone; 


if (Extension!= "") _Employees.Extension =  Extension; 


if (ReportsTo!= "") _Employees.ReportsTo = Convert.ToInt32(ReportsTo);

if (PhotoPath!= "") _Employees.PhotoPath =  PhotoPath; 


  _EmployeesDb._Employees = _Employees;
    _EmployeesDb.Update(); 
   return "";
   }

    [WebMethod]
public string Delete(string EmployeeID,string LastName,string FirstName,string Title,string TitleOfCourtesy,string BirthDate,string HireDate,string Address,string City,string Region,string PostalCode,string Country,string HomePhone,string Extension,string ReportsTo,string PhotoPath)
    {
 Employees _Employees = new Employees(); 
  EmployeesDb _EmployeesDb = new EmployeesDb(); 
if (EmployeeID!= "") _Employees.EmployeeID = Convert.ToInt32(EmployeeID);

if (LastName!= "") _Employees.LastName =  LastName; 


if (FirstName!= "") _Employees.FirstName =  FirstName; 


if (Title!= "") _Employees.Title =  Title; 


if (TitleOfCourtesy!= "") _Employees.TitleOfCourtesy =  TitleOfCourtesy; 


if (BirthDate!= "") _Employees.BirthDate =StkGlobalDate.TextEnToDate(BirthDate);

if (HireDate!= "") _Employees.HireDate =StkGlobalDate.TextEnToDate(HireDate);

if (Address!= "") _Employees.Address =  Address; 


if (City!= "") _Employees.City =  City; 


if (Region!= "") _Employees.Region =  Region; 


if (PostalCode!= "") _Employees.PostalCode =  PostalCode; 


if (Country!= "") _Employees.Country =  Country; 


if (HomePhone!= "") _Employees.HomePhone =  HomePhone; 


if (Extension!= "") _Employees.Extension =  Extension; 


if (ReportsTo!= "") _Employees.ReportsTo = Convert.ToInt32(ReportsTo);

if (PhotoPath!= "") _Employees.PhotoPath =  PhotoPath; 


  _EmployeesDb._Employees = _Employees;
    _EmployeesDb.Delete(); 
   return "";
   }
  [WebMethod]
    public List<SelectInputProperties> SelectAll()
    {
        EmployeesDb _EmployeesDb = new EmployeesDb();
        return _EmployeesDb.Select();
    }
 [WebMethod] 
   public Employees Select(string EmployeeID)
    {
        EmployeesDb _EmployeesDb = new EmployeesDb();
        return _EmployeesDb.Select(EmployeeID);
    }
}
