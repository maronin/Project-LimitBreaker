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

    //page event functions
    private void viewExercises_userControlEventHappened(object sender, EventArgs e)
    {
        addGoalResultLbl.Text = "";
        deleteGoalResultLbl.Text = "";
        modifyGoalResultlbl.Text = "";
        showAddGoal();
    }

    protected void viewGoalsBtn_Click(object sender, EventArgs e)
    {
        viewGoalsBtn.Enabled = false;
        addGoalBtn.Enabled = true;
        deleteGoalResultLbl.Text = "";
        modifyGoalResultlbl.Text = "";

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
        deleteGoalResultLbl.Text = "";
        modifyGoalResultlbl.Text = "";
        loadExerciseGoals();
    }

    protected void userGoalsListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadSelectedGoalsAttributes(userGoalsListBox.SelectedValue);
        resetGoalView();
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

    protected void updateGoalbtn_Click(object sender, EventArgs e)
    {
        if (singleGoalAttributesMultiView.ActiveViewIndex == 0)
        {
            singleGoalAttributesMultiView.ActiveViewIndex = 1;
            updateGoalbtn.Text = "Cancel";
            saveModifyGoalBtn.Visible = true;
            ExerciseGoal eg = goalMngr.getExerciseGoalByExerciseNameAndUserName(userGoalsListBox.SelectedValue, userName);
            Exercise ex = goalMngr.getExerciseWithinGoal(userName, userGoalsListBox.SelectedValue);

            if (ex.time)
            {
                modGoalTimePanel.Visible = true;
                NumericUpDownExtender5.Minimum = 1;
                RegularExpressionValidator5.ValidationExpression = "^[1-9][0-9]*$";
            }
            else
            {
                modGoalTimePanel.Visible = false;
                NumericUpDownExtender5.Minimum = 0;
                RegularExpressionValidator5.ValidationExpression = "[0-9]+";
            }

            if (ex.distance)
            {
                modGoalDistancePanel.Visible = true;
                NumericUpDownExtender6.Minimum = 0.1;
                RegularExpressionValidator7.ValidationExpression = "^[1-9][0-9]*(\\.[0-9]+)?|0+\\.[0-9]*[1-9][0-9]*$";
            }
            else
            {
                modGoalDistancePanel.Visible = false;
                NumericUpDownExtender6.Minimum = 0;
                RegularExpressionValidator7.ValidationExpression = "[0-9]+([\\.][0-9]{1,3})?$";
            }

            if (ex.weight)
            {
                modGoalWeightPanel.Visible = true;
                NumericUpDownExtender7.Minimum = 1;
                RegularExpressionValidator6.ValidationExpression = "^[1-9][0-9]*$";
            }
            else
            {
                modGoalWeightPanel.Visible = false;
                NumericUpDownExtender7.Minimum = 0;
                RegularExpressionValidator6.ValidationExpression = "[0-9]+";
            }

            if (ex.rep)
            {
                modGoalRepsPanel.Visible = true;
                NumericUpDownExtender8.Minimum = 1;
                RegularExpressionValidator8.ValidationExpression = "^[1-9][0-9]*$";
            }
            else
            {
                modGoalRepsPanel.Visible = false;
                NumericUpDownExtender8.Minimum = 0;
                RegularExpressionValidator8.ValidationExpression = "[0-9]+";
            }

            exerciseNameLbl.Text = userGoalsListBox.SelectedValue;
            modGoalTimeTxtBox.Text = (eg.time/60).ToString();
            modGoalDistanceTxtBox.Text = eg.distance.ToString();
            modGoalWeightTxtBox.Text = eg.weight.ToString();
            modGoalRepsTxtBox.Text = eg.reps.ToString();
        }

        else
        {
            resetGoalView();
        }
    }

    protected void deleteGoalBtn_Click(object sender, EventArgs e)
    {
        try
        {
            if (goalMngr.deleteExerciseGoalByExerciseNameAndUserName(userName, userGoalsListBox.SelectedValue))
                deleteGoalResultLbl.Text = "The goal has been successfully deleted!";
            else
                deleteGoalResultLbl.Text = "Something went wrong with deleting the goal, and it has not been deleted...";
        }

        catch (Exception ex)
        {
            deleteGoalResultLbl.Text = "Something went wrong with deleting the goal, and it has not been deleted: " + ex.Message;
        }
        
        loadExerciseGoals();
    }

    protected void saveModifyGoalBtn_Click(object sender, EventArgs e)
    {
        try
        {
            if (goalMngr.modifyExerciseGoalByExerciseNameAndUserName(userName, userGoalsListBox.SelectedValue, Convert.ToInt32(modGoalTimeTxtBox.Text) * 60, Convert.ToDouble(modGoalDistanceTxtBox.Text), Convert.ToInt32(modGoalWeightTxtBox.Text), Convert.ToInt32(modGoalRepsTxtBox.Text)))
                modifyGoalResultlbl.Text = "The goal has been successfully modified!";
            else
                modifyGoalResultlbl.Text = "Something went wrong with the modification of the goal, and it has not been modified...";
        }

        catch (Exception ex)
        {
            modifyGoalResultlbl.Text = "Something went wrong with the modification of the goal, and it has not been modified: " + ex.Message;
        }

        resetGoalView();
        loadSelectedGoalsAttributes(userGoalsListBox.SelectedValue);
    }

    protected void achievedRbl_SelectedIndexChanged(object sender, EventArgs e)
    {
        deleteGoalResultLbl.Text = "";
        modifyGoalResultlbl.Text = "";
        loadExerciseGoals();
    }

    //page data loading functions
    public void loadExerciseGoals()
    {
        List<ExerciseGoal> goalSet;

        if (Convert.ToInt32(achievedRbl.SelectedValue) == 0)
        {
            goalSet = goalMngr.getUnachievedExerciseGoalsFromUser(userName, Convert.ToInt32(orderByRbl.SelectedValue));
            updateGoalbtn.Visible = true;
            deleteGoalBtn.Visible = true;
        }
        else
        {
            goalSet = goalMngr.getAchievedExerciseGoalsFromUser(userName, Convert.ToInt32(orderByRbl.SelectedValue));
            updateGoalbtn.Visible = false;
            deleteGoalBtn.Visible = false;
        }

        userGoalsListBox.Items.Clear();

        foreach (ExerciseGoal ex in goalSet)
        {
            userGoalsListBox.Items.Add(ex.Exercise.name);
        }

        if (userGoalsListBox.Items.Count > 0)
        {
            noAchievedPanel.Visible = true;
            resetGoalView();
            userGoalsListBox.SelectedIndex = 0;
            loadSelectedGoalsAttributes(userGoalsListBox.SelectedValue);
        }
        else if (userGoalsListBox.Items.Count == 0 && Convert.ToInt32(achievedRbl.SelectedValue) == 1)
        {
            noAchievedPanel.Visible = false;
            deleteGoalResultLbl.Text = "You do not have achieved exercise goals yet";
        }
        else
            exerciseGoalMultiView.ActiveViewIndex = 1;
    }

    public void loadSelectedGoalsAttributes(string exerciseName)
    {
        try
        {
            singleGoalAttributesMultiView.ActiveViewIndex = 0;
            ExerciseGoal eg = goalMngr.getExerciseGoalByExerciseNameAndUserName(exerciseName, userName);
            Exercise ex = goalMngr.getExerciseWithinGoal(userName, exerciseName);

            if (ex.time)
                goalTimePanel.Visible = true;
            else
                goalTimePanel.Visible = false;

            if (ex.distance)
                goalDistancePanel.Visible = true;
            else
                goalDistancePanel.Visible = false;

            if (ex.weight)
                goalWeightPanel.Visible = true;
            else
                goalWeightPanel.Visible = false;

            if (ex.rep)
                goalRepsPanel.Visible = true;
            else
                goalRepsPanel.Visible = false;

            exerciseNameLbl.Text = exerciseName;
            goalTimeLbl.Text = (eg.time / 60).ToString();
            goalDistancelbl.Text = eg.distance.ToString();
            goalWeightLbl.Text = eg.weight.ToString();
            goalRepsLbl.Text = eg.reps.ToString();
        }

        catch (Exception ex)
        {
            deleteGoalResultLbl.Text = "Something went horribly wrong: " + ex.Message;
        }
    }

    public void showAddGoal()
    {
        if (viewExercises.ddlCount != 0)
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
                    NumericUpDownExtender1.Minimum = 1;
                    goalTimeTxtBox.Text = "1";
                    RegularExpressionValidator1.ValidationExpression = "^[1-9][0-9]*$";
                }
                else
                {
                    goalTimeTxtBox.Enabled = false;
                    NumericUpDownExtender1.Enabled = false;
                    NumericUpDownExtender1.Minimum = 0;
                    goalTimeTxtBox.Text = "0";
                    RegularExpressionValidator1.ValidationExpression = "[0-9]+";
                }

                if (exercise.weight)
                {
                    goalWeightTxtBox.Enabled = true;
                    NumericUpDownExtender2.Enabled = true;
                    NumericUpDownExtender2.Minimum = 1;
                    goalWeightTxtBox.Text = "1";
                    RegularExpressionValidator2.ValidationExpression = "^[1-9][0-9]*$";
                }
                else
                {
                    goalWeightTxtBox.Enabled = false;
                    NumericUpDownExtender2.Enabled = false;
                    NumericUpDownExtender2.Minimum = 0;
                    goalWeightTxtBox.Text = "0";
                    RegularExpressionValidator2.ValidationExpression = "[0-9]+";
                }

                if (exercise.distance)
                {
                    goalDistanceTxtBox.Enabled = true;
                    NumericUpDownExtender3.Enabled = true;
                    NumericUpDownExtender3.Minimum = 0.1;
                    goalDistanceTxtBox.Text = "0.1";
                    RegularExpressionValidator3.ValidationExpression = "^[1-9][0-9]*(\\.[0-9]+)?|0+\\.[0-9]*[1-9][0-9]*$";
                }
                else
                {
                    goalDistanceTxtBox.Enabled = false;
                    NumericUpDownExtender3.Enabled = false;
                    NumericUpDownExtender3.Minimum = 0;
                    goalDistanceTxtBox.Text = "0";
                    RegularExpressionValidator3.ValidationExpression = "[0-9]+([\\.][0-9]{1,3})?$";
                }

                if (exercise.rep)
                {
                    goalRepsTxtBox.Enabled = true;
                    NumericUpDownExtender4.Enabled = true;
                    NumericUpDownExtender4.Minimum = 1;
                    goalRepsTxtBox.Text = "1";
                    RegularExpressionValidator4.ValidationExpression = "^[1-9][0-9]*$";
                }

                else
                {
                    goalRepsTxtBox.Enabled = false;
                    NumericUpDownExtender4.Enabled = false;
                    NumericUpDownExtender4.Minimum = 0;
                    goalRepsTxtBox.Text = "0";
                    RegularExpressionValidator4.ValidationExpression = "[0-9]+";
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
        {
            addGoalPanel.Visible = false;

            viewExercises.ddle = false;
        }
    }

    public void resetGoalView()
    {
        singleGoalAttributesMultiView.ActiveViewIndex = 0;
        updateGoalbtn.Text = "Update";
        saveModifyGoalBtn.Visible = false;
    }
}