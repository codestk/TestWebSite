 
using System;
using System.Web;
 
 
    public class Stk_QueryString
    {
        private readonly string _key = Config.GetApllicationKey();

        public string EncryptQueryString(string lotNo)
        {
            return EncryptDecryptQueryString.Encrypt(lotNo, _key);
        }

        public string DecryptQueryString(string lotNoEncrypt)
        {
            return EncryptDecryptQueryString.Decrypt(lotNoEncrypt, _key);
        }

        /*For Web*/

        public static string DecryptQuery(string parameter)
        {
            string q = HttpContext.Current.Request.QueryString[parameter];
            var stkQuery = new Stk_QueryString();
            string data = stkQuery.DecryptQueryString(q);
            return data;
        }

        public static string EncryptQuery(object data)
        {
            if (data == null) throw new ArgumentNullException("data");

            var stkQuery = new Stk_QueryString();

            return stkQuery.EncryptQueryString(data.ToString());
        }

        public static bool HaveQuery(string parameter)
        {
            bool o = false;
            if (HttpContext.Current.Request.QueryString[parameter] != null)
            {
                o = true;
            }
            return o;
        }
    }
 