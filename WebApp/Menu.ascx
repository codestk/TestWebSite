<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Menu.ascx.cs" Inherits="Menu" %>
 
<%@ Import Namespace="StkLib.CCEnum" %>
<%@ Import Namespace="WebApp.Code.FrameWork.Enum" %>
<% if (HttpContext.Current.User.IsInRole(StringEnum.GetStringValue(EnumStkRole.Admin)))
    { %>
  <nav id="DivMenu" class="blue-grey darken-2" role="navigation">
                <div class=" container">
                    <a id="logo-container" href="#" class="brand-logo">Registration form</a>

                    <ul id="nav-mobile" class="right hide-on-med-and-down">
                        <li><a href="AccountRegistrationWeb.aspx">Add</a></li>
                        <li><a href="AccountRegistrationListFilter.aspx">Manage</a></li>
                    <%--    <li><a href="LocationUpload.aspx">Upload</a></li>--%>
                        <li>
                            <asp:LoginView ID="HeadLoginView1" runat="server" EnableViewState="false">
                                <AnonymousTemplate>
                                   
                                    <a href="Login.aspx">Log In</a>
                                </AnonymousTemplate>
                                <LoggedInTemplate>
                                 
                                    <asp:LoginStatus ID="HeadLoginStatus1" runat="server" LogoutAction="Redirect" LogoutText="Log Out"
                                        LogoutPageUrl="~/" />
                                  
                                </LoggedInTemplate>
                            </asp:LoginView>
                        </li>
                    </ul>
                </div>
            </nav>
 <% }
     else {%>
<nav id="DivMenu" class="blue-grey darken-2" role="navigation">
                <div class=" container">
                    <a id="logo-container" href="#" class="brand-logo">Registration</a>

                    <ul id="nav-mobile" class="right hide-on-med-and-down">
                        <li><a href="AccountRegistrationWeb.aspx">Add</a></li>
                        <li><a href="AccountRegistrationListFilter.aspx">Manage</a></li>
                      <%--  <li><a href="LocationUpload.aspx">Upload</a></li>--%>
                        <li>
                            <asp:LoginView ID="HeadLoginView2" runat="server" EnableViewState="false">
                                <AnonymousTemplate>
                                   
                                    <a href="Login.aspx">Log In</a>
                                </AnonymousTemplate>
                                <LoggedInTemplate>
                                 
                                    <asp:LoginStatus ID="HeadLoginStatus2" runat="server" LogoutAction="Redirect" LogoutText="Log Out"
                                        LogoutPageUrl="~/" />
                                  
                                </LoggedInTemplate>
                            </asp:LoginView>
                        </li>
                    </ul>
                </div>
            </nav>
<%} %>

