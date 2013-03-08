using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_reset : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.Name != "")
        {
            Response.Redirect("profile.aspx");
        }
        if (String.IsNullOrEmpty(Request.QueryString["ID"]) || !Regex.IsMatch(Request.QueryString["ID"], "[0-9a-f]{8}\\-([0-9a-f]{4}\\-){3}[0-9a-f]{12}"))
        {
            Label1.Text = "Invalid! Go lift some more.";
        }
        else
        {
            //Needed because page will post back and cause these actions to occur again, changing the password
            if (!IsPostBack)
            {
                Guid userID = new Guid(Request.QueryString["ID"]);
                MembershipUser userInfo = Membership.GetUser(userID);
                if (userInfo == null)
                {
                    Label1.Text = "Stop screwing with my site";
                }
                else
                {
                    userInfo.UnlockUser();
                    Label1.Text = "Your password has been reset to " + userInfo.ResetPassword() + "\nPlease login and change your password";
                    Membership.UpdateUser(userInfo);
                }
            }
        }
    }
}