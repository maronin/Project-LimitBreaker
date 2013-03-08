using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_changePassword : System.Web.UI.Page
{
    UserManager manager = new UserManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.Name == "")
        {
            Response.Redirect("createUser.aspx");
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        MembershipUser userInfo = Membership.GetUser(User.Identity.Name);
        if (oldPass.Text != userInfo.GetPassword())
        {
            oldPassLbl.Text = "Password incorrect";
        }
        else
        {
            if (manager.updatePassword(userInfo, newPass.Text, oldPass.Text))
            {
                status.ForeColor = System.Drawing.Color.Green;
                status.Text = "Success!";
            }
            else
            {
                status.ForeColor = System.Drawing.Color.Red;
                status.Text = "Something went boom!";
            }
        }
    }
}