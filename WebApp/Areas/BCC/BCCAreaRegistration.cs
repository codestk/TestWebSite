using System.Web.Mvc;

namespace WebApp.Areas.BCC
{
    public class BCCAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "BCC";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "BCC_default",
                "BCC/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}