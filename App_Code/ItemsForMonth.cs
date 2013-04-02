using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for getItemsForMonth
/// </summary>
public class ItemsForMonth : abstractClass
{
	public ItemsForMonth()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public override bool getByDay(ScheduledRoutine r, DateTime day)
    {
        //nothing
        return false;
    }

    public override bool getByDayOfYear(ScheduledRoutine r, DateTime day)
    {
        //nothing
        return false;
    }

    public override bool getItemsForMonth(ScheduledRoutine r, DateTime day)
    {
        return r.startTime.Month == day.Month && r.startTime.Year == day.Year;
    }

}