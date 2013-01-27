using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ui_uc_CreateNewRoutine : System.Web.UI.UserControl
{
    public string userID { get; set; }

    SystemExerciseManager sysManager;
    routineManager routManager;
    Dictionary<int, int[]> exGoals;// = new Dictionary<string, int[]>();

    protected void Page_Load(object sender, EventArgs e)
    {
        sysManager = new SystemExerciseManager();
        routManager = new routineManager();

        if (Session["exGoals"] == null)
        {
            exGoals = new Dictionary<int, int[]>();
            Session["exGoals"] = exGoals;
        }

        if (!IsPostBack)
        {
            // full refresh of page will abandon current session

            Session.Abandon();
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        var selectedItems = from item in lbExerciseList.Items.OfType<ListItem>()
                            where item.Selected
                            select item;

        int[] goals = new int[4] { 0, 0, 0, 0 };

        foreach (ListItem li in selectedItems)
        {
            if (!lbSelected.Items.Contains(li))
            {
                lbSelected.Items.Add(li);
                btnConfirm.Enabled = lbSelected.Items.Count != 1 ? true : false;
                if (tbRep.Text.Trim() != null)
                    goals[0] = tbRep.Enabled == true ? Convert.ToInt32(tbRep.Text.Trim()) : 0;
                if (tbWeight.Text.Trim() != null)
                    goals[1] = tbWeight.Enabled == true ? Convert.ToInt32(tbWeight.Text.Trim()) : 0;
                if (tbDistance.Text.Trim() != null)
                    goals[2] = tbDistance.Enabled == true ? Convert.ToInt32(tbDistance.Text.Trim()) : 0;
                if (tbTime.Text.Trim() != null)
                    goals[3] = tbTime.Enabled == true ? Convert.ToInt32(tbTime.Text.Trim()) : 0;
                AddOrUpdate(Convert.ToInt32(li.Value), goals);
            }
        }

        for (int i = 0; i < lbSelected.Items.Count; i++)
        {
            lbSelected.Items[i].Selected = false;
        }

    }
    protected void btnRemove_Click(object sender, EventArgs e)
    {
        if (lbSelected.SelectedIndex != 0)
        {
            exGoals = Session["exGoals"] != null ? (Dictionary<int, int[]>)Session["exGoals"] : null;
            if (exGoals != null)
            {
                if (exGoals.ContainsKey(Convert.ToInt32(lbSelected.SelectedItem.Value)))
                    exGoals.Remove(Convert.ToInt32(lbSelected.SelectedItem.Value));
            }
            while (lbSelected.SelectedItem != null)
            {
                lbSelected.Items.Remove(lbSelected.SelectedItem);
            }
            btnConfirm.Enabled = lbSelected.Items.Count != 1 ? true : false;

            Session["exGoals"] = exGoals;
        }
    }

    protected void lbSelected_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (lbSelected.SelectedIndex != 0)
        {
            var selectedItems = from item in lbSelected.Items.OfType<ListItem>()
                                where item.Selected == true
                                select item;

            Exercise selectedExercise = sysManager.getExercise(lbSelected.SelectedItem.ToString());
            exGoals = Session["exGoals"] != null ? (Dictionary<int, int[]>)Session["exGoals"] : null;

            if (exGoals != null)
            {
                tbRep.Enabled = selectedExercise.rep == true ? true : false;
                tbRep.Text = tbRep.Enabled == true ? exGoals[selectedExercise.id].GetValue(0).ToString() : Convert.ToString(0);

                tbWeight.Enabled = selectedExercise.weight == true ? true : false;
                tbWeight.Text = tbWeight.Enabled == true ? exGoals[selectedExercise.id].GetValue(1).ToString() : Convert.ToString(0);

                tbDistance.Enabled = selectedExercise.distance == true ? true : false;
                tbDistance.Text = tbDistance.Enabled == true ? exGoals[selectedExercise.id].GetValue(2).ToString() : Convert.ToString(0);

                tbTime.Enabled = selectedExercise.time == true ? true : false;
                tbTime.Text = tbTime.Enabled == true ? exGoals[selectedExercise.id].GetValue(3).ToString() : Convert.ToString(0);
            }
        }
        else
        {
            tbRep.Enabled = false;
            tbRep.Text = Convert.ToString(0);

            tbWeight.Enabled = false;
            tbWeight.Text = Convert.ToString(0);

            tbDistance.Enabled = false;
            tbDistance.Text = Convert.ToString(0);

            tbTime.Enabled = false;
            tbTime.Text = Convert.ToString(0);
        }
    }

    void AddOrUpdate(int key, int[] value)
    {
        exGoals = Session["exGoals"] != null ? (Dictionary<int, int[]>)Session["exGoals"] : null;
        if (exGoals != null)
        {
            if (exGoals.ContainsKey(key) == true)
                exGoals[key] = value;
            else
                exGoals.Add(key, value);
        }
    }
    /* for debugging dictionary
    protected void Button1_Click(object sender, EventArgs e)
    {
        exGoals = Session["exGoals"] != null ? (Dictionary<string, int[]>)Session["exGoals"] : null;
        if (exGoals != null)
        {
            foreach (KeyValuePair<string, int[]> pair in exGoals)
            {
                Response.Write("<br/>" + pair.Key);
                for (int i = 0; i < 4; i++)
                {
                    Response.Write("<br/>+" + pair.Value[i]);
                }
            }
        }
    }*/
    protected void lbExerciseList_SelectedIndexChanged(object sender, EventArgs e)
    {
        var selectedItems = from item in lbExerciseList.Items.OfType<ListItem>()
                            where item.Selected == true
                            select item;

        Exercise selectedExercise = sysManager.getExercise(lbExerciseList.SelectedItem.ToString());

        tbRep.Enabled = selectedExercise.rep == true ? true : false;
        tbRep.Text = Convert.ToString(0);

        tbWeight.Enabled = selectedExercise.weight == true ? true : false;
        tbWeight.Text = Convert.ToString(0);

        tbDistance.Enabled = selectedExercise.distance == true ? true : false;
        tbDistance.Text = Convert.ToString(0);

        tbTime.Enabled = selectedExercise.time == true ? true : false;
        tbTime.Text = Convert.ToString(0);
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        if (lbSelected.SelectedIndex != 0)
        {
            var selectedItems = from item in lbSelected.Items.OfType<ListItem>()
                                where item.Selected
                                select item;

            exGoals = Session["exGoals"] != null ? (Dictionary<int, int[]>)Session["exGoals"] : null;
            Exercise selectedExercise = sysManager.getExercise(lbSelected.SelectedItem.ToString());

            int[] goals = new int[4] { 0, 0, 0, 0 };
            if (exGoals != null)
            {
                btnConfirm.Enabled = lbSelected.Items.Count != 1 ? true : false;
                if (tbRep.Text.Trim() != null)
                    goals[0] = tbRep.Enabled == true ? Convert.ToInt32(tbRep.Text.Trim()) : 0;
                if (tbWeight.Text.Trim() != null)
                    goals[1] = tbWeight.Enabled == true ? Convert.ToInt32(tbWeight.Text.Trim()) : 0;
                if (tbDistance.Text.Trim() != null)
                    goals[2] = tbDistance.Enabled == true ? Convert.ToInt32(tbDistance.Text.Trim()) : 0;
                if (tbTime.Text.Trim() != null)
                    goals[3] = tbTime.Enabled == true ? Convert.ToInt32(tbTime.Text.Trim()) : 0;
                AddOrUpdate(selectedExercise.id, goals);
            }
            for (int i = 0; i < lbSelected.Items.Count; i++)
            {
                lbSelected.Items[i].Selected = false;
            }
        }
    }

    ICollection<Exercise> convertListBox(ListBox lb)
    {
        ICollection<Exercise> rc = new List<Exercise>();
        Exercise ex = new Exercise();

        if (lb.Items.Count > 1)
        {
            for (int i = 1; i < lb.Items.Count; i++)
            {
                ex = sysManager.getExercise(lb.Items[i].ToString());
                if (ex != null)
                    rc.Add(ex);
            }
        }

        return rc;
    }

    void clearAll()
    {
        ddlMuscleGroups.SelectedIndex = 0;
        for (int i = 1; i < lbSelected.Items.Count; i++)
        {
            lbSelected.Items.RemoveAt(i);
        }
        tbRoutineName.Text = "";
    }

    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        Routine rt = new Routine();
        ICollection<Exercise> exerciseList = convertListBox(lbSelected);
        ICollection<LoggedExercise> loggedExercises = new List<LoggedExercise>();
        ICollection<SetAttributes> setAttributes = new List<SetAttributes>();
        Dictionary<LoggedExercise, int[]> dictLoggedExercises = new Dictionary<LoggedExercise,int[]>();
        ICollection<ExerciseGoal> exerciseGoals = new List<ExerciseGoal>();

        // user id to be changed later so that function createNewRoutine makes a routine for specified user
        //rt = routManager.createNewRoutine(tbRoutineName.Text.Trim(), 1);
        
        //if (rt != null)
            loggedExercises = routManager.createLoggedExercises(exerciseList, 1, 4);
        /*
        if (loggedExercises != null)
            dictLoggedExercises = routManager.convertIntToLoggedExercise(exGoals);
        if (dictLoggedExercises != null)
            setAttributes = routManager.createSetAttribute(dictLoggedExercises);
        if (setAttributes != null)
            exerciseGoals = routManager.createExerciseGoals(4, setAttributes);
        */
        clearAll();
    }
}