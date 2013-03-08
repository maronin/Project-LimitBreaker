using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Drawing;
using System.Web.UI.HtmlControls;

public partial class LoggedExercise_default : System.Web.UI.Page
{
    SystemExerciseManager exerciseManager = new SystemExerciseManager();
    LoggedExerciseManager logManager = new LoggedExerciseManager();
    UserManager userManager = new UserManager();
    GoalManager goalMngr = new GoalManager();

    Exercise selectedExercise;
    Int64 logID;
    bool repOn, distanceOn, weightOn, timeOn;
    LimitBreaker user;

    protected void Page_Load(object sender, EventArgs e)
    {

        HtmlGenericControl li = (HtmlGenericControl)this.Page.Master.FindControl("Ulnav").FindControl("liLoggedExercises");
        li.Attributes.Add("class", "active");

        user = userManager.getLimitBreaker(User.Identity.Name);
        ucViewExercise.userControlEventHappened += new EventHandler(viewExercises_userControlEventHappened);
        if (!IsPostBack)
        {
            selectedExercise = exerciseManager.getFirstExercise();
            createTextBoxes();
            displayLogs();
        }
        else
        {
            if (loggedExercises.SelectedIndex != -1)
            {
                logID = Convert.ToInt64(loggedExercises.SelectedValue);
            }
            selectedExercise = exerciseManager.getExerciseById(ucViewExercise.ddlSelectedValue);
            createTextBoxes();
        }
    }

    private void viewExercises_userControlEventHappened(object sender, EventArgs e)
    {
        selectedExercise = exerciseManager.getExerciseById(ucViewExercise.ddlSelectedValue);
        createTextBoxes();
        displayLogs();
        disableLabels();

    }
    protected void createTextBoxes()
    {
        if (selectedExercise.rep)
        {
            rep.Enabled = true;
            repOn = true;
            repREV.Enabled = true;
            repRF.Enabled = true;
        }
        else
        {
            rep.Enabled = false;
            repOn = false;
            rep.Text = "";
            repREV.Enabled = false;
            repRF.Enabled = false;
        }

        if (selectedExercise.time)
        {
            timeMinutes.Enabled = true;
            timeSeconds.Enabled = true;
            timeOn = true;
            minutesREV.Enabled = true;
            minutesRF.Enabled = true;
            secondsREV.Enabled = true;
            secondsRF.Enabled = true;
        }
        else
        {
            timeMinutes.Enabled = false;
            timeSeconds.Enabled = false;
            timeOn = false;
            timeMinutes.Text = "";
            timeSeconds.Text = "";
            minutesREV.Enabled = false;
            minutesRF.Enabled = false;
            secondsREV.Enabled = false;
            secondsRF.Enabled = false;
        }

        if (selectedExercise.weight)
        {
            weight.Enabled = true;
            weightOn = true;
            weightREV.Enabled = true;
            weightRF.Enabled = true;
        }
        else
        {
            weight.Enabled = false;
            weightOn = false;
            weight.Text = "";
            weightREV.Enabled = false;
            weightRF.Enabled = false;
        }

        if (selectedExercise.distance)
        {
            distance.Enabled = true;
            distanceOn = true;
            distanceREV.Enabled = true;
            distanceRF.Enabled = true;
        }
        else
        {
            distance.Enabled = false;
            distanceOn = false;
            distance.Text = "";
            distanceREV.Enabled = false;
            distanceRF.Enabled = false;
        }
    }
    protected void recordSet_Click(object sender, EventArgs e)
    {
        int timeValue, weightValue, repValue;
        double distanceValue;
        if (timeOn)
        {
            timeValue = createTime(Convert.ToInt32(timeMinutes.Text.Trim()), Convert.ToInt32(timeSeconds.Text.Trim()));
        }
        else
        {
            timeValue = 0;
        }

        if (weightOn)
        {
            weightValue = Convert.ToInt32(weight.Text.Trim());
        }
        else
        {
            weightValue = 0;
        }

        if (repOn)
        {
            repValue = Convert.ToInt32(rep.Text.Trim());
        }
        else
        {
            repValue = 0;
        }

        if (distanceOn)
        {
            distanceValue = Convert.ToDouble(distance.Text.Trim());
        }
        else
        {
            distanceValue = 0;
        }

        //Begin log operations and exp extraction

        ExperienceManager expMngr = new ExperienceManager();
        int exp = logManager.logExercise(user.id, selectedExercise.id, repValue, timeValue, weightValue, distanceValue);
        ExerciseGoal eg = goalMngr.getUnachievedGoalByExerciseNameAndUserID(selectedExercise.name, user.id);

        if (eg != null)
        {
            if (goalMngr.achieveGoal(eg, repValue, timeValue, weightValue, distanceValue))
            {
                goalAchievedLbl.Text = "Congratulations! You have achieved your goal for this exercise. You can view your goals ";
                goalsLink.Visible = true;
            }
        }
        if (exp != 0)
        {
            bool leveled = expMngr.rewardExperienceToUser(user.id, exp);
            successLbl.Visible = true;
            expRewardLbl.Visible = true;
            expRewardLbl.Text = "You received " + exp.ToString() + " experience for logging a set for " + ucViewExercise.ddlValue;
            if (leveled)
                expRewardLbl.Text += "<br />Congratulations, you have leveled up!";
            displayLogs();

            //Manually set the selected index to 0 (the most recently logged exercise) and set the logID to the selected one to display the most recent log (this one)
            loggedExercises.SelectedIndex = 0;
            logID = Convert.ToInt64(loggedExercises.SelectedValue);

            loggedExercises_SelectedIndexChanged(sender, e);
        }
        else
        {
            successLbl.Visible = true;
            successLbl.Text = "Something went wrong!";
            successLbl.ForeColor = Color.Red;
        }
    }
    private int createTime(int minutes, int seconds)
    {
        return minutes * 60 + seconds;
    }

    private void displayLogs()
    {
        List<LoggedExercise> logs = logManager.getLoggedExercises(user.id, selectedExercise.id);
        loggedExercises.DataSource = logs;
        loggedExercises.DataBind();
    }
    protected void loggedExercises_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<SetAttributes> sets = logManager.getSetAttributes(logID);
        setsLbl.Text = logManager.setsToString(sets);
    }

    private void disableLabels()
    {
        expRewardLbl.Visible = false;
        successLbl.Visible = false;
        goalAchievedLbl.Text = "";
        goalsLink.Visible = false;
        setsLbl.Text = "";
    }
}