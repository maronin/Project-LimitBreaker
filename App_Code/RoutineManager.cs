using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

/// <summary>
/// Summary description for routineManager
/// </summary>
public class routineManager
{
    public routineManager()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    // Return a list of routines
    public ICollection<Routine> viewRoutines()
    {
        using (var context = new Layer2Container())
        {
            ICollection<Routine> rc = context.Routines.ToList();

            return rc;
        }
    }

    // Return a single routine object based on routine ID parameter
    public Routine getRoutine(int routineID)
    {
        using (var context = new Layer2Container())
        {
            Routine rc = context.Routines.Where(x => x.id == routineID).FirstOrDefault();

            return rc;
        }
    }

    // 1st step
    public Routine createNewRoutine(String routineName, int userID)
    {
        using (var context = new Layer2Container())
        {
            Routine rc = new Routine();
            try
            {
                LimitBreaker lb = context.LimitBreakers.Where(x => x.id == userID).FirstOrDefault();

                if (lb != null)
                {
                    rc.name = routineName.Trim();
                    rc.LimitBreaker = lb;
                    rc.last_modified = DateTime.Now;

                    context.Routines.AddObject(rc);
                    context.SaveChanges();
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message + Environment.NewLine + e.StackTrace);
                // write off the execeptions to my error.log file
                StreamWriter wrtr = new StreamWriter(System.Web.HttpContext.Current.ApplicationInstance.Server.MapPath("~/assets/documents/" + @"\" + "error.log"), true);

                wrtr.WriteLine(DateTime.Now.ToString() + " | Error: " + e);

                wrtr.Close();
            }

            return rc;
        }
    }

    // 2nd step
    public ICollection<LoggedExercise> createLoggedExercises(ICollection<Exercise> exercises, int userID, int routineID = -1)
    {
        using (var context = new Layer2Container())
        {
            LoggedExercise le = new LoggedExercise();
            ICollection<LoggedExercise> rc = new List<LoggedExercise>();
            Exercise id = new Exercise();
            try
            {
                LimitBreaker lb = context.LimitBreakers.Where(x => x.id == userID).FirstOrDefault();
                Routine rt = context.Routines.Where(x => x.id == routineID).First();

                if (lb != null && exercises != null)
                {
                    foreach (Exercise ex in exercises)
                    {
                        // stops the object out of context error
                        id = context.Exercises.Where(x => ex.id == x.id).FirstOrDefault();
                        le.LimitBreaker = lb;
                        le.ExerciseBase = id;
                        le.timeLogged = DateTime.Now;
                        le.sets = 0;
                        if (rt != null)
                        {
                            le.Routine = rt;
                        }
                        context.LoggedExercises.AddObject(le);
                        rc.Add(le);

                        // required to add new instances of loggedExercises
                        le = new LoggedExercise();
                        id = new Exercise();
                    }
                    context.SaveChanges();
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message + Environment.NewLine + e.StackTrace);
                // write off the execeptions to my error.log file
                StreamWriter wrtr = new StreamWriter(System.Web.HttpContext.Current.ApplicationInstance.Server.MapPath("~/assets/documents/" + @"\" + "error.log"), true);

                wrtr.WriteLine(DateTime.Now.ToString() + " | Error: " + e);

                wrtr.Close();
            }

            return rc.ToList();
        }
    }

    // 3rd step
    public Dictionary<LoggedExercise, int[]> convertIntToLoggedExercise(Dictionary<int, int[]> exGoals)
    {
        using (var context = new Layer2Container())
        {
            Dictionary<LoggedExercise, int[]> rc = new Dictionary<LoggedExercise, int[]>();
            LoggedExercise le = new LoggedExercise();
            try
            {
                foreach (KeyValuePair<int, int[]> pair in exGoals)
                {
                    // ordered by descending to grab the latest exercises entered
                    le = context.LoggedExercises.Where(x => x.ExerciseBase.id == pair.Key).OrderByDescending(x => x.id).FirstOrDefault();
                    if (le != null)
                        rc.Add(le, pair.Value);
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message + Environment.NewLine + e.StackTrace);
                // write off the execeptions to my error.log file
                StreamWriter wrtr = new StreamWriter(System.Web.HttpContext.Current.ApplicationInstance.Server.MapPath("~/assets/documents/" + @"\" + "error.log"), true);

                wrtr.WriteLine(DateTime.Now.ToString() + " | Error: " + e);

                wrtr.Close();
            }

            return rc;
        }

    }

    /*
     * 4th step
     * int[0] = rep, int[1] = weight, int[2] = distance, int[3] = time
     * */
    public ICollection<SetAttributes> createSetAttribute(Dictionary<LoggedExercise, int[]> loggedExercises)
    {
        using (var context = new Layer2Container())
        {
            ICollection<SetAttributes> rc = new List<SetAttributes>();
            SetAttributes sa = new SetAttributes();
            LoggedExercise id = new LoggedExercise();
            try
            {
                foreach (KeyValuePair<LoggedExercise, int[]> pair in loggedExercises)
                {
                    id = context.LoggedExercises.Where(x => pair.Key.id == x.id).FirstOrDefault();
                    sa.LoggedExercise = id;
                    sa.reps = Convert.ToInt16(pair.Value[0]);
                    sa.weight = pair.Value[1];
                    sa.distance = pair.Value[2];
                    sa.time = pair.Value[3];

                    context.SetAttributes.AddObject(sa);
                    rc.Add(sa);
                    sa = new SetAttributes();
                    id = new LoggedExercise();
                }
                context.SaveChanges();
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message + Environment.NewLine + e.StackTrace);
                // write off the execeptions to my error.log file
                StreamWriter wrtr = new StreamWriter(System.Web.HttpContext.Current.ApplicationInstance.Server.MapPath("~/assets/documents/" + @"\" + "error.log"), true);

                wrtr.WriteLine(DateTime.Now.ToString() + " | Error: " + e);

                wrtr.Close();
            }

            return rc;
        }
    }

    // 5th step
    public ICollection<ExerciseGoal> createExerciseGoals(int routineID, ICollection<SetAttributes> setAttributes)
    {
        using (var context = new Layer2Container())
        {
            ICollection<ExerciseGoal> rc = new List<ExerciseGoal>();
            ExerciseGoal eg = new ExerciseGoal();
            SetAttributes id = new SetAttributes();
            Routine rt = new Routine();
            try
            {
                foreach (SetAttributes sa in setAttributes)
                {
                    rt = context.Routines.Where(x => x.id == routineID).First();
                    eg.Routine = rt;
                    id = context.SetAttributes.Where(x => x.id == sa.id).FirstOrDefault();
                    eg.SetAttribute = id;

                    Exercise ex = context.Exercises.Where(x => x.id == id.LoggedExercise.ExerciseBase.id).FirstOrDefault();
                    if (ex != null)
                        eg.ExerciseBase = ex;
                    context.ExerciseGoals.AddObject(eg);
                    rc.Add(eg);
                    eg = new ExerciseGoal();
                    id = new SetAttributes();
                    rt = new Routine();
                }
                context.SaveChanges();
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message + Environment.NewLine + e.StackTrace);
                // write off the execeptions to my error.log file
                StreamWriter wrtr = new StreamWriter(System.Web.HttpContext.Current.ApplicationInstance.Server.MapPath("~/assets/documents/" + @"\" + "error.log"), true);

                wrtr.WriteLine(DateTime.Now.ToString() + " | Error: " + e);

                wrtr.Close();
            }

            return rc;
        }
    }


    public List<LoggedExercise> getLoggedExercisesInRoutineById(int routineId)
    {
        using (var context = new Layer2Container())
        {
            return context.LoggedExercises.Where(s => s.Routine.id == routineId).OrderBy(o => o.id).ToList();
        }
    }
}