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
    Dictionary<string, int[]> exGoals;// = new Dictionary<string, int[]>();

    protected void Page_Load(object sender, EventArgs e)
    {
        sysManager = new SystemExerciseManager();
        routManager = new routineManager();

        if (Session["exGoals"] == null)
        {
            exGoals = new Dictionary<string, int[]>();
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
                AddOrUpdate(li.Text, goals);
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
            exGoals = Session["exGoals"] != null ? (Dictionary<string, int[]>)Session["exGoals"] : null;
            if (exGoals != null)
            {
                if (exGoals.ContainsKey(lbSelected.SelectedItem.Text))
                    exGoals.Remove(lbSelected.SelectedItem.Text);
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
            exGoals = Session["exGoals"] != null ? (Dictionary<string, int[]>)Session["exGoals"] : null;

            if (exGoals != null)
            {
                tbRep.Enabled = selectedExercise.rep == true ? true : false;
                tbRep.Text = tbRep.Enabled == true ? exGoals[selectedExercise.name].GetValue(0).ToString() : Convert.ToString(0);

                tbWeight.Enabled = selectedExercise.weight == true ? true : false;
                tbWeight.Text = tbWeight.Enabled == true ? exGoals[selectedExercise.name].GetValue(1).ToString() : Convert.ToString(0);

                tbDistance.Enabled = selectedExercise.distance == true ? true : false;
                tbDistance.Text = tbDistance.Enabled == true ? exGoals[selectedExercise.name].GetValue(2).ToString() : Convert.ToString(0);

                tbTime.Enabled = selectedExercise.time == true ? true : false;
                tbTime.Text = tbTime.Enabled == true ? exGoals[selectedExercise.name].GetValue(3).ToString() : Convert.ToString(0);
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

    void AddOrUpdate(string key, int[] value)
    {
        exGoals = Session["exGoals"] != null ? (Dictionary<string, int[]>)Session["exGoals"] : null;
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

            exGoals = Session["exGoals"] != null ? (Dictionary<string, int[]>)Session["exGoals"] : null;
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
                AddOrUpdate(selectedExercise.name, goals);
            }
            for (int i = 0; i < lbSelected.Items.Count; i++)
            {
                lbSelected.Items[i].Selected = false;
            }
        }
    }
    protected void btnConfirm_Click(object sender, EventArgs e)
    {

    }
}