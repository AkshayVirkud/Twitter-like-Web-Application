using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TwitterAplication
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox txtUserName = (TextBox)ctrllogin.FindControl("UserName");
            txtUserName.MaxLength = 25;
            TextBox password = (TextBox)ctrllogin.FindControl("Password");
            password.MaxLength = 25;
        }

        /// <summary>
        /// Performs user authentication by verifying user's Id and password.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ctrllogin_Authenticate(object sender, AuthenticateEventArgs e)
        {
            try
            {
                Regex objRegex = new Regex("^[a-zA-Z0-9\\s]*$");

                if (!objRegex.IsMatch(ctrllogin.Password.ToString()) || !objRegex.IsMatch(ctrllogin.UserName.ToString()))
                {
                    e.Authenticated = false;
                    ctrllogin.FailureText = "Please enter valid Username / Password.";
                }
                else
                {
                    DataSet objDs = new DataSet();

                    string userPassword = Utility.ComputeHashedPassword(ctrllogin.Password.ToString());

                    string command = "Select UserId, Username from Users where Username = '" + ctrllogin.UserName.ToString() + "' and Password = '" + userPassword + "'";

                    objDs = Utility.ExecuteSelectQuery(command);

                    if (objDs != null && objDs.Tables != null && objDs.Tables[0].Rows.Count > 0)
                    {
                        string userId = string.Empty;
                        string userName = string.Empty;

                        foreach (DataRow dr in objDs.Tables[0].Rows)
                        {
                            userId = dr[0].ToString();
                            userName = dr[1].ToString();
                        }
                        Session["UserName"] = userName;
                        Session["UserId"] = userId;
                        Session["IsAuthenticated"] = true;
                        Response.Redirect("Home.aspx", false);
                    }
                    else
                    {
                        e.Authenticated = false;
                        ctrllogin.FailureText = "Please enter valid Username / Password.";
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
        /// Invoked when login fails for a particular user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ctrllogin_LoginError(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(ctrllogin.UserName.ToString()))
            {
                ctrllogin.UserNameRequiredErrorMessage = "Please Enter Username";
            }
            else if (string.IsNullOrEmpty(ctrllogin.Password.ToString()))
            {
                ctrllogin.PasswordRequiredErrorMessage = "Please Enter Password";
            }

        }
    }
}