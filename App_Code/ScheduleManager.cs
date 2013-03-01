using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.IO;

/// <summary>
/// The schedulemanager contains methods which allow to retreive information associated with scheduled items in the database
/// </summary>
public class ScheduleManager
{
    public ScheduleManager()
    {

    }

    /// <summary>
    /// Gets all the routines in the database
    /// </summary>
    /// <returns></returns>
    public List<ScheduledRoutine> getRoutines()
    {
        using (var context = new Layer2Container())
        {
            return context.ScheduledRoutines.OrderBy(o => o.startTime).ToList();
        }
    }

    /// <summary>
    /// Get scheduled items for a specific day
    /// </summary>
    /// <param name="userID">The id of the current user logged</param>
    /// <param name="day">The day to get scheduled items for</param>
    /// <returns>returns a list of scheduled routines and exercises</returns>
    public List<scheduledItem> getScheduledItemsByDay(Int32 userID, DateTime day)
    {
        using (var context = new Layer2Container())
        {
            var ruleDate = Convert.ToDateTime(day).Date;
            var routines = from r in context.ScheduledRoutines
                           orderby r.startTime
                           where (r.LimitBreaker.id == userID && r.startTime.Day == day.Day)
                           select new scheduledItem
                           {
                               itemName = r.Routine.name,
                               startTime = r.startTime,
                               user = r.LimitBreaker,
                               id = r.id,
                               isExericse = false
                           };
            var exercises = from e in context.ScheduledExercises
                            orderby e.startTime
                            where (e.LimitBreakers.id == userID && e.startTime.Day == day.Day)
                            select new scheduledItem
                            {
                                itemName = e.Exercise.name,
                                startTime = e.startTime,
                                user = e.LimitBreakers,
                                id = e.id,
                                isExericse = true
                            };
            var items = routines.Concat(exercises).ToList();

            return items.ToList();
        }
    }
    /// <summary>
    /// Schedule a new routine
    /// </summary>
    /// <param name="routineID">The ID of the routine being scheduled</param>
    /// <param name="start">The start time of the routine being scheduled</param>
    /// <param name="userID">The current user logged in</param>
    /// <param name="notification">If the user wants a notification or not</param>
    /// <returns>Returns true if added a scheduled item, false otherwise</returns>
    public bool scheduleNewRoutine(Int32 routineID, DateTime start, Int32 userID, bool notification)
    {
        bool rc = false;
        using (var context = new Layer2Container())
        {
            LimitBreaker lb = context.LimitBreakers.Where(x => x.id == userID).FirstOrDefault();
            if (lb != null)
            {
                List<scheduledItem> scheduledItemsForThatDay = new List<scheduledItem>();
                ScheduledRoutine newScheduledRoutine = new ScheduledRoutine();

                //This part is for validating if the exercise can be scheduled for a certain time
                /*scheduledItemsForThatDay = getScheduledItemsByDay(userID, start);
                foreach (var item in scheduledItemsForThatDay)
                {
                    if (item != null && start.AddHours(-1) <= item.startTime && start.AddHours(1) >= item.startTime)
                    {
                        return false;
                    }
                }
                */
                Routine routine = context.Routines.Where(e => e.id == routineID).FirstOrDefault();
                newScheduledRoutine.Routine = routine;
                newScheduledRoutine.startTime = start;
                newScheduledRoutine.LimitBreaker = lb;
                newScheduledRoutine.needEmailNotification = notification;
                context.ScheduledRoutines.AddObject(newScheduledRoutine);
                context.SaveChanges();
                rc = true;
            }
            return rc;
        }
    }

    /// <summary>
    /// Schedule a new exercise
    /// </summary>
    /// <param name="exerciseID">The id of the exercise being scheduled</param>
    /// <param name="start">The start time of the exercise being scheduled</param>
    /// <param name="userID">The current user logged in</param>
    /// <param name="notification">If the user wants notification or not</param>
    /// <returns>Returns true if the exercise was scheduled, otherwise false</returns>
    public bool scheduleNewExercise(Int32 exerciseID, DateTime start, Int32 userID, bool notification, bool repeat, string repeatInterval, int repeatEvery, string endsOnAfterValue, string onAfter)
    {
        bool rc = false;

        using (var context = new Layer2Container())
        {

            LimitBreaker lb = context.LimitBreakers.Where(x => x.id == userID).FirstOrDefault();
            if (lb != null)
            {
                List<scheduledItem> scheduledItemsForThatDay = new List<scheduledItem>();
                
                Exercise exercise = context.Exercises.Where(e => e.id == exerciseID).FirstOrDefault();
                //This part is for validating if the exercise can be scheduled for a certain time
                /* scheduledItemsForThatDay = getScheduledItemsByDay(userID, start);
                foreach (var item in scheduledItemsForThatDay)
                {
                    if (item != null && start.AddHours(-1) <= item.startTime && start.AddHours(1) >= item.startTime)
                    {
                        return false;
                    }
                }
                */
                if (repeat)
                {
                    if (repeatInterval.Trim() == "Daily")
                    {
                        if(onAfter.Trim() == "After"){
                            for (int i = 0; i < Convert.ToInt32(endsOnAfterValue); i++)
                            {
                                ScheduledExercise newScheduledExercise = new ScheduledExercise();
                                newScheduledExercise.Exercise = exercise;
                                newScheduledExercise.startTime = start;
                                newScheduledExercise.LimitBreakers = lb;
                                newScheduledExercise.needEmailNotification = notification;
                                context.ScheduledExercises.AddObject(newScheduledExercise);
                                context.SaveChanges();
                                rc = true;
                                start = start.AddDays(repeatEvery);
                            }
                        }
                    }
                    else if (repeatInterval.Trim() == "Weekly")
                    {

                    }
                    else if (repeatInterval.Trim() == "Monthly")
                    {

                    }
                }
                else {
                 ScheduledExercise newScheduledExercise = new ScheduledExercise();
                newScheduledExercise.Exercise = exercise;
                newScheduledExercise.startTime = start;
                newScheduledExercise.LimitBreakers = lb;
                newScheduledExercise.needEmailNotification = notification;
                context.ScheduledExercises.AddObject(newScheduledExercise);
                context.SaveChanges();
                rc = true;
                }
            }
            return rc;
        }
    }
/// <summary>
/// Removes a scheduled from the users schedule
/// </summary>
/// <param name="itemID">The scheduled item ID</param>
/// <param name="isExercise">If its an exercise or a routine</param>
/// <param name="userID">The id of the currently logged in user</param>
/// <returns>Returns true if deleted the scheduled Item</returns>
    public bool deletecheduledItem(Int32 itemID, bool isExercise, Int32 userID)
    {
        bool result = false;
        using (var context = new Layer2Container())
        {
            //Routine rc = new Routine();
            try
            {
                if (isExercise)
                {
                    ScheduledExercise rc = context.ScheduledExercises.Where(e => e.id == itemID).FirstOrDefault();
                    if (rc != null)
                    {
                        context.ScheduledExercises.DeleteObject(rc);
                        context.SaveChanges();
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
                else
                {
                    ScheduledRoutine rc = context.ScheduledRoutines.Where(e => e.id == itemID).FirstOrDefault();
                    if (rc != null)
                    {
                        context.ScheduledRoutines.DeleteObject(rc);
                        context.SaveChanges();
                        result = true;

                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            catch (NullReferenceException e)
            {
                //Console.WriteLine(e.Message + Environment.NewLine + e.StackTrace);
                //// write off the execeptions to my error.log file
                //StreamWriter wrtr = new StreamWriter(System.Web.HttpContext.Current.ApplicationInstance.Server.MapPath("~/assets/documents/" + @"\" + "error.log"), true);

                //wrtr.WriteLine(DateTime.Now.ToString() + " | Error: " + e);

                //wrtr.Close();
            }

        }

        return result;
    }

    /// <summary>
    /// Modify a scheduled item for a user
    /// </summary>
    /// <param name="id">The id of the scheduled item</param>
    /// <param name="newItemID">The id of the new exercise or routine</param>
    /// <param name="isExercise">If its a routine or exercise</param>
    /// <param name="date">The new date to schedule for</param>
    /// <returns>True if modified succesfully</returns>
    public bool modifyScheduledItem(Int32 id, Int32 newItemID, bool isExercise, DateTime date)
    {
        bool result = false;
        using (var context = new Layer2Container())
        {
            try
            {
                if (isExercise)
                {
                    ScheduledExercise rc = context.ScheduledExercises.Where(e => e.id == id).FirstOrDefault();
                    if (rc != null)
                    {
                        rc.Exercise = context.Exercises.Where(e => e.id == newItemID).FirstOrDefault();
                        rc.startTime = date;
                        context.ScheduledExercises.ApplyCurrentValues(rc);
                        context.SaveChanges();
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
                else
                {
                    ScheduledRoutine rc = context.ScheduledRoutines.Where(e => e.id == id).FirstOrDefault();
                    if (rc != null)
                    {
                        rc.Routine = context.Routines.Where(e => e.id == newItemID).FirstOrDefault();
                        rc.startTime = date;
                        context.ScheduledRoutines.ApplyCurrentValues(rc);
                        context.SaveChanges();
                        result = true;

                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message + Environment.NewLine + e.StackTrace);
            }
        }
        return result;
    }

    /// <summary>
    /// Gets the scheduled item based on the id
    /// </summary>
    /// <param name="id">the id of the exercise or routine</param>
    /// <param name="isExercise">if its a routine or exercise</param>
    /// <returns>returns a scheduled item based on the routine</returns>
    public scheduledItem getScheduledItemByID(int id, bool isExercise)
    {
        using (var context = new Layer2Container())
        {
            try
            {
                if (isExercise)
                {

                    var exercise = from e in context.ScheduledExercises
                                   where (e.id == id)
                                   select new scheduledItem
                                   {
                                       itemName = e.Exercise.name,
                                       startTime = e.startTime,
                                       user = e.LimitBreakers,
                                       id = e.id,
                                       isExericse = true
                                   };
                    return exercise.FirstOrDefault();
                }
                else
                {
                    var routine = from r in context.ScheduledRoutines
                                  where (r.id == id)
                                  select new scheduledItem
                                  {
                                      itemName = r.Routine.name,
                                      startTime = r.startTime,
                                      user = r.LimitBreaker,
                                      id = r.id,
                                      isExericse = false
                                  };
                    return routine.FirstOrDefault();

                }
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message + Environment.NewLine + e.StackTrace);
                //// write off the execeptions to my error.log file
                //StreamWriter wrtr = new StreamWriter(System.Web.HttpContext.Current.ApplicationInstance.Server.MapPath("~/assets/documents/" + @"\" + "error.log"), true);

                //wrtr.WriteLine(DateTime.Now.ToString() + " | Error: " + e);

                //wrtr.Close();
                return null;

            }
        }


    }

}