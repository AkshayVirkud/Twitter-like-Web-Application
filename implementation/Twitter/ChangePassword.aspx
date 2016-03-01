<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="TwitterAplication.ChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body style="font-weight: 700">
    <form id="form1" runat="server" style="align-content: center">
        <div style="align-content: center">
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
                            <asp:Label ID="Label1" runat="server" Text="Change Password"></asp:Label>
                            <table style="align-content: center" border="1" contenteditable="false">
                                <tr>
                                    <td>
                                        <asp:Label ID="SecurityQuestions" runat="server" Text="Security Questions"></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="TxtSecurityQuestions" runat="server" Style="margin-left: 31px" Width="263px" ReadOnly="true"></asp:TextBox>*</td>
                                </tr>


                                <tr>
                                    <td>
                                        <asp:Label ID="SecurityAnswers" runat="server" Text="Security Answers"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtSecurityAnswers" runat="server" Style="margin-left: 31px" Width="265px"></asp:TextBox>*</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="NewPassword" runat="server" Text="New Password" Visible="False"></asp:Label>

                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtNewPassword" runat="server" Style="margin-left: 29px" Width="263px" Visible="False" TextMode="Password"></asp:TextBox>*

                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <asp:Label ID="ConfirmPassword" runat="server" Text="Confirm Password" Visible="False"></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="TxtConfirmPassword" runat="server" Style="margin-left: 31px" Width="267px" Visible="False" TextMode="Password"></asp:TextBox>*

                                    </td>
                                </tr>
                                <tr>
                                    <td></td>

                                    <td>
                                        <asp:Button ID="BtnSubmit" runat="server" Text="Submit" OnClick="BtnSubmit_Click" />

                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

       <asp:Button ID="BtnUpdate" runat="server" Text="Update Password" OnClick="BtnUpdate_Click" Visible="False" />

                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblError" runat="server" Text="Incorrect Security Answer" Visible="False"></asp:Label>

                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
    </form>
</body>
</html>

