using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LoggedExerciseManager
/// </summary>

public class LoggedExerciseManager
{
    ExperienceManager expMngr;

    System.Web.HttpApplication _context;
    public LoggedExerciseManager()
    {
        _context = System.Web.HttpContext.Current.ApplicationInstance;
        expMngr = new ExperienceManager();
    }

    public int logExercise(Int32 userID, Int32 exerciseID, Int32 reps, Int32 time, Int32 weight, Double distance)
    {       //changed the return type to return the amount of exp rewarded
        //Get a logged exercise that has been logged within the hour and with the same exercise, else create a new one
        using (var context = new Layer2Container())
        {
            LoggedExercise log = logExists(exerciseID, userID);
            SetAttributes set;
            if (log != null)
            {
                set = createSet(reps, time, weight, distance, log.id);

            }
            else
            {
                log = createLoggedExercise(userID, exerciseID);
                set = createSet(reps, time, weight, distance, log.id);
            }

            int exp = 0;

            if (set != null)
            {
                string exerciseName = context.Exercises.Where(s => s.id == exerciseID).FirstOrDefault().name;
                exp = expMngr.calculateLoggedExerciseExperience(exerciseName, set);
            }

            return exp;
        }
    }

    // neil - log exercise set with note
    public int logExerciseIntoRoutine(Int32 userID, Int32 exerciseID, Int32 routineID, Int32 reps, Int32 time, Int32 weight, Double distance, string note)
    {       //changed the return type to return the amount of exp rewarded
        //Get a logged exercise that has been logged within the hour and with the same exercise, else create a new one
        using (var context = new Layer2Container())
        {
            LoggedExercise log = logExists(exerciseID, userID, routineID);
            SetAttributes set;
            if (log != null)
            {
                set = createSet(reps, time, weight, distance, log.id, note);
            }
            else
            {
                log = createLoggedExercise(userID, exerciseID, routineID);
                set = createSet(reps, time, weight, distance, log.id, note);
            }

            int exp = 0;

            if (set != null)
            {
                string exerciseName = context.Exercises.Where(s => s.id == exerciseID).FirstOrDefault().name;
                exp = expMngr.calculateLoggedExerciseExperience(exerciseName, set);
            }

            return exp;
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
            }
            return null;
        }
    }

    // neil - check if log exists within routine
    LoggedExercise logExists(Int32 exerciseID, Int32 userID, Int32 routineID)
    {
        using (var context = new Layer2Container())
        {
            List<LoggedExercise> logs = (from loggedExercise in context.LoggedExercises
                                         where loggedExercise.LimitBreaker.id == userID
                                         where loggedExercise.Routine.id == routineID
                                         where loggedExercise.Exercise.id == exerciseID
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
            }
            return null;
        }
    }

    public LoggedExercise createLoggedExercise(Int32 userID, Int32 exerciseID)
    {

        using (var context = new Layer2Container())
        {
            Exercise exercise = context.Exercises.Where(e => e.id == exerciseID).FirstOrDefault();
            LimitBreaker limitBreaker = context.LimitBreakers.Where(l => l.id == userID).FirstOrDefault();
            if (exercise != null && limitBreaker != null)
            {
                LoggedExercise log;
                log = new LoggedExercise();
                log.timeLogged = DateTime.Now;
                log.Exercise = exercise;
                log.LimitBreaker = limitBreaker;
                context.LoggedExercises.AddObject(log);
                context.SaveChanges();
                return log;
            }
            else
            {
                return null;
            }
        }
    }

    // neil - create logged exercise with a routine
    public LoggedExercise createLoggedExercise(Int32 userID, Int32 exerciseID, Int32 routineID)
    {

        using (var context = new Layer2Container())
        {
            Exercise exercise = context.Exercises.Where(e => e.id == exerciseID).FirstOrDefault();
            LimitBreaker limitBreaker = context.LimitBreakers.Where(l => l.id == userID).FirstOrDefault();
            Routine routine = context.Routines.Where(r => r.id == routineID).FirstOrDefault();

            if (exercise != null && limitBreaker != null && routine != null)
            {
                LoggedExercise log;
                log = new LoggedExercise();
                log.timeLogged = DateTime.Now;
                log.Exercise = exercise;
                log.LimitBreaker = limitBreaker;
                log.Routine = routine;
                context.LoggedExercises.AddObject(log);
                context.SaveChanges();
                return log;
            }
            else
            {
                return null;
            }
        }
    }

    public SetAttributes createSet(Int32 rep, Int32 time, Int32 weight, Double distance, Int64 logID)
    {

        using (var context = new Layer2Container())
        {
            LoggedExercise existingLog = context.LoggedExercises.Where(log => log.id == logID).FirstOrDefault();
            if (existingLog != null)
            {
                SetAttributes set;
                set = new SetAttributes();
                set.reps = rep;
                set.time = time;
                set.weight = weight;
                set.distance = distance;
                set.timeLogged = DateTime.Now;
                set.LoggedExercise = existingLog;
                context.SetAttributes.AddObject(set);
                context.SaveChanges();
                return set;
            }
            else
            {
                return null;
            }
        }
    }

    // neil - create set with note
    public SetAttributes createSet(Int32 rep, Int32 time, Int32 weight, Double distance, Int64 logID, string note)
    {

        using (var context = new Layer2Container())
        {
            LoggedExercise existingLog = context.LoggedExercises.Where(log => log.id == logID).FirstOrDefault();
            if (existingLog != null)
            {
                SetAttributes set;
                set = new SetAttributes();
                set.reps = rep;
                set.time = time;
                set.weight = weight;
                set.note = note.Trim();
                set.distance = distance;
                set.timeLogged = DateTime.Now;
                set.LoggedExercise = existingLog;
                context.SetAttributes.AddObject(set);
                context.SaveChanges();
                return set;
            }
            else
            {
                return null;
            }
        }
    }

    public List<LoggedExercise> getLoggedExercises(Int32 userID, Int32 exerciseID)
    {
        using (var context = new Layer2Container())
        {
            return context.LoggedExercises.Where(log => log.Exercise.id == exerciseID && log.LimitBreaker.id == userID).OrderByDescending(log => log.timeLogged).ToList();
        }
    }

    public List<LoggedExercise> getLoggedExercisesFromRoutine(Int32 userID, Int32 routineID)
    {
        using (var context = new Layer2Container())
        {
            return context.LoggedExercises.Where(log => log.LimitBreaker.id == userID && log.Routine.id == routineID).OrderByDescending(log => log.timeLogged).ToList();
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
            rc += "<br/><strong>Set " + i + "</strong><br /> ";
            if (set.weight > 0)
            {
                rc += "Weight: " + set.weight + "kg | ";
            }
            if (set.reps > 0)
            {
                rc += "Reps: " + set.reps + " | ";
            }
            if (set.distance > 0)
            {
                rc += "Distance: " + set.distance + "km | ";
            }
            if (set.time > 0)
            {
                int minutes = (Int32)set.time / 60;
                int seconds = (Int32)set.time - minutes * 60;
                rc += "time: " + minutes + "m " + seconds + "s | ";
            }
            i++;
            rc += "<br />";
            if (set.note != null)
            {
                if (!set.note.Equals(""))
                {
                    rc += "Note: " + set.note + "<br />";
                }
            }
        }
        return rc;
    }

    public List<SetAttributes> getSetAttributesFromLoggedExerciseFromUser(string userName, string exerciseName)
    {
        using (var context = new Layer2Container())
        {
            return context.LoggedExercises.Where(s => s.Exercise.name == exerciseName && s.LimitBreaker.username == userName).FirstOrDefault().SetAttributes.ToList();
        }
    }
}