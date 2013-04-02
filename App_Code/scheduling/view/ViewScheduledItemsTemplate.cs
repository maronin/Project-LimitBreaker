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
                scheduledItem newItem = new scheduledItem();
                newItem.itemName = "[R]" + item.Routine.name;
                newItem.startTime = item.startTime;
                newItem.user = item.LimitBreaker;
                newItem.id = item.id;
                newItem.description = "None";
                newItem.isExericse = false;
                routines.Add(newItem);
            }   

            foreach (var item in allExercises)
            {
                scheduledItem newItem = new scheduledItem();
                newItem.itemName = "[E]" + item.Exercise.name;
                newItem.startTime = item.startTime;
                newItem.user = item.LimitBreakers;
                newItem.id = item.id;
                newItem.description = item.Exercise.description;
                newItem.isExericse = true;
                exercises.Add(newItem);
            }

            var items = routines.Concat(exercises).ToList();

            return items.ToList();
        }
    }
}