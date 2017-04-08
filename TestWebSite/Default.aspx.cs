using StkLib.CCEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int b = 99;
        int a = 0;
        Response.Write(User.IsInRole(StringEnum.GetStringValue(EnumStkRole.Admin)));
        Response.Write(User.IsInRole(StringEnum.GetStringValue(EnumStkRole.User)));
    }
}