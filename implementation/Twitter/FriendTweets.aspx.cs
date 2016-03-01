using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TwitterAplication
{
    public partial class FriendTweets : System.Web.UI.Page
    {
        static List<Tweet> lstTweets = new List<Tweet>();

        /// <summary>
        /// Page Load of Friends Page
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
                    BindRepeater();
                }
            }
            catch (Exception ex)
            {
                Session["Error"] = ex.Message;
                Response.Redirect("Error.aspx");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void rptFriendTweets_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                BindRepeater();
            }
            catch (Exception ex)
            {
                Session["Error"] = ex.Message;
                Response.Redirect("Error.aspx");
            }
        }

        /// <summary>
        /// Bind Friends Data to the Repeater
        /// </summary>
        protected void BindRepeater()
        {
            try
            {
                //Code for execting the select query and binding the repeater with the resulting dataset.

                lstTweets = new List<Tweet>();

                string selectCommand = "SELECT t.TweetId, u.Username, t.Tweet FROM Tweets t LEFT OUTER JOIN Users u ON t.UserId = u. UserId WHERE u.UserId in (SELECT FriendId FROM Friends where UserId =" + Session["UserId"].ToString() + " )";

                DataSet objDs = new DataSet();
                objDs = Utility.ExecuteSelectQuery(selectCommand);

                if (objDs != null && objDs.Tables != null && objDs.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in objDs.Tables[0].Rows)
                    {
                        Tweet objTweet = new Tweet();
                        objTweet.TweetContent = dr["Tweet"].ToString();
                        objTweet.TweetUserName = dr["Username"].ToString();
                        objTweet.TweetId = Convert.ToInt32(dr["TweetId"].ToString());
                        lstTweets.Add(objTweet);
                    }
                }

                this.rptFriendTweets.DataSource = null;
                this.rptFriendTweets.DataSource = lstTweets;
                this.rptFriendTweets.DataBind();
            }
            catch (Exception ex)
            {
                Session["Error"] = ex.Message;
                Response.Redirect("Error.aspx");
            }
        }

        /// <summary>
        /// Logout from the Twitter Application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

    }
}