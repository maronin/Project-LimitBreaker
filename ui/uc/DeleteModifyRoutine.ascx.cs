using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class ui_uc_DeleteModifyRoutine : System.Web.UI.UserControl
{
    RadioButtonList rbl;
    SystemExerciseManager sysManager;
    routineManager routManager;

    protected void Page_Load(object sender, EventArgs e)
    {
        sysManager = new SystemExerciseManager();
        routManager = new routineManager();
        rbl = (RadioButtonList)this.Parent.FindControl("rblRoutines");
        if (!IsPostBack)
        {

        }
        if (rbl != null && rbl.SelectedIndex > -1)
        {
            GridView1.DataSource = routManager.getExerciseFromRoutine(Convert.ToInt32(rbl.SelectedItem.Value));
            GridView1.DataBind();
            btnDelete.Visible = true;
            btnDelete.Enabled = true;
            //Response.Write(rbl.SelectedIndex + " item: " + rbl.SelectedItem);
        }

    }
    protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        e.ExceptionHandled = true;
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "del")
        {
            Response.Write("command argument: " + e.CommandArgument.ToString() + "<br/>");

        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        bool rc = false;
        if (rbl != null && rbl.SelectedIndex > -1)
        {
            try
            {

                rc = routManager.deleteRoutine(Convert.ToInt32(rbl.SelectedItem.Value));
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
                // write off the execeptions to my error.log file
                StreamWriter wrtr = new StreamWriter(System.Web.HttpContext.Current.ApplicationInstance.Server.MapPath("~/assets/documents/" + @"\" + "error.log"), true);

                wrtr.WriteLine(DateTime.Now.ToString() + " | Error: " + ex);

                wrtr.Close();
            }
        }

        if (rc)
        {
            // redirect page to itself (refresh)
            Response.Redirect(Request.RawUrl);
        }
    }
}