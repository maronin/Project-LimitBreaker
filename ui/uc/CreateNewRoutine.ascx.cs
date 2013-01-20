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
    Dictionary<string, int[]> exerciseGoals = new Dictionary<string, int[]>();

    protected void Page_Load(object sender, EventArgs e)
    {
        sysManager = new SystemExerciseManager();
        routManager = new routineManager();

        if (!IsPostBack)
        {
        }

        foreach (Exercise it in sysManager.getAllExercises())
        {
            String exerciseName = it.name;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        var selectedItems = from item in lbExerciseList.Items.OfType<ListItem>()
                            where item.Selected
                            select item;
        foreach (ListItem li in selectedItems)
        {
            if (!lbSelected.Items.Contains(li))
                lbSelected.Items.Add(li);
            if (!exerciseGoals.ContainsKey(li.Text))
                exerciseGoals.Add(li.Text, new int[4] { 0, 0, 0, 0 });
        }

        if (selectedItems.Count() == 1)
        {
            lbSelected_SelectedIndexChanged(null, null);
        }

    }
    protected void btnRemove_Click(object sender, EventArgs e)
    {
        while (lbSelected.SelectedItem != null)
        {
            lbSelected.Items.Remove(lbSelected.SelectedItem);
        }
    }
    protected void lbSelected_SelectedIndexChanged(object sender, EventArgs e)
    {
        var selectedItems = from item in lbSelected.Items.OfType<ListItem>()
                            where item.Selected
                            select item;
        Response.Write(lbSelected.SelectedIndex);
        Response.Write("<br/> + Dictionary: ");
        foreach (KeyValuePair<string, int[]> pair in exerciseGoals)
        {
            Response.Write("<br/> + " + pair.Key);
            foreach (int i in pair.Value)
            {
                Response.Write("<br/>  " + i);
            }
        }
        if (selectedItems.Count() == 1)
        {
            Exercise selectedExercise = sysManager.getExercise(lbSelected.SelectedItem.ToString());
            if (selectedExercise.enabled == true)
            {
                if (selectedExercise.rep == true)
                {
                    tbRep.Enabled = true;
                    tbRep.Text = exerciseGoals[selectedExercise.name][0].ToString();
                }
                if (selectedExercise.weight == true)
                {
                    tbWeight.Enabled = true;
                    tbWeight.Text = exerciseGoals[selectedExercise.name][1].ToString();
                }
                if (selectedExercise.distance == true)
                {
                    tbDistance.Enabled = true;
                    tbDistance.Text = exerciseGoals[selectedExercise.name][2].ToString();
                }
                if (selectedExercise.time == true)
                {
                    tbTime.Enabled = true;
                    tbTime.Text = exerciseGoals[selectedExercise.name][3].ToString();
                }
            }
        }
        else
        {
            tbDistance.Enabled = false;
            tbRep.Enabled = false;
            tbTime.Enabled = false;
            tbWeight.Enabled = false;
        }
    }
}