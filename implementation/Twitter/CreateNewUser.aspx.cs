using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TwitterAplication
{
    public partial class CreateNewUser : System.Web.UI.Page
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
        /// User details are inserted in "insertusers"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            Regex objRegex = new Regex("^[a-zA-Z0-9\\s]*$");

            try
            {
                if (String.IsNullOrEmpty(TxtFirstName.Text) || String.IsNullOrEmpty(TxtLastName.Text) ||
                    String.IsNullOrEmpty(TxtUsername.Text) || String.IsNullOrEmpty(TxtPassword.Text) ||
                     String.IsNullOrEmpty(TxtSecurityQuestion.Text) || String.IsNullOrEmpty(TxtSecurityAnswer.Text))
                {
                    lblError.Visible = true;
                    lblError.Text = "Please enter values in all the fields";
                }
                else if (!objRegex.IsMatch(TxtUsername.Text) || !objRegex.IsMatch(TxtPassword.Text) || !objRegex.IsMatch(TxtSecurityQuestion.Text) || !objRegex.IsMatch(TxtSecurityAnswer.Text))
                {
                    lblError.Text = "Please enter alphanumeric characters in all the fields";
                    lblError.Visible = true;
                }
                else
                {
                    lblError.Visible = false;
                    string UserPassword = Utility.ComputeHashedPassword(TxtPassword.Text);
                    string insertusers = "Insert into Users(Username,Password, SECURITY_QUES , SECURITY_ANS) VALUES ( '" + TxtUsername.Text + "','" + UserPassword + "','" + TxtSecurityQuestion.Text + "','" + TxtSecurityAnswer.Text + "')";

                    Utility.ExecuteInsertQuery(insertusers);

                    Response.Redirect("Login.aspx", false);
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