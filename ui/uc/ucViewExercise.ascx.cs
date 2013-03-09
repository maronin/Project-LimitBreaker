using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ui_uc_ucViewExercise : System.Web.UI.UserControl
{
    SystemExerciseManager manager = new SystemExerciseManager();
    ExerciseManager exerciseManager = new ExerciseManager();
    public event EventHandler userControlEventHappened;

    private void OnUserControlEvent()
    {
        if (userControlEventHappened != null)
        {
            userControlEventHappened(this, EventArgs.Empty);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        exerciseAutoComplete.SourceList = manager.getExerciseNamesAC();
        
        if (!IsPostBack)
        {
            populateExiseList();
            populateExerciseInfo();
        }

    }

    protected void exerciseSearchButton_Click(object sender, EventArgs e)
    {
        //lblResult.Text = "";
        List<Exercise> foundExercises = manager.getExercisesByName(exerciseSearchBox.Text.Trim());
        ExerciseDDL.Items.Clear();
        if (foundExercises.Count != 0)
        {

            ExerciseDDL.DataSource = foundExercises;
            ExerciseDDL.DataBind();
           // foreach (Exercise name in foundExercises)
           // {
             //   ExerciseDDL.Items.Add(name.name);
                //    if (name.enabled)
                //        rblEnaber.Items[0].Selected = true;
                //    else
                //        rblEnaber.Items[1].Selected = false;
            //}
            //rblEnaber.Visible = true;

            exceriseNotFound.Visible = false;
            ExerciseDDL_SelectedIndexChanged(sender, e);
            ExerciseDDL.Visible = true;
            viewExercisePanel.Visible = true;
        }
        else
            exerciesNotFound();

        OnUserControlEvent();
    }

    protected void MuscleGroupDDL_SelectedIndexChanged(object sender, EventArgs e)
    {
        //lblResult.Text = "";
        populateExiseList();
        OnUserControlEvent();
    }

    protected void ExerciseDDL_SelectedIndexChanged(object sender, EventArgs e)
    {
        populateExerciseInfo();
        colorCodeExercises();
        /*
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
        //populateForm();
        */
        OnUserControlEvent();
    }

    public void colorCodeExercises()
    {
        foreach (ListItem items in ExerciseDDL.Items)
        {
            if (exerciseManager.enabled(Convert.ToInt32(items.Value)))
                items.Attributes.Add("style", "background-color:#67E667; color:#008500");
            else
            {
                items.Attributes.Add("style", "background-color:#FF7373; color:#A60000");
            }

        }

        if (exerciseManager.enabled(Convert.ToInt32(ExerciseDDL.SelectedItem.Value)))
        {
            ExerciseDDL.Attributes.Add("style", "background-color:#67E667; color:#008500");
        }
        else
        {
            ExerciseDDL.Attributes.Add("style", "background-color:#FF7373; color:#A60000");
        }

    }

    protected void exerciesNotFound()
    {
        //exerciseName.Visible = false;
        //exerciseEquipment.Visible = false;
        //exerciseVideo.Visible = false;
        //exerciseAttributes.Visible = false;
        //exerciseEnabled.Visible = false;
        exceriseNotFound.Visible = true;
          lblExerciseEquipment.Text = "";
          lblExerciseMuscleGroups.Text = "";
          lblExerciseVideo.Text = "";
          lblExerciseDescription.Text = "";
          viewExercisePanel.Visible = false;
          //ExerciseDDL.Items.Insert(0, new ListItem("No Exercises", "NONE"));
          //ExerciseDDL.SelectedIndex = 0;
    }

    public string ddlValue
    {
        get { return ExerciseDDL.SelectedItem.Text; }
    }

    public bool exists
    {
        get { return ExerciseDDL.SelectedItem != null ? true : false; }
    }

    public int ddlSelectedValue
    {
        get { return Convert.ToInt32(ExerciseDDL.SelectedValue); }
    }

    public int ddlCount
    {
        get { return ExerciseDDL.Items.Count; }
    }

    public bool ddle
    {
        set {
            viewExercisePanel.Visible = value; }
    }

    protected void dllExercises_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    public void populateExiseList()
    {
   
        List<Exercise> foundExercises = manager.getExercisesByMuscleGroup(ddlMuscleGroups.SelectedValue.Trim());
        ExerciseDDL.Items.Clear();
        exerciseSearchBox.Text = "";
        if (foundExercises.Count != 0)
        {
            //ExerciseDDL.DataSource = foundExercises;
            //ExerciseDDL.DataBind();

            // ExerciseDDL.DataSource = foundExercises;
            ListItem item;
            foreach (Exercise name in foundExercises)
            {
                //ExerciseDDL.Items.Add(new ListItem(name.name, Convert.ToString(name.id), name.enabled));
                if (name.enabled)
                {
                    item = new ListItem(name.name, name.id.ToString());
                    ExerciseDDL.Items.Add(item);
                }
                else
                {
                    item = new ListItem(name.name, name.id.ToString());
                    ExerciseDDL.Items.Add(item);
                }

            }
            colorCodeExercises();
            //ExerciseDDL.DataBind();






            exceriseNotFound.Visible = false;
            viewExercisePanel.Visible = true;
            populateExerciseInfo();
        }
        else
            exerciesNotFound();
        
    }

    protected void populateExerciseInfo()
    {
        lblExerciseEquipment.Text = "";
        lblExerciseMuscleGroups.Text = "";
        lblExerciseVideo.Text = "[Video]";
        //if (ExerciseDDL.SelectedValue != "NONE")
        //{
        Exercise exercise = exerciseManager.getExerciseById(Convert.ToInt32(ExerciseDDL.SelectedValue));
            lblExerciseEquipment.Text = exercise.equipment;

            if (exercise.description == "")
            {
                lblExerciseDescription.Text = "None";
            }
            else
            {
                lblExerciseDescription.Text = exercise.description;
            }



            lblExerciseVideo.NavigateUrl = exercise.videoLink;


            String[] muscles = exerciseManager.splitMuscleGroups(exercise.muscleGroups);


            foreach (var item in muscles)
            {
                if (item != "")
                    lblExerciseMuscleGroups.Text += "- " + item + "<br/>";
            }
        //}
        //else
        //{
         //   lblExerciseEquipment.Text = "";
         //   lblExerciseMuscleGroups.Text = "";
         //   lblExerciseVideo.Text = "";
         //   lblExerciseDescription.Text = "";
        //}
    }


}