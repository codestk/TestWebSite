<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://fonts.googleapis.com/css?family=Open+Sans" rel="stylesheet">
    <link href="Module/Materialize/css/materialize.css" rel="stylesheet" media="screen,projection" />
    <link href="Module/Materialize/css/style.css" rel="stylesheet" media="screen,projection" />
    <link href="Module/Materialize/FixedCss/MaterializedFixed.css" rel="stylesheet" />

    <title>Login</title>
    <style>
        body {
            margin: 0;
            padding: 0;
            background: #fff;
            color: #fff;
            /*font-family: Arial;
            font-size: 12px;*/
            font-family: 'Open Sans', sans-serif;
        }

        .body {
            position: absolute;
            top: -20px;
            left: -20px;
            right: -40px;
            bottom: -40px;
            /*width: auto;*/
            /*height: auto;*/
            background-image: url('images/loginBg.jpg');
            /*background-image: url('images/the-queens-gallery-2.jpg');
                    background-image: url('images/backgroundligthup.jpg');*/
            background-image: url('images/pexels-photo-261706.jpeg');
            background-position:center right;
            background-size: cover;
            -webkit-filter: blur(5px);
            z-index: 0; /* color */
            width: 101%;
            height: 103%;
        }

        .grad {
            position: absolute;
            top: -20px;
            left: -20px;
            right: -40px;
            bottom: -40px;
            /*width: auto;*/
            /*height: auto;*/
            background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,rgba(0,0,0,0)), color-stop(100%,rgba(0,0,0,0.65))); /* Chrome,Safari4+ */
            z-index: 1;
            opacity: 0.7;
            width: 101%;
            height: 103%;
        }

        .header {
            position: absolute;
            top: calc(50% - 35px);
            left: calc(50% - 255px);
            z-index: 2;
        }

            .header div {
                float: left;
                color: #fff;
                font-family: 'Exo', sans-serif;
                font-size: 35px;
                font-weight: 200;
            }

                .header div span {
                    color: #5379fa !important;
                }

        .login {
            position: absolute;
            top: calc(50% - 75px);
            left: calc(50% - 50px);
            height: 150px;
            width: 450px;
            padding: 10px;
            z-index: 2;
        }

            .login input[type=text] {
                width: 250px;
                height: 30px;
                background: transparent;
                border: 1px solid rgba(255,255,255,0.6);
                border-radius: 2px;
                color: #fff;
                /*font-family: 'Exo', sans-serif;
                font-size: 16px;*/
                font-weight: 400;
                padding: 4px;
            }

            .login input[type=password] {
                width: 250px;
                height: 30px;
                background: transparent;
                border: 1px solid rgba(255,255,255,0.6);
                border-radius: 2px;
                color: #fff;
                /*font-family: 'Exo', sans-serif;
                font-size: 16px;*/
                font-weight: 400;
                padding: 4px;
                margin-top: 10px;
            }

            .login input[type=submit] {
                width: 260px;
                height: 35px;
                background: #00CC99;
                
                     background: #00D75E;
                border: 0px solid #0088CC;
                cursor: pointer;
                border-radius: 2px;
                color: #fff !important;
                font-weight: 400;
                padding: 6px;
                margin-top: 10px;
                /*width: 260px;
                height: 35px;
                background: #fff;
                border: 1px solid #fff;
                cursor: pointer;
                border-radius: 2px;
                color: #a18d6c;

                font-weight: 400;
                padding: 6px;
                margin-top: 10px;*/
            }

                .login input[type=submit]:hover {
                    opacity: 0.8;
                }

                .login input[type=submit]:active {
                    opacity: 0.6;
                }

            .login input[type=text]:focus {
                outline: none;
                border: 1px solid rgba(255,255,255,0.9);
            }

            .login input[type=password]:focus {
                outline: none;
                border: 1px solid rgba(255,255,255,0.9);
            }

            .login input[type=submit]:focus {
                outline: none;
            }

        ::-webkit-input-placeholder {
            color: rgba(255,255,255,0.6);
        }

        ::-moz-input-placeholder {
            color: rgba(255,255,255,0.6);
        }

        .LoginFail {
            margin-top: 20px;
            display: block;
        }
    </style>
</head>
<body>
    <form id="form1" autocomplete="off" runat="server">
        <div class="body">
        </div>
        <div class="grad" style="background-color:#1c1c1c;">
            <img src="Images/Logo.png" style="margin:20px; " />

        </div>
        <div class="header">
            <div>
            </div>
            <div>
       
              Site<span>Demo</span> 
            </div>
        </div>
        <br>
        <div class="login">
            <asp:TextBox ID="user" placeholder="username" autocomplete="off" runat="server"></asp:TextBox>
            <%--	<input type="text" placeholder="username" name="user">--%>
            <br>
            <asp:TextBox ID="password" placeholder="password" TextMode="Password" autocomplete="off"
                runat="server"></asp:TextBox>
            <%--<input type="password" placeholder="password" name="password">--%>
            <br>
            <%--<input type="button" value="Login">--%>
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="Button1_Click" /><br />
            <asp:Label ID="lblError" CssClass="LoginFail" runat="server" Text="Invalid email/password combination. Please try again."
                Visible="False"></asp:Label>
        </div>
    </form>
</body>
</html>