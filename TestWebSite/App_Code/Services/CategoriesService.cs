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
 
public class CategoriesService : System.Web.Services.WebService 
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
            CategoriesDb _CategoriesDb = new CategoriesDb(); 
 
 
            bool isUpdate = _CategoriesDb.UpdateColumn(id, column, value); 
            return isUpdate; 
        }
[WebMethod] 
       public List<string> GetKeyWordsAllColumn(string keyword) 
       { 
           CategoriesDb _CategoriesDb = new CategoriesDb(); 
           List<string> keywords = _CategoriesDb.GetKeyWordsAllColumn(keyword); 
           return keywords; 
       }

[WebMethod] 
       public List<string> GetKeyWordsOneColumn(string column, string keyword) 
       { 
           CategoriesDb _CategoriesDb = new CategoriesDb(); 
           List<string> keywords = _CategoriesDb.GetKeyWordsOneColumn(column,keyword); 
           return keywords; 
       }


    [WebMethod]
public List<Categories> Search(string PageIndex,string PageSize,string SortExpression,string SortDirection,string CategoryID,string CategoryName)
    {
 Categories _Categories = new Categories(); 
  CategoriesDb _CategoriesDb = new CategoriesDb(); 
if (CategoryID!= "") _Categories.CategoryID = Convert.ToInt32(CategoryID);

if (CategoryName!= "") _Categories.CategoryName =  CategoryName; 


  _CategoriesDb._Categories = _Categories;
int _PageIndex = Convert.ToInt32(PageIndex);
int _PageSize = Convert.ToInt32(PageSize);

 if (SortExpression.Trim() != "")
        {
            _CategoriesDb._SortDirection = SortDirection;

            _CategoriesDb._SortExpression = SortExpression;
        }
return _CategoriesDb.GetPageWise(_PageIndex, _PageSize);
   }

    [WebMethod]
public string Save(string CategoryID,string CategoryName)
    {
 Categories _Categories = new Categories(); 
  CategoriesDb _CategoriesDb = new CategoriesDb(); 
// if (CategoryID!= "") _Categories.CategoryID = Convert.ToInt32(CategoryID);

if (CategoryName!= "") _Categories.CategoryName =  CategoryName; 


  _CategoriesDb._Categories = _Categories;
  object result= _CategoriesDb.Insert(); 
   return result.ToString();
   }

    [WebMethod]
public string Update(string CategoryID,string CategoryName)
    {
 Categories _Categories = new Categories(); 
  CategoriesDb _CategoriesDb = new CategoriesDb(); 
if (CategoryID!= "") _Categories.CategoryID = Convert.ToInt32(CategoryID);

if (CategoryName!= "") _Categories.CategoryName =  CategoryName; 


  _CategoriesDb._Categories = _Categories;
    _CategoriesDb.Update(); 
   return "";
   }

    [WebMethod]
public string Delete(string CategoryID,string CategoryName)
    {
 Categories _Categories = new Categories(); 
  CategoriesDb _CategoriesDb = new CategoriesDb(); 
if (CategoryID!= "") _Categories.CategoryID = Convert.ToInt32(CategoryID);

if (CategoryName!= "") _Categories.CategoryName =  CategoryName; 


  _CategoriesDb._Categories = _Categories;
    _CategoriesDb.Delete(); 
   return "";
   }
  [WebMethod]
    public List<SelectInputProperties> SelectAll()
    {
        CategoriesDb _CategoriesDb = new CategoriesDb();
        return _CategoriesDb.Select();
    }
 [WebMethod] 
   public Categories Select(string CategoryID)
    {
        CategoriesDb _CategoriesDb = new CategoriesDb();
        return _CategoriesDb.Select(CategoryID);
    }
}
