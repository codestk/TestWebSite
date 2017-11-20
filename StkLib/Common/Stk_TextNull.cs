using System;

namespace StkLib.Common
{
    public class Stk_TextNull
    {
        private const string DefaultEmpty = "";

        public static string DateTotext(DateTime? dt)
        {
            string txt = dt.ToString();
            if (txt == "")
            {
                txt = DefaultEmpty;
            }
            return txt;
        }

        public static string StringTotext(string s)
        {
            string txt = s;
            if (string.IsNullOrEmpty(txt))
                txt = DefaultEmpty;

            return txt;
        }
    }
}