/// <summary>
/// Summary description for StkGlobalDate
/// </summary>

using System;
using System.Globalization;

namespace StkLib.Common
{
    public class StkGlobalDate
    {
        private CultureInfo culture;
        private const string LangName = "en-Us";

        public StkGlobalDate()
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="str"> 9 Jun 2016  d Mmm yyyy</param>
        /// <returns></returns>
        public static DateTime? TextEnToDate(string str)
        {
            DateTime? dt = null;
            try
            {
                //dt = DateTime.ParseExact(str, "d MMMM yyyy",CultureInfo.InvariantCulture);
                dt = DateTime.ParseExact(str, "d MMM yyyy", CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                string a = ex.ToString();
                dt = null;
            }

            return dt;
        }

        /// <summary>
        /// Convert โดยไม่ขึ้นกับ Culture ใช้ Eng
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string DateToTextEngFormat(object dt)
        {
            string output = "";
            try
            {
                DateTime? _Datetemp;
                _Datetemp = (DateTime?)(dt);
                if (_Datetemp.HasValue)
                {
                    DateTime tempDateTime = Convert.ToDateTime(_Datetemp);
                    output = tempDateTime.ToString("d MMMM yyyy", new CultureInfo(LangName, false));
                }

                //output = _Datetemp.ToString("d MMMM yyyy", new CultureInfo(LangName, false));
            }
            catch
            {
                output = "";
            }
            return output;
        }
    }
}