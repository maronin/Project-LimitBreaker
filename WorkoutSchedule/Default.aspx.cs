using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Text;
public partial class WorkoutSchedule_Default4 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadMonths();
            loadYears();
            loadCalendar();
        }
    }

    protected void loadMonths()
    {
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
        sb.Append(dt.ToString("dddd")); //' gets the day name based on the users computer settings (their local day name rather than English default)
        lnk_dayLink.Text = sb.ToString();
        lnk_dayLink.CommandArgument = dt.ToString();
        //Check to see if we have any dates matching today


    }
    protected void lnk_loadCalendar_Click(object sender, EventArgs e)
    {
        loadCalendar();
    }
    protected void loadCalendar()
    {
        Int16 m = Convert.ToInt16(ddl_month.SelectedItem.Value);
        Int16 y = Convert.ToInt16(ddl_year.SelectedItem.Value);


        List<DateTime> dates = new List<DateTime>();

        for (int i = 1; i < System.DateTime.DaysInMonth(y,m) + 1; i++)
        {
            DateTime d = new DateTime(y, m, i);
            dates.Add(d);
        }
        rpt_calendar.DataSource = dates;
        rpt_calendar.DataBind();

        ddl_month.SelectedItem.Selected = false;
        ddl_year.SelectedItem.Selected = false;
    }



}