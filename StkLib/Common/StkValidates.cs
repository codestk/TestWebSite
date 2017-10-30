using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace MPO.Code.Common
{
    public class StkValidates
    {
        /// <summary>
        /// Return Ture if is Nummerric
        /// </summary>
        /// <param name="inputvalue"></param>
        /// <returns></returns>
        public static bool IsNumber(string inputvalue)
        {
            if (inputvalue.Trim() == "")
                return false;

            var isnumber = new Regex("[^0-9]");
            inputvalue = inputvalue.Trim();
            return !isnumber.IsMatch(inputvalue);
        }

        public static bool IsDecimal(string inputvalue)
        {
            decimal checkDecimal;
            if (decimal.TryParse(inputvalue, out checkDecimal))
                return true;
            return false;
        }
        /// <summary>
        /// dd/MM/yyyy
        /// </summary>
        /// <param name="inputvalue"></param>
        /// <returns></returns>
            public static bool IsDate(string inputvalue)
        {
            DateTime dt;
            bool valid = DateTime.TryParseExact(inputvalue, "d/M/yyyy", null, DateTimeStyles.None, out dt);
            return valid;
        }

        /// <summary>
        /// True = Mail Formats
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
         public static bool IsValidEmail(string email)     {       
             // source: http://thedailywtf.com/Articles/Validating_Email_Addresses.aspx        
             var rx = new Regex(@"^[-!#$%&'*+/0-9=?A-Z^_a-z{|}~](\.?[-!#$%&'*+/0-9=?A-Z^_a-z{|}~])*@[a-zA-Z](-?[a-zA-Z0-9])*(\.[a-zA-Z](-?[a-zA-Z0-9])*)+$");       
             return rx.IsMatch(email);     }


     

     
    }
}