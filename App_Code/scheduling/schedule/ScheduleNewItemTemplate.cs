using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ScheduleItemTemplate
/// </summary>
public abstract class ScheduleNewItemTemplate
{
    public abstract void scheduleItem(Exercise item, DateTime start, LimitBreaker lb, bool notification, Layer2Container context);
    public abstract void scheduleItem(Routine item, DateTime start, LimitBreaker lb, bool notification, Layer2Container context);

    public bool scheduleNewItem(Int32 itemID, DateTime start, Int32 userID, bool notification, bool repeat, string repeatInterval, int repeatEvery, string endsOnAfterValue, string onAfter, List<string> selectedDaysOfWeek)
    {
        bool rc = false;

        using (var context = new Layer2Container())
        {
            LimitBreaker lb = context.LimitBreakers.Where(x => x.id == userID).FirstOrDefault();
            if (lb != null)
            {
                Routine routine = context.Routines.Where(e => e.id == itemID).FirstOrDefault();
                Exercise exercise = context.Exercises.Where(e => e.id == itemID).FirstOrDefault();

                if (repeat)
                {
                    //If Daily
                    if (repeatInterval.Trim() == "Daily")
                    {
                        int difference = 0;
                        if (onAfter.Trim() == "After")
                        {
                            difference = Convert.ToInt32(endsOnAfterValue);
                        }
                        if (onAfter.Trim() == "On")
                        {
                            difference = (Convert.ToDateTime(endsOnAfterValue) - start).Days;
                            difference += 2;
                        }

                        for (int i = 0; i < difference; i++)
                        {
                            scheduleItem(routine, start, lb, notification, context);
                            scheduleItem(exercise, start, lb, notification, context);
                            rc = true;
                            start = start.AddDays(repeatEvery);
                        }

                    }

                    //If Weekly
                    else if (repeatInterval.Trim() == "Weekly")
                    {
                        int weeks = 0;
                        int occurances = -1;
                        int occurancesEnd = 0;
                        //if its after certain amount of days
                        if (onAfter.Trim() == "After")
                        {
                            //get the number occurances
                            weeks = occurancesEnd = Convert.ToInt32(endsOnAfterValue);
                            occurances = 0;
                        }
                        if (onAfter.Trim() == "On")
                        {
                            //get he number of occurances
                            weeks = (Convert.ToDateTime(endsOnAfterValue) - start).Days + 1;
                            weeks /= repeatEvery * 7;
                            weeks++;
                        }
                        //go through each week
                        for (int i = 0; i < weeks; i++)
                        {
                            //go through each day of the week
                            for (int k = 0; k < 7; k++)
                            {
                                if (selectedDaysOfWeek.Contains(Convert.ToString((Int32)start.DayOfWeek)) && occurances < occurancesEnd)
                                {
                                    scheduleItem(routine, start, lb, notification, context);
                                    scheduleItem(exercise, start, lb, notification, context);
                                    rc = true;
                                    if (onAfter.Trim() == "After")
                                    {
                                        occurances++;
                                    }
                                }
                                start = start.AddDays(1);
                                //if reached a new week, break out of the for loop and start the new week
                                if (start.DayOfWeek == DayOfWeek.Sunday)
                                {
                                    break;
                                }
                            }
                            // start = start.AddDays(repeatEvery * 7);

                        }
                    }
                    else if (repeatInterval.Trim() == "Monthly")
                    {

                    }
                }

                else
                {
                    scheduleItem(routine, start, lb, notification, context);
                    scheduleItem(exercise, start, lb, notification, context);
                    rc = true;
                }

            }
        }
        return rc;
    }
}