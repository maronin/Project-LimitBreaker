using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ui_mp_MasterPage : System.Web.UI.MasterPage
{
   static bool[] selectedOption = new bool[6];
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.MaintainScrollPositionOnPostBack = true;

        if (selectedOption[0])
            lnkSysExercises.CssClass = "selected";
        else if (selectedOption[1])
            lnkRoutines.CssClass = "selected";
        else if (selectedOption[2])
            lnkUser.CssClass = "selected";
        else if (selectedOption[3])
            lnkExperience.CssClass = "selected";
        else if (selectedOption[4])
            lnkSchedule.CssClass = "selected";
        else if (selectedOption[5])
            lnkLogin.CssClass = "selected";


    }
    protected void btnManageSysExercise_Click(object sender, EventArgs e)
    {

        selectedOption[0] = true;
        selectedOption[1] = selectedOption[2] = selectedOption[3] = selectedOption[4] = selectedOption[5] = false;
        Response.Redirect("~/SystemExercise/default.aspx");

    }
    protected void btnManageUserRoutines_Click(object sender, EventArgs e)
    {
        selectedOption[1] = true;
        selectedOption[0] = selectedOption[2] = selectedOption[3] = selectedOption[4] = selectedOption[5] = false;
        Response.Redirect("~/UserRoutines/default.aspx");
    }
    protected void btnCreateUser(object sender, EventArgs e)
    {
        selectedOption[2] = true;
        selectedOption[1] = selectedOption[0] = selectedOption[3] = selectedOption[4] = selectedOption[5] = false;
        Response.Redirect("~/User/createUser.aspx");
        
    }
    protected void btnManageExperience(object sender, EventArgs e)
    {
        selectedOption[3] = true;
        selectedOption[1] = selectedOption[2] = selectedOption[0] = selectedOption[4] = selectedOption[5] = false;
        Response.Redirect("~/SystemExercise/manageExerciseExperience.aspx");
        
    }
    protected void btnWorkOutSchedule_Click(object sender, EventArgs e)
    {
        selectedOption[4] = true;
        selectedOption[1] = selectedOption[2] = selectedOption[3] = selectedOption[0] = selectedOption[5] = false;
        Response.Redirect("~/WorkoutSchedule/default.aspx");
        
    }
    protected void btnLogin(object sender, EventArgs e)
    {
        selectedOption[5] = true;
        selectedOption[1] = selectedOption[2] = selectedOption[3] = selectedOption[4] = selectedOption[0] = false;
        Response.Redirect("~/login.aspx");
       
    }
}
