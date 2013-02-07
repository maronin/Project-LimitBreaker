using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_manageExerciseGoals : System.Web.UI.Page
{
    string userName;
    GoalManager goalMngr;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        userName = User.Identity.Name;
        goalMngr = new GoalManager();
        viewExercises.userControlEventHappened += new EventHandler(viewExercises_userControlEventHappened);
        
        if (!Page.IsPostBack)
        {
            viewGoalsBtn.Enabled = false;
            addGoalBtn.Enabled = true;

            if (goalMngr.getUnachievedExerciseGoalsFromUser(userName, Convert.ToInt32(orderByRbl.SelectedValue)).Count < 1)
                exerciseGoalMultiView.ActiveViewIndex = 1;
            else
            {
                exerciseGoalMultiView.ActiveViewIndex = 2;
                loadExerciseGoals();
            }
        }
    }

    private void viewExercises_userControlEventHappened(object sender, EventArgs e)
    {
        addGoalResultLbl.Text = "";
        showAddGoal();
    }

    protected void viewGoalsBtn_Click(object sender, EventArgs e)
    {
        viewGoalsBtn.Enabled = false;
        addGoalBtn.Enabled = true;

        if (goalMngr.getUnachievedExerciseGoalsFromUser(userName, Convert.ToInt32(orderByRbl.SelectedValue)).Count < 1)
            exerciseGoalMultiView.ActiveViewIndex = 1;
        else
        {
            exerciseGoalMultiView.ActiveViewIndex = 2;
            loadExerciseGoals();
        }
    }

    protected void addGoalBtn_Click(object sender, EventArgs e)
    {
        viewGoalsBtn.Enabled = true;
        addGoalBtn.Enabled = false;
        exerciseGoalMultiView.ActiveViewIndex = 0;
        addGoalResultLbl.Text = "";
        showAddGoal();
    }

    protected void orderByRbl_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadExerciseGoals();
    }

    protected void userGoalsListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadSelectedGoalsAttributes(userGoalsListBox.SelectedValue);
    }

    protected void saveNewGoalBtn_Click(object sender, EventArgs e)
    {
        try
        {
            if (goalMngr.addNewExerciseGoal(Convert.ToInt32(goalWeightTxtBox.Text), Convert.ToDouble(goalDistanceTxtBox.Text), Convert.ToInt32(goalTimeTxtBox.Text)*60, Convert.ToInt32(goalRepsTxtBox.Text), userName, viewExercises.ddlValue))
            {
                addGoalResultLbl.Text = "You have successfully added a new exercise goal!";
                saveNewGoalBtn.Enabled = false;
            }
            else
                addGoalResultLbl.Text = "Something went wrong with making a new exercise goal...";
        }

        catch (Exception ex)
        {
            addGoalResultLbl.Text = "Something went wrong with making a new exercise goal: " + ex.Message;
        }
    }

    public void loadExerciseGoals()
    {
        List<ExerciseGoal> goalSet = goalMngr.getUnachievedExerciseGoalsFromUser(userName, Convert.ToInt32(orderByRbl.SelectedValue));
        userGoalsListBox.Items.Clear();

        foreach (ExerciseGoal ex in goalSet)
        {
            userGoalsListBox.Items.Add(ex.Exercise.name);
        }

        userGoalsListBox.SelectedIndex = 0;
        loadSelectedGoalsAttributes(userGoalsListBox.SelectedValue);
    }

    public void loadSelectedGoalsAttributes(string exerciseName)
    {
        singleGoalAttributesMultiView.ActiveViewIndex = 0;
        ExerciseGoal eg = goalMngr.getExerciseGoalByExerciseNameAndUserName(exerciseName, userName);

        exerciseNameLbl.Text = exerciseName;
        goalTimeLbl.Text = eg.time.ToString();
        goalDistancelbl.Text = eg.distance.ToString();
        goalWeightLbl.Text = eg.weight.ToString();
        goalRepsLbl.Text = eg.reps.ToString();
    }

    public void showAddGoal()
    {
        if (viewExercises.ddlCount > 0)
        {
            try
            {
                SystemExerciseManager manager = new SystemExerciseManager();
                Exercise exercise = manager.getExercise(viewExercises.ddlValue);

                addGoalPanel.Visible = true;

                if (exercise.time)
                {
                    goalTimeTxtBox.Enabled = true;
                    NumericUpDownExtender1.Enabled = true;
                    goalTimeTxtBox.Text = "0";
                }
                else
                {
                    goalTimeTxtBox.Enabled = false;
                    NumericUpDownExtender1.Enabled = false;
                    goalTimeTxtBox.Text = "0";
                }

                if (exercise.weight)
                {
                    goalWeightTxtBox.Enabled = true;
                    NumericUpDownExtender2.Enabled = true;
                    goalWeightTxtBox.Text = "0";
                }
                else
                {
                    goalWeightTxtBox.Enabled = false;
                    NumericUpDownExtender2.Enabled = false;
                    goalWeightTxtBox.Text = "0";
                }

                if (exercise.distance)
                {
                    goalDistanceTxtBox.Enabled = true;
                    NumericUpDownExtender3.Enabled = true;
                    goalDistanceTxtBox.Text = "0";
                }
                else
                {
                    goalDistanceTxtBox.Enabled = false;
                    NumericUpDownExtender3.Enabled = false;
                    goalDistanceTxtBox.Text = "0";
                }

                if (exercise.rep)
                {
                    goalRepsTxtBox.Enabled = true;
                    NumericUpDownExtender4.Enabled = true;
                    goalRepsTxtBox.Text = "0";
                }

                else
                {
                    goalRepsTxtBox.Enabled = false;
                    NumericUpDownExtender4.Enabled = false;
                    goalRepsTxtBox.Text = "0";
                }


                if (goalMngr.getExerciseNameWithinGoal(userName, exercise.name) == exercise.name)
                {
                    saveNewGoalBtn.Enabled = false;
                    addGoalResultLbl.Text = "You already have a Goal for this exercise.  You can modify it in the \"View Exercise Goals\" page.";
                }
                else
                    saveNewGoalBtn.Enabled = true;
            }

            catch (Exception ex)
            {
                addGoalResultLbl.Text = "Something went wrong with the creating of the form: " + ex.Message + ex.StackTrace;
            }
        }
        else
            addGoalPanel.Visible = false;
    }
}