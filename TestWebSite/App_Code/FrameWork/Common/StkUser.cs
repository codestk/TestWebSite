using System.Web;

namespace MPO.Code.Common
{
    public class StkUser
    {
        public static string GetCurrentUser()
        {
            return HttpContext.Current.User.Identity.Name ;
            //For Test Error
            //return HttpContext.Current.User.ToString();
        }

   
    }
}