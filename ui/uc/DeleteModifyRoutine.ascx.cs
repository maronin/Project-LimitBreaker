using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ui_uc_DeleteModifyRoutine : System.Web.UI.UserControl
{
    RadioButtonList rbl;
    SystemExerciseManager sysManager;
    routineManager routManager;

    protected void Page_Load(object sender, EventArgs e)
    {
        sysManager = new SystemExerciseManager();
        routManager = new routineManager();
        rbl = (RadioButtonList)this.Parent.FindControl("rblRoutines");
        if (!IsPostBack)
        {
            
        }
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        GridView1.DataSource = routManager.getExerciseFromRoutine(Convert.ToInt32(rbl.SelectedItem.Value));
        GridView1.DataBind();
    }
}