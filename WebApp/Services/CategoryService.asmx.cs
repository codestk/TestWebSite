using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Web; 
using System.Web.Services; 
using WebApp.Business;
using StkLib.Common;
using WebApp.Code.Utility.Properties.Controls;
namespace WebApp.Services  
{
    /// <summary> 
    /// Summary description for AutoCompleteService 
    /// </summary> 
    [WebService(Namespace = "http://tempuri.org/")] 
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)] 
    [System.ComponentModel.ToolboxItem(false)] 
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.  
     [System.Web.Script.Services.ScriptService] 
 
public class CategoryService : System.Web.Services.WebService 
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
            CategoryDb _CategoryDb = new CategoryDb(); 
 
 
            bool isUpdate = _CategoryDb.UpdateColumn(id, column, value); 
            return isUpdate; 
        }
[WebMethod] 
       public List<string> GetKeyWordsAllColumn(string keyword) 
       { 
           CategoryDb _CategoryDb = new CategoryDb(); 
           List<string> keywords = _CategoryDb.GetKeyWordsAllColumn(keyword); 
           return keywords; 
       }

[WebMethod] 
       public List<string> GetKeyWordsOneColumn(string column, string keyword) 
       { 
           CategoryDb _CategoryDb = new CategoryDb(); 
           List<string> keywords = _CategoryDb.GetKeyWordsOneColumn(column,keyword); 
           return keywords; 
       }


    [WebMethod]
public List<Category> Search(string PageIndex,string PageSize,string SortExpression,string SortDirection,string CategoryID,string CategoryName,string CategoryDetail)
    {
 Category _Category = new Category(); 
  CategoryDb _CategoryDb = new CategoryDb(); 
if (CategoryID!= "") _Category.CategoryID =  CategoryID; 


if (CategoryName!= "") _Category.CategoryName =  CategoryName; 


if (CategoryDetail!= "") _Category.CategoryDetail =  CategoryDetail; 


  _CategoryDb._Category = _Category;
int _PageIndex = Convert.ToInt32(PageIndex);
int _PageSize = Convert.ToInt32(PageSize);

 if (SortExpression.Trim() != "")
        {
            _CategoryDb._SortDirection = SortDirection;

            _CategoryDb._SortExpression = SortExpression;
        }
return _CategoryDb.GetPageWise(_PageIndex, _PageSize);
   }

    [WebMethod]
public string Save(string CategoryID,string CategoryName,string CategoryDetail)
    {
 Category _Category = new Category(); 
  CategoryDb _CategoryDb = new CategoryDb(); 
if (CategoryID!= "") _Category.CategoryID =  CategoryID; 


if (CategoryName!= "") _Category.CategoryName =  CategoryName; 


if (CategoryDetail!= "") _Category.CategoryDetail =  CategoryDetail; 


  _CategoryDb._Category = _Category;
  object result= _CategoryDb.Insert(); 
   return result.ToString();
   }

    [WebMethod]
public string Update(string CategoryID,string CategoryName,string CategoryDetail)
    {
 Category _Category = new Category(); 
  CategoryDb _CategoryDb = new CategoryDb(); 
if (CategoryID!= "") _Category.CategoryID =  CategoryID; 


if (CategoryName!= "") _Category.CategoryName =  CategoryName; 


if (CategoryDetail!= "") _Category.CategoryDetail =  CategoryDetail; 


  _CategoryDb._Category = _Category;
    _CategoryDb.Update(); 
   return "";
   }

    [WebMethod]
public string Delete(string CategoryID,string CategoryName,string CategoryDetail)
    {
 Category _Category = new Category(); 
  CategoryDb _CategoryDb = new CategoryDb(); 
if (CategoryID!= "") _Category.CategoryID =  CategoryID; 


if (CategoryName!= "") _Category.CategoryName =  CategoryName; 


if (CategoryDetail!= "") _Category.CategoryDetail =  CategoryDetail; 


  _CategoryDb._Category = _Category;
    _CategoryDb.Delete(); 
   return "";
   }
  [WebMethod]
    public List<SelectInputProperties> SelectAll()
    {
        CategoryDb _CategoryDb = new CategoryDb();
        return _CategoryDb.Select();
    }
 [WebMethod] 
   public Category Select(string CategoryID)
    {
        CategoryDb _CategoryDb = new CategoryDb();
        return _CategoryDb.Select(CategoryID);
    }
}}