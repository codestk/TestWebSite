using System;
using System.Globalization;

namespace StkLib.Common
{
    public class StkDate
    {
        /// <summary>
        ///     ใช้เพื่อ....
        /// </summary>
        /// <param name="dd/MM/yyyy"></param>
        /// en-US
        /// <returns></returns>
        public static DateTime TextToDate(string ddMMyyyy)
        {
            string[] dateArray = ddMMyyyy.Split('/');

            string d = dateArray[0];
            string m = dateArray[1];
            string y = dateArray[2];

            //MM/dd/yyyy
            string dateStringReformat = dateArray[1] + "/" + dateArray[0] + "/" + dateArray[2];

            var culture = new CultureInfo("en-US", false);


            DateTime dt = DateTime.ParseExact(dateStringReformat, "d", culture);

            return dt;
        }


        /// <summary>
        ///     ใช้เพื่อ....
        /// </summary>
        /// <param name="dd/MM/yyyy"></param>
        /// en-US
        /// <returns></returns>
        public static DateTime TextToDateThToEn(string ddMMyyyyTh)
        {
            string[] DateArray = ddMMyyyyTh.Split('/');

            string d = DateArray[0];
            string m = DateArray[1];
            string y = DateArray[2];

            //MM/dd/yyyy
            // string dateStringReformat   =DateArray[0] + "/"+ DateArray[1] + "/" + DateArray[2];
            //  string dateStringReformat   =DateArray[1] + "/"+ DateArray[0] + "/" + DateArray[2];
            // System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("th-TH", false);

            int Id = Convert.ToInt32(DateArray[0]);
            int Im = Convert.ToInt32(DateArray[1]);
            int Iy = Convert.ToInt32(DateArray[2]);

            if (Iy > 2500)
            {
                Iy = Iy - 543;
            }

            var dt = new DateTime(Iy, Im, Id);

            return dt;
        }


        /// <summary>
        ///     ใช้เพื่อ....
        /// </summary>
        /// <param name="ddMMyyyy"></param>
        /// <param name="HHmmAMPM"></param>
        /// <returns></returns>
        public static DateTime GetTimeStam(string ddMMyyyy, string HHmmAMPM)
        {
            DateTime dt;
            var culture = new CultureInfo("th-TH", false);
            dt = DateTime.Parse(ddMMyyyy + " " + HHmmAMPM, culture.DateTimeFormat);
            return dt;
        }


        /// <summary>
        ///     ใช้เพื่อ Convert Date ให้เข้ากับ Data Basee
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ConvertDateEnForDb(DateTime date)
        {
            var culture = new CultureInfo("en-US", false);

            return date.ToString("MM/dd/yyyy", culture);
            //return date.ToString("MM/dd/yyyy HH:mm", culture);
            //return date.ToString("d", culture);
        }


        /// <summary>
        ///     ใช้เพื่อแสดง Date ใน TextBox
        /// </summary>
        /// <param name="dt"></param>
        public static string DateTotext(DateTime date)
        {
            var culture = new CultureInfo("th-TH", false);
            return date.ToString("dd/MM/yyyy", culture);

            //   return date.ToString("dd/MM/yyyy", Config.GlobalCulture());
        }
        public static string DateTotext(DateTime? date)
        {
            DateTime dtTemp = Convert.ToDateTime(date);
            string dtString = DateTotext(dtTemp);
            return dtString;
            //   return date.ToString("dd/MM/yyyy", Config.GlobalCulture());
        }

        /// <summary>
        ///     ใช้เพื่อแสดง Date ใน TextBox
        /// </summary>
        /// <param name="dt"></param>
        public static string DateTotextThaiFull(DateTime date)
        {
            var culture = new CultureInfo("th-TH", false);
            return date.ToString("dd MMMM yy", culture);

            //   return date.ToString("dd/MM/yyyy", Config.GlobalCulture());
        }

        public static string DateTotextThaiFull(DateTime? date)
        {
            DateTime dtTemp = Convert.ToDateTime(date);
            string dtString = DateTotextThaiFull(dtTemp);
            return dtString;

        
        }


        /// <summary>
        ///     ใช้เพื่อแสดง Time ใน TextBox
        /// </summary>
        /// <param name="dt"></param>
        public static string TimeTotext(DateTime date)
        {
            var culture = new CultureInfo("en-Us", false);


            return date.ToString("hh:mm tt", culture);
        }


        /// <summary>
        ///     Fix Bug to date
        /// </summary>
        /// <returns></returns>
        public static DateTime ConvertToDate(DateTime? dt)
        {
            DateTime _dt = Convert.ToDateTime(dt);
            return _dt.AddHours(23).AddMinutes(59).AddMilliseconds(59);
        }
    }
}
   