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
    ListBox lb;
    SystemExerciseManager sysManager;
    LoggedExerciseManager logManager;
    routineManager routManager;
    GoalManager goalMngr;
    int exerciseID;
    int routineID;

    protected void Page_Load(object sender, EventArgs e)
    {
        sysManager = new SystemExerciseManager();
        routManager = new routineManager();
        logManager = new LoggedExerciseManager();
        goalMngr = new GoalManager();
        lb = (ListBox)this.Parent.FindControl("lbRoutines");


        if (Session["exerciseID"] != null)
        {
            exerciseID = (int)Session["exerciseID"];
        }

        if (!IsPostBack)
        {
            Session.Abandon();
            init();
        }
        if (lb != null && lb.SelectedIndex > -1)
        {
            GridView1.DataSource = routManager.getExerciseFromRoutine(Convert.ToInt32(lb.SelectedItem.Value));
            GridView1.DataBind();
            routineID = Convert.ToInt32(lb.SelectedItem.Value);
            pnlInfo.Visible = false;
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
        if (checkZeroes())
        {
            exerciseID = Session["exerciseID"] != null ? (int)Session["exerciseID"] : -1;
            //pnlExerciseDetails.Visible = false;
            string note = tbNotes.Text.Trim();
            int weight = Convert.ToInt32(tbWeight.Text.ToString());
            float distance = (float)Convert.ToDouble(tbDistance.Text.ToString());
            // convert the 2 text boxes to seconds
            int time = Convert.ToInt32(tbTime_min.Text.ToString()) * 60 + Convert.ToInt32(tbTime_sec.Text.ToString());
            int rep = Convert.ToInt32(tbRep.Text.ToString());
            
            ExperienceManager expMngr = new ExperienceManager();
            int exp = logManager.logExerciseIntoRoutine(userID, exerciseID, routineID, rep, time, weight, distance, note);

            ExerciseGoal eg = goalMngr.getUnachievedGoalByExerciseNameAndUserID(sysManager.getExerciseInfo(exerciseID).name, userID);

            if (eg != null)
            {
                if (goalMngr.achieveGoal(eg, rep, time, weight, distance))
                {
                    goalAchievedLbl.Text = "Congratulations! You have achieved your goal for this exercise. You can view your goals ";
                    goalsLink.Visible = true;
                }
                else
                {
                    goalAchievedLbl.Text = "";
                    goalsLink.Visible = false;
                }
            }

            bool leveled = expMngr.rewardExperienceToUser(userID, exp);
            expRewardLbl.Text = "<br />You received " + exp.ToString() + " experience";
            if (leveled)
                expRewardLbl.Text += "<br />Congratulations, you have leveled up!";

            init();
            pnlInfo.Visible = true;
        }
    }

    public bool checkZeroes()
    {
        int weight = Convert.ToInt32(tbWeight.Text.ToString());
        float distance = (float)Convert.ToDouble(tbDistance.Text.ToString());
        // convert the 2 text boxes to seconds
        int time = Convert.ToInt32(tbTime_min.Text.ToString()) * 60 + Convert.ToInt32(tbTime_sec.Text.ToString());
        int rep = Convert.ToInt32(tbRep.Text.ToString());

        int sum = weight + Convert.ToInt32(distance) + time + rep;

        return sum > 0;
    }

    public void init()
    {
        clearAll();

        pnlExerciseDetails.Visible = false;
        ltlExerciseName.Text = "";
        tbNotes.Text = "";
        pnlInfo.Visible = false;

        tbWeight.Enabled = false;
        tbDistance.Enabled = false;
        tbTime_min.Enabled = false;
        tbTime_sec.Enabled = false;
        tbRep.Enabled = false;

        rfWeight.Enabled = false;
        rfDistance.Enabled = false;
        rfMinute.Enabled = false;
        rfSecond.Enabled = false;
        rfReps.Enabled = false;
    }

    public void checkEnabled()
    {
        exerciseID = Session["exerciseID"] != null ? (int)Session["exerciseID"] : -1;
        Exercise ex = sysManager.getExerciseInfo(exerciseID);

        tbWeight.Enabled = ex.weight;
        rfWeight.Enabled = ex.weight;
        tbWeight.BackColor = ex.weight ? Color.White : Color.Gray;
        tbWeight.Text = "0";

        tbDistance.Enabled = ex.distance;
        rfDistance.Enabled = ex.distance;
        tbDistance.BackColor = ex.distance ? Color.White : Color.Gray;
        tbDistance.Text = "0";

        tbTime_min.Enabled = ex.time;
        rfMinute.Enabled = ex.time;
        tbTime_min.BackColor = ex.time ? Color.White : Color.Gray;
        tbTime_min.Text = "0";

        tbTime_sec.Enabled = ex.time;
        rfSecond.Enabled = ex.time;
        tbTime_sec.BackColor = ex.time ? Color.White : Color.Gray;
        tbTime_sec.Text = "0";

        tbRep.Enabled = ex.rep;
        rfReps.Enabled = ex.rep;
        tbRep.BackColor = ex.rep ? Color.White : Color.Gray;
        tbRep.Text = "0";
    }

    public void clearAll()
    {
        tbWeight.Text = "0";
        tbDistance.Text = "0";
        tbTime_min.Text = "0";
        tbTime_sec.Text = "0";
        tbRep.Text = "0";

        tbNotes.Text = "";

    }
}