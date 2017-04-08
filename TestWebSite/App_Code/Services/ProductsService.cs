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
 
public class ProductsService : System.Web.Services.WebService 
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
            ProductsDb _ProductsDb = new ProductsDb(); 
 
 
            bool isUpdate = _ProductsDb.UpdateColumn(id, column, value); 
            return isUpdate; 
        }
[WebMethod] 
       public List<string> GetKeyWordsAllColumn(string keyword) 
       { 
           ProductsDb _ProductsDb = new ProductsDb(); 
           List<string> keywords = _ProductsDb.GetKeyWordsAllColumn(keyword); 
           return keywords; 
       }

[WebMethod] 
       public List<string> GetKeyWordsOneColumn(string column, string keyword) 
       { 
           ProductsDb _ProductsDb = new ProductsDb(); 
           List<string> keywords = _ProductsDb.GetKeyWordsOneColumn(column,keyword); 
           return keywords; 
       }


    [WebMethod]
public List<Products> Search(string PageIndex,string PageSize,string SortExpression,string SortDirection,string ProductID,string ProductName,string SupplierID,string CategoryID,string QuantityPerUnit,string UnitPrice,string UnitsInStock,string UnitsOnOrder,string ReorderLevel,string Discontinued)
    {
 Products _Products = new Products(); 
  ProductsDb _ProductsDb = new ProductsDb(); 
if (ProductID!= "") _Products.ProductID = Convert.ToInt32(ProductID);

if (ProductName!= "") _Products.ProductName =  ProductName; 


if (SupplierID!= "") _Products.SupplierID = Convert.ToInt32(SupplierID);

if (CategoryID!= "") _Products.CategoryID = Convert.ToInt32(CategoryID);

if (QuantityPerUnit!= "") _Products.QuantityPerUnit =  QuantityPerUnit; 


if (UnitPrice!= "") _Products.UnitPrice =  Convert.ToDecimal (UnitPrice);

if (UnitsInStock!= "") {string bit = (UnitsInStock == "true" ? "1" : "0");
_Products.UnitsInStock =Convert.ToInt16(bit);}


if (UnitsOnOrder!= "") {string bit = (UnitsOnOrder == "true" ? "1" : "0");
_Products.UnitsOnOrder =Convert.ToInt16(bit);}


if (ReorderLevel!= "") {string bit = (ReorderLevel == "true" ? "1" : "0");
_Products.ReorderLevel =Convert.ToInt16(bit);}


if (Discontinued!= "") {string bit = (Discontinued == "true" ? "1" : "0");
_Products.Discontinued =Convert.ToBoolean(bit);}


  _ProductsDb._Products = _Products;
int _PageIndex = Convert.ToInt32(PageIndex);
int _PageSize = Convert.ToInt32(PageSize);

 if (SortExpression.Trim() != "")
        {
            _ProductsDb._SortDirection = SortDirection;

            _ProductsDb._SortExpression = SortExpression;
        }
return _ProductsDb.GetPageWise(_PageIndex, _PageSize);
   }

    [WebMethod]
public string Save(string ProductID,string ProductName,string SupplierID,string CategoryID,string QuantityPerUnit,string UnitPrice,string UnitsInStock,string UnitsOnOrder,string ReorderLevel,string Discontinued)
    {
 Products _Products = new Products(); 
  ProductsDb _ProductsDb = new ProductsDb(); 
// if (ProductID!= "") _Products.ProductID = Convert.ToInt32(ProductID);

if (ProductName!= "") _Products.ProductName =  ProductName; 


if (SupplierID!= "") _Products.SupplierID = Convert.ToInt32(SupplierID);

if (CategoryID!= "") _Products.CategoryID = Convert.ToInt32(CategoryID);

if (QuantityPerUnit!= "") _Products.QuantityPerUnit =  QuantityPerUnit; 


if (UnitPrice!= "") _Products.UnitPrice =  Convert.ToDecimal (UnitPrice);

if (UnitsInStock!= "") {string bit = (UnitsInStock == "true" ? "1" : "0");
_Products.UnitsInStock =Convert.ToInt16(bit);}


if (UnitsOnOrder!= "") {string bit = (UnitsOnOrder == "true" ? "1" : "0");
_Products.UnitsOnOrder =Convert.ToInt16(bit);}


if (ReorderLevel!= "") {string bit = (ReorderLevel == "true" ? "1" : "0");
_Products.ReorderLevel =Convert.ToInt16(bit);}


if (Discontinued!= "") {string bit = (Discontinued == "true" ? "1" : "0");
_Products.Discontinued =Convert.ToBoolean(bit);}


  _ProductsDb._Products = _Products;
  object result= _ProductsDb.Insert(); 
   return result.ToString();
   }

    [WebMethod]
public string Update(string ProductID,string ProductName,string SupplierID,string CategoryID,string QuantityPerUnit,string UnitPrice,string UnitsInStock,string UnitsOnOrder,string ReorderLevel,string Discontinued)
    {
 Products _Products = new Products(); 
  ProductsDb _ProductsDb = new ProductsDb(); 
if (ProductID!= "") _Products.ProductID = Convert.ToInt32(ProductID);

if (ProductName!= "") _Products.ProductName =  ProductName; 


if (SupplierID!= "") _Products.SupplierID = Convert.ToInt32(SupplierID);

if (CategoryID!= "") _Products.CategoryID = Convert.ToInt32(CategoryID);

if (QuantityPerUnit!= "") _Products.QuantityPerUnit =  QuantityPerUnit; 


if (UnitPrice!= "") _Products.UnitPrice =  Convert.ToDecimal (UnitPrice);

if (UnitsInStock!= "") {string bit = (UnitsInStock == "true" ? "1" : "0");
_Products.UnitsInStock =Convert.ToInt16(bit);}


if (UnitsOnOrder!= "") {string bit = (UnitsOnOrder == "true" ? "1" : "0");
_Products.UnitsOnOrder =Convert.ToInt16(bit);}


if (ReorderLevel!= "") {string bit = (ReorderLevel == "true" ? "1" : "0");
_Products.ReorderLevel =Convert.ToInt16(bit);}


if (Discontinued!= "") {string bit = (Discontinued == "true" ? "1" : "0");
_Products.Discontinued =Convert.ToBoolean(bit);}


  _ProductsDb._Products = _Products;
    _ProductsDb.Update(); 
   return "";
   }

    [WebMethod]
public string Delete(string ProductID,string ProductName,string SupplierID,string CategoryID,string QuantityPerUnit,string UnitPrice,string UnitsInStock,string UnitsOnOrder,string ReorderLevel,string Discontinued)
    {
 Products _Products = new Products(); 
  ProductsDb _ProductsDb = new ProductsDb(); 
if (ProductID!= "") _Products.ProductID = Convert.ToInt32(ProductID);

if (ProductName!= "") _Products.ProductName =  ProductName; 


if (SupplierID!= "") _Products.SupplierID = Convert.ToInt32(SupplierID);

if (CategoryID!= "") _Products.CategoryID = Convert.ToInt32(CategoryID);

if (QuantityPerUnit!= "") _Products.QuantityPerUnit =  QuantityPerUnit; 


if (UnitPrice!= "") _Products.UnitPrice =  Convert.ToDecimal (UnitPrice);

if (UnitsInStock!= "") {string bit = (UnitsInStock == "true" ? "1" : "0");
_Products.UnitsInStock =Convert.ToInt16(bit);}


if (UnitsOnOrder!= "") {string bit = (UnitsOnOrder == "true" ? "1" : "0");
_Products.UnitsOnOrder =Convert.ToInt16(bit);}


if (ReorderLevel!= "") {string bit = (ReorderLevel == "true" ? "1" : "0");
_Products.ReorderLevel =Convert.ToInt16(bit);}


if (Discontinued!= "") {string bit = (Discontinued == "true" ? "1" : "0");
_Products.Discontinued =Convert.ToBoolean(bit);}


  _ProductsDb._Products = _Products;
    _ProductsDb.Delete(); 
   return "";
   }
  [WebMethod]
    public List<SelectInputProperties> SelectAll()
    {
        ProductsDb _ProductsDb = new ProductsDb();
        return _ProductsDb.Select();
    }
 [WebMethod] 
   public Products Select(string ProductID)
    {
        ProductsDb _ProductsDb = new ProductsDb();
        return _ProductsDb.Select(ProductID);
    }
}
