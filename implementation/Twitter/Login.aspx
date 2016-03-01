<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TwitterAplication.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width: 100%">
                <tr>
                    <td>
                        <img src="Images/gossip_birds_48.ico" height="48" alt="" style="width: 48px; margin-left: 300px;" />
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td>
                        <div style="width: 600px; margin-left: 400px; margin-right: auto; margin-top: 100px; padding: 25px; border: 1px solid">
                            <asp:Login ID="ctrllogin" runat="server"
                                CreateUserText="New Here ? Create New User" CreateUserUrl="~/CreateNewUser.aspx" OnAuthenticate="ctrllogin_Authenticate"
                                TitleText="Log in to Twitter !" PasswordRecoveryText="Forgot your password ?" PasswordRecoveryUrl="~/ForgotPassword.aspx"
                                DisplayRememberMe="False" Width="388px" PasswordRequiredErrorMessage="Please Enter Password" UserNameRequiredErrorMessage="Please Enter Username" OnLoginError="ctrllogin_LoginError">
                                <TextBoxStyle Width="200px"></TextBoxStyle>
                            </asp:Login>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
