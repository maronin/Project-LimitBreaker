using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class LoggedExercise_default : System.Web.UI.Page
{
    Int32 exerciseID;
    Exercise selectedExercise;
    SystemExerciseManager exerciseManager = new SystemExerciseManager();
    LoggedExerciseManager logManager = new LoggedExerciseManager();
    UserManager userManager = new UserManager();
    Int64 logID;
    bool repOn, distanceOn, weightOn, timeOn;
    LimitBreaker user;

    protected void Page_Load(object sender, EventArgs e)
    {
        user = userManager.getLimitBreaker(User.Identity.Name);
        ucViewExercise.userControlEventHappened += new EventHandler(viewExercises_userControlEventHappened);
        if (!IsPostBack)
        {
            selectedExercise = exerciseManager.getFirstExercise();
            createTextBoxes();
            displayLogs(selectedExercise.name);
        }
        else
        {
            if (loggedExercises.SelectedIndex != -1)
            {
                logID = Convert.ToInt64(loggedExercises.SelectedValue);
            }
            exerciseID = ucViewExercise.ddlSelectedValue;
            selectedExercise = exerciseManager.getExerciseById(exerciseID);
            createTextBoxes();
        }
    }

    private void viewExercises_userControlEventHappened(object sender, EventArgs e)
    {
        exerciseID = ucViewExercise.ddlSelectedValue;
        selectedExercise = exerciseManager.getExerciseById(exerciseID);
        createTextBoxes();
        displayLogs(selectedExercise.name);
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
        logManager.logExercise(user.id, exerciseID, repValue, timeValue, weightValue, distanceValue);
        displayLogs(selectedExercise.name);
    }
    private int createTime(int minutes, int seconds)
    {
        return minutes * 60 + seconds;
    }

    private void displayLogs(string exerciseName)
    {
        List<LoggedExercise> logs = logManager.getLoggedExercises(user.id, exerciseName);
        loggedExercises.DataSource = logs;
        loggedExercises.DataBind();
    }
    protected void loggedExercises_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<SetAttributes> sets = logManager.getSetAttributes(logID);
        setsLbl.Text = logManager.setsToString(sets);
    }
}