using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ItemsByDayOfYear
/// </summary>
public class ItemsByDayOfYear : ViewScheduledItemsTemplate
{
	public ItemsByDayOfYear()
	{
	}

    public override ICollection<ScheduledRoutine> getByDay(ICollection<ScheduledRoutine> r, DateTime day, int userID)
    {
        //return the same thing i.e do nothing with it
        return r;
    }

    public override ICollection<ScheduledRoutine> getByDayOfYear(ICollection<ScheduledRoutine> r, DateTime day, int userID)
    {
        return r.Where(x => x.startTime.Day == day.Day && x.startTime.Month == day.Month && x.startTime.Year == day.Year).ToList();
    }

    public override ICollection<ScheduledRoutine> getItemsForMonth(ICollection<ScheduledRoutine> r, DateTime day, int userID)
    {
        //return the same thing i.e do nothing with it
        return r;
    }

    public override ICollection<ScheduledExercise> getByDay(ICollection<ScheduledExercise> r, DateTime day, int userID)
    {
        //return the same thing i.e do nothing with it
        return r;
    }

    public override ICollection<ScheduledExercise> getByDayOfYear(ICollection<ScheduledExercise> r, DateTime day, int userID)
    {
        
        return r.Where(x => x.startTime.Day == day.Day && x.startTime.Month == day.Month && x.startTime.Year == day.Year).ToList();
    }

    public override ICollection<ScheduledExercise> getItemsForMonth(ICollection<ScheduledExercise> r, DateTime day, int userID)
    {
        //return the same thing i.e do nothing with it
        return r;
    }
}