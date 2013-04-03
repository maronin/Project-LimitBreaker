using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class ScheduleNewExercise : ScheduleNewItemTemplate
{

    public override void scheduleItem(Exercise item, DateTime start, LimitBreaker lb, bool notification, Layer2Container context)
    {

            ScheduledExercise newScheduledExercise = new ScheduledExercise();
            newScheduledExercise.Exercise = item;
            newScheduledExercise.startTime = start;
            newScheduledExercise.LimitBreakers = lb;
            newScheduledExercise.needEmailNotification = notification;
            context.ScheduledExercises.AddObject(newScheduledExercise);
            context.SaveChanges();
        
    }

    public override void scheduleItem(Routine item, DateTime start, LimitBreaker lb, bool notification, Layer2Container context)
    {
        //do nothing, don't schedule a routine
    }
}