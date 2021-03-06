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
 
public class ProductLineService : System.Web.Services.WebService 
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
            ProductLineDb _ProductLineDb = new ProductLineDb(); 
 
 
            bool isUpdate = _ProductLineDb.UpdateColumn(id, column, value); 
            return isUpdate; 
        }
[WebMethod] 
       public List<string> GetKeyWordsAllColumn(string keyword) 
       { 
           ProductLineDb _ProductLineDb = new ProductLineDb(); 
           List<string> keywords = _ProductLineDb.GetKeyWordsAllColumn(keyword); 
           return keywords; 
       }

[WebMethod] 
       public List<string> GetKeyWordsOneColumn(string column, string keyword) 
       { 
           ProductLineDb _ProductLineDb = new ProductLineDb(); 
           List<string> keywords = _ProductLineDb.GetKeyWordsOneColumn(column,keyword); 
           return keywords; 
       }


    [WebMethod]
public List<ProductLine> Search(string PageIndex,string PageSize,string SortExpression,string SortDirection,string ProductLineId,string SourceID,string LineID,string TestFormulaID,string ContainID,string LineSizeID,string CustomerBrandID,string ManufacturingDate,string ExpectItems,string ProcessItems,string CreateDate)
    {
 ProductLine _ProductLine = new ProductLine(); 
  ProductLineDb _ProductLineDb = new ProductLineDb(); 
if (ProductLineId!= "") _ProductLine.ProductLineId =  Convert.ToDecimal (ProductLineId);

if (SourceID!= "") _ProductLine.SourceID =  SourceID; 


if (LineID!= "") _ProductLine.LineID =  LineID; 


if (TestFormulaID!= "") _ProductLine.TestFormulaID =  TestFormulaID; 


if (ContainID!= "") _ProductLine.ContainID =  ContainID; 


if (LineSizeID!= "") _ProductLine.LineSizeID =  LineSizeID; 


if (CustomerBrandID!= "") _ProductLine.CustomerBrandID =  CustomerBrandID; 


if (ManufacturingDate!= "") _ProductLine.ManufacturingDate =StkGlobalDate.TextEnToDate(ManufacturingDate);

if (ExpectItems!= "") _ProductLine.ExpectItems = Convert.ToInt32(ExpectItems);

if (ProcessItems!= "") _ProductLine.ProcessItems = Convert.ToInt32(ProcessItems);

if (CreateDate!= "") _ProductLine.CreateDate =StkGlobalDate.TextEnToDate(CreateDate);

  _ProductLineDb._ProductLine = _ProductLine;
int _PageIndex = Convert.ToInt32(PageIndex);
int _PageSize = Convert.ToInt32(PageSize);

 if (SortExpression.Trim() != "")
        {
            _ProductLineDb._SortDirection = SortDirection;

            _ProductLineDb._SortExpression = SortExpression;
        }
return _ProductLineDb.GetPageWise(_PageIndex, _PageSize);
   }

    [WebMethod]
public string Save(string ProductLineId,string SourceID,string LineID,string TestFormulaID,string ContainID,string LineSizeID,string CustomerBrandID,string ManufacturingDate,string ExpectItems,string ProcessItems)
    {
 ProductLine _ProductLine = new ProductLine(); 
  ProductLineDb _ProductLineDb = new ProductLineDb(); 
// if (ProductLineId!= "") _ProductLine.ProductLineId =  Convert.ToDecimal (ProductLineId);

if (SourceID!= "") _ProductLine.SourceID =  SourceID; 


if (LineID!= "") _ProductLine.LineID =  LineID; 


if (TestFormulaID!= "") _ProductLine.TestFormulaID =  TestFormulaID; 


if (ContainID!= "") _ProductLine.ContainID =  ContainID; 


if (LineSizeID!= "") _ProductLine.LineSizeID =  LineSizeID; 


if (CustomerBrandID!= "") _ProductLine.CustomerBrandID =  CustomerBrandID; 


if (ManufacturingDate!= "") _ProductLine.ManufacturingDate =StkGlobalDate.TextEnToDate(ManufacturingDate);

if (ExpectItems!= "") _ProductLine.ExpectItems = Convert.ToInt32(ExpectItems);

if (ProcessItems!= "") _ProductLine.ProcessItems = Convert.ToInt32(ProcessItems);

  _ProductLineDb._ProductLine = _ProductLine;
  object result= _ProductLineDb.Insert(); 
   return result.ToString();
   }

    [WebMethod]
public string Update(string ProductLineId,string SourceID,string LineID,string TestFormulaID,string ContainID,string LineSizeID,string CustomerBrandID,string ManufacturingDate,string ExpectItems,string ProcessItems)
    {
 ProductLine _ProductLine = new ProductLine(); 
  ProductLineDb _ProductLineDb = new ProductLineDb(); 
if (ProductLineId!= "") _ProductLine.ProductLineId =  Convert.ToDecimal (ProductLineId);

if (SourceID!= "") _ProductLine.SourceID =  SourceID; 


if (LineID!= "") _ProductLine.LineID =  LineID; 


if (TestFormulaID!= "") _ProductLine.TestFormulaID =  TestFormulaID; 


if (ContainID!= "") _ProductLine.ContainID =  ContainID; 


if (LineSizeID!= "") _ProductLine.LineSizeID =  LineSizeID; 


if (CustomerBrandID!= "") _ProductLine.CustomerBrandID =  CustomerBrandID; 


if (ManufacturingDate!= "") _ProductLine.ManufacturingDate =StkGlobalDate.TextEnToDate(ManufacturingDate);

if (ExpectItems!= "") _ProductLine.ExpectItems = Convert.ToInt32(ExpectItems);

if (ProcessItems!= "") _ProductLine.ProcessItems = Convert.ToInt32(ProcessItems);

  _ProductLineDb._ProductLine = _ProductLine;
    _ProductLineDb.Update(); 
   return "";
   }

    [WebMethod]
public string Delete(string ProductLineId,string SourceID,string LineID,string TestFormulaID,string ContainID,string LineSizeID,string CustomerBrandID,string ManufacturingDate,string ExpectItems,string ProcessItems,string CreateDate)
    {
 ProductLine _ProductLine = new ProductLine(); 
  ProductLineDb _ProductLineDb = new ProductLineDb(); 
if (ProductLineId!= "") _ProductLine.ProductLineId =  Convert.ToDecimal (ProductLineId);

if (SourceID!= "") _ProductLine.SourceID =  SourceID; 


if (LineID!= "") _ProductLine.LineID =  LineID; 


if (TestFormulaID!= "") _ProductLine.TestFormulaID =  TestFormulaID; 


if (ContainID!= "") _ProductLine.ContainID =  ContainID; 


if (LineSizeID!= "") _ProductLine.LineSizeID =  LineSizeID; 


if (CustomerBrandID!= "") _ProductLine.CustomerBrandID =  CustomerBrandID; 


if (ManufacturingDate!= "") _ProductLine.ManufacturingDate =StkGlobalDate.TextEnToDate(ManufacturingDate);

if (ExpectItems!= "") _ProductLine.ExpectItems = Convert.ToInt32(ExpectItems);

if (ProcessItems!= "") _ProductLine.ProcessItems = Convert.ToInt32(ProcessItems);

  _ProductLineDb._ProductLine = _ProductLine;
    _ProductLineDb.Delete(); 
   return "";
   }
  [WebMethod]
    public List<SelectInputProperties> SelectAll()
    {
        ProductLineDb _ProductLineDb = new ProductLineDb();
        return _ProductLineDb.Select();
    }
 [WebMethod] 
   public ProductLine Select(string ProductLineId)
    {
        ProductLineDb _ProductLineDb = new ProductLineDb();
        return _ProductLineDb.Select(ProductLineId);
    }
}}