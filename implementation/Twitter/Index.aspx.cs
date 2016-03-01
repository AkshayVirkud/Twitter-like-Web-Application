using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TwitterAplication
{
    public partial class Index : System.Web.UI.Page
    {
        /// <summary>
        /// Index Page - Page Load Event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            picComment.Text = "We broke the world record for outdoor yoga!  #excitedpose";
            picUserName.Text = "Tweet and Photo by @Alice";
            picTime.Text = "10:01 AM - 25 August 2014";
        }

        /// <summary>
        /// This function is called on tick event of the timer in order to change images.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gettickvalue(object sender, EventArgs e)
        {
            try
            {
                //The function selects Random number from 1 to 7 and depending on the number the corresponding picture and its details are displayed.
 
                Random RandomNumber = new Random();

                int n = RandomNumber.Next(1, 7);

                BgImagePanel.BackImageUrl = System.String.Concat("~/Images/TweetImage", n.ToString(), ".jpg");

                switch (n)
                {
                    case 1: picComment.Text = "We broke the world record for outdoor yoga!  #excitedpose";
                        picUserName.Text = "Tweet and Photo by @Alice";
                        picTime.Text = "10:01 AM - 25 August 2014";
                        break;

                    case 2: picComment.Text = "Sydney Opera House from our trip around the harbor.  Love Australia!";
                        picUserName.Text = "Tweet and Photo by @Oscar";
                        picTime.Text = "07:05 PM - 07 October 2014";
                        break;

                    case 3: picComment.Text = "Lionel Messi sets up a shot!";
                        picUserName.Text = "Tweet and Photo by @Sam";
                        picTime.Text = "05:15 PM - 05 November 2014";
                        break;

                    case 4: picComment.Text = "Dinnertime at home.  Homemade pizza!  #organic";
                        picUserName.Text = "Tweet and Photo by @Arthur";
                        picTime.Text = "08:45 PM - 10 August 2014";
                        break;

                    case 5: picComment.Text = "Sunsets are so beautiful.  #Lovinglife";
                        picUserName.Text = "Tweet and Photo by @Bob";
                        picTime.Text = "04:11 PM - 28 November 2014";
                        break;

                    case 6: picComment.Text = "Look at the clouds today!  #beautiful";
                        picUserName.Text = "Tweet and Photo by @Su";
                        picTime.Text = "06:55 AM - 31 July 2014";
                        break;

                    case 7: picComment.Text = "At the base of the Eiffel Tower on vacation!  #filterasopposedtonofilter";
                        picUserName.Text = "Tweet and Photo by @John";
                        picTime.Text = "09:25 AM - 01 December 2014";
                        break;

                    default:
                        break;
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