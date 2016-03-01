<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FriendTweets.aspx.cs" Inherits="TwitterAplication.FriendTweets" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="CSS/Friend.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="mainFriendPageTable">
                <tr>
                    <td>
                        <table class="friendTableHeader">
                            <tr>
                                <td>
                                    <asp:HyperLink ID="hypHome" runat="server" NavigateUrl="~/Home.aspx" Text="Home"></asp:HyperLink></td>
                                <td>
                                    <asp:HyperLink ID="hypChangePassword" runat="server" NavigateUrl="~/ChangePassword.aspx" Text="Change Password"></asp:HyperLink></td>
                                <td>
                                    <img src="Images/gossip_birds_48.ico" height="48" alt="" style="width: 48px; margin-left: 200px; margin-right: 50px;" /></td>
                                <td>
                                    <asp:Button ID="btnLogout" runat="server" Text="Log Out" OnClick="btnLogout_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table class="friendTableContent">
                            <asp:Repeater runat="server" ID="rptFriendTweets" OnItemCommand="rptFriendTweets_ItemCommand">
                                <HeaderTemplate>
                                    <table id="tblFollow">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblID" Visible="false" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TweetId") %>'></asp:Label>
                                            <asp:Label ID="lblUsername" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TweetUserName") %>'></asp:Label>
                                            &nbsp;tweeted :
                                        <br />
                                            <asp:Label ID="lblTweets" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TweetContent") %>' Width="300"></asp:Label>
                                            <hr />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
