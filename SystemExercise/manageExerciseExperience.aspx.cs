using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class systemExercise_manageExerciseExperience : System.Web.UI.Page
{
    ExperienceManager expMngr = new ExperienceManager();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (viewExerciseExp.ddlCount != 0)
        {
            manageExperienceMultiView.ActiveViewIndex = 1;
            ExerciseExp selectedExercise = expMngr.getExerciseExpByExerciseName(viewExerciseExp.ddlValue);

            try
            {
                baseTxtBox.Text = selectedExercise.baseExperience.ToString();
                timeTxtBox.Text = selectedExercise.timeModifier.ToString();
                weightTxtBox.Text = selectedExercise.weightModifier.ToString();
                repTxtBox.Text = selectedExercise.repModifier.ToString();
                distanceTxtBox.Text = selectedExercise.distanceModifier.ToString();
            }

            catch (Exception ex)
            {
                noExpLbl.Text = "This exercise does not have any experience values associated with it yet";
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