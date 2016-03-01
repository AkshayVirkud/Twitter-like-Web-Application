using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;

namespace TwitterAplication
{
    public partial class Home : System.Web.UI.Page
    {
        static List<Tweet> lstTweets = new List<Tweet>();
        static List<Friends> lstFriends = new List<Friends>();
        static bool isEditRow = false;

        /// <summary>
        /// If the user is LoggedIn to the system, it loads the list of user tweets.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //If session is null, redirect the user to Login page
                if (Session["IsAuthenticated"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    lblUserName.Text = "Hi " + Convert.ToString(Session["UserName"]);

                    if (!IsPostBack)
                    {
                        BindRepeater();
                    }
                }
            }
            catch (Exception ex)
            {
                Session["Error"] = ex.Message;
                Response.Redirect("Error.aspx");
            }
        }

        /// <summary>
        /// Performs insert, update & delete operations on the tweets
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void rptTweets_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            ImageButton imgBtnUpdate = (ImageButton)e.Item.FindControl("imgBtnUpdate");
            ImageButton imgBtnCancel = (ImageButton)e.Item.FindControl("imgBtnCancel");
            ImageButton imgBtnEdit = (ImageButton)e.Item.FindControl("imgBtnEdit");
            ImageButton imgBtnDelete = (ImageButton)e.Item.FindControl("imgBtnDelete");
            Label lblTweets = (Label)e.Item.FindControl("lblTweets");
            Label lblID = (Label)e.Item.FindControl("lblID");
            TextBox txtTweet = (TextBox)e.Item.FindControl("txtTweet");

            if (e.CommandName == "edit" && !isEditRow)
            {
                imgBtnCancel.Visible = true;
                imgBtnUpdate.Visible = true;
                imgBtnEdit.Visible = false;
                imgBtnDelete.Visible = false;
                txtTweet.Visible = true;
                lblTweets.Visible = false;
                isEditRow = true;

            }
            else if (e.CommandName == "cancel")
            {
                BindRepeater();
                isEditRow = false;
            }
            else if (e.CommandName == "update")
            {
                try
                {
                    int id = Convert.ToInt32(e.CommandArgument);

                    string tweetContent = Convert.ToString(txtTweet.Text).Replace("'", "''");
                    string updateCommand = "UPDATE Tweets SET Tweet = '" + tweetContent + "'  WHERE TweetId = " + id.ToString();

                    Utility.ExecuteUpdateQuery(updateCommand);

                }
                catch (Exception ex)
                {
                    Session["Error"] = ex.Message;
                    Response.Redirect("Error.aspx");
                }
                finally
                {
                    isEditRow = false;
                }
                BindRepeater();
            }
            else if (e.CommandName == "delete")
            {
                try
                {
                    int id = Convert.ToInt32(e.CommandArgument);

                    string deleteCommand = "DELETE FROM Tweets WHERE TweetId = " + id.ToString();

                    Utility.ExecuteDeleteQuery(deleteCommand);
                }
                catch (Exception ex)
                {
                    Session["Error"] = ex.Message;
                    Response.Redirect("Error.aspx");
                }
                finally
                {

                }
                BindRepeater();
            }
        }

        /// <summary>
        /// It Binds the Repeater control with the Tweets that are feched from the database.
        /// </summary>
        protected void BindRepeater()
        {
            lstTweets = new List<Tweet>();

            string selectCommand = "Select TweetId, Tweet from Tweets where UserID = " + Session["UserId"].ToString() + " order by TweetId desc";

            DataSet objDs = new DataSet();
            objDs = Utility.ExecuteSelectQuery(selectCommand);

            if (objDs != null && objDs.Tables != null && objDs.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in objDs.Tables[0].Rows)
                {
                    Tweet objTweet = new Tweet();
                    objTweet.TweetContent = dr["Tweet"].ToString();
                    objTweet.TweetId = Convert.ToInt32(dr["TweetId"].ToString());
                    lstTweets.Add(objTweet);
                }
            }

            this.rptTweets.DataSource = null;
            this.rptTweets.DataSource = lstTweets;
            this.rptTweets.DataBind();
        }

        /// <summary>
        /// Inserts a new tweet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnTweet_Click(object sender, EventArgs e)
        {
            try
            {
                //First we select max tweet id from Tweets. Then we increment it by one and assign it to new Tweet.
                if (!string.IsNullOrEmpty(txtNewTweet.Text))
                {
                    string selectCommand = "Select max(tweetid) from Tweets";

                    int maxTweetId = Convert.ToInt32(Utility.ExecuteSelectQueryWithSingleResult(selectCommand));
                    int newTweetId = maxTweetId + 1;

                    string tweetContent = Convert.ToString(txtNewTweet.Text).Replace("'", "''");

                    string insertCommand = "INSERT INTO Tweets (TweetId, UserId, Tweet) VALUES (" + Convert.ToString(newTweetId) + " , " + Session["UserId"].ToString() + ", '" + tweetContent + "');";

                    Utility.ExecuteInsertQuery(insertCommand);

                    BindRepeater();

                    txtNewTweet.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                Session["Error"] = ex.Message;
                Response.Redirect("Error.aspx");
            }
        }

        /// <summary>
        /// LogsOut the user and abandons current session
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

        /// <summary>
        /// Functionality to add friend
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void rptSeachPeople_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {

                ImageButton imgBtnFollowFriend = (ImageButton)e.Item.FindControl("imgBtnFollowFriend");

                Label lblFriendId = (Label)e.Item.FindControl("lblFriendId");
                Label lblFriendName = (Label)e.Item.FindControl("lblFriendName");

                if (e.CommandName == "follow")
                {
                    string insertCommand = "INSERT INTO Friends (UserId, FriendId) VALUES (" + Convert.ToString(Session["UserId"]) + " , " + lblFriendId.Text + ");";

                    if (Utility.ExecuteInsertQuery(insertCommand) == true)
                    {
                        string selectCommand = "Select UserId, Username from Users where Username like '%" + txtSearchPeople.Text.Trim() + "'  and UserId NOT IN (SELECT FRIENDID FROM Friends WHERE UserId = " + Convert.ToString(Session["UserId"]) + ") AND UserId != " + Convert.ToString(Session["UserId"]);
                        lstFriends = new List<Friends>();

                        DataSet objDs = new DataSet();
                        objDs = Utility.ExecuteSelectQuery(selectCommand);

                        if (objDs != null && objDs.Tables != null && objDs.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow dr in objDs.Tables[0].Rows)
                            {
                                Friends objFriends = new Friends();
                                objFriends.FriendId = Convert.ToInt32(dr["UserId"].ToString());
                                objFriends.FriendName = Convert.ToString(dr["Username"]);
                                lstFriends.Add(objFriends);
                            }
                        }

                        this.rptSeachPeople.DataSource = null;
                        this.rptSeachPeople.DataSource = lstFriends;
                        this.rptSeachPeople.DataBind();
                    }

                }
            }
            catch (Exception ex)
            {
                Session["Error"] = ex.Message;
                Response.Redirect("Error.aspx");
            }

        }

        /// <summary>
        /// Searches for friends on the basis of the text entered in the seacrch textbox. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearchFriend_Click(object sender, EventArgs e)
        {
            try
            {
                Regex objRegex = new Regex("^[a-zA-Z0-9\\s]*$");

                if (!string.IsNullOrEmpty(txtSearchPeople.Text.Trim()) && objRegex.IsMatch(txtSearchPeople.Text.Trim()))
                {
                    string selectCommand = "Select UserId, Username from Users where Username like '%" + txtSearchPeople.Text.Trim() + "' and UserId NOT IN (SELECT FRIENDID FROM Friends WHERE UserId = " + Convert.ToString(Session["UserId"]) + ") AND UserId != " + Convert.ToString(Session["UserId"]);
                    lstFriends = new List<Friends>();

                    DataSet objDs = new DataSet();
                    objDs = Utility.ExecuteSelectQuery(selectCommand);

                    if (objDs != null && objDs.Tables != null && objDs.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in objDs.Tables[0].Rows)
                        {
                            Friends objFriends = new Friends();
                            objFriends.FriendId = Convert.ToInt32(dr["UserId"].ToString());
                            objFriends.FriendName = Convert.ToString(dr["Username"]);
                            lstFriends.Add(objFriends);
                        }
                    }

                    this.rptSeachPeople.DataSource = null;
                    this.rptSeachPeople.DataSource = lstFriends;
                    this.rptSeachPeople.DataBind();
                }
            }
            catch (Exception ex)
            {
                Session["Error"] = ex.Message;
                Response.Redirect("Error.aspx");
            }
        }
    }
}