using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_manageExerciseGoals : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        if (!Page.IsPostBack)
        {
            viewGoalsBtn.Enabled = false;
            addGoalBtn.Enabled = true;
            //query for the ExerciseGoal set from the logged in user, set exerciseGoalMultiView.ActiveViewIndex = 1;  then populate that view with all of the users goals
            //if the user has no goals then set exerciseGoalMultiView.ActiveViewIndex = 0;
        }
    }

    protected void viewGoalsBtn_Click(object sender, EventArgs e)
    {
        viewGoalsBtn.Enabled = false;
        addGoalBtn.Enabled = true;
        //if the user has no goals then set exerciseGoalMultiView.ActiveViewIndex = 0;
        //else then set exerciseGoalMultiView.ActiveViewIndex = 1;
    }

    protected void addGoalBtn_Click(object sender, EventArgs e)
    {
        viewGoalsBtn.Enabled = true;
        addGoalBtn.Enabled = false;
        exerciseGoalMultiView.ActiveViewIndex = 2;
    }
}