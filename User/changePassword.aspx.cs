using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_changePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.Name == "")
        {
            Response.Redirect("createUser.aspx");
        }

    }

    protected void ContinuePushButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("profile.aspx");
    }
    protected void Confirm_Click(object sender, EventArgs e)
    {
        MembershipUser userInfo = Membership.GetUser(User.Identity.Name);
        if (userInfo.ChangePassword(oldPassword.Text, newPassword.Text))
        {
            Membership.UpdateUser(userInfo);
            status.ForeColor = System.Drawing.Color.Green;
            status.Text = "Change successful!";
        }
        else
        {
            status.ForeColor = System.Drawing.Color.Red;
            status.Text = "Passwords do not match";
        }
    }

}