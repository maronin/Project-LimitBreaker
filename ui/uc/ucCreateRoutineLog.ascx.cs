using System;
using System.Collections.Generic;
using System.Drawing;
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
    int exerciseID;
    int routineID;

    protected void Page_Load(object sender, EventArgs e)
    {
        sysManager = new SystemExerciseManager();
        routManager = new routineManager();
        rbl = (RadioButtonList)this.Parent.FindControl("rblRoutines");
        

        if (Session["exerciseID"] != null)
        {
            exerciseID = (int)Session["exerciseID"];
        }

        if (!IsPostBack)
        {
            Session.Abandon();
            init();
        }
        if (rbl != null && rbl.SelectedIndex > -1)
        {
            GridView1.DataSource = routManager.getExerciseFromRoutine(Convert.ToInt32(rbl.SelectedItem.Value));
            GridView1.DataBind();
            routineID = Convert.ToInt32(rbl.SelectedItem.Value);
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
        if (e.CommandName == "log")
        {
            exerciseID = Convert.ToInt32(e.CommandArgument.ToString());
            Session["exerciseID"] = exerciseID;
            pnlExerciseDetails.Visible = true;
            ltlExerciseName.Text = "<h4>" + sysManager.getExerciseInfo(exerciseID).name + "</h4>";
            checkEnabled();
        }
    }

    protected void btnLog_Click(object sender, EventArgs e)
    {
        exerciseID = Session["exerciseID"] != null ? (int)Session["exerciseID"] : -1;
        //pnlExerciseDetails.Visible = false;
        pnlInfo.Visible = true;
        int sets = Convert.ToInt32(tbSets.Text.ToString());
        string note = tbNotes.Text.Trim();
        DateTime logTime = Convert.ToDateTime(tbTimeLogged.Text.ToString());
        int weight = Convert.ToInt32(tbWeight.Text.ToString());
        float distance = (float)Convert.ToDouble(tbDistance.Text.ToString());
        int time = Convert.ToInt32(tbTime.Text.ToString());
        int rep = Convert.ToInt32(tbRep.Text.ToString());
        
        LoggedExercise le = routManager.createLoggedExerciseRoutine(userID, exerciseID, routineID, sets, logTime, note);
        if (le != null)
        {
            int loggedExerciseID = Convert.ToInt32(le.id.ToString());
            SetAttributes sa = routManager.createSetAttributes(loggedExerciseID, weight, distance, time, rep);
        }

        clearAll();

        Response.Redirect(Request.RawUrl);
    }

    public void init()
    {
        pnlExerciseDetails.Visible = false;
        ltlExerciseName.Text = "";
        pnlInfo.Visible = false;

        tbWeight.Enabled = false;
        tbWeight.Text = "0";

        tbDistance.Enabled = false;
        tbDistance.Text = "0";

        tbTime.Enabled = false;
        tbTime.Text = "0";

        tbRep.Enabled = false;
        tbRep.Text = "0";

        tbTimeLogged.Text = DateTime.Now.ToString("HH:mm");
    }

    public void checkEnabled()
    {
        exerciseID = Session["exerciseID"] != null ? (int)Session["exerciseID"] : -1;
        Exercise ex = sysManager.getExerciseInfo(exerciseID);

        tbWeight.Enabled = ex.weight;
        tbWeight.BackColor = ex.weight ? Color.White : Color.Gray;
        //tbWeight.Text = ex.weight ? "0" : "";
        tbWeight.Text = "0";

        tbDistance.Enabled = ex.distance;
        tbDistance.BackColor = ex.distance ? Color.White : Color.Gray;
        //tbDistance.Text = ex.distance ? "0" : "";
        tbDistance.Text = "0";

        tbTime.Enabled = ex.time;
        tbTime.BackColor = ex.time ? Color.White : Color.Gray;
        //tbTime.Text = ex.time ? "0" : "";
        tbTime.Text = "0";

        tbRep.Enabled = ex.rep;
        tbRep.BackColor = ex.rep ? Color.White : Color.Gray;
        //tbRep.Text = ex.rep ? "0" : "";
        tbRep.Text = "0";
    }

    public void clearAll()
    {
        tbWeight.Text = "0";
        tbDistance.Text = "0";
        tbTime.Text = "0";
        tbRep.Text = "0";

        tbNotes.Text = "";
        tbSets.Text = "";
        tbTimeLogged.Text = "";

    }
}