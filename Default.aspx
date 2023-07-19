<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default"
    Title="ARQUIVO HSPM" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Login V15</title>
    <meta content="text/html; charset=UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!--===============================================================================================-->
    <link rel="icon" type="image/png" href="images/icons/favicon.ico" />
    <!--===============================================================================================-->
    <link href="vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="fonts/font-awesome-4.7.0/css/font-awesome.min.css" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="fonts/Linearicons-Free-v1.0.0/icon-font.min.css" />
    <!--===============================================================================================-->
    
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="css/util.css" />
    <link rel="stylesheet" type="text/css" href="css/main.css" />
    <!--===============================================================================================-->
</head>
<body>
    <div class="limiter">
        <div class="container-login100">
            <div class="wrap-login100">
                <div class="login100-form-title" style="background-image: url(images/prontuario.jpg);">
                    <span class="login100-form-title-1">HSPM</span>
                    <span class="login100-form-title-1">Arquivo Médico</span>
                </div>
                <form id="form" runat="server" class="login100-form validate-form">
                <asp:Login ID="Login1" runat="server" DestinationPageUrl="~/Publico/Principal.aspx"
                    Width="100%">
                    <LayoutTemplate>
                        <div class="wrap-input100 validate-input m-b-26">
                            <span class="label-input100">Usuário</span>
                            <asp:TextBox ID="UserName" runat="server" class="input100" ></asp:TextBox>
                            <span class="focus-input100"></span>
                            
                        </div>
                        <div class="wrap-input100 validate-input m-b-18" >
                            <span class="label-input100">Senha</span>
                            <asp:TextBox ID="Password" runat="server" class="input100" TextMode="Password"></asp:TextBox>
                            <span class="focus-input100"></span>
                           
                        </div>
                        <div align="center" style="color: Red;">
                            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                        </div>
                        
                        <div class="container-login100-form-btn">
                            <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Entrar" ValidationGroup="Login1"
                                class="login100-form-btn" />
                        </div>
                    </LayoutTemplate>
                </asp:Login>
                </form>
               
            </div>
        </div>
    </div>
</body>
</html>