using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TwitterAplication
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Check if username exists in the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string username = "Select UserId from Users where Username = '" + TxtUsername.Text +"'";
                string uname = Convert.ToString(Utility.ExecuteSelectQueryWithSingleResult(username));
                Session["UserId"] = uname;

                if (string.IsNullOrEmpty(TxtUsername.Text))
                {
                    Alert.Visible = true;
                }
                else
                {
                    Response.Redirect("ChangePassword.aspx", false);
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