using FluentValidation.Results;
using StkLib.Common;
using System;
using System.Collections.Generic;
using System.Web.Services;
using WebApp.AppCode.Business;
using WebApp.Business;
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
    public class APP_USERService : System.Web.Services.WebService
    {
        [WebMethod]
        public string Service()
        {
            return "1.0.0.1";
        }

        //For Jquery  ----------------------------------------------------------------------------------------------
        [WebMethod]
        public Boolean SaveColumn(string id, string column, string value)
        {
            APP_USERDb _APP_USERDb = new APP_USERDb();

            bool isUpdate = _APP_USERDb.UpdateColumn(id, column, value);
            return isUpdate;
        }

        [WebMethod]
        public List<string> GetKeyWordsAllColumn(string keyword)
        {
            APP_USERDb _APP_USERDb = new APP_USERDb();
            List<string> keywords = _APP_USERDb.GetKeyWordsAllColumn(keyword);
            return keywords;
        }

        [WebMethod]
        public List<string> GetKeyWordsOneColumn(string column, string keyword)
        {
            APP_USERDb _APP_USERDb = new APP_USERDb();
            List<string> keywords = _APP_USERDb.GetKeyWordsOneColumn(column, keyword);
            return keywords;
        }

        [WebMethod]
        public List<APP_USER> Search(string PageIndex, string PageSize, string SortExpression, string SortDirection, string UserID, string Password, string FirstName, string LastName, string Tel, string FLAG, string RoleAdmin, string RoleUser, string Created)
        {
            APP_USER _APP_USER = new APP_USER();
            APP_USERDb _APP_USERDb = new APP_USERDb();
            if (UserID != "") _APP_USER.UserID = UserID;

            if (Password != "") _APP_USER.Password = Password;

            if (FirstName != "") _APP_USER.FirstName = FirstName;

            if (LastName != "") _APP_USER.LastName = LastName;

            if (Tel != "") _APP_USER.Tel = Tel;

            if (FLAG != "")
            {
                int bit = (FLAG == "true" ? 1 : 0);
                _APP_USER.FLAG = Convert.ToBoolean(bit);
            }

            if (RoleAdmin != "")
            {
                int bit = (RoleAdmin == "true" ? 1 : 0);
                _APP_USER.RoleAdmin = Convert.ToBoolean(bit);
            }

            if (RoleUser != "")
            {
                int bit = (RoleUser == "true" ? 1 : 0);
                _APP_USER.RoleUser = Convert.ToBoolean(bit);
            }

            if (Created != "") _APP_USER.Created = StkGlobalDate.TextEnToDate(Created);

            _APP_USERDb._APP_USER = _APP_USER;
            int _PageIndex = Convert.ToInt32(PageIndex);
            int _PageSize = Convert.ToInt32(PageSize);

            if (SortExpression.Trim() != "")
            {
                _APP_USERDb._SortDirection = SortDirection;

                _APP_USERDb._SortExpression = SortExpression;
            }
            return _APP_USERDb.GetPageWise(_PageIndex, _PageSize);
        }

        [WebMethod]
        public string Save(string UserID, string Password, string FirstName, string LastName, string Tel, string FLAG, string RoleAdmin, string RoleUser, string Created)
        {
            APP_USER _APP_USER = new APP_USER();
            APP_USERDb _APP_USERDb = new APP_USERDb();
            if (UserID != "") _APP_USER.UserID = UserID;

            if (Password != "") _APP_USER.Password = Password;

            if (FirstName != "") _APP_USER.FirstName = FirstName;

            if (LastName != "") _APP_USER.LastName = LastName;

            if (Tel != "") _APP_USER.Tel = Tel;

            if (FLAG != "")
            {
                int bit = (FLAG == "true" ? 1 : 0);
                _APP_USER.FLAG = Convert.ToBoolean(bit);
            }

            if (RoleAdmin != "")
            {
                int bit = (RoleAdmin == "true" ? 1 : 0);
                _APP_USER.RoleAdmin = Convert.ToBoolean(bit);
            }

            if (RoleUser != "")
            {
                int bit = (RoleUser == "true" ? 1 : 0);
                _APP_USER.RoleUser = Convert.ToBoolean(bit);
            }

            if (Created != "") _APP_USER.Created = StkGlobalDate.TextEnToDate(Created);

            AppUserValidatetor appUserValidatetor = new AppUserValidatetor();

            ValidationResult results = appUserValidatetor.Validate(_APP_USER);

            if (results.IsValid == false)
            {
                IList<ValidationFailure> failures = results.Errors;
            }

            _APP_USERDb._APP_USER = _APP_USER;
            object result = _APP_USERDb.Insert();
            return result.ToString();
        }

        [WebMethod]
        public string Update(string UserID, string Password, string FirstName, string LastName, string Tel, string FLAG, string RoleAdmin, string RoleUser, string Created)
        {
            APP_USER _APP_USER = new APP_USER();
            APP_USERDb _APP_USERDb = new APP_USERDb();
            if (UserID != "") _APP_USER.UserID = UserID;

            if (Password != "") _APP_USER.Password = Password;

            if (FirstName != "") _APP_USER.FirstName = FirstName;

            if (LastName != "") _APP_USER.LastName = LastName;

            if (Tel != "") _APP_USER.Tel = Tel;

            if (FLAG != "")
            {
                int bit = (FLAG == "true" ? 1 : 0);
                _APP_USER.FLAG = Convert.ToBoolean(bit);
            }

            if (RoleAdmin != "")
            {
                int bit = (RoleAdmin == "true" ? 1 : 0);
                _APP_USER.RoleAdmin = Convert.ToBoolean(bit);
            }

            if (RoleUser != "")
            {
                int bit = (RoleUser == "true" ? 1 : 0);
                _APP_USER.RoleUser = Convert.ToBoolean(bit);
            }

            if (Created != "") _APP_USER.Created = StkGlobalDate.TextEnToDate(Created);

            _APP_USERDb._APP_USER = _APP_USER;
            _APP_USERDb.Update();
            return "";
        }

        [WebMethod]
        public string Delete(string UserID, string Password, string FirstName, string LastName, string Tel, string FLAG, string RoleAdmin, string RoleUser, string Created)
        {
            APP_USER _APP_USER = new APP_USER();
            APP_USERDb _APP_USERDb = new APP_USERDb();
            if (UserID != "") _APP_USER.UserID = UserID;

            if (Password != "") _APP_USER.Password = Password;

            if (FirstName != "") _APP_USER.FirstName = FirstName;

            if (LastName != "") _APP_USER.LastName = LastName;

            if (Tel != "") _APP_USER.Tel = Tel;

            if (FLAG != "")
            {
                int bit = (FLAG == "true" ? 1 : 0);
                _APP_USER.FLAG = Convert.ToBoolean(bit);
            }

            if (RoleAdmin != "")
            {
                int bit = (RoleAdmin == "true" ? 1 : 0);
                _APP_USER.RoleAdmin = Convert.ToBoolean(bit);
            }

            if (RoleUser != "")
            {
                int bit = (RoleUser == "true" ? 1 : 0);
                _APP_USER.RoleUser = Convert.ToBoolean(bit);
            }

            if (Created != "") _APP_USER.Created = StkGlobalDate.TextEnToDate(Created);

            _APP_USERDb._APP_USER = _APP_USER;
            _APP_USERDb.Delete();
            return "";
        }

        [WebMethod]
        public List<SelectInputProperties> SelectAll()
        {
            APP_USERDb _APP_USERDb = new APP_USERDb();
            return _APP_USERDb.Select();
        }

        [WebMethod]
        public APP_USER Select(string UserID)
        {
            APP_USERDb _APP_USERDb = new APP_USERDb();
            return _APP_USERDb.Select(UserID);
        }
    }
}