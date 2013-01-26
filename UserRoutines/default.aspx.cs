using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class userRoutines_Default : System.Web.UI.Page
{
    // Create a manager instance to access class methods
    routineManager manager;

    protected void Page_Load(object sender, EventArgs e)
    {
        manager = new routineManager();
    }

    // When a routine is selected from the list, user will be able to modify, delete and view details of the routine
    protected void rblRoutines_SelectedIndexChanged(object sender, EventArgs e)
    {
        // bind the data source of the details view with a routine object
        // convert to a temporary list of routines so that it can be bound
        dvRoutineDetails.DataSource = new List<Routine> { manager.getRoutine(Convert.ToInt32(rblRoutines.SelectedValue)) };
        dvRoutineDetails.DataBind();
    }
}