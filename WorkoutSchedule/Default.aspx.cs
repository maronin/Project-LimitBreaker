using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Text;
using System.Drawing;
using System.Web.UI.HtmlControls;
public partial class WorkoutSchedule_Default4 : System.Web.UI.Page
{
    ScheduleManager scheduleManager = new ScheduleManager();
    ExerciseManager exerciseManager = new ExerciseManager();
    routineManager routineManager = new routineManager();
    bool atlernatingColor = true;
    static bool addNewItem = false;
    String currentUser;
    bool authenticated;
    UserManager userManager = new UserManager();
    static int userID;
    static DateTime itemScheduledOn;
    static bool modifyExercise;
    static Int32 modifyItemID;
    static string endsOnAfterValue = "";
    static List<scheduledItem> schdledItems;
    protected void Page_Load(object sender, EventArgs e)
    {
        HtmlGenericControl li = (HtmlGenericControl)this.Page.Master.FindControl("Ulnav").FindControl("liWorkoutSchedule");
        li.Attributes.Add("class", "active");

        Page.MaintainScrollPositionOnPostBack = true;
        authenticated = System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
        currentUser = authenticated ? HttpContext.Current.User.Identity.Name : "";
        userID = userManager.getUserID(currentUser);

        if (authenticated && userID != -1)
        {
            DropDownList ddlRoutines = (DropDownList)LoginView1.FindControl("ddlRoutines");
            if (ddlRoutines.Items.Count == 0)
            {
                lnkNotHaveRoutines.Visible = true;
                ddlRoutines.Visible = false;
                tbDate_routine.Enabled = false;
            }
            else
            {
                lnkNotHaveRoutines.Visible = false;
                ddlRoutines.Visible = true;
                tbDate_routine.Enabled = true;
            }

            viewExercises.userControlEventHappened += new EventHandler(viewExercises_userControlEventHappened);
            if (!IsPostBack)
            {
                MultiView multiViewCalendar = (MultiView)LoginView1.FindControl("multiViewCalendar");
                multiViewCalendar.ActiveViewIndex = 0;
                loadMonths();
                loadYears();
                loadCalendar();
                populateUserRoutines();
                exercises.ForeColor = Color.CornflowerBlue;
                routines.ForeColor = Color.MediumBlue;
                //populateExerciseInfo();
                populateRepeatEveryList();

            }



        }


    }
    private void viewExercises_userControlEventHappened(object sender, EventArgs e)
    {
        if (viewExercises.ddlCount == 0)
        {
            TimeSelectPanel.Visible = false;
        }
        else
        {
            TimeSelectPanel.Visible = true;
        }
    }

    protected void loadMonths()
    {
        ddl_month.ClearSelection();
        ddl_month.Items.Clear();
        for (int i = 1; i <= 12; i++)
        {
            ListItem li = new ListItem();
            li.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i);
            li.Value = i.ToString();
            ddl_month.Items.Add(li);
            if (li.Value == DateTime.Now.Month.ToString())
            {
                li.Selected = true;

            }
        }
    }
    protected void loadYears()
    {
        ddl_year.ClearSelection();
        ddl_year.Items.Clear();
        int yearsBack = 3;
        int yearsForward = 3;
        for (int i = DateTime.Now.AddYears(-yearsBack).Year; i <= DateTime.Now.AddYears(yearsForward).Year; i++)
        {
            ListItem li = new ListItem();
            li.Text = i.ToString();
            li.Value = i.ToString();
            ddl_year.Items.Add(li);
            if (li.Value == DateTime.Now.Year.ToString())
                li.Selected = true;
        }
    }
    protected void rpt_calendar_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
    {
        //find the controls
        Panel pnl_calendarDay = (Panel)e.Item.FindControl("pnl_calendarDay");
        LinkButton lnk_dayLink = (LinkButton)e.Item.FindControl("lnk_dayLink");
        Literal ltl_dayEvents = (Literal)e.Item.FindControl("ltl_dayEvents");
        Literal lineBreak = (Literal)e.Item.FindControl("lineBreak");
        //set values
        DateTime dt = (DateTime)e.Item.DataItem;
        //Here we set the day value for each day entry within the calendar
        StringBuilder sb = new StringBuilder();
        sb.Append(dt.Day.ToString());
        sb.Append(" ");
        //sb.Append(dt.ToString("d")); //' gets the day name based on the users computer settings (their local day name rather than English default)

        lnk_dayLink.Text = sb.ToString();
        lnk_dayLink.CommandArgument = dt.ToString();
        //Check to see if we have any dates matching today
        Label lbl = (Label)e.Item.FindControl("lbl_dayEvents");

        List<ScheduledRoutine> routine;
        List<scheduledItem> items;

        items = scheduleManager.getScheduledItemsByDay(userID, dt);
        if (atlernatingColor)
        {
            //pnl_calendarDay.BackColor = Color.Azure;
            atlernatingColor = false;
        }
        else
        {
            //pnl_calendarDay.BackColor = Color.LightCyan;
            atlernatingColor = true;

        }

        if (dt.Date == DateTime.Today)
        {
            pnl_calendarDay.BackColor = Color.Gainsboro;

        }

        if (dt.DayOfWeek == DayOfWeek.Saturday)
        {
            rpt_calendar.Controls.Add(new LiteralControl("<br class=\"newWeek\"></>"));
        }
        
        
        
        lnk_dayLink.CssClass = "date";

        routine = scheduleManager.getRoutines();

        foreach (scheduledItem item in items)
        {
            if (item.startTime.ToString("MMMM dd, yyyy") == dt.ToString("MMMM dd, yyyy"))
            {
                if (item.isExericse)
                {
                    lbl.Font.Size = 12;
                    lbl.Text = lbl.Text + "<span class=\"CalendarItemsSpanExercises\"><b>" + item.itemName + "</b>" + "<br/> Starts at: " + item.startTime.ToString("hh:mm tt") + "<br/></span>";
                }
                else
                {

                    lbl.Font.Size = 12;
                    lbl.Text = lbl.Text + "<span class=\"CalendarItemsSpanRoutines\"><b>" + item.itemName + "</b>" + "<br/> Starts at: " + item.startTime.ToString("hh:mm tt") + "<br/></span>";
                }
            }
        }



    }


    protected void rpt_emptyDates_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
    {
        //find the controls
        Panel pnl_calendarDay = (Panel)e.Item.FindControl("pnl_emptyDate");
        Label lblEmpty = (Label)e.Item.FindControl("lblEmpty");
        //Here we set the day value for each day entry within the calendar
        StringBuilder sb = new StringBuilder();
        sb.Append(" ");
        lblEmpty.Text = sb.ToString();
        pnl_calendarDay.BackColor = Color.Ivory;
    }

    protected void lnk_loadCalendar_Click(object sender, EventArgs e)
    {
        loadCalendar();
    }

    protected void nextMonth(object sender, EventArgs e)
    {
        Int16 m = Convert.ToInt16(ddl_month.SelectedIndex);
        if (m < 11)
            ddl_month.SelectedIndex = m + 1;

        else
        {
            Int16 y = Convert.ToInt16(ddl_year.SelectedIndex);
            ddl_year.SelectedIndex = y + 1;
            ddl_month.SelectedIndex = 0;

        }


        loadCalendar();
    }

    protected void prevMonth(object sender, EventArgs e)
    {
        Int16 m = Convert.ToInt16(ddl_month.SelectedIndex);
        if (m > 0)
            ddl_month.SelectedIndex = m - 1;

        else
        {
            Int16 y = Convert.ToInt16(ddl_year.SelectedIndex);
            ddl_year.SelectedIndex = y - 1;
            ddl_month.SelectedIndex = 11;
        }


        loadCalendar();
    }

    protected void today(object sender, EventArgs e)
    {
        DateTime today = DateTime.Today;

        loadMonths();
        loadYears();
        loadCalendar();
    }

    public static DateTime LastSunday(DateTime validDate)
    {
        Int32 daysInThisMonth = DateTime.DaysInMonth(validDate.Year, validDate.Month);
        DateTime lastDayOfMonth = new DateTime(validDate.Year, validDate.Month, daysInThisMonth);
        Int32 dayValue = (Int32)lastDayOfMonth.DayOfWeek;
        return lastDayOfMonth.AddDays(-1 * dayValue);
    }

    protected void loadCalendar()
    {
        Int16 m = Convert.ToInt16(ddl_month.SelectedItem.Value);
        Int16 y = Convert.ToInt16(ddl_year.SelectedItem.Value);
        List<DateTime> dates = new List<DateTime>();
        List<String> empty = new List<String>();
        DateTime dateValue = new DateTime(Convert.ToInt32(ddl_year.SelectedValue), Convert.ToInt32(ddl_month.SelectedValue), 1);

        int sunday = Convert.ToInt32(DayOfWeek.Sunday) + 1;
        int currentDay = Convert.ToInt32(dateValue.DayOfWeek) + 1;


        DateTime lastSunday = LastSunday(new DateTime(Convert.ToInt32(ddl_year.SelectedValue), Convert.ToInt32(ddl_month.SelectedValue), 1).AddMonths(-1).AddDays(0));
        DateTime lastDayOfMonth = new DateTime(Convert.ToInt32(ddl_year.SelectedValue), Convert.ToInt32(ddl_month.SelectedValue), 1).AddMonths(0).AddDays(-1);


        int difference = (lastDayOfMonth - lastSunday).Days + 1;

        for (int i = 0; i < difference; i++)
        {
            String e = "";
            empty.Add(e);
        }

        rpt_emptyDates.DataSource = empty;
        rpt_emptyDates.DataBind();

        for (int i = 1; i < System.DateTime.DaysInMonth(y, m) + 1; i++)
        {
            DateTime d = new DateTime(y, m, i);
            dates.Add(d);
        }

        rpt_calendar.DataSource = dates;

        rpt_calendar.DataBind();


        lblToday.Text = ddl_month.SelectedItem.Text + " " + ddl_year.Text;

    }

    protected void ItemCommand(Object Sender, RepeaterCommandEventArgs e)
    {
        if (((LinkButton)e.CommandSource).Text == "Add Item")
        {

            multiViewCalendar.ActiveViewIndex = 1;
            addItemView.ActiveViewIndex = 0;
        }
        else
        {
            // multiViewCalendar.ActiveViewIndex = 1;
            //addItemView.ActiveViewIndex = 0;

            List<scheduledItem> items;
            itemScheduledOn = Convert.ToDateTime(ddl_month.SelectedValue + "/" + ((LinkButton)e.CommandSource).Text.Trim() + "/" + ddl_year.SelectedValue);
            items = scheduleManager.getScheduledItemsByDayOfYear(userID, itemScheduledOn);
            GridViewScheduledItems.DataSource = items;
            GridViewScheduledItems.DataBind();
            multiViewCalendar.ActiveViewIndex = 2;
            tbRemoveDate.Text = itemScheduledOn.ToString("M/dd/yyyy");
        }
        if (GridViewScheduledItems.Rows.Count == 0)
        {
            lblRemoveResult.Visible = true;
            lnkRemoveAll.Visible = false;
        }
        else
        {
            lblRemoveResult.Visible = false;
            lnkRemoveAll.Visible = true;
        }

    }


    protected void addExercise_Click(object sender, EventArgs e)
    {
        addItemView.ActiveViewIndex = 1;

    }

    protected void addRoutine_Click(object sender, EventArgs e)
    {
        addItemView.ActiveViewIndex = 2;

    }

    protected void btnScheduleRoutine_Click(object sender, EventArgs e)
    {
        List<string> selectedDaysOfWeek = new List<string>();
        for (int i = 0; i < cblDayOfWeek.Items.Count; i++)
        {
            if (cblDayOfWeek.Items[i].Selected)
            {
                selectedDaysOfWeek.Add(cblDayOfWeek.Items[i].Value);
            }
        }

        if (scheduleManager.scheduleNewRoutine(Convert.ToInt32(ddlRoutines.SelectedValue),
            Convert.ToDateTime(
            tbDate_routine.Text + " " + ddlHours_routine.Text + ":" + ddlMinutes_routine.Text + ":00 " + ddlAmPm_routine.Text), Convert.ToInt32(userID), false, 
            cbRepeatRoutine.Checked,
            ddlRepeatType.SelectedItem.Text,
            Convert.ToInt32(ddlRepeatEvery.SelectedItem.Text),
            endsOnAfterValue,
            rblEnd.SelectedItem.Text,
            selectedDaysOfWeek))
        {
            addNewItem = true;
            clearScheduleForm();
            lblResult_Routine.Text = "Successfuly scheduled your routine!";
        }
        else
            lblResult_Routine.Text = "Did not schedule anything";

    }
    /*
    //Routine
    protected void calendar_selectionChanged_routine(object sender, EventArgs e)
    {
        tbDate_routine.Text = calDateRoutine.SelectedDate.ToString("d") + " " + ddlHours_routine.SelectedItem.Text + ":" + ddlMinutes_routine.SelectedItem.Text + ":00 " + ddlAmPm_routine.SelectedItem.Text;

    }


    //Exericse
    protected void calendar_selectionChanged_exercise(object sender, EventArgs e)
    {
        tbDate_exercise.Text = calDateExercise.SelectedDate.ToString("d") + " " + dllHours_exercise.SelectedItem.Text + ":" + ddlMinutes_exercise.SelectedItem.Text + ":00 " + ddlAmPm_exericse.SelectedItem.Text;

    }

    protected void calDateExercise_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
    {

    }*/



    protected void lnk_add_item_Click(object sender, EventArgs e)
    {
        multiViewCalendar.ActiveViewIndex = 1;
        addItemView.ActiveViewIndex = 0;
    }

    protected void lnk_remove_item_Click(object sender, EventArgs e)
    {
        multiViewCalendar.ActiveViewIndex = 2;
        GridViewScheduledItems.Visible = true;
        tbRemoveDate.Text = "";
    }

    //Schedule a new exercise
    protected void btnScheduleExercise_Click(object sender, EventArgs e)
    {
        List<string> selectedDaysOfWeek = new List<string>();
        for (int i = 0; i < cblDayOfWeek.Items.Count; i++)
        {
            if (cblDayOfWeek.Items[i].Selected)
            {
                selectedDaysOfWeek.Add(cblDayOfWeek.Items[i].Value);
            }
        }

        if (
            scheduleManager.scheduleNewExercise
            (viewExercises.ddlSelectedValue,
            Convert.ToDateTime(tbDate_exercise.Text + " " + ddlHours_exercise.Text + ":" + ddlMinutes_exercise.Text + ":00 " + ddlAmPm_exercise.Text),
            Convert.ToInt32(userID),
            false,
            cbRepeatExercise.Checked,
            ddlRepeatType.SelectedItem.Text,
            Convert.ToInt32(ddlRepeatEvery.SelectedItem.Text),
            endsOnAfterValue,
            rblEnd.SelectedItem.Text,
            selectedDaysOfWeek)
            )
        {
            addNewItem = true;
            clearScheduleForm();
            lblResult_Exercise.Text = "Successfully scheduled your exercise!";

        }
        else
            lblResult_Exercise.Text = "Scheduled items can't be within 1 hour of each other! Please choose a different time or date";

    }

    protected void clearScheduleForm()
    {
        ddlMinutes_exercise.SelectedIndex = 0;
        ddlHours_exercise.SelectedIndex = 0;
        ddlAmPm_exercise.SelectedIndex = 0;
        ddlMinutes_routine.SelectedIndex = 0;
        ddlHours_routine.SelectedIndex = 0;
        ddlAmPm_routine.SelectedIndex = 0;
        tbDate_exercise.Text = "";
        tbDate_routine.Text = "";
        lblResult_Exercise.Text = "";
        lblResult_Routine.Text = "";
        if (addItemView.ActiveViewIndex == 1)
        {
            cbRepeatExercise.Checked = false;
            cbRepeatExercise.Enabled = false;
            lnkEditRepeatExercise.Visible = false;
        }
        else if (addItemView.ActiveViewIndex == 2)
        {
            cbRepeatRoutine.Checked = false;
            cbRepeatRoutine.Enabled = false;
            lnkEditRepeatRoutine.Visible = false;
        }

    }

    protected void goBack_Click(object sender, EventArgs e)
    {

        //if a new item has been added, reset all the fields, refresh the calendar and go back to the calendar
        if (addNewItem)
        {
            addNewItem = false;
            clearScheduleForm();


        }
        Response.Redirect("~/WorkoutSchedule/default.aspx");
        multiViewCalendar.ActiveViewIndex = 0;
        addItemView.ActiveViewIndex = 0;


    }

    protected void populateUserRoutines()
    {
        ddlRoutines.DataSource = routineManager.getUsersRoutines(userID);
        ddlRoutines.DataBind();
    }

    protected void changeToRoutine(object sender, EventArgs e)
    {
        Response.Redirect("~/userRoutines/Default.aspx");
    }

    /*protected void populateExerciseInfo()
    {
        lblExerciseEquipment.Text = "";
        lblExerciseMuscleGroups.Text = "";
        lblExerciseVideo.Text = "[Video]";
        if (ddlExercises.SelectedValue != "NONE")
        {
            Exercise exercise = exerciseManager.getExerciseById(Convert.ToInt32(ddlExercises.SelectedValue));
            lblExerciseEquipment.Text = exercise.equipment;

            if (exercise.description == null)
            {
                lblExerciseDescription.Text = "None";
            }
            else
            {
                lblExerciseDescription.Text = exercise.description;
            }



            lblExerciseVideo.NavigateUrl = exercise.videoLink;


            String[] muscles = exerciseManager.splitMuscleGroups(exercise.muscleGroups);


            foreach (var item in muscles)
            {
                if (item != "")
                    lblExerciseMuscleGroups.Text += "- " + item + "<br/>";
            }
        }
        else
        {
            lblExerciseEquipment.Text = "";
            lblExerciseMuscleGroups.Text = "";
            lblExerciseVideo.Text = "";
            lblExerciseDescription.Text = "";
        }
    }
    */
    // protected void dllExercises_SelectedIndexChanged(object sender, EventArgs e)
    // {
    //     populateExerciseInfo();

    //  }



    HttpResponse response = System.Web.HttpContext.Current.Response;

    protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        e.ExceptionHandled = true;
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ';' });
        modifyExercise = Convert.ToBoolean(commandArgs[1]);
        modifyItemID = Convert.ToInt32(commandArgs[0]);
        if (e.CommandName == "del")
        {

            if (scheduleManager.deletecheduledItem(Convert.ToInt32(commandArgs[0]), Convert.ToBoolean(commandArgs[1]), userID))
            {
                lblResultModify.Text = "Removed your item!";
                pnlModifyItem.Visible = false;
                populateRemoveItems();
            }

            else
                lblResultModify.Text = "Somthing went worng!";

        }

        if (e.CommandName == "modify")
        {
            lblMuscleGroupsModify.Text = "";
            pnlModifyItem.Visible = true;
            btnModify.Visible = true;
            ddlModifyItems.Visible = true;
            lblEquipmentModify.Visible = true;
            pnlEquipmentMuscle.Visible = true;

            scheduledItem selectedItem = scheduleManager.getScheduledItemByID(modifyItemID, modifyExercise);
            DateTime itemStartTime = selectedItem.startTime;

            //User selected a scheduled Exercise
            if (Convert.ToBoolean(commandArgs[1]))
            {
                Exercise exercise = exerciseManager.getExerciseByScheduledItem(Convert.ToInt32(modifyItemID));
                ddlModifyItems.DataSource = exerciseManager.getExercises();
                ddlModifyItems.DataBind();
                lblEquipmentModify.Text = exercise.equipment;
                if (exercise != null)
                    if (exercise.description != null)
                        lblDescriptionModify.Text = exercise.description;
                    else
                    {
                        lblDescriptionModify.Text = "None";
                    }


                String[] muscles = exerciseManager.splitMuscleGroups(exercise.muscleGroups);
                foreach (var item in muscles)
                {
                    if (item != "")
                        lblMuscleGroupsModify.Text += "- " + item + "<br/>";
                }
                //lblDescriptionModify.Text = itemStartTime.Date.ToString("MM/dd/yyyy");

            }

            //User selected a scheduled Routine
            else
            {
                Routine routine = routineManager.getRoutine(Convert.ToInt32(commandArgs[0]));
                ddlModifyItems.DataSource = routineManager.getUsersRoutines(userID);
                ddlModifyItems.DataBind();
                lblEquipmentModify.Visible = false;
                pnlEquipmentMuscle.Visible = false;
                lblDescriptionModify.Text = "";
            }


            tbDateModify.Text = itemStartTime.Date.ToString("MM/dd/yyyy");
            for (int i = 0; i < ddlModifyItems.Items.Count; i++)
            {
                if (ddlModifyItems.Items[i].Text == selectedItem.itemName)
                {
                    ddlModifyItems.SelectedIndex = i;
                    break;
                }
            }



            //Select the dropdownlist for Hour based on the selected item
            for (int i = 0; i < ddlHoursModify.Items.Count; i++)
            {
                if (Convert.ToInt32(ddlHoursModify.Items[i].Text) == Convert.ToInt32(itemStartTime.ToString("hh")))
                {
                    ddlHoursModify.SelectedIndex = i;
                    break;
                }
            }
            //Select the dropdownlist for the minute based on the selected item
            for (int i = 0; i < ddlMinutesModify.Items.Count; i++)
            {
                if (Convert.ToInt32(ddlMinutesModify.Items[i].Text) == Convert.ToInt32(itemStartTime.ToString("mm")))
                {
                    ddlMinutesModify.SelectedIndex = i;
                    break;
                }
            }
            //select the dropdownlist for the AM or PM for the selected item
            if (itemStartTime.ToString("tt") == "AM")
            {
                ddlAmPmModify.SelectedIndex = 0;
            }
            else
            {
                ddlAmPmModify.SelectedIndex = 1;
            }
        }


    }
    protected void populateRemoveItems()
    {
        GridViewScheduledItems.DataSource = null;
        GridViewScheduledItems.DataBind();
        if (tbRemoveDate.Text != "")
            schdledItems = scheduleManager.getScheduledItemsByDayOfYear(userID, Convert.ToDateTime(tbRemoveDate.Text));

        else
        {
            itemScheduledOn = Convert.ToDateTime("01/" + ddlRemoveMonth.SelectedItem.Text + "/" + ddl_year.SelectedItem.Text);
            schdledItems = scheduleManager.getScheduledItemsForMonth(userID, itemScheduledOn);
        }
        GridViewScheduledItems.DataSource = schdledItems;
        GridViewScheduledItems.DataBind();

        if (GridViewScheduledItems.Rows.Count == 0)
        {
            lblRemoveResult.Visible = true;
            lnkRemoveAll.Visible = false;
        }
        else
        {
            lblRemoveResult.Visible = false;
            lnkRemoveAll.Visible = true;
        }
    }
    protected void tbRemoveDate_TextChanged(object sender, EventArgs e)
    {
        lblResultModify.Text = "";
        pnlModifyItem.Visible = false;
        btnModify.Visible = false;
        GridViewScheduledItems.Visible = true;

        populateRemoveItems();
    }

    protected void btnModify_Click(object sender, EventArgs e)
    {

        if (scheduleManager.modifyScheduledItem(Convert.ToInt32(modifyItemID), Convert.ToInt32(ddlModifyItems.SelectedValue), modifyExercise, Convert.ToDateTime(Convert.ToDateTime(tbDateModify.Text + " " + ddlHoursModify.Text + ":" + ddlMinutesModify.Text + ":00 " + ddlAmPmModify.Text))))
        {
            lblResultModify.Text = "Successfully modified scheduled item";

        }

        else
        {
            lblResultModify.Text = "Somthing went wrong";
        }
        populateRemoveItems();

    }

    protected void tbDateModify_textChanged(object sender, EventArgs e)
    {
        modifyDateRequired.Validate();
        modifyDateValidator.Validate();

    }

    protected void populateRepeatEveryList()
    {
        ddlRepeatEvery.ClearSelection();
        for (int i = 1; i <= 30; i++)
        {
            ddlRepeatEvery.Items.Add(new ListItem(Convert.ToString(i), Convert.ToString(i)));
        }



    }

    protected void reaptClicked(object sender, EventArgs e)
    {
        if (addItemView.ActiveViewIndex == 1)
        {
            if (cbRepeatExercise.Checked == true)
            {
                pnlRepeatItem.Visible = true;
                pnlDim.Visible = true;
                lnkEditRepeatExercise.Visible = true;
            }
            else
            {
                lnkEditRepeatExercise.Visible = false;
            }

            tbStartsOnDate.Text = tbDate_exercise.Text;
        }
        else if (addItemView.ActiveViewIndex == 2)
        {
            if (cbRepeatRoutine.Checked == true)
            {
                pnlRepeatItem.Visible = true;
                pnlDim.Visible = true;
                lnkEditRepeatRoutine.Visible = true;
            }
            else
            {
                lnkEditRepeatRoutine.Visible = false;
            }

            tbStartsOnDate.Text = tbDate_routine.Text;
        }
    }


    protected void ddlRepeatType_indexChanged(object sender, EventArgs e)
    {

        if (ddlRepeatType.SelectedIndex == 1)
        {
            lblDayType.Text = "weeks";
            repeatOn.Visible = true;
        }

        else if (ddlRepeatType.SelectedIndex == 2)
        {
            lblDayType.Text = "months";
            repeatOn.Visible = false;
        }
        else
        {
            lblDayType.Text = "days";
            repeatOn.Visible = false;
        }

    }

    protected void rblEnd_IndexChanged(object sender, EventArgs e)
    {
        if (rblEnd.SelectedIndex == 0)
        {
            tbEndOnDate.Enabled = false;
            tbEndAfter.Enabled = true;
            btnDoneRepeat.ValidationGroup = "";
        }
        else if (rblEnd.SelectedIndex == 1)
        {
            tbEndAfter.Enabled = false;
            tbEndOnDate.Enabled = true;
            btnDoneRepeat.ValidationGroup = "EndOnRepeat";
        }

    }

    //Done Button
    protected void btnDoneRepeat_Clicked(object sender, EventArgs e)
    {
        pnlDim.Visible = false;
        pnlRepeatItem.Visible = false;

        if (rblEnd.SelectedIndex == 0)
        {
            endsOnAfterValue = tbEndAfter.Text;

        }
        else if (rblEnd.SelectedIndex == 1)
        {

            endsOnAfterValue = tbEndOnDate.Text;
            repeatCalendarValidator.Validate();
            repeatCalendarRequiredValidator.Validate();

        }


    }

    //Cancel Button
    protected void btnCancelRepeat_Clicked(object sender, EventArgs e)
    {
        if (addItemView.ActiveViewIndex == 1)
        {
            pnlDim.Visible = false;
            pnlRepeatItem.Visible = false;
            cbRepeatExercise.Checked = false;
            lnkEditRepeatExercise.Visible = false;
        }
        else if (addItemView.ActiveViewIndex == 2)
        {
            pnlDim.Visible = false;
            pnlRepeatItem.Visible = false;
            cbRepeatRoutine.Checked = false;
            lnkEditRepeatRoutine.Visible = false;
        }
    }
    protected void prevRemoveMonth(object sender, EventArgs e)
    {
        tbRemoveDate.Text = Convert.ToDateTime(tbRemoveDate.Text).AddDays(-1).ToString("MM/dd/yyyy");
    }

    protected void nextRemoveMonth(object sender, EventArgs e)
    {
        tbRemoveDate.Text = Convert.ToDateTime(tbRemoveDate.Text).AddDays(1).ToString("MM/dd/yyyy");
    }


    protected void ddlRemoveMonth_indexChanged(object sender, EventArgs e)
    {

        itemScheduledOn = Convert.ToDateTime("01/" + ddlRemoveMonth.SelectedItem.Text + "/" + ddl_year.SelectedItem.Text);

        schdledItems = scheduleManager.getScheduledItemsForMonth(userID, itemScheduledOn);
        GridViewScheduledItems.DataSource = schdledItems;
        GridViewScheduledItems.DataBind();
        if (GridViewScheduledItems.Rows.Count == 0)
        {
            lblRemoveResult.Visible = true;
            lnkRemoveAll.Visible = false;
        }
        else
        {
            lblRemoveResult.Visible = false;
            lnkRemoveAll.Visible = true;
        }
    }

    protected void lnkRemoveAll_clicked(object sender, EventArgs e)
    {
        scheduleManager.deleteListOfScheduledItems(schdledItems, userID);
        populateRemoveItems();

    }
    protected void tbEndOnDate_checkDate(object sender, EventArgs e)
    {
        validateEndDate();

    }
    protected void tbDate_validate(object sender, EventArgs e)
    {
        validateEndDate();
        if (addItemView.ActiveViewIndex == 1)
        {
            RegularExpressionValidatorExercise.Validate();
            RequiredFieldValidatorExercise.Validate();
            
            if (RegularExpressionValidatorExercise.IsValid && RequiredFieldValidatorExercise.IsValid)
            {
                cbRepeatExercise.Enabled = true;
                lblResult_Exercise.Text = "";
            }
            else
            {
                cbRepeatExercise.Enabled = false;
            }
           
        }
        else if (addItemView.ActiveViewIndex == 2)
        {

            RegularExpressionValidatorRoutine.Validate();
            RequiredFieldValidatorRoutine.Validate();
            
            if (RegularExpressionValidatorRoutine.IsValid && RequiredFieldValidatorRoutine.IsValid)
            {
                cbRepeatRoutine.Enabled = true;
                lblResult_Routine.Text = "";
            }
            else
            {
                cbRepeatRoutine.Enabled = false;
            }

        }

    }

    protected void validateEndDate()
    {
        if (tbStartsOnDate.Text != "" && tbEndOnDate.Text != "")
        {
            DateTime start = Convert.ToDateTime(tbDate_exercise.Text);
            DateTime end = Convert.ToDateTime(tbEndOnDate.Text);

            int difference = (end - start).Days;

            if (difference <= 0)
            {
                tbEndOnDate.Text = tbDate_exercise.Text;
            }
        }
    }

    protected void lnkEditRepeat_EditRepeat(object sender, EventArgs e)
    {
        pnlRepeatItem.Visible = true;
        pnlDim.Visible = true;
    }

}