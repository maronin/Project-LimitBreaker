using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for abstractClass
/// </summary>
public abstract class ViewScheduledItemsTemplate
{
    public abstract ICollection<ScheduledRoutine> getByDay(ICollection<ScheduledRoutine> r, DateTime day, int userID);
    public abstract ICollection<ScheduledRoutine> getByDayOfYear(ICollection<ScheduledRoutine> r, DateTime day, int userID);
    public abstract ICollection<ScheduledRoutine> getItemsForMonth(ICollection<ScheduledRoutine> r, DateTime day, int userID);
    
    //Overloaded exercise methods
    public abstract ICollection<ScheduledExercise> getByDay(ICollection<ScheduledExercise> r, DateTime day, int userID);
    public abstract ICollection<ScheduledExercise> getByDayOfYear(ICollection<ScheduledExercise> r, DateTime day, int userID);
    public abstract ICollection<ScheduledExercise> getItemsForMonth(ICollection<ScheduledExercise> r, DateTime day, int userID);
   
    public List<scheduledItem> getScheduledItems(Int32 userID, DateTime day)
    {
        using (var context = new Layer2Container())
        {
            List<scheduledItem> exercises = new List<scheduledItem>();
            List<scheduledItem> routines = new List<scheduledItem>();
            ICollection<ScheduledRoutine> allRoutines = context.ScheduledRoutines.Where(r => r.LimitBreaker.id == userID).ToList();
            ICollection<ScheduledExercise> allExercises = context.ScheduledExercises.Where(e => e.LimitBreakers.id == userID).ToList();

            //routines
            allRoutines = getByDay(allRoutines, day, userID);
            allRoutines = getByDayOfYear(allRoutines, day, userID);
            allRoutines = getItemsForMonth(allRoutines, day, userID);

            //exercises
            allExercises = getByDay(allExercises, day, userID);
            allExercises = getByDayOfYear(allExercises, day, userID);
            allExercises = getItemsForMonth(allExercises, day, userID);

            foreach (var item in allRoutines)
            {
                scheduledItem r = new scheduledItem();
                r.itemName = "[R]" + item.Routine.name;
                r.startTime = item.startTime;
                r.user = item.LimitBreaker;
                r.id = item.id;
                r.description = "None";
                r.isExericse = false;
                r.enabled = true;
                routines.Add(r);
            }   

            foreach (var item in allExercises)
            {
                scheduledItem e = new scheduledItem();
                e.itemName = "[E]" + item.Exercise.name;
                e.startTime = item.startTime;
                e.user = item.LimitBreakers;
                e.id = item.id;
                e.description = item.Exercise.description;
                e.isExericse = true;
                e.enabled = item.Exercise.enabled;
                exercises.Add(e);
            }

            var items = routines.Concat(exercises).ToList();

            return items.ToList();
        }
    }
}