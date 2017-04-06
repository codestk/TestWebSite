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
 
public class MPO_PRODUCT_P2Service : System.Web.Services.WebService 
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
            MPO_PRODUCT_P2Db _MPO_PRODUCT_P2Db = new MPO_PRODUCT_P2Db(); 
 
 
            bool isUpdate = _MPO_PRODUCT_P2Db.UpdateColumn(id, column, value); 
            return isUpdate; 
        }
[WebMethod] 
       public List<string> GetKeyWordsAllColumn(string keyword) 
       { 
           MPO_PRODUCT_P2Db _MPO_PRODUCT_P2Db = new MPO_PRODUCT_P2Db(); 
           List<string> keywords = _MPO_PRODUCT_P2Db.GetKeyWordsAllColumn(keyword); 
           return keywords; 
       }

[WebMethod] 
       public List<string> GetKeyWordsOneColumn(string column, string keyword) 
       { 
           MPO_PRODUCT_P2Db _MPO_PRODUCT_P2Db = new MPO_PRODUCT_P2Db(); 
           List<string> keywords = _MPO_PRODUCT_P2Db.GetKeyWordsOneColumn(column,keyword); 
           return keywords; 
       }


    [WebMethod]
public List<MPO_PRODUCT_P2> Search(string PageIndex,string PageSize,string SortExpression,string SortDirection,string PR_LOT,string PR_SOURCE,string PR_PRODUCT_LINE,string PR_FORMULA_AND_TEST,string PR_SIZE)
    {
 MPO_PRODUCT_P2 _MPO_PRODUCT_P2 = new MPO_PRODUCT_P2(); 
  MPO_PRODUCT_P2Db _MPO_PRODUCT_P2Db = new MPO_PRODUCT_P2Db(); 
if (PR_LOT!= "") _MPO_PRODUCT_P2.PR_LOT = Convert.ToInt32(PR_LOT);

if (PR_SOURCE!= "") _MPO_PRODUCT_P2.PR_SOURCE =  PR_SOURCE; 


if (PR_PRODUCT_LINE!= "") _MPO_PRODUCT_P2.PR_PRODUCT_LINE =  PR_PRODUCT_LINE; 


if (PR_FORMULA_AND_TEST!= "") _MPO_PRODUCT_P2.PR_FORMULA_AND_TEST =  PR_FORMULA_AND_TEST; 


if (PR_SIZE!= "") _MPO_PRODUCT_P2.PR_SIZE =  PR_SIZE; 


  _MPO_PRODUCT_P2Db._MPO_PRODUCT_P2 = _MPO_PRODUCT_P2;
int _PageIndex = Convert.ToInt32(PageIndex);
int _PageSize = Convert.ToInt32(PageSize);

 if (SortExpression.Trim() != "")
        {
            _MPO_PRODUCT_P2Db._SortDirection = SortDirection;

            _MPO_PRODUCT_P2Db._SortExpression = SortExpression;
        }
return _MPO_PRODUCT_P2Db.GetPageWise(_PageIndex, _PageSize);
   }

    [WebMethod]
public string Save(string PR_LOT,string PR_SOURCE,string PR_PRODUCT_LINE,string PR_FORMULA_AND_TEST,string PR_SIZE)
    {
 MPO_PRODUCT_P2 _MPO_PRODUCT_P2 = new MPO_PRODUCT_P2(); 
  MPO_PRODUCT_P2Db _MPO_PRODUCT_P2Db = new MPO_PRODUCT_P2Db(); 
if (PR_LOT!= "") _MPO_PRODUCT_P2.PR_LOT = Convert.ToInt32(PR_LOT);

if (PR_SOURCE!= "") _MPO_PRODUCT_P2.PR_SOURCE =  PR_SOURCE; 


if (PR_PRODUCT_LINE!= "") _MPO_PRODUCT_P2.PR_PRODUCT_LINE =  PR_PRODUCT_LINE; 


if (PR_FORMULA_AND_TEST!= "") _MPO_PRODUCT_P2.PR_FORMULA_AND_TEST =  PR_FORMULA_AND_TEST; 


if (PR_SIZE!= "") _MPO_PRODUCT_P2.PR_SIZE =  PR_SIZE; 


  _MPO_PRODUCT_P2Db._MPO_PRODUCT_P2 = _MPO_PRODUCT_P2;
  object result= _MPO_PRODUCT_P2Db.Insert(); 
   return result.ToString();
   }

    [WebMethod]
public string Update(string PR_LOT,string PR_SOURCE,string PR_PRODUCT_LINE,string PR_FORMULA_AND_TEST,string PR_SIZE)
    {
 MPO_PRODUCT_P2 _MPO_PRODUCT_P2 = new MPO_PRODUCT_P2(); 
  MPO_PRODUCT_P2Db _MPO_PRODUCT_P2Db = new MPO_PRODUCT_P2Db(); 
if (PR_LOT!= "") _MPO_PRODUCT_P2.PR_LOT = Convert.ToInt32(PR_LOT);

if (PR_SOURCE!= "") _MPO_PRODUCT_P2.PR_SOURCE =  PR_SOURCE; 


if (PR_PRODUCT_LINE!= "") _MPO_PRODUCT_P2.PR_PRODUCT_LINE =  PR_PRODUCT_LINE; 


if (PR_FORMULA_AND_TEST!= "") _MPO_PRODUCT_P2.PR_FORMULA_AND_TEST =  PR_FORMULA_AND_TEST; 


if (PR_SIZE!= "") _MPO_PRODUCT_P2.PR_SIZE =  PR_SIZE; 


  _MPO_PRODUCT_P2Db._MPO_PRODUCT_P2 = _MPO_PRODUCT_P2;
    _MPO_PRODUCT_P2Db.Update(); 
   return "";
   }

    [WebMethod]
public string Delete(string PR_LOT,string PR_SOURCE,string PR_PRODUCT_LINE,string PR_FORMULA_AND_TEST,string PR_SIZE)
    {
 MPO_PRODUCT_P2 _MPO_PRODUCT_P2 = new MPO_PRODUCT_P2(); 
  MPO_PRODUCT_P2Db _MPO_PRODUCT_P2Db = new MPO_PRODUCT_P2Db(); 
if (PR_LOT!= "") _MPO_PRODUCT_P2.PR_LOT = Convert.ToInt32(PR_LOT);

if (PR_SOURCE!= "") _MPO_PRODUCT_P2.PR_SOURCE =  PR_SOURCE; 


if (PR_PRODUCT_LINE!= "") _MPO_PRODUCT_P2.PR_PRODUCT_LINE =  PR_PRODUCT_LINE; 


if (PR_FORMULA_AND_TEST!= "") _MPO_PRODUCT_P2.PR_FORMULA_AND_TEST =  PR_FORMULA_AND_TEST; 


if (PR_SIZE!= "") _MPO_PRODUCT_P2.PR_SIZE =  PR_SIZE; 


  _MPO_PRODUCT_P2Db._MPO_PRODUCT_P2 = _MPO_PRODUCT_P2;
    _MPO_PRODUCT_P2Db.Delete(); 
   return "";
   }
  [WebMethod]
    public List<SelectInputProperties> SelectAll()
    {
        MPO_PRODUCT_P2Db _MPO_PRODUCT_P2Db = new MPO_PRODUCT_P2Db();
        return _MPO_PRODUCT_P2Db.Select();
    }
 [WebMethod] 
   public MPO_PRODUCT_P2 Select(string PR_LOT)
    {
        MPO_PRODUCT_P2Db _MPO_PRODUCT_P2Db = new MPO_PRODUCT_P2Db();
        return _MPO_PRODUCT_P2Db.Select(PR_LOT);
    }
}
