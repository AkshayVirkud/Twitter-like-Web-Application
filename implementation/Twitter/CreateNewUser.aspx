<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateNewUser.aspx.cs" Inherits="TwitterAplication.CreateNewUser" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body style="font-weight: 700">
    <form id="form1" runat="server" align="center">
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
                        <table>
                            <tr>
                                <td></td>
                                <td>Join Twitter</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblError" runat="server" Text="" Visible="False" ForeColor="Red"></asp:Label>
                                    <br />
                                </td>
                                <td></td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label ID="FirstName" runat="server" Text="First Name"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="TxtFirstName" runat="server" Width="161px" maxlength="25"></asp:TextBox>*</td>
                            </tr>


                            <tr>
                                <td>
                                    <asp:Label ID="LastName" runat="server" Text="Last Name"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="TxtLastName" runat="server" Width="161px" maxlength="25"></asp:TextBox>*</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Username" runat="server" Text="Username"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="TxtUsername" runat="server" Width="161px" maxlength="25"></asp:TextBox>*</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Pswd" runat="server" Text="Password" TextMode="Password"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="TxtPassword" runat="server" Width="161px" maxlength="25"></asp:TextBox>*</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="SecurityQuestion" runat="server" Text="Security Question"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="TxtSecurityQuestion" runat="server" Width="161px" maxlength="100"></asp:TextBox>*</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="SecurityAnswer" runat="server" Text="Security Answer"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="TxtSecurityAnswer" runat="server" Width="161px" maxlength="100"></asp:TextBox>*</td>
                            </tr>
                        </table>
                        <br />

                        <br />
                        <asp:Button ID="BtnSubmit" runat="server" OnClick="Button1_Click" Text="Submit" />
                        <br />

                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

