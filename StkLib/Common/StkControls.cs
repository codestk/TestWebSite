using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Stk.Common
{
    public class StkControls
    {
        private static void DisableAllTextBoxes(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                var tb = c as TextBox;

                if (tb != null)
                {
                    //tb.Enabled = false;
                    tb.ReadOnly = true;
                    tb.BackColor = System.Drawing.Color.FromName("#c6efce");
                    tb.BorderWidth = 0;
                    tb.ForeColor = System.Drawing.Color.Black;
                }

                DisableAllTextBoxes(c);
            }
        }
    }
}