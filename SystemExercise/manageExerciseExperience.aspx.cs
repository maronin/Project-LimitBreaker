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
        noExpLbl.Text = "";

        if (viewExerciseExp.ddlCount != 0)
        {
            manageExperienceMultiView.ActiveViewIndex = 1;
            ExerciseExp selectedExercise = expMngr.getExerciseExpByExerciseName(viewExerciseExp.ddlValue);
            Exercise exercise = manager.getExercise(viewExerciseExp.ddlValue);

            try
            {
                baseTxtBox.Text = selectedExercise.baseExperience.ToString();

                if (exercise.time == true)
                {
                    timeTxtBox.Enabled = true;
                    timeTxtBox.Text = selectedExercise.timeModifier.ToString();
                }
                else
                {
                    timeTxtBox.Enabled = false;
                }

                if (exercise.weight == true)
                {
                    weightTxtBox.Enabled = true;
                    weightTxtBox.Text = selectedExercise.weightModifier.ToString();
                }
                else
                {
                    weightTxtBox.Enabled = false;
                }

                if (exercise.rep == true)
                {
                    repTxtBox.Enabled = true;
                    repTxtBox.Text = selectedExercise.repModifier.ToString();
                }
                else
                {
                    repTxtBox.Enabled = false;
                }

                if (exercise.distance == true)
                {
                    distanceTxtBox.Enabled = true;
                    distanceTxtBox.Text = selectedExercise.distanceModifier.ToString();
                }
                else
                {
                    distanceTxtBox.Enabled = false;
                }
            }

            catch (Exception ex)
            {
                noExpLbl.Text = "This exercise does not have any experience values associated with it yet";
                noExpLbl.Text = ex.Message + Environment.NewLine + ex.StackTrace;
            }
        }

        else
        {
            manageExperienceMultiView.ActiveViewIndex = 0;
        }
    }
    protected void saveExpBtn_Click(object sender, EventArgs e)
    {

    }
}