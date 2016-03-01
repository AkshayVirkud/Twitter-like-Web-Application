<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TwitterAplication.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="CSS/Login.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:Timer ID="Timer1" runat="server" OnTick="gettickvalue" Interval="5000"></asp:Timer>
        <div align="center">
            <table cellpadding="1" cellspacing="1" align="center" class="MainTable" id="MainTable">
                <tr>
                    <td colspan="2">
                        <img src="Images/gossip_birds_48.ico" height="48" alt="" style="width: 48px; margin-left:100px" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="BannerPanel" runat="server" UpdateMode="Conditional" width="100%">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                            </Triggers>
                            <ContentTemplate>
                                <asp:Panel ID="BgImagePanel" runat="server" BackImageUrl="~/Images/TweetImage1.jpg" class="BgImagePanel">
                                    <table>
                                        <tr>
                                            <td width="70%" id="ImageContent">
                                                <h1>Welcome to Twitter.</h1>
                                                <br />
                                                <h3>Connect with your friends - and other fascinating</h3>
                                                <h3>people. Get-in-the-moment updates on the things</h3>
                                                <h3>that interest you. And watch events unfold, in real</h3>
                                                <h3>time, from every angle</h3>
                                                <br />
                                                <br />
                                                <br />
                                                <asp:Label ID="picComment" runat="server" Text="Label" ForeColor="White"></asp:Label><br /><br />
                                                <asp:Label ID="picUserName" runat="server" Text="Label" ForeColor="White"></asp:Label><br />
                                                <asp:Label ID="picTime" runat="server" Text="Label" ForeColor="White"></asp:Label>
                                            </td>
                                            <td id="HyperLinks">
                                                <h2>Existing User <asp:HyperLink ID="hypLogIn" runat="server" NavigateUrl="~/Login.aspx" Text="Log In"></asp:HyperLink></h2>
                                                <br />
                                                <br />
                                                <h2>New to Twitter? <asp:HyperLink ID="hypSignUp" runat="server" NavigateUrl="~/CreateNewUser.aspx" Text="Sign Up"></asp:HyperLink></h2>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
