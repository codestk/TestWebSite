using System;
using System.Web;
using System.Web.Security;
using WebApp;

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
              Logon lg = new Logon();
            //if (lg.ValidateUser(user.Text, password.Text))

            if ((user.Text == "demo") && (password.Text == "demo"))
            {
                FormsAuthenticationTicket tkt;
                string cookiestr;
                HttpCookie ck;

                //STkRolesGroup stkRole = new STkRolesGroup();
                string Roles;
                //Roles = lg.GetRole();
                Roles = "A";
                //var stkEmployee = new Bu.Stk_Employee();

                //stkEmployee.GetEmployee(txtUserName.Text.Trim());
                tkt = new FormsAuthenticationTicket(1, user.Text, DateTime.Now, DateTime.Now.AddMinutes(50), true,
                    Roles);

                cookiestr = FormsAuthentication.Encrypt(tkt);
                ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
                //if (chkPersistCookie.Checked)
                //    ck.Expires = tkt.Expiration;
                ck.Path = FormsAuthentication.FormsCookiePath;
                Response.Cookies.Add(ck);

                string strRedirect;
                //strRedirect = Request["ReturnUrl"];
                // if (strRedirect == null)
                // {
                strRedirect = "AccountRegistrationListFilter.aspx";

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