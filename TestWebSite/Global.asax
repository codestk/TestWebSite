<%@ Application Language="C#" %>
 
<script RunAt="server">

    void Application_Start(object sender, EventArgs e)
    {
        //Code that runs on application startup
        System.Web.Http.GlobalConfiguration.Configure(WebApiConfig.Register);
    }

    void Application_End(object sender, EventArgs e)
    {
        //Code that runs on application shutdown

    }

    protected void Application_AuthenticateRequest(object sender, EventArgs e)
    {
        if (HttpContext.Current.User != null)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                if (HttpContext.Current.User.Identity is FormsIdentity)
                {
                    FormsIdentity id =
                        (FormsIdentity)HttpContext.Current.User.Identity;
                    FormsAuthenticationTicket ticket = id.Ticket;

                    // Get the stored user-data, in this case, our roles
                    string userData = ticket.UserData;
                    string[] roles = userData.Split(',');
                    HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(id, roles);
                }
            }
        }

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs
        // find out the last error
        System.Exception ex = Server.GetLastError().GetBaseException();
        // log the error now
        StkLib.Errors.ErrorLogging.LogError(ex, "");
    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends.
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer
        // or SQLServer, the event is not raised.

    }
</script>