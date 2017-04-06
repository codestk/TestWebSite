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
 
public class MPO_BRANDService : System.Web.Services.WebService 
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
            MPO_BRANDDb _MPO_BRANDDb = new MPO_BRANDDb(); 
 
 
            bool isUpdate = _MPO_BRANDDb.UpdateColumn(id, column, value); 
            return isUpdate; 
        }
[WebMethod] 
       public List<string> GetKeyWordsAllColumn(string keyword) 
       { 
           MPO_BRANDDb _MPO_BRANDDb = new MPO_BRANDDb(); 
           List<string> keywords = _MPO_BRANDDb.GetKeyWordsAllColumn(keyword); 
           return keywords; 
       }

[WebMethod] 
       public List<string> GetKeyWordsOneColumn(string column, string keyword) 
       { 
           MPO_BRANDDb _MPO_BRANDDb = new MPO_BRANDDb(); 
           List<string> keywords = _MPO_BRANDDb.GetKeyWordsOneColumn(column,keyword); 
           return keywords; 
       }


    [WebMethod]
public List<MPO_BRAND> Search(string PageIndex,string PageSize,string SortExpression,string SortDirection,string PR_BRAND,string BRAND_DEC)
    {
 MPO_BRAND _MPO_BRAND = new MPO_BRAND(); 
  MPO_BRANDDb _MPO_BRANDDb = new MPO_BRANDDb(); 
if (PR_BRAND!= "") _MPO_BRAND.PR_BRAND =  PR_BRAND; 


if (BRAND_DEC!= "") _MPO_BRAND.BRAND_DEC =  BRAND_DEC; 


  _MPO_BRANDDb._MPO_BRAND = _MPO_BRAND;
int _PageIndex = Convert.ToInt32(PageIndex);
int _PageSize = Convert.ToInt32(PageSize);

 if (SortExpression.Trim() != "")
        {
            _MPO_BRANDDb._SortDirection = SortDirection;

            _MPO_BRANDDb._SortExpression = SortExpression;
        }
return _MPO_BRANDDb.GetPageWise(_PageIndex, _PageSize);
   }

    [WebMethod]
public string Save(string PR_BRAND,string BRAND_DEC)
    {
 MPO_BRAND _MPO_BRAND = new MPO_BRAND(); 
  MPO_BRANDDb _MPO_BRANDDb = new MPO_BRANDDb(); 
if (PR_BRAND!= "") _MPO_BRAND.PR_BRAND =  PR_BRAND; 


if (BRAND_DEC!= "") _MPO_BRAND.BRAND_DEC =  BRAND_DEC; 


  _MPO_BRANDDb._MPO_BRAND = _MPO_BRAND;
  object result= _MPO_BRANDDb.Insert(); 
   return result.ToString();
   }

    [WebMethod]
public string Update(string PR_BRAND,string BRAND_DEC)
    {
 MPO_BRAND _MPO_BRAND = new MPO_BRAND(); 
  MPO_BRANDDb _MPO_BRANDDb = new MPO_BRANDDb(); 
if (PR_BRAND!= "") _MPO_BRAND.PR_BRAND =  PR_BRAND; 


if (BRAND_DEC!= "") _MPO_BRAND.BRAND_DEC =  BRAND_DEC; 


  _MPO_BRANDDb._MPO_BRAND = _MPO_BRAND;
    _MPO_BRANDDb.Update(); 
   return "";
   }

    [WebMethod]
public string Delete(string PR_BRAND,string BRAND_DEC)
    {
 MPO_BRAND _MPO_BRAND = new MPO_BRAND(); 
  MPO_BRANDDb _MPO_BRANDDb = new MPO_BRANDDb(); 
if (PR_BRAND!= "") _MPO_BRAND.PR_BRAND =  PR_BRAND; 


if (BRAND_DEC!= "") _MPO_BRAND.BRAND_DEC =  BRAND_DEC; 


  _MPO_BRANDDb._MPO_BRAND = _MPO_BRAND;
    _MPO_BRANDDb.Delete(); 
   return "";
   }
  [WebMethod]
    public List<SelectInputProperties> SelectAll()
    {
        MPO_BRANDDb _MPO_BRANDDb = new MPO_BRANDDb();
        return _MPO_BRANDDb.Select();
    }
 [WebMethod] 
   public MPO_BRAND Select(string PR_BRAND)
    {
        MPO_BRANDDb _MPO_BRANDDb = new MPO_BRANDDb();
        return _MPO_BRANDDb.Select(PR_BRAND);
    }
}
