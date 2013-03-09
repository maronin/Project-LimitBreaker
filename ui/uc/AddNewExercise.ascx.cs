using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class ui_uc_AddNewExercise : System.Web.UI.UserControl
{
    SystemExerciseManager manager;
    protected void Page_Load(object sender, EventArgs e)
    {
        manager = new SystemExerciseManager();     
    }
    protected void btnCreateExercise_Click(object sender, EventArgs e)
    {   
        lblResult.Text = "";
        bool rep = false, wieght = false, time = false, distance = false, enabled = false;
        string muscleGroups = "";

        if (cblAttributes.Items[0].Selected)
            rep = true;
        if (cblAttributes.Items[1].Selected)
            wieght = true;
        if (cblAttributes.Items[2].Selected)
            distance = true;
        if (cblAttributes.Items[3].Selected)
            time = true;
        if (cbEnabled.Checked)
            enabled = true;

        foreach (ListItem item in cblMuscleGroups.Items)
        {
            if (item.Selected)
                muscleGroups += item.Text + System.Environment.NewLine;
        }

        if (manager.createNewExercise(tbExerciseName.Text, muscleGroups, tbEquipment.Text, tbVideoLink.Text, rep, wieght, distance, time, enabled, tbDescription.Text) && tbExerciseName.Text != ""){  
            lblResult.ForeColor = System.Drawing.Color.Green;       
            lblResult.Text = "Added Succesfully!";

        }
        else
        {
            lblResult.ForeColor = System.Drawing.Color.Red;
            lblResult.Text = "Exercise name already exists, please try again";
        }

        if (tbExerciseName.Text == ""){
            lblResult.ForeColor = System.Drawing.Color.Orange;
            lblResult.Text = "Please enter an exercise name";
        }

        tbExerciseName.Text = "";
        tbEquipment.Text = "";
        tbVideoLink.Text = "";
        tbDescription.Text = "";

        cblAttributes.ClearSelection();
        cblMuscleGroups.ClearSelection();
    }
}