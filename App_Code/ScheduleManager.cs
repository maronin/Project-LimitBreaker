using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ScheduleManager
/// </summary>
public class ScheduleManager
{
    public ScheduleManager()
    {

    }

    public List<ScheduledRoutine> getRoutines()
    {
        using (var context = new Layer2Container())
        {
            return context.ScheduledRoutines.OrderBy(o => o.startTime).ToList();
        }
    }

    public List<scheduledItem> getScheduledItems()
    {
        using (var context = new Layer2Container())
        {
            var routines = from r in context.ScheduledRoutines
                           orderby r.startTime
                           select new scheduledItem
                           {
                               itemName = r.Routine.name,
                               startTime = r.startTime,
                               user = r.LimitBreaker
                           };
            var exercises = from e in context.ScheduledExercises
                            orderby e.startTime
                            select new scheduledItem
                            {
                                itemName = e.Exercise.name,
                                startTime = e.startTime,
                                user = e.LimitBreakers
                            };
            var items = routines.Concat(exercises).ToList();

            return items.ToList();
        }
    }




}