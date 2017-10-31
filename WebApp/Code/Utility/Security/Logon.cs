using System;
using System.Collections.Generic;
using System.Data;
using WebApp.Code.Utility;


public class Logon
    {
        private string _userName;
        private string _passWord;

        public string userName
        {
            get { return _userName; }
            set
            {
                _userName = value;
            }
        }

        public string passWord
        {
            get { return _passWord; }
            set
            {
                _passWord = value;
            }
        }

        public bool ValidateUser(string userName, string passWord)
        {
            string lookupPassword = null;

            // Check for invalid userName.
            // userName must not be null and must be between 1 and 15 characters.
            if ((null == userName) || (0 == userName.Length) || (userName.Length > 15))
            {
                //System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of userName failed.");
                return false;
            }

            // Check for invalid passWord.
            // passWord must not be null and must be between 1 and 25 characters.
            if ((null == passWord) || (0 == passWord.Length) || (passWord.Length > 25))
            {
                //System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of passWord failed.");
                return false;
            }

            // Consult with your SQL Server administrator for an appropriate connection
            // string to use to connect to your local SQL Server.
            //conn = new SqlConnection("server=localhost;Integrated Security=SSPI;database=pubs");
            //conn.Open();

            //// Create SqlCommand to select pwd field from users table given supplied userName.
            //cmd = new SqlCommand("Select pwd from users where uname=@userName", conn);
            //cmd.Parameters.Add("@userName", SqlDbType.VarChar, 25);
            //cmd.Parameters["@userName"].Value = userName;

            // Execute command and fetch pwd field into lookupPassword string.
            //DataAccessLayer db = new DataAccessLayer();

            //Stk_BuBase_R2 stkbasR2=new Stk_BuBase_R2();

            DataAccess _DataAccess = new DataAccess();

            //string SqlCommand = "SELECT EM_PASS FROM EMPLOYEE  where LOWER(EM_ID)='" + userName.ToLower() + "'  AND EM_FLAG ='A';";
            string SqlCommand = "SELECT EM_PASS FROM STK_USER  where LOWER(EM_ID)=@EM_ID  AND EM_FLAG ='A';";

            var prset = new List<IDataParameter>();
            prset.Add(_DataAccess.Db.CreateParameterDb("@EM_ID", userName.ToLower()));
            //prset.Add(_DataAccess.Db.CreateParameterDb("@EM_PASS", passWord));
            lookupPassword = Convert.ToString(_DataAccess.Db.FbExecuteScalar(SqlCommand, prset));
            _userName = userName;
            _passWord = lookupPassword;

            // Add error handling here for debugging.
            // This error message should not be sent back to the caller.

            // If no password found, return false.
            if (null == lookupPassword)
            {
                // You could write failed login attempts here to event log for additional security.
                return false;
            }

            // Compare lookupPassword and input passWord, using a case-sensitive comparison.
            return (0 == string.Compare(lookupPassword, passWord, false));
        }

        public string GetRole()
        {
            string Roles = null;

            DataAccess _DataAccess = new DataAccess();

            //List<IDataParameter> parms = new List<IDataParameter>();
            //parms.Add(new FbParameter(":EM_ID", lg.userName.ToLower()));
            //parms.Add(new FbParameter(":EM_PASS", lg.passWord));
            var prset = new List<IDataParameter>();
            prset.Add(_DataAccess.Db.CreateParameterDb("@EM_ID", _userName));
            prset.Add(_DataAccess.Db.CreateParameterDb("@EM_PASS", _passWord));

            Roles = Convert.ToString(_DataAccess.Db.FbExecuteScalar("SELECT  iif(EM_ROLE_USER = 1, 'A', '') || ',' || iif(EM_ROLE_USER = 1, 'S', '') FROM STK_USER WHERE  (LOWER(EM_ID)=@EM_ID) and (EM_PASS =@EM_PASS)", prset));

            return Roles;
        }
    }
