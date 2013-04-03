using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class ScheduleNewRoutine : ScheduleNewItemTemplate
{

    public override void scheduleItem(Exercise item, DateTime start, LimitBreaker lb, bool notification, Layer2Container context)
    {

        //do nothing, don't schedule an exercise

    }

    public override void scheduleItem(Routine item, DateTime start, LimitBreaker lb, bool notification, Layer2Container context)
    {
        ScheduledRoutine newScheduledRoutine = new ScheduledRoutine();
        newScheduledRoutine.Routine = item;
        newScheduledRoutine.startTime = start;
        newScheduledRoutine.LimitBreaker = lb;
        newScheduledRoutine.needEmailNotification = notification;
        context.ScheduledRoutines.AddObject(newScheduledRoutine);
        context.SaveChanges();
    }
}