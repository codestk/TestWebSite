using System.Web;

namespace Stk.Common
{
    public class StkDefaultValue
    {
        public static string GetCurrentUSerId()
        {
            string UserId;
            UserId = HttpContext.Current.User.Identity.Name;
            //Fore Test

            return UserId;
        }

        public static System.Drawing.Color GetErrorColor()
        {
            return System.Drawing.Color.FromName("#989A9A");
        }

        public static System.Drawing.Color GetWarningColor()
        {
            return System.Drawing.Color.FromName("#ffeb9c");
        }

        public static System.Drawing.Color GetSuccessColor()
        {
            return System.Drawing.Color.FromName("#c6efce");
        }
    }
}