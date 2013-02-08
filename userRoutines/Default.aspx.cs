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
    String currentUser;
    bool authenticated;
    ui_uc_CreateNewRoutine cnr;

    protected void Page_Load(object sender, EventArgs e)
    {
        manager = new routineManager();
        authenticated = System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
        currentUser = authenticated ? HttpContext.Current.User.Identity.Name : "";
        cnr = LoginView1.FindControl("CreateNewRoutine") as ui_uc_CreateNewRoutine;
        if (authenticated && cnr != null)
        {
            cnr.userID = manager.getUserID(currentUser);
        }
        
    }

    // When a routine is selected from the list, user will be able to modify, delete and view details of the routine
    protected void rblRoutines_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
}