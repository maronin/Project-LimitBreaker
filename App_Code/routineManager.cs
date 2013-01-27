using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
            try
            {
                LimitBreaker lb = context.LimitBreakers.Where(x => x.id == userID).FirstOrDefault();
                Routine rt = context.Routines.Where(x => x.id == routineID).First();

                if (lb != null && exercises != null)
                {
                    foreach (Exercise ex in exercises)
                    {
                        le.LimitBreaker = lb;
                        le.ExerciseBase = ex;
                        le.timeLogged = new DateTime(0);
                        le.sets = 0;
                        if (rt != null)
                        {
                            le.Routine = rt;
                        }

                        context.LoggedExercises.AddObject(le);
                        rc.Add(le);
                    }
                    //context.SaveChanges();
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message + Environment.NewLine + e.StackTrace);
            }

            return rc;
        }
    }

    /*
     * 4th step
     * int[0] = rep
     * int[1] = weight
     * int[2] = distance
     * int[3] = time
     * */
    public ICollection<SetAttributes> createSetAttribute(Dictionary<LoggedExercise, int[]> loggedExercises)
    {
        using (var context = new Layer2Container())
        {
            ICollection<SetAttributes> rc = new List<SetAttributes>();
            SetAttributes sa = new SetAttributes();
            try
            {
                foreach (KeyValuePair<LoggedExercise, int[]> pair in loggedExercises)
                {
                    sa.LoggedExercise = pair.Key;
                    sa.reps = Convert.ToInt16(pair.Value[0]);
                    sa.weight = pair.Value[1];
                    sa.distance = pair.Value[2];
                    sa.time = pair.Value[3];

                    context.SetAttributes.AddObject(sa);
                    rc.Add(sa);
                    sa = new SetAttributes();
                }
                context.SaveChanges();
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message + Environment.NewLine + e.StackTrace);
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
            try
            {
                Routine rt = context.Routines.Where(x => x.id == routineID).First();
                
                if (rt != null)
                {
                    foreach (SetAttributes sa in setAttributes)
                    {
                        eg.Routine = rt;
                        eg.SetAttribute = sa;
                        Exercise ex = context.Exercises.Where(x => x.id == sa.LoggedExercise.ExerciseBase.id).First();
                        if (ex != null)
                            eg.ExerciseBase = ex;

                        context.ExerciseGoals.AddObject(eg);
                        rc.Add(eg);
                    }
                    context.SaveChanges();
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message + Environment.NewLine + e.StackTrace);
            }

            return rc;
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
                    le = context.LoggedExercises.Where(x => x.ExerciseBase.id == pair.Key).FirstOrDefault();
                    if (le != null)
                        rc.Add(le, pair.Value);
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message + Environment.NewLine + e.StackTrace);
            }

            return rc;
        }

    }
}