<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TwitterAplication.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="CSS/Home.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="mainHomePageDiv">
            <table class="mainHomePageTable">
                <tr>
                    <td>
                        <table>
                            <tr class="tweetTableHeader">
                                <td><asp:HyperLink ID="hypFriends" runat="server" NavigateUrl="~/FriendTweets.aspx" Text="Friends"></asp:HyperLink></td>
                                <td><asp:HyperLink ID="hypChangePassword" runat="server" NavigateUrl="~/ChangePassword.aspx" Text="Change Password"></asp:HyperLink></td>
                                <td><img src="Images/gossip_birds_48.ico" height="48" alt="" style="width: 48px; margin-left: 200px; margin-right: 50px;" /></td>
                                <td>
                                    <asp:Button ID="btnLogout" runat="server" Text="Log Out" OnClick="btnLogout_Click"/>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table class="tweetTableContent">
                            <tr>
                                <td rowspan="2">
                                    <asp:Label ID="lblUserName" runat="server" Text="" Font-Bold="True"></asp:Label>
                                   <b> , 
                        <br />
                                    Welcome to Twitter !! </b></td>
                                <td><b>Tweet Here</b></td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:TextBox ID="txtNewTweet" runat="server" TextMode="MultiLine" Rows="5" Width="300" maxlength="140"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:Button ID="btnTweet" runat="server" Text="Tweet" OnClick="btnTweet_Click" /></td>
                            </tr>
                            <tr>
                                <td>
                                    <table>
                                        <tr>
                                            <td><b>Follow People</b><br />
                                                <asp:TextBox ID="txtSearchPeople" runat="server" maxlength="25"></asp:TextBox>
                                                <asp:Button ID="btnSearchFriend" runat="server" Text="Search" OnClick="btnSearchFriend_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Repeater runat="server" ID="rptSeachPeople" OnItemCommand="rptSeachPeople_ItemCommand">
                                                    <HeaderTemplate>
                                                        <table id="tblFollow">
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr style="background-color: #ffffff; outline: thin solid">
                                                            <td>
                                                                <asp:Label ID="lblFriendId" Visible="false" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FriendId") %>'></asp:Label>
                                                                <asp:Label ID="lblFriendName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FriendName") %>' Width="150"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="imgBtnFollowFriend" runat="server" CommandName="follow" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "FriendId") %>' ImageUrl="~/Images/Follow.ico" Height="15px" Width="15px" />
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        </table>
                                                    </FooterTemplate>
                                                </asp:Repeater>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td>
                                    <b> Recent Tweets </b><br />
                                    <asp:Repeater ID="rptTweets" runat="server" OnItemCommand="rptTweets_ItemCommand">
                                        <HeaderTemplate>
                                            <table id="tblTweets">
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr style="background-color: #ffffff">
                                                <td>
                                                    <asp:Label ID="lblID" Visible="false" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TweetId") %>'></asp:Label>
                                                    <asp:Label ID="lblTweets" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TweetContent") %>' Width="300"></asp:Label>
                                                    <asp:TextBox ID="txtTweet" Visible="false" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TweetContent") %>' TextMode="MultiLine" Rows="5" Width="300" maxlength="140"></asp:TextBox>
                                                     <hr />
                                                </td>
                                                <td>
                                                    <%--<asp:LinkButton ID="lnkEdit" runat="server" CommandName="edit" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "TweetId") %>'>Edit</asp:LinkButton>--%>
                                                    <asp:ImageButton ID="imgBtnEdit" runat="server" CommandName="edit" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "TweetId") %>' ImageUrl="~/Images/EditTweet.ico" Height="15px" Width="15px" />
                                                    <asp:ImageButton Visible="false" ID="imgBtnUpdate" runat="server" CommandName="update" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "TweetId") %>' ImageUrl="~/Images/UpdateTweet.ico" Height="15px" Width="15px"></asp:ImageButton>
                                                    <asp:ImageButton Visible="false" ID="imgBtnCancel" runat="server" CommandName="cancel" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "TweetId") %>' ImageUrl="~/Images/CancelUpdateTweet.ico" Height="15px" Width="15px"></asp:ImageButton>
                                                    <asp:ImageButton ID="imgBtnDelete" runat="server" CommandName="delete" OnClientClick='javascript:return confirm("Are you sure you want to delete?")'
                                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "TweetId") %>' ImageUrl="~/Images/DeleteTweet.ico" Height="15px" Width="15px"></asp:ImageButton>

                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </table>
                                        </FooterTemplate>
                                    </asp:Repeater>
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
