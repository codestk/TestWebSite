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
 
public class TestValidateService : System.Web.Services.WebService 
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
            TestValidateDb _TestValidateDb = new TestValidateDb(); 
 
 
            bool isUpdate = _TestValidateDb.UpdateColumn(id, column, value); 
            return isUpdate; 
        }
[WebMethod] 
       public List<string> GetKeyWordsAllColumn(string keyword) 
       { 
           TestValidateDb _TestValidateDb = new TestValidateDb(); 
           List<string> keywords = _TestValidateDb.GetKeyWordsAllColumn(keyword); 
           return keywords; 
       }

[WebMethod] 
       public List<string> GetKeyWordsOneColumn(string column, string keyword) 
       { 
           TestValidateDb _TestValidateDb = new TestValidateDb(); 
           List<string> keywords = _TestValidateDb.GetKeyWordsOneColumn(column,keyword); 
           return keywords; 
       }


    [WebMethod]
public List<TestValidate> Search(string PageIndex,string PageSize,string SortExpression,string SortDirection,string Id,string Name,string NickName,string Max,string Item,string CreateItme)
    {
 TestValidate _TestValidate = new TestValidate(); 
  TestValidateDb _TestValidateDb = new TestValidateDb(); 
if (Id!= "") _TestValidate.Id = Convert.ToInt32(Id);

if (Name!= "") _TestValidate.Name =  Name; 


if (NickName!= "") _TestValidate.NickName =  NickName; 


if (Max!= "") _TestValidate.Max =  Max; 


if (Item!= "") _TestValidate.Item = Convert.ToInt32(Item);

if (CreateItme!= "") _TestValidate.CreateItme =StkGlobalDate.TextEnToDate(CreateItme);

  _TestValidateDb._TestValidate = _TestValidate;
int _PageIndex = Convert.ToInt32(PageIndex);
int _PageSize = Convert.ToInt32(PageSize);

 if (SortExpression.Trim() != "")
        {
            _TestValidateDb._SortDirection = SortDirection;

            _TestValidateDb._SortExpression = SortExpression;
        }
return _TestValidateDb.GetPageWise(_PageIndex, _PageSize);
   }

    [WebMethod]
public string Save(string Id,string Name,string NickName,string Max,string Item,string CreateItme)
    {
 TestValidate _TestValidate = new TestValidate(); 
  TestValidateDb _TestValidateDb = new TestValidateDb(); 
if (Id!= "") _TestValidate.Id = Convert.ToInt32(Id);

if (Name!= "") _TestValidate.Name =  Name; 


if (NickName!= "") _TestValidate.NickName =  NickName; 


if (Max!= "") _TestValidate.Max =  Max; 


if (Item!= "") _TestValidate.Item = Convert.ToInt32(Item);

if (CreateItme!= "") _TestValidate.CreateItme =StkGlobalDate.TextEnToDate(CreateItme);

  _TestValidateDb._TestValidate = _TestValidate;
  object result= _TestValidateDb.Insert(); 
   return result.ToString();
   }

    [WebMethod]
public string Update(string Id,string Name,string NickName,string Max,string Item,string CreateItme)
    {
 TestValidate _TestValidate = new TestValidate(); 
  TestValidateDb _TestValidateDb = new TestValidateDb(); 
if (Id!= "") _TestValidate.Id = Convert.ToInt32(Id);

if (Name!= "") _TestValidate.Name =  Name; 


if (NickName!= "") _TestValidate.NickName =  NickName; 


if (Max!= "") _TestValidate.Max =  Max; 


if (Item!= "") _TestValidate.Item = Convert.ToInt32(Item);

if (CreateItme!= "") _TestValidate.CreateItme =StkGlobalDate.TextEnToDate(CreateItme);

  _TestValidateDb._TestValidate = _TestValidate;
    _TestValidateDb.Update(); 
   return "";
   }

    [WebMethod]
public string Delete(string Id,string Name,string NickName,string Max,string Item,string CreateItme)
    {
 TestValidate _TestValidate = new TestValidate(); 
  TestValidateDb _TestValidateDb = new TestValidateDb(); 
if (Id!= "") _TestValidate.Id = Convert.ToInt32(Id);

if (Name!= "") _TestValidate.Name =  Name; 


if (NickName!= "") _TestValidate.NickName =  NickName; 


if (Max!= "") _TestValidate.Max =  Max; 


if (Item!= "") _TestValidate.Item = Convert.ToInt32(Item);

if (CreateItme!= "") _TestValidate.CreateItme =StkGlobalDate.TextEnToDate(CreateItme);

  _TestValidateDb._TestValidate = _TestValidate;
    _TestValidateDb.Delete(); 
   return "";
   }
  [WebMethod]
    public List<SelectInputProperties> SelectAll()
    {
        TestValidateDb _TestValidateDb = new TestValidateDb();
        return _TestValidateDb.Select();
    }
 [WebMethod] 
   public TestValidate Select(string Id)
    {
        TestValidateDb _TestValidateDb = new TestValidateDb();
        return _TestValidateDb.Select(Id);
    }
}}