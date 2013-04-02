using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for abstractClass
/// </summary>
public abstract class abstractClass
{
	public  abstractClass()
	{

	}

    public abstract bool getByDay(ScheduledRoutine r, DateTime day);
    public abstract bool getByDayOfYear(ScheduledRoutine r, DateTime day);
    public abstract bool getItemsForMonth(ScheduledRoutine r, DateTime day);

    public List<scheduledItem> TemaplteMethod(Int32 userID, DateTime day)
    {
        using (var context = new Layer2Container())
        {

            var ruleDate = Convert.ToDateTime(day).Date;
            var routines = from r in context.ScheduledRoutines
                           orderby r.startTime
                           where (r.LimitBreaker.id == userID && r.startTime.Day == day.Day)
                           //where (r.LimitBreaker.id == userID && (getByDay(r, day) || getByDayOfYear(r, day) || getItemsForMonth(r, day)))
                           select new scheduledItem
                           {
                               itemName = "[R] " + r.Routine.name,
                               startTime = r.startTime,
                               user = r.LimitBreaker,
                               id = r.id,
                               description = "None",
                               isExericse = false
                           };
            var exercises = from e in context.ScheduledExercises
                            orderby e.startTime
                            where (e.LimitBreakers.id == userID && e.startTime.Day == day.Day)
                            select new scheduledItem
                            {
                                itemName = "[E] " + e.Exercise.name,
                                startTime = e.startTime,
                                user = e.LimitBreakers,
                                id = e.id,
                                description = e.Exercise.description,
                                isExericse = true
                            };
            var items = routines.Concat(exercises).ToList();

            return items.ToList();
        }
    }
}