using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    SystemExerciseManager manager = new SystemExerciseManager();

    protected void Page_Load(object sender, EventArgs e)
    {
        exerciseAutoComplete.SourceList = manager.getExerciseNamesAC();
        rblEnaber.Visible = false;
        Panel1.Visible = false;
    }
    protected void exerciseSearchButton_Click(object sender, EventArgs e)
    {
        lblResult.Text = "";
        List<Exercise> foundExercises = manager.getExercisesByName(exerciseSearchBox.Text.Trim());
        ExerciseDDL.Items.Clear();
        if (foundExercises.Count != 0)
        {
            foreach (Exercise name in foundExercises)
            {
                ExerciseDDL.Items.Add(name.name);
                if (name.enabled)
                    rblEnaber.Items[0].Selected = true;
                else
                    rblEnaber.Items[1].Selected = false;
            }
            exceriseNotFound.Visible = false;
            ExerciseDDL_SelectedIndexChanged(sender, e);
            rblEnaber.Visible = true;
            ExerciseDDL.Visible = true;
        }
        else
            exerciesNotFound();
    }
    protected void MuscleGroupRBL_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblResult.Text = "";
        List<Exercise> foundExercises = manager.getExercisesByMuscleGroup(MuscleGroupRBL.SelectedValue.Trim());
        ExerciseDDL.Items.Clear();
        exerciseSearchBox.Text="";
        if (foundExercises.Count != 0)
        {
            foreach (Exercise name in foundExercises)
            {
                ExerciseDDL.Items.Add(name.name);
            }
            exceriseNotFound.Visible = false;
            ExerciseDDL_SelectedIndexChanged(sender, e);
        }
        else
            exerciesNotFound();
    }
    protected void ExerciseDDL_SelectedIndexChanged(object sender, EventArgs e)
    {
        Exercise exercise = manager.getExercise(ExerciseDDL.SelectedValue);
        exerciseName.Visible = true;
        exerciseName.Text = exercise.name;
        exerciseEquipment.Visible = true;
        exerciseEquipment.Text = exercise.equipment;
        exerciseVideo.Visible = true;
        exerciseVideo.Text = exercise.videoLink;
        exerciseAttributes.Visible = true;
        exerciseAttributes.Text = "";
        if (exercise.weight)
            exerciseAttributes.Text += "Weight\n";
        if (exercise.rep)
            exerciseAttributes.Text += "Reps\n";
        if (exercise.time)
            exerciseAttributes.Text += "Time\n";
        if (exercise.distance)
            exerciseAttributes.Text += "Distance\n";
        exerciseEnabled.Visible = true;
        exerciseEnabled.Text = exercise.enabled.ToString();
        populateForm();
    }
    protected void rblEnaber_SelectedIndexChanged(object sender, EventArgs e)
    {
        disableManager enabler = new disableManager();
        try
        {
            if (Convert.ToInt32(rblEnaber.SelectedValue) == 1)
            {
                enabler.enableExerciseByName(ExerciseDDL.SelectedValue);
                exerciseEnabled.Text = "True";
            }

            else if (Convert.ToInt32(rblEnaber.SelectedValue) == 0)
            {
                enabler.disableExerciseByName(ExerciseDDL.SelectedValue);
                exerciseEnabled.Text = "False";
            }

            populateForm();
        }
        catch (Exception)
        {

        }
    }
    protected void exerciesNotFound()
    {
        exerciseName.Visible = false;
        exerciseEquipment.Visible = false;
        exerciseVideo.Visible = false;
        exerciseAttributes.Visible = false;
        exerciseEnabled.Visible = false;
        exceriseNotFound.Visible = true;
    }


    protected void initBoxes()
    {
        for (int i = 0; i < cblAttributes.Items.Count; i++)
        {
            cblAttributes.Items[i].Selected = false;
        }
        for (int i = 0; i < cblMuscleGroups.Items.Count; i++)
        {
            cblMuscleGroups.Items[i].Selected = false;
        }
    }

    protected void populateForm()
    {
        Exercise foundExercise = manager.getExerciseInfo(manager.getExerciseID(ExerciseDDL.SelectedValue));
        String[] muscleGroups;
        initBoxes();

        if (foundExercise != null)
        {
            rblEnaber.Visible = true;
            muscleGroups = manager.splitMuscleGroups(foundExercise.muscleGroups);
            Panel1.Visible = true;
            if (foundExercise.rep)
                cblAttributes.Items[0].Selected = true;
            if (foundExercise.weight)
                cblAttributes.Items[1].Selected = true;
            if (foundExercise.distance)
                cblAttributes.Items[2].Selected = true;
            if (foundExercise.time)
                cblAttributes.Items[3].Selected = true;

            foreach (String muscle in muscleGroups)
            {
                //Response.Write(muscle +"<br>");
                switch (muscle)
                {
                    case "Chest":
                        cblMuscleGroups.Items[0].Selected = true;
                        break;
                    case "Back":
                        cblMuscleGroups.Items[1].Selected = true;
                        break;
                    case "Shoulder":
                        cblMuscleGroups.Items[2].Selected = true;
                        break;
                    case "Arms":
                        cblMuscleGroups.Items[3].Selected = true;
                        break;
                    case "Legs":
                        cblMuscleGroups.Items[4].Selected = true;
                        break;
                    case "Cardio":
                        cblMuscleGroups.Items[5].Selected = true;
                        break;

                }
            }

            tbExerciseName.Text = foundExercise.name;
            tbVideoLink.Text = foundExercise.videoLink;
            tbEquipment.Text = foundExercise.equipment;
        }
    }

    protected void btnConfirmChanges_Click(object sender, EventArgs e)
    {
        bool rep = false, wieght = false, time = false, distance = false;
        string muscleGroups = "";

        if (cblAttributes.Items[0].Selected)
            rep = true;
        if (cblAttributes.Items[1].Selected)
            wieght = true;
        if (cblAttributes.Items[2].Selected)
            distance = true;
        if (cblAttributes.Items[3].Selected)
            time = true;

        foreach (ListItem item in cblMuscleGroups.Items)
        {
            if (item.Selected)
                muscleGroups += item.Text + System.Environment.NewLine;
        }

        if (manager.modifyExercise(manager.getExerciseID(ExerciseDDL.SelectedValue), tbExerciseName.Text, muscleGroups, tbEquipment.Text, tbVideoLink.Text, rep, wieght, distance, time) && tbExerciseName.Text != "")
        {
            lblResult.ForeColor = System.Drawing.Color.Green;
            lblResult.Text = "Modified Succesfully!";
        }
        else
        {
            lblResult.ForeColor = System.Drawing.Color.Red;
            lblResult.Text = "Exercise name already exists";
        }

        if (tbExerciseName.Text == "")
        {
            lblResult.ForeColor = System.Drawing.Color.Orange;
            lblResult.Text = "Please enter an exercise name";
        }

        populateForm();
    }
    protected void btnDeleteExercise_Click(object sender, EventArgs e)
    {
        ExerciseManager deleter = new ExerciseManager();

        try
        {
            bool result = deleter.deleteExerciseByName(ExerciseDDL.SelectedValue);

            if (result)
            {
                lblDeletionResult.Text = "The exercise has been removed";
                Response.Redirect("default.aspx");
            }

            else
            {
                lblDeletionResult.Text = "Something went wrong with the database deletion";
            }
        }

        catch (Exception)
        {
            lblDeletionResult.Text = "Something went wrong with the execution of the page";
        }
    }
}