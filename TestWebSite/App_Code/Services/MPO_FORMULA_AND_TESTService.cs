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
 
public class MPO_FORMULA_AND_TESTService : System.Web.Services.WebService 
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
            MPO_FORMULA_AND_TESTDb _MPO_FORMULA_AND_TESTDb = new MPO_FORMULA_AND_TESTDb(); 
 
 
            bool isUpdate = _MPO_FORMULA_AND_TESTDb.UpdateColumn(id, column, value); 
            return isUpdate; 
        }
[WebMethod] 
       public List<string> GetKeyWordsAllColumn(string keyword) 
       { 
           MPO_FORMULA_AND_TESTDb _MPO_FORMULA_AND_TESTDb = new MPO_FORMULA_AND_TESTDb(); 
           List<string> keywords = _MPO_FORMULA_AND_TESTDb.GetKeyWordsAllColumn(keyword); 
           return keywords; 
       }

[WebMethod] 
       public List<string> GetKeyWordsOneColumn(string column, string keyword) 
       { 
           MPO_FORMULA_AND_TESTDb _MPO_FORMULA_AND_TESTDb = new MPO_FORMULA_AND_TESTDb(); 
           List<string> keywords = _MPO_FORMULA_AND_TESTDb.GetKeyWordsOneColumn(column,keyword); 
           return keywords; 
       }


    [WebMethod]
public List<MPO_FORMULA_AND_TEST> Search(string PageIndex,string PageSize,string SortExpression,string SortDirection,string PR_FORMULA_AND_TEST,string FORMULA_AND_TEST_DEC)
    {
 MPO_FORMULA_AND_TEST _MPO_FORMULA_AND_TEST = new MPO_FORMULA_AND_TEST(); 
  MPO_FORMULA_AND_TESTDb _MPO_FORMULA_AND_TESTDb = new MPO_FORMULA_AND_TESTDb(); 
if (PR_FORMULA_AND_TEST!= "") _MPO_FORMULA_AND_TEST.PR_FORMULA_AND_TEST =  PR_FORMULA_AND_TEST; 


if (FORMULA_AND_TEST_DEC!= "") _MPO_FORMULA_AND_TEST.FORMULA_AND_TEST_DEC =  FORMULA_AND_TEST_DEC; 


  _MPO_FORMULA_AND_TESTDb._MPO_FORMULA_AND_TEST = _MPO_FORMULA_AND_TEST;
int _PageIndex = Convert.ToInt32(PageIndex);
int _PageSize = Convert.ToInt32(PageSize);

 if (SortExpression.Trim() != "")
        {
            _MPO_FORMULA_AND_TESTDb._SortDirection = SortDirection;

            _MPO_FORMULA_AND_TESTDb._SortExpression = SortExpression;
        }
return _MPO_FORMULA_AND_TESTDb.GetPageWise(_PageIndex, _PageSize);
   }

    [WebMethod]
public string Save(string PR_FORMULA_AND_TEST,string FORMULA_AND_TEST_DEC)
    {
 MPO_FORMULA_AND_TEST _MPO_FORMULA_AND_TEST = new MPO_FORMULA_AND_TEST(); 
  MPO_FORMULA_AND_TESTDb _MPO_FORMULA_AND_TESTDb = new MPO_FORMULA_AND_TESTDb(); 
if (PR_FORMULA_AND_TEST!= "") _MPO_FORMULA_AND_TEST.PR_FORMULA_AND_TEST =  PR_FORMULA_AND_TEST; 


if (FORMULA_AND_TEST_DEC!= "") _MPO_FORMULA_AND_TEST.FORMULA_AND_TEST_DEC =  FORMULA_AND_TEST_DEC; 


  _MPO_FORMULA_AND_TESTDb._MPO_FORMULA_AND_TEST = _MPO_FORMULA_AND_TEST;
  object result= _MPO_FORMULA_AND_TESTDb.Insert(); 
   return result.ToString();
   }

    [WebMethod]
public string Update(string PR_FORMULA_AND_TEST,string FORMULA_AND_TEST_DEC)
    {
 MPO_FORMULA_AND_TEST _MPO_FORMULA_AND_TEST = new MPO_FORMULA_AND_TEST(); 
  MPO_FORMULA_AND_TESTDb _MPO_FORMULA_AND_TESTDb = new MPO_FORMULA_AND_TESTDb(); 
if (PR_FORMULA_AND_TEST!= "") _MPO_FORMULA_AND_TEST.PR_FORMULA_AND_TEST =  PR_FORMULA_AND_TEST; 


if (FORMULA_AND_TEST_DEC!= "") _MPO_FORMULA_AND_TEST.FORMULA_AND_TEST_DEC =  FORMULA_AND_TEST_DEC; 


  _MPO_FORMULA_AND_TESTDb._MPO_FORMULA_AND_TEST = _MPO_FORMULA_AND_TEST;
    _MPO_FORMULA_AND_TESTDb.Update(); 
   return "";
   }

    [WebMethod]
public string Delete(string PR_FORMULA_AND_TEST,string FORMULA_AND_TEST_DEC)
    {
 MPO_FORMULA_AND_TEST _MPO_FORMULA_AND_TEST = new MPO_FORMULA_AND_TEST(); 
  MPO_FORMULA_AND_TESTDb _MPO_FORMULA_AND_TESTDb = new MPO_FORMULA_AND_TESTDb(); 
if (PR_FORMULA_AND_TEST!= "") _MPO_FORMULA_AND_TEST.PR_FORMULA_AND_TEST =  PR_FORMULA_AND_TEST; 


if (FORMULA_AND_TEST_DEC!= "") _MPO_FORMULA_AND_TEST.FORMULA_AND_TEST_DEC =  FORMULA_AND_TEST_DEC; 


  _MPO_FORMULA_AND_TESTDb._MPO_FORMULA_AND_TEST = _MPO_FORMULA_AND_TEST;
    _MPO_FORMULA_AND_TESTDb.Delete(); 
   return "";
   }
  [WebMethod]
    public List<SelectInputProperties> SelectAll()
    {
        MPO_FORMULA_AND_TESTDb _MPO_FORMULA_AND_TESTDb = new MPO_FORMULA_AND_TESTDb();
        return _MPO_FORMULA_AND_TESTDb.Select();
    }
 [WebMethod] 
   public MPO_FORMULA_AND_TEST Select(string PR_FORMULA_AND_TEST)
    {
        MPO_FORMULA_AND_TESTDb _MPO_FORMULA_AND_TESTDb = new MPO_FORMULA_AND_TESTDb();
        return _MPO_FORMULA_AND_TESTDb.Select(PR_FORMULA_AND_TEST);
    }
}
