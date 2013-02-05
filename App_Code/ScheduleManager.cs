using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
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
                               user = r.LimitBreaker,
                               isExericse = false
                           };
            var exercises = from e in context.ScheduledExercises
                            orderby e.startTime
                            select new scheduledItem
                            {
                                itemName = e.Exercise.name,
                                startTime = e.startTime,
                                user = e.LimitBreakers,
                                isExericse = true
                            };
            var items = routines.Concat(exercises).ToList();

            return items.ToList();
        }
    }

    public bool scheduleNewRoutine(Int32 routineID, DateTime start, Int32 userID, bool notification)
    {
        bool rc = false;

        using (var context = new Layer2Container())
        {

            ScheduledRoutine newScheduledRoutine = new ScheduledRoutine();
            //try
            //{
            LimitBreaker lb = context.LimitBreakers.Where(x => x.id == userID).FirstOrDefault();

            if (lb != null)
            {
                Routine routine = context.Routines.Where(e => e.id == routineID).FirstOrDefault();
               // List<ScheduledRoutine> schRoutines = new List<ScheduledRoutine>();
              //  ScheduledRoutine schRoutine = context.ScheduledRoutines.Where(e => e.id == routineID).FirstOrDefault();
                //check if the item is already scheduled for that day and time
               // if ((schRoutine != null && context.ScheduledExercises.FirstOrDefault(e => e.Exercise.id == routineID).startTime == start))
                //    rc = false;

             //   else
              //  {
                    newScheduledRoutine.Routine = routine;
                    newScheduledRoutine.startTime = start;
                    newScheduledRoutine.LimitBreaker = lb;
                    newScheduledRoutine.needEmailNotification = notification;
                    context.ScheduledRoutines.AddObject(newScheduledRoutine);
                    context.SaveChanges();
                    rc = true;
             //   }

            }
            //}
            /* catch (NullReferenceException e)
             {

                 rc = false;
             }*/
            return rc;
        }
    }

    public bool scheduleNewExercise(Int32 exerciseID, DateTime start, Int32 userID, bool notification)
    {
        bool rc = false;

        using (var context = new Layer2Container())
        {

            ScheduledExercise newScheduledExercise = new ScheduledExercise();
            //try
            //{
            LimitBreaker lb = context.LimitBreakers.Where(x => x.id == userID).FirstOrDefault();

            if (lb != null)
            {
                Exercise exercise = context.Exercises.Where(e => e.id == exerciseID).FirstOrDefault();
                List<ScheduledExercise> schExercises = new List<ScheduledExercise>();
                ScheduledExercise schExercise = context.ScheduledExercises.Where(e => e.id == exerciseID).FirstOrDefault();
                //check if the item is already scheduled for that day and time
               //if ((schExercise != null && context.ScheduledExercises.FirstOrDefault(e => e.Exercise.id == exerciseID).startTime == start))
                   //     rc = false;
              
               // else
               // {
                    newScheduledExercise.Exercise = exercise;
                    newScheduledExercise.startTime = start;
                    newScheduledExercise.LimitBreakers = lb;
                    newScheduledExercise.needEmailNotification = notification;
                    context.ScheduledExercises.AddObject(newScheduledExercise);
                    context.SaveChanges();
                    rc = true;
              //  }
                
            }
            //}
            /* catch (NullReferenceException e)
             {

                 rc = false;
             }*/
            return rc;
        }
    }

    //temp user for testing
    public List<LimitBreaker> getUsers()
    {
        using (var context = new Layer2Container())
        {
            return context.LimitBreakers.OrderBy(o => o.id).ToList();
        }
    }

    public LimitBreaker getUser(int userID)
    {
        using (var context = new Layer2Container())
        {
            context.ContextOptions.LazyLoadingEnabled = false;

            return context.LimitBreakers.FirstOrDefault(x => x.id == userID);

        }
    }
}