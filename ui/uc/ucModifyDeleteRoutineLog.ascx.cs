using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ui_uc_ucModifyDeleteRoutineLog : System.Web.UI.UserControl
{
    public int userID { get; set; }
    routineManager routManager;
    ListBox lb;
    SystemExerciseManager sysManager;
    LoggedExerciseManager logManager;
    int routineID;
    int loggedExerciseID;

    protected void Page_Load(object sender, EventArgs e)
    {
        sysManager = new SystemExerciseManager();
        routManager = new routineManager();
        logManager = new LoggedExerciseManager();

        lb = (ListBox)this.Parent.FindControl("lbRoutines");

        if (Session["loggedExerciseID"] != null)
        {
            loggedExerciseID = (int)Session["loggedExerciseID"];
        }

        if (!IsPostBack)
        {
            Session.Abandon();
            //pnlSets.Visible = false;
        }

        if (lb != null && lb.SelectedIndex > -1)
        {
            routineID = Convert.ToInt32(lb.SelectedItem.Value);
            GridView1.DataSource = routManager.getLoggedExercises(userID, routineID);
            GridView1.DataBind();
            //pnlSets.Visible = false;
        }
    }
    protected void okButton_Click(object sender, EventArgs e)
    {
        bool rc = routManager.deleteLoggedExercises(userID, routineID);
        if (rc)
        {
            GridView1.DataSource = routManager.getLoggedExercises(userID, routineID);
            GridView1.DataBind();
            // redirect page to itself (refresh)
            //Response.Redirect(Request.RawUrl);
        }
    }

    protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        e.ExceptionHandled = true;
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "view")
        {
            loggedExerciseID = Convert.ToInt32(e.CommandArgument.ToString());
            Session["loggedExerciseID"] = loggedExerciseID;
            pnlSets.Visible = true;

            List<SetAttributes> sets = routManager.getSetAttributes(userID, routineID, loggedExerciseID).ToList();
            lblSets.Text = logManager.setsToString(sets);
        }
    }
}