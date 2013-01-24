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
        foreach (ListItem li in selectedItems)
        {
            if (!lbSelected.Items.Contains(li))
            {
                lbSelected.Items.Add(li);
                btnConfirm.Enabled = lbSelected.Items.Count != 0 ? true : false;
                AddOrUpdate(li.Text, new int[4] { 0, 0, 0, 0 });
            }
        }

        for (int i = 0; i < lbSelected.Items.Count; i++)
        {
            lbSelected.Items[i].Selected = false;
        }

    }
    protected void btnRemove_Click(object sender, EventArgs e)
    {
        while (lbSelected.SelectedItem != null)
        {
            lbSelected.Items.Remove(lbSelected.SelectedItem);
        }
        btnConfirm.Enabled = lbSelected.Items.Count != 0 ? true : false;
    }
    protected void lbSelected_SelectedIndexChanged(object sender, EventArgs e)
    {

        var selectedItems = from item in lbSelected.Items.OfType<ListItem>()
                            where item.Selected == true
                            select item;

        Exercise selectedExercise = sysManager.getExercise(lbSelected.SelectedItem.ToString());

        if (selectedExercise.enabled == true)
        {
            tbRep.Enabled = selectedExercise.rep == true ? true : false;
            tbWeight.Enabled = selectedExercise.weight == true ? true : false;
            tbDistance.Enabled = selectedExercise.distance == true ? true : false;
            tbTime.Enabled = selectedExercise.time == true ? true : false;
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
    }
}