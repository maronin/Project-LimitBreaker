using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ui_uc_ucCreateRoutineLog : System.Web.UI.UserControl
{
    public int userID { get; set; }
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
        if (rbl != null && rbl.SelectedIndex > -1)
        {
            GridView1.DataSource = routManager.getExerciseFromRoutine(Convert.ToInt32(rbl.SelectedItem.Value));
            GridView1.DataBind();
            //Panel1.Visible = true;
            //Panel1.Enabled = true;
            //Response.Write(rbl.SelectedIndex + " item: " + rbl.SelectedItem);

            // to get the id of the button so that enter = submit
            /*
            tbRoutineName.Attributes.Add("onKeyPress",
                 "doClick('" + btnConfirm.ClientID + "',event)");
             * */
        }
    }
    protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        e.ExceptionHandled = true;
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "del")
        {
            /*
            //Response.Write("item: "+ e.CommandArgument.ToString());
            int routineID = Convert.ToInt32(rbl.SelectedItem.Value);
            int exerciseID = Convert.ToInt32(e.CommandArgument.ToString());
            Routine rtn = routManager.removeExerciseFromRoutine(routineID, exerciseID);

            if (rtn != null)
            {
                GridView1.DataSource = routManager.getExerciseFromRoutine(Convert.ToInt32(rbl.SelectedItem.Value));
                GridView1.DataBind();
            }
             * */
        }
    }
}