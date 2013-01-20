using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ui_mp_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.MaintainScrollPositionOnPostBack = true;
    }
    protected void btnManageSysExercise_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/systemExercise/default.aspx");
    }
    protected void btnManageUserRoutines_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/userRoutines/default.aspx");
    }
    protected void Button9_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/login.aspx");
    }
}
