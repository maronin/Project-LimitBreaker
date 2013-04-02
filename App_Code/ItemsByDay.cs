using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
public class ItemsByDay : abstractClass
{
    public ItemsByDay()
    {

    }

    public override bool getByDay(ScheduledRoutine r, DateTime day)
    {
        return r.startTime.Day == day.Day;
    }

    public override bool getByDayOfYear(ScheduledRoutine r, DateTime day)
    {
        return false;
    }

    public override bool getItemsForMonth(ScheduledRoutine r, DateTime day)
    {
        return false;
    }

}