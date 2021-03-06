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
 
public class TestFormulaService : System.Web.Services.WebService 
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
            TestFormulaDb _TestFormulaDb = new TestFormulaDb(); 
 
 
            bool isUpdate = _TestFormulaDb.UpdateColumn(id, column, value); 
            return isUpdate; 
        }
[WebMethod] 
       public List<string> GetKeyWordsAllColumn(string keyword) 
       { 
           TestFormulaDb _TestFormulaDb = new TestFormulaDb(); 
           List<string> keywords = _TestFormulaDb.GetKeyWordsAllColumn(keyword); 
           return keywords; 
       }

[WebMethod] 
       public List<string> GetKeyWordsOneColumn(string column, string keyword) 
       { 
           TestFormulaDb _TestFormulaDb = new TestFormulaDb(); 
           List<string> keywords = _TestFormulaDb.GetKeyWordsOneColumn(column,keyword); 
           return keywords; 
       }


    [WebMethod]
public List<TestFormula> Search(string PageIndex,string PageSize,string SortExpression,string SortDirection,string TestFormulaID,string TestFormulaName,string TestFormulaDetail)
    {
 TestFormula _TestFormula = new TestFormula(); 
  TestFormulaDb _TestFormulaDb = new TestFormulaDb(); 
if (TestFormulaID!= "") _TestFormula.TestFormulaID =  TestFormulaID; 


if (TestFormulaName!= "") _TestFormula.TestFormulaName =  TestFormulaName; 


if (TestFormulaDetail!= "") _TestFormula.TestFormulaDetail =  TestFormulaDetail; 


  _TestFormulaDb._TestFormula = _TestFormula;
int _PageIndex = Convert.ToInt32(PageIndex);
int _PageSize = Convert.ToInt32(PageSize);

 if (SortExpression.Trim() != "")
        {
            _TestFormulaDb._SortDirection = SortDirection;

            _TestFormulaDb._SortExpression = SortExpression;
        }
return _TestFormulaDb.GetPageWise(_PageIndex, _PageSize);
   }

    [WebMethod]
public string Save(string TestFormulaID,string TestFormulaName,string TestFormulaDetail)
    {
 TestFormula _TestFormula = new TestFormula(); 
  TestFormulaDb _TestFormulaDb = new TestFormulaDb(); 
if (TestFormulaID!= "") _TestFormula.TestFormulaID =  TestFormulaID; 


if (TestFormulaName!= "") _TestFormula.TestFormulaName =  TestFormulaName; 


if (TestFormulaDetail!= "") _TestFormula.TestFormulaDetail =  TestFormulaDetail; 


  _TestFormulaDb._TestFormula = _TestFormula;
  object result= _TestFormulaDb.Insert(); 
   return result.ToString();
   }

    [WebMethod]
public string Update(string TestFormulaID,string TestFormulaName,string TestFormulaDetail)
    {
 TestFormula _TestFormula = new TestFormula(); 
  TestFormulaDb _TestFormulaDb = new TestFormulaDb(); 
if (TestFormulaID!= "") _TestFormula.TestFormulaID =  TestFormulaID; 


if (TestFormulaName!= "") _TestFormula.TestFormulaName =  TestFormulaName; 


if (TestFormulaDetail!= "") _TestFormula.TestFormulaDetail =  TestFormulaDetail; 


  _TestFormulaDb._TestFormula = _TestFormula;
    _TestFormulaDb.Update(); 
   return "";
   }

    [WebMethod]
public string Delete(string TestFormulaID,string TestFormulaName,string TestFormulaDetail)
    {
 TestFormula _TestFormula = new TestFormula(); 
  TestFormulaDb _TestFormulaDb = new TestFormulaDb(); 
if (TestFormulaID!= "") _TestFormula.TestFormulaID =  TestFormulaID; 


if (TestFormulaName!= "") _TestFormula.TestFormulaName =  TestFormulaName; 


if (TestFormulaDetail!= "") _TestFormula.TestFormulaDetail =  TestFormulaDetail; 


  _TestFormulaDb._TestFormula = _TestFormula;
    _TestFormulaDb.Delete(); 
   return "";
   }
  [WebMethod]
    public List<SelectInputProperties> SelectAll()
    {
        TestFormulaDb _TestFormulaDb = new TestFormulaDb();
        return _TestFormulaDb.Select();
    }
 [WebMethod] 
   public TestFormula Select(string TestFormulaID)
    {
        TestFormulaDb _TestFormulaDb = new TestFormulaDb();
        return _TestFormulaDb.Select(TestFormulaID);
    }
}}