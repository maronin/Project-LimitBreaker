using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_createUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Create_Click(object sender, EventArgs e)
    {
        System.Web.Security.MembershipCreateStatus status;
        System.Web.Security.Membership.CreateUser(((TextBox)LoginView1.FindControl("userName")).Text, ((TextBox)LoginView1.FindControl("password")).Text, ((TextBox)LoginView1.FindControl("email")).Text, "WTF", "123 answer", true, out status);
    }
}