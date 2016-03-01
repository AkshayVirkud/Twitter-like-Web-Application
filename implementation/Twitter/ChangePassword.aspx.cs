using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TwitterAplication
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        static string query = string.Empty;
        static string answer = string.Empty;

        /// <summary>
        /// Load Security Question on Page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string sq = "Select SECURITY_QUES from Users where userid = " + Convert.ToString(Session["Userid"]) + " ";
                string sa = "Select SECURITY_ANS from Users where userid = " + Convert.ToString(Session["Userid"]) + " ";

                 query = Convert.ToString(Utility.ExecuteSelectQueryWithSingleResult(sq));
                 answer = Convert.ToString(Utility.ExecuteSelectQueryWithSingleResult(sa));
                 TxtSecurityQuestions.Text = query;
            }
            catch (Exception ex)
            {
                Session["Error"] = ex.Message;
                Response.Redirect("Error.aspx");
            }

        }

        /// <summary>
        /// Button Submit Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {

            try
            {
                if (TxtSecurityAnswers.Text == answer)
                {

                    TxtNewPassword.Visible = true;
                    NewPassword.Visible = true;

                    TxtConfirmPassword.Visible = true;
                    ConfirmPassword.Visible = true;

                    lblError.Visible = false;
                    BtnUpdate.Visible = true;
                    BtnSubmit.Enabled = false;
                }
                else
                {
                    lblError.Text = "Incorrect Security Answer";
                    lblError.Visible = true;
                    BtnSubmit.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                Session["Error"] = ex.Message;
                Response.Redirect("Error.aspx");
            }
        }

        /// <summary>
        /// Update the newly entered password in database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (TxtNewPassword.Text == TxtConfirmPassword.Text)
                {
                    lblError.Visible = false;
                    string updatedPassword = Utility.ComputeHashedPassword(TxtNewPassword.Text);
                    string updatepswd = "Update Users Set Password = '" + updatedPassword + "' where userid = " + Convert.ToString(Session["Userid"]) + " ";
                    Utility.ExecuteUpdateQuery(updatepswd);
                    //Session.Abandon();
                    Response.Redirect("Login.aspx", false);
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Confirm Password Is Not Equal to New Password";
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