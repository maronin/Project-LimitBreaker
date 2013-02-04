//#define DEBUG
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
    HttpResponse response = System.Web.HttpContext.Current.Response;

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

    // return the routine created
    public Routine createNewRoutine(String routineName, int userID, ICollection<Exercise> exerciseList)
    {
        using (var context = new Layer2Container())
        {
            Routine rc = new Routine();
            try
            {
                LimitBreaker lb = context.LimitBreakers.Where(x => x.id == userID).FirstOrDefault();
                Exercise exc = new Exercise();
                if (lb != null)
                {
                    rc.name = routineName.Trim();
                    rc.LimitBreaker = lb;
                    rc.lastModified = DateTime.Now;
                    foreach (Exercise ex in exerciseList)
                    {
#if DEBUG
                        response.Write("Exercise: " + ex.name + "<br/> ID: " + ex.id + "<br/>");
#endif
                        // to prevent object out of context error
                        exc = context.Exercises.Where(x => x.id == ex.id).FirstOrDefault();
                        rc.Exercises.Add(exc);
                        exc = new Exercise();
                    }

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

    public ICollection<Exercise> getExerciseFromRoutine(int routineID)
    {
        using (var context = new Layer2Container())
        {
            ICollection<Exercise> rc = new List<Exercise>();

            try
            {
                Routine rtn = context.Routines.Where(x => x.id == routineID).FirstOrDefault();
                if (rtn != null)
                {
                    foreach (Exercise ex in rtn.Exercises)
                    {
                        rc.Add(ex);
                    }
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

    public bool deleteRoutine(int routineID)
    {
        using (var context = new Layer2Container())
        {
            bool rc = false;
            try
            {
                Routine rtn = context.Routines.Where(x => x.id == routineID).FirstOrDefault();
                Exercise exc = new Exercise();
                if (rtn != null)
                {
                    ICollection<Exercise> exerciseList = rtn.Exercises;
                    foreach (Exercise ex in exerciseList.ToList())
                    {

                        //exc = context.Exercises.Where(x => x.id == ex.id).FirstOrDefault();
                        if (ex.Routines.Contains(rtn))
                        {
                            rtn.Exercises.Remove(ex);
                        }
                        exc = new Exercise();

                    }
                    context.Routines.DeleteObject(rtn);
                    context.SaveChanges();
                    rc = true;
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
}