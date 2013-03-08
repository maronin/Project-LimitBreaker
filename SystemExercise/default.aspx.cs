using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Drawing;
public partial class _Default : System.Web.UI.Page
{
    SystemExerciseManager manager = new SystemExerciseManager();

    protected void Page_Load(object sender, EventArgs e)
    {
        HtmlGenericControl home = (HtmlGenericControl)this.Page.Master.FindControl("Ulnav").FindControl("lisystemExercise");
        home.Attributes.Add("class", "active");


        viewExercises.userControlEventHappened += new EventHandler(viewExercises_userControlEventHappened);
        //rblEnaber.Visible = false;
        //pnlModifyExercise.Visible = false;
        if (!IsPostBack) { 
        viewExercises.populateExiseList();
        populateForm();
        }
    }

    private void viewExercises_userControlEventHappened(object sender, EventArgs e)
    {
        if (viewExercises.exists)
            populateForm();
        
    }

    protected void rblEnaber_SelectedIndexChanged(object sender, EventArgs e)
    {
        disableManager enabler = new disableManager();
        try
        {
            

            if (cbEnabler.Checked)
            {
                enabler.enableExerciseByName(viewExercises.ddlValue);
            }

            else  if (!cbEnabler.Checked)
            {
                enabler.disableExerciseByName(viewExercises.ddlValue);
            }

            populateForm();
        }
        catch (Exception)
        {

        }
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
        Exercise foundExercise = manager.getExerciseInfo(manager.getExerciseID(viewExercises.ddlValue));
        String[] muscleGroups;
        initBoxes();

        if (foundExercise != null)
        {
            cbEnabler.Visible = true;
            muscleGroups = manager.splitMuscleGroups(foundExercise.muscleGroups);
            pnlModifyExercise.Visible = true;
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

            if (foundExercise.enabled)
            {
                cbEnabler.Checked = true;
                lblEnabled.ForeColor = Color.Green;
                lblEnabled.Text = "Enabled Exercise";
            }
            else
            {
                cbEnabler.Checked = false;
                lblEnabled.ForeColor = Color.Red;
                lblEnabled.Text = "Disabled Exercise";
            }

            tbVideoLink.Text = foundExercise.videoLink;
            tbEquipment.Text = foundExercise.equipment;
            tbModifyDescription.Text = foundExercise.description;
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

        if (manager.modifyExercise(manager.getExerciseID(viewExercises.ddlValue), tbExerciseName.Text, muscleGroups, tbEquipment.Text, tbVideoLink.Text, rep, wieght, distance, time, tbModifyDescription.Text) && tbExerciseName.Text != "")
        {
            lblResult.ForeColor = System.Drawing.Color.Green;
            lblResult.Text = "Modified Succesfully!";
            viewExercises.populateExiseList();
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
            bool result = deleter.deleteExerciseByName(viewExercises.ddlValue);

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