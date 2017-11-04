using System;
using System.Web;
using System.Web.Security;
using WebApp.AppCode.Utility.Security;

namespace WebApp
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Button1_Click(object sender, EventArgs e)
        {

            //Demo
            //if((user.Text=="a") && (password.Text=="a")

            //    )
            //{
            //    Response.Redirect("AccountRegistrationListFilter.aspx");

            //}
            //else
            //{
            //    lblError.Visible = true;
            //    //Response.Redirect("login.aspx", true);
            //}

            Sigon();
        }

        private void Sigon()
        {
            Logon logon = new Logon
            {
                //userName = user.Text,
                //passWord = password.Text

                 userName = "momojojo",
                passWord = "P@ssw0rd"
            };
            if (logon.ValidateUser())

            //if ((user.Text == "demo") && (password.Text == "demo"))
            {
                //STkRolesGroup stkRole = new STkRolesGroup();
                //Roles = lg.GetRole();
                var Roles = "Admin";
                //var stkEmployee = new Bu.Stk_Employee();

                //stkEmployee.GetEmployee(txtUserName.Text.Trim());
                var tkt = new FormsAuthenticationTicket(1, user.Text, DateTime.Now, DateTime.Now.AddMinutes(50), true,
                    Roles);

                var cookiestr = FormsAuthentication.Encrypt(tkt);
                var ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr)
                {
                    Path = FormsAuthentication.FormsCookiePath
                };
                //if (chkPersistCookie.Checked)
                //    ck.Expires = tkt.Expiration;
                Response.Cookies.Add(ck);

                //strRedirect = Request["ReturnUrl"];
                // if (strRedirect == null)
                // {
                var strRedirect = "AccountRegistrationListFilter.aspx";

                // }

                Response.Redirect(strRedirect, true);
            }
            else
            {
                lblError.Visible = true;
                //Response.Redirect("login.aspx", true);
            }
        }
    }
}