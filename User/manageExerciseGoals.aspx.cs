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
        
        if (!Page.IsPostBack)
        {
            viewGoalsBtn.Enabled = false;
            addGoalBtn.Enabled = true;

            if (goalMngr.getUnachievedExerciseGoalsFromUser(userName, Convert.ToInt32(orderByRbl.SelectedValue)).Count < 1)
                exerciseGoalMultiView.ActiveViewIndex = 0;
            else
            {
                exerciseGoalMultiView.ActiveViewIndex = 1;
                loadExerciseGoals();
            }
        }
    }

    protected void viewGoalsBtn_Click(object sender, EventArgs e)
    {
        viewGoalsBtn.Enabled = false;
        addGoalBtn.Enabled = true;

        if (goalMngr.getUnachievedExerciseGoalsFromUser(userName, Convert.ToInt32(orderByRbl.SelectedValue)).Count < 1)
            exerciseGoalMultiView.ActiveViewIndex = 0;
        else
        {
            exerciseGoalMultiView.ActiveViewIndex = 1;
            loadExerciseGoals();
        }
    }

    protected void addGoalBtn_Click(object sender, EventArgs e)
    {
        viewGoalsBtn.Enabled = true;
        addGoalBtn.Enabled = false;
        exerciseGoalMultiView.ActiveViewIndex = 2;
    }

    protected void orderByRbl_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadExerciseGoals();
    }

    public void loadExerciseGoals()
    {
        List<ExerciseGoal> goalSet = goalMngr.getUnachievedExerciseGoalsFromUser(userName, Convert.ToInt32(orderByRbl.SelectedValue));
        userGoalsListBox.Items.Clear();

        foreach (ExerciseGoal ex in goalSet)
        {
            userGoalsListBox.Items.Add(ex.Exercise.name);
        }
    }
}