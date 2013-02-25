using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LoggedExerciseManager
/// </summary>

public class LoggedExerciseManager
{
    System.Web.HttpApplication _context;
    public LoggedExerciseManager()
    {
        _context = System.Web.HttpContext.Current.ApplicationInstance;
    }

    public bool logExercise(Int32 userID, Int32 exerciseID, Int32 reps, Int32 time, Int32 weight, Double distance)
    {
        //Get a logged exercise that has been logged within the hour and with the same exercise, else create a new one
        using (var context = new Layer2Container())
        {
            LoggedExercise log = logExists(exerciseID, userID);
            SetAttributes set;
            if (log != null)
            {
                set = createSet(reps, time, weight, distance, log.id);
                return true;

            }
            else
            {
                log = createLoggedExercise(userID, exerciseID);
                set = createSet(reps, time, weight, distance, log.id);
                return true;
            }
        }
    }

    LoggedExercise logExists(Int32 exerciseID, Int32 userID)
    {
        using (var context = new Layer2Container())
        {
            List<LoggedExercise> logs = (from loggedExercise in context.LoggedExercises
                                         where loggedExercise.Exercise.id == exerciseID && loggedExercise.LimitBreaker.id == userID
                                         select loggedExercise).ToList();
            if (logs != null)
            {
                foreach (LoggedExercise log in logs)
                {
                    if ((DateTime.Now - log.timeLogged).Hours < 1)
                    {
                        return log;
                    }
                }
                return null;
            }
            else
            {
                return null;
            }
        }
    }

    public LoggedExercise createLoggedExercise(Int32 userID, Int32 exerciseID)
    {

        using (var context = new Layer2Container())
        {
            LoggedExercise log;
            log = new LoggedExercise();
            log.sets = 1;
            log.note = "";
            log.timeLogged = DateTime.Now;
            log.Exercise = context.Exercises.Where(e => e.id == exerciseID).First();
            log.LimitBreaker = context.LimitBreakers.Where(l => l.id == userID).First();
            context.LoggedExercises.AddObject(log);
            context.SaveChanges();
            return log;
        }
    }

    public SetAttributes createSet(Int32 rep, Int32 time, Int32 weight, Double distance, Int64 logID)
    {

        using (var context = new Layer2Container())
        {
            SetAttributes set;
            set = new SetAttributes();
            set.reps = rep;
            set.time = time;
            set.weight = weight;
            set.distance = distance;
            set.timeLogged = DateTime.Now;
            set.LoggedExercise = context.LoggedExercises.Where(log => log.id == logID).First();
            context.SetAttributes.AddObject(set);
            context.SaveChanges();
            return set;
        }
    }

    public List<LoggedExercise> getLoggedExercises(Int32 userID, String exerciseName)
    {
        using (var context = new Layer2Container())
        {
            return context.LoggedExercises.Where(log => log.Exercise.name == exerciseName && log.LimitBreaker.id == userID).OrderByDescending(log => log.timeLogged).ToList();
        }
    }

    public List<SetAttributes> getSetAttributes(Int64 logID)
    {
        using (var context = new Layer2Container())
        {
            return context.SetAttributes.Where(sets => sets.LoggedExercise.id == logID).ToList();
        }
    }

    public String setsToString(List<SetAttributes> sets)
    {
        int i = 1;
        String rc = "";
        foreach (var set in sets)
        {
            rc += "<strong>Set " + i + "</strong><br /> ";
            if (set.weight > 0)
            {
                rc += "Weight: " + set.weight + " | ";
            }
            if (set.reps > 0)
            {
                rc += "Reps: " + set.reps + " | ";
            }
            if (set.distance > 0)
            {
                rc += "Distance: " + set.distance + " | ";
            }
            if (set.time > 0)
            {
                rc += "time: " + set.time + " | ";
            }
            i++;
            rc += "<br />";
        }
        return rc;
    }
}