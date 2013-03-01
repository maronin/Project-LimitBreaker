using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Security;

public partial class ui_mp_MasterPage : System.Web.UI.MasterPage
{
   static bool[] selectedOption = new bool[6];
    protected void Page_Load(object sender, EventArgs e)
    {
        String[] role = Roles.GetRolesForUser();
        if (!role.Contains("admin"))
        {
            lisystemExercise.Visible = false;
            liManageExerciseExperience.Visible = false;
        }
    }

}