using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ui_uc_CreateNewRoutine : System.Web.UI.UserControl
{
    public int userID { get; set; }

    SystemExerciseManager sysManager;
    routineManager routManager;
    List<Exercise> exercises;
    ListBox lb;

    protected void Page_Load(object sender, EventArgs e)
    {
        sysManager = new SystemExerciseManager();
        routManager = new routineManager();

        if (Session["exercises"] == null)
        {
            exercises = new List<Exercise>();
            Session["exercises"] = exercises;
        }

        if (!IsPostBack)
        {
            // full refresh of page will abandon current session
            Session.Abandon();
            lb = (ListBox)this.Parent.FindControl("lbRoutines");
            if (userID != null)
            {
                lb.DataSource = routManager.getUsersRoutines(userID).ToList();
                lb.DataTextField = "name";
                lb.DataValueField = "id";
                lb.DataBind();
            }

            // to get the id of the button so that enter = submit
            tbRoutineName.Attributes.Add("onKeyPress",
                 "doClick('" + btnConfirm.ClientID + "',event)");
        }

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        var selectedItems = from item in lbExerciseList.Items.OfType<ListItem>()
                            where item.Selected
                            select item;
        Exercise exerciseItem = new Exercise();
        foreach (ListItem li in selectedItems)
        {
            if (!lbSelected.Items.Contains(li))
            {
                lbSelected.Items.Add(li);
                btnConfirm.Enabled = lbSelected.Items.Count != 0 ? true : false;
                exerciseItem = sysManager.getExercise(li.Text);
                if (exerciseItem != null)
                    AddExercise(exerciseItem);
            }
        }

        for (int i = 0; i < lbSelected.Items.Count; i++)
        {
            lbSelected.Items[i].Selected = false;
        }

    }
    protected void btnRemove_Click(object sender, EventArgs e)
    {
        if (lbSelected.SelectedIndex > -1)
        {
            Exercise exerciseItem = new Exercise();
            exercises = Session["exercises"] != null ? (List<Exercise>)Session["exercises"] : null;
            if (exercises != null)
            {
                exerciseItem = sysManager.getExercise(lbSelected.SelectedItem.Text);
                if (exercises.Contains(exerciseItem))
                    exercises.Remove(exerciseItem);
            }
            while (lbSelected.SelectedItem != null)
            {
                lbSelected.Items.Remove(lbSelected.SelectedItem);
            }
            btnConfirm.Enabled = lbSelected.Items.Count != 1 ? true : false;

            Session["exercises"] = exercises;
        }
    }

    void AddExercise(Exercise exerciseItem)
    {
        exercises = Session["exercises"] != null ? (List<Exercise>)Session["exercises"] : null;
        if (exercises != null)
        {
            if (exercises.Contains(exerciseItem) == false)
                exercises.Add(exerciseItem);
        }
    }

    ICollection<Exercise> convertListBox(ListBox lb)
    {
        ICollection<Exercise> rc = new List<Exercise>();
        Exercise ex = new Exercise();

        if (lb.Items.Count > 0)
        {
            for (int i = 0; i < lb.Items.Count; i++)
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
        Session.Clear();
        ddlMuscleGroups.SelectedIndex = 0;
        lbSelected.Items.Clear();
        tbRoutineName.Text = "";
    }

    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        exercises = Session["exercises"] != null ? (List<Exercise>)Session["exercises"] : null;
        Routine rt = new Routine();
        ICollection<Exercise> exerciseList = convertListBox(lbSelected);
        // user id to be changed later so that function createNewRoutine makes a routine for specified user
        if (exerciseList != null && Convert.ToInt32(userID) != -1)
            rt = routManager.createNewRoutine(tbRoutineName.Text.Trim(), userID, exerciseList);

        clearAll();

        // redirect page to itself (refresh)
        Response.Redirect(Request.RawUrl);
    }

}