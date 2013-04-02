using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ItemsByDayOfYear
/// </summary>
public class ItemsByDayOfYear : abstractClass
{
	public ItemsByDayOfYear()
	{
	}

    public override bool getByDay(ScheduledRoutine r, DateTime day)
    {
        //nothing
        return false;
    }

    public override bool getByDayOfYear(ScheduledRoutine r, DateTime day)
    {
        return r.startTime.Day == day.Day && r.startTime.Month == day.Month && r.startTime.Year == day.Year;
    }

    public override bool getItemsForMonth(ScheduledRoutine r, DateTime day)
    {
        //nothing
        return false;
    }


}