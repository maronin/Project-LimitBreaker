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

    // Still missing stuff like: exercise goals, logged exercises, and scheduled routines
    // Also need to have a test user to actually test this on
    // exercise goals would be the exercise set to be in the routine
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
                    rc.last_modified = new DateTime();
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