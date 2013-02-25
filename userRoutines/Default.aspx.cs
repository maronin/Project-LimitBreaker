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
    ui_uc_DeleteModifyRoutine dmr;
    ui_uc_ucCreateRoutineLog crl;
    ui_uc_ucModifyDeleteRoutineLog mdrl;
    MultiView mvRoutines;
    Panel pnlButtons;
    Button btnBack;
    RadioButtonList rblRoutines;

    protected void Page_Load(object sender, EventArgs e)
    {
        manager = new routineManager();
        authenticated = System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
        currentUser = authenticated ? HttpContext.Current.User.Identity.Name : "";
        if (authenticated)
        {
            cnr = LoginView1.FindControl("CreateNewRoutine") as ui_uc_CreateNewRoutine;
            dmr = LoginView1.FindControl("DeleteModifyRoutine") as ui_uc_DeleteModifyRoutine;
            crl = LoginView1.FindControl("ucCreateRoutineLog") as ui_uc_ucCreateRoutineLog;
            mdrl = LoginView1.FindControl("ucModifyDeleteRoutineLog") as ui_uc_ucModifyDeleteRoutineLog;
            mvRoutines = LoginView1.FindControl("mvRoutine") as MultiView;
            pnlButtons = LoginView1.FindControl("pnlButtons") as Panel;
            btnBack = LoginView1.FindControl("btnBack") as Button;
            rblRoutines = LoginView1.FindControl("rblRoutines") as RadioButtonList;

        }
        if (!IsPostBack)
        {
            if (authenticated)
            {
                pnlButtons.Visible = true;
                btnBack.Visible = false;
            }
        }

        if (authenticated && cnr != null)
        {
            cnr.userID = manager.getUserID(currentUser);
        }
        if (authenticated && dmr != null)
        {
            dmr.userID = manager.getUserID(currentUser);
        }
        if (authenticated && crl != null)
        {
            crl.userID = manager.getUserID(currentUser);
        }
        if (authenticated && mdrl != null)
        {
            mdrl.userID = manager.getUserID(currentUser);
        }

    }
    protected void btnModifyRoutines_Click(object sender, EventArgs e)
    {
        mvRoutines.ActiveViewIndex = 0;
        pnlButtons.Visible = false;
        btnBack.Visible = true;
    }
    protected void btnCreateRoutines_Click(object sender, EventArgs e)
    {
        mvRoutines.ActiveViewIndex = 1;
        pnlButtons.Visible = false;
        btnBack.Visible = true;
    }
    protected void btnViewLogs_Click(object sender, EventArgs e)
    {
        mvRoutines.ActiveViewIndex = 2;
        pnlButtons.Visible = false;
        btnBack.Visible = true;
    }
    protected void btnCreateLogs_Click(object sender, EventArgs e)
    {
        mvRoutines.ActiveViewIndex = 3;
        pnlButtons.Visible = false;
        btnBack.Visible = true;
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        /*
        mvRoutines.ActiveViewIndex = -1;
        pnlButtons.Visible = true;
        btnBack.Visible = false;
         * */
        Response.Redirect(Request.RawUrl);
    }
}