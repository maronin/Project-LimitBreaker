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
    static bool nameChanged = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        HtmlGenericControl home = (HtmlGenericControl)this.Page.Master.FindControl("Ulnav").FindControl("lisystemExercise");
        home.Attributes.Add("class", "active");
        nameChanged = false;
        lblResult.Text = "";
        viewExercises.userControlEventHappened += new EventHandler(viewExercises_userControlEventHappened);
        //rblEnaber.Visible = false;
        //pnlModifyExercise.Visible = false;
        if (!IsPostBack) { 
        viewExercises.populateExiseList();
        populateForm();
        pnlAddExercise.Visible = true;
        pnlModifyExercises.Visible = false;
        btnModifyExercise.Enabled = true;
        btnAddExercise.Enabled = false;

       
        }

        viewExercises.hideInfo = false;

    }

    private void viewExercises_userControlEventHappened(object sender, EventArgs e)
    {
        if (viewExercises.exists)
            populateForm();
        lblDeletionResult.Text = "";
        
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
            viewExercises.colorCodeExercises();
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
        string muscleGroups = "";

        foreach (ListItem item in cblMuscleGroups.Items)
        {
            if (item.Selected)
                muscleGroups += item.Text + System.Environment.NewLine;
        }

        if (manager.modifyExercise(manager.getExerciseID(viewExercises.ddlValue), tbExerciseName.Text, muscleGroups, tbEquipment.Text, tbVideoLink.Text, cblAttributes.Items[0].Selected, cblAttributes.Items[1].Selected, cblAttributes.Items[2].Selected, cblAttributes.Items[3].Selected, tbModifyDescription.Text, nameChanged) && tbExerciseName.Text != "")
        {
            lblResult.ForeColor = System.Drawing.Color.Green;
            lblResult.Text = "Modified Succesfully!";
            viewExercises.populateExiseList();
        }
        else
        {
            lblResult.ForeColor = System.Drawing.Color.Red;
            lblResult.Text = "Exercise name already exists";
            lblResult.ForeColor = Color.Red;
            viewExercises.populateExiseList();
        }

        if (tbExerciseName.Text == "")
        {
            lblResult.ForeColor = System.Drawing.Color.Orange;
            lblResult.Text = "Please enter an exercise name";
            lblResult.ForeColor = Color.Orange;
        }
        clearModifyForm();
        populateForm();
    }

    protected void clearModifyForm()
    {

        cblAttributes.Items[0].Selected = false;
        cblAttributes.Items[1].Selected = false;
        cblAttributes.Items[2].Selected = false;
        cblAttributes.Items[3].Selected = false;
        tbEquipment.Text = "";
        tbModifyDescription.Text = "";
        tbVideoLink.Text = "";

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
                lblDeletionResult.ForeColor = Color.Green;
                //Response.Redirect("default.aspx");
                viewExercises.populateExiseList();
                clearModifyForm();
                populateForm();
            }

            else
            {
                lblDeletionResult.Text = "Something went wrong with the database deletion";
                lblDeletionResult.ForeColor = Color.Red;
            }
        }

        catch (Exception)
        {
            lblDeletionResult.Text = "Something went wrong with the execution of the page";
            lblDeletionResult.ForeColor = Color.Red;
        }
    }
    protected void tbExerciseName_TextChanged(object sender, EventArgs e)
    {
        nameChanged = true;
    }
    protected void btnAddExercise_Click(object sender, EventArgs e)
    {
        btnAddExercise.Enabled = false;
        //MultiViewExercises.ActiveViewIndex = 0;
        pnlAddExercise.Visible = true;
        pnlModifyExercises.Visible = false;
        btnModifyExercise.Enabled = true;
        Label result = (Label)addExercises.FindControl("lblResult");
        result.Text = "";
    }
    protected void btnModifyExercise_Click(object sender, EventArgs e)
    {
        btnModifyExercise.Enabled = false;
        //MultiViewExercises.ActiveViewIndex = 1;
        pnlAddExercise.Visible = false;
        pnlModifyExercises.Visible = true;
        btnAddExercise.Enabled = true;
        viewExercises.populateExiseList();
        viewExercises.colorCodeExercises();
    }
}