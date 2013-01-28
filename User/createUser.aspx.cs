using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_createUser : System.Web.UI.Page
{
    UserManager manager = new UserManager();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Create_Click(object sender, EventArgs e)
    {
        String userName=((TextBox)LoginView1.FindControl("userName")).Text;
        String password=((TextBox)LoginView1.FindControl("password")).Text;
        String email=((TextBox)LoginView1.FindControl("email")).Text;
        String gender=((RadioButtonList)LoginView1.FindControl("gender")).SelectedValue;
        Double 

        System.Web.Security.MembershipCreateStatus status;
        System.Web.Security.Membership.CreateUser(userName, password, email, "none", "none", true, out status);
        System.Web.Security.Roles.AddUserToRole(userName, "user");

        manager.createNewLimitBreaker(userName, email, 
    }
}