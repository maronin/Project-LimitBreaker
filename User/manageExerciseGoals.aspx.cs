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
            addGoalPanel.Visible = true;
        else
            addGoalPanel.Visible = false;
    }
}