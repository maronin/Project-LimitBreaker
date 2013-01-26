using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class systemExercise_manageExerciseExperience : System.Web.UI.Page
{
    ExperienceManager expMngr = new ExperienceManager();
    SystemExerciseManager manager = new SystemExerciseManager();

    protected void Page_Load(object sender, EventArgs e)
    {
        viewExerciseExp.userControlEventHappened += new EventHandler(viewExerciseExp_userControlEventHappened);

        if (!Page.IsPostBack)
        {
            loadFields();
        }
    }

    private void viewExerciseExp_userControlEventHappened(object sender, EventArgs e)
    {
        loadFields();
    }

    protected void saveExpBtn_Click(object sender, EventArgs e)
    {
        if (expMngr.modifyExerciseExpByName(viewExerciseExp.ddlValue, Convert.ToDouble(baseTxtBox.Text), Convert.ToDouble(weightTxtBox.Text), Convert.ToDouble(repTxtBox.Text), Convert.ToDouble(distanceTxtBox.Text), Convert.ToDouble(timeTxtBox.Text)))
            loadFields();
    }

    protected void addExpBtn_Click(object sender, EventArgs e)
    {

    }

    protected void loadFields()
    {
        if (viewExerciseExp.ddlCount != 0)
        {
            manageExperienceMultiView.ActiveViewIndex = 1;
            ExerciseExp selectedExercise = expMngr.getExerciseExpByExerciseName(viewExerciseExp.ddlValue);
            Exercise exercise = manager.getExercise(viewExerciseExp.ddlValue);

            try
            {
                baseTxtBox.Text = selectedExercise.baseExperience.ToString();

                if (exercise.time)
                {
                    timeTxtBox.Enabled = true;
                    timeTxtBox.Text = selectedExercise.timeModifier.ToString();
                }
                else
                {
                    timeTxtBox.Enabled = false;
                    timeTxtBox.Text = "0";
                }

                if (exercise.weight)
                {
                    weightTxtBox.Enabled = true;
                    weightTxtBox.Text = selectedExercise.weightModifier.ToString();
                }
                else
                {
                    weightTxtBox.Enabled = false;
                    weightTxtBox.Text = "0";
                }

                if (exercise.rep)
                {
                    repTxtBox.Enabled = true;
                    repTxtBox.Text = selectedExercise.repModifier.ToString();
                }
                else
                {
                    repTxtBox.Enabled = false;
                    repTxtBox.Text = "0";
                }

                if (exercise.distance)
                {
                    distanceTxtBox.Enabled = true;
                    distanceTxtBox.Text = selectedExercise.distanceModifier.ToString();
                }
                else
                {
                    distanceTxtBox.Enabled = false;
                    distanceTxtBox.Text = "0";
                }
            }

            catch (Exception ex)
            {
                //noExpLbl.Text = ex.Message + Environment.NewLine + ex.StackTrace;
                manageExperienceMultiView.ActiveViewIndex = 2;

                addBaseTxtBox.Text = "0";
                addTimeTxtBox.Text = "0";
                addWeightTxtBox.Text = "0";
                addRepTxtBox.Text = "0";
                addDistanceTxtBox.Text = "0";

                if (exercise.time)
                    addTimeTxtBox.Enabled = true;
                else
                    addTimeTxtBox.Enabled = false;

                if (exercise.weight)
                    addWeightTxtBox.Enabled = true;
                else
                    addWeightTxtBox.Enabled = false;

                if (exercise.rep)
                    addRepTxtBox.Enabled = true;
                else
                    addRepTxtBox.Enabled = false;

                if (exercise.distance)
                    addDistanceTxtBox.Enabled = true;
                else
                    addDistanceTxtBox.Enabled = false;
            }
        }

        else
        {
            manageExperienceMultiView.ActiveViewIndex = 0;
        }

    }
}