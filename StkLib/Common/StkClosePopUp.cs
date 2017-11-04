using System.Web;
using System.Text;
using System.Web.UI;
namespace Stk.Common
{
    public class StkClosePopUp
    {

        public static void Close()
        {
            Page page = HttpContext.Current.CurrentHandler as Page;
            if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("closeThickBox"))
            {
                page.ClientScript.RegisterStartupScript(typeof(StkClosePopUp), "closeThickBox", "self.parent.updated();", true);
            }
            }


        public static void CloseAjax(Control ct)
        {

            ScriptManager.RegisterClientScriptBlock(ct, typeof(StkClosePopUp), "closeThickBox", "self.parent.updated();", true);
        }



        public static void CloseBindDataAjax(Control ct)
        {

            ScriptManager.RegisterClientScriptBlock(ct, typeof(StkClosePopUp), "closeThickBox", "self.parent.updatedBind();", true);
        }
    }
}