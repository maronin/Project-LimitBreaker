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
        Response.Redirect("~/SystemExercise/default.aspx");
    }
    protected void btnManageUserRoutines_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/UserRoutines/default.aspx");
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/User/createUser.aspx");
    }
    protected void btnWorkOutSchedule_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/WorkoutSchedule/default.aspx");
    }
}
