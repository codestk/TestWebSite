using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

 
    public class MsgBox
    {
        /// <summary>
        /// Shows a client-side JavaScript alert in the browser.
        /// </summary>
        /// <param name="message">The message to appear in the alert.</param>
        public static void Alert(string message)
        {
            // Cleans the message to allow single quotation marks
            string cleanMessage = message.Replace("'", "\\'");
            string script = "<script type=\"text/javascript\">$(document).ready(function(){$('#PmsageAlert').html( '" + message + "' );$('#modal1').openModal();});</script>";
            // Gets the executing web page
            var page = HttpContext.Current.CurrentHandler as Page;
            // Checks if the handler is a Page and that the script isn't all ready on the Page
            if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("alert"))
            {
                page.ClientScript.RegisterClientScriptBlock(typeof(MsgBox), "MessageBox", script);
            }
        }
    }
 