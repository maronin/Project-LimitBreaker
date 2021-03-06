﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Text;
using System.Drawing;
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
    protected void Page_Load(object sender, EventArgs e)
    {
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

            
            if (!IsPostBack)
            {
                MultiView multiViewCalendar = (MultiView)LoginView1.FindControl("multiViewCalendar");
                multiViewCalendar.ActiveViewIndex = 0;
                loadMonths();
                loadYears();
                loadCalendar();
                populateUserRoutines();
                exercises.ForeColor = Color.DarkViolet;
                routines.ForeColor = Color.Red;
            }
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

        lnk_dayLink.CssClass = "date";

        routine = scheduleManager.getRoutines();

        foreach (scheduledItem item in items)
        {
            if (item.startTime.ToString("MMMM dd, yyyy") == dt.ToString("MMMM dd, yyyy"))
            {
                if (item.isExericse)
                {
                    lbl.Font.Size = 12;
                    lbl.Text = lbl.Text + "<span style=\"color: DarkViolet\"><b>" + item.itemName + "</b>" + "<br/> Starts at: " + item.startTime.ToString("hh:mm tt") + "<br/></span>";
                }
                else
                {
                    lbl.Font.Size = 12;
                    lbl.Text = lbl.Text + "<span style=\"color: Red\"><b>" + item.itemName + "</b>" + "<br/> Starts at: " + item.startTime.ToString("hh:mm tt") + "<br/></span>";
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

    protected void loadCalendar()
    {
        Int16 m = Convert.ToInt16(ddl_month.SelectedItem.Value);
        Int16 y = Convert.ToInt16(ddl_year.SelectedItem.Value);
        List<DateTime> dates = new List<DateTime>();
        List<String> empty = new List<String>();
        DateTime dateValue = new DateTime(Convert.ToInt32(ddl_year.SelectedValue), Convert.ToInt32(ddl_month.SelectedValue), 1);
        int sunday = Convert.ToInt32(DayOfWeek.Sunday) + 1;
        int currentDay = Convert.ToInt32(dateValue.DayOfWeek) + 1;
        int difference = currentDay - sunday;

        if (dateValue.DayOfWeek == DayOfWeek.Sunday)
        {
            for (int i = 1; i < System.DateTime.DaysInMonth(y, m) + 1; i++)
            {
                DateTime d = new DateTime(y, m, i);
                dates.Add(d);
            }
            rpt_calendar.DataSource = dates;
            rpt_calendar.DataBind();
        }

        if (dateValue.DayOfWeek != DayOfWeek.Sunday)
        {

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

        }
        lblToday.Text = ddl_month.SelectedItem.Text + " " + ddl_year.Text;

    }

    protected void ItemCommand(Object Sender, RepeaterCommandEventArgs e)
    {
        if (((LinkButton)e.CommandSource).Text == "Add Item")
        {

            multiViewCalendar.ActiveViewIndex = 1;
            addItemView.ActiveViewIndex = 0;
        }
        /*
         * Unfinished, when user clicks on any of the dates
                else
                {
                    lblTest.Text = ((LinkButton)e.CommandSource).Text;
                    multiViewCalendar.ActiveViewIndex = 1;
                    addItemView.ActiveViewIndex = 0;
                }
          */
    }


    protected void addExercise_Click(object sender, EventArgs e)
    {
        addItemView.ActiveViewIndex = 1;
    }

    protected void addRoutine_Click(object sender, EventArgs e)
    {
        addItemView.ActiveViewIndex = 3;

    }

    protected void btnScheduleRoutine_Click(object sender, EventArgs e)
    {
        if (scheduleManager.scheduleNewRoutine(Convert.ToInt32(ddlRoutines.SelectedValue),
            Convert.ToDateTime(
            tbDate_routine.Text + " " + ddlHours_routine.Text + ":" + ddlMinutes_routine.Text + ":00 " + ddlAmPm_routine.Text), Convert.ToInt32(userID), false))
        {
            addNewItem = true;
            lblResult_Routine.Text = "Successfuly scheduled your routine!";
        }
        else
            lblResult_Routine.Text = "Scheduled items can't be within 1 hour of each other! Please choose a different time or date";

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


    protected void btnScheduleExercise_Click(object sender, EventArgs e)
    {
        if (scheduleManager.scheduleNewExercise(Convert.ToInt32(dllExercises.SelectedValue), Convert.ToDateTime(/*calDate.SelectedDate.ToString("d") + " " + ddlHours.Text + ":" + ddlMinutes.Text + ":00 " + ddlAmPm.Text*/ tbDate_exercise.Text + " " + ddlHours_exercise.Text + ":" + ddlMinutes_exercise.Text + ":00 " + ddlAmPm_exercise.Text), Convert.ToInt32(userID), false))
        {
            addNewItem = true;
            lblResult_Exercise.Text = "Successfuly scheduled your routine!";
        }
        else
            lblResult_Exercise.Text = "Scheduled items can't be within 1 hour of each other! Please choose a different time or date";

    }
    protected void goBack_Click(object sender, EventArgs e)
    {
        //if a new item has been added, reset all the fields, refresh the calendar and go back to the calendar
        if (addNewItem)
        {
            addNewItem = false;
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
            Response.Redirect("~/WorkoutSchedule/default.aspx");

        }

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
}