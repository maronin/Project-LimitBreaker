﻿//#define DEBUG
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

    public ICollection<Routine> getUsersRoutines(int userID)
    {
        using (var context = new Layer2Container())
        {
            ICollection<Routine> rc;
            //LimitBreaker lb = context.LimitBreakers.Where(x => x.id == userID).FirstOrDefault();
            //if (lb != null)
                rc = context.Routines.Where(x => x.LimitBreaker.id == userID).ToList();
            //else
                //rc = null;

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
                ICollection<ScheduledRoutine> srList = rtn.ScheduledRoutines;
                if (rtn != null)
                {
                    // clear dependencies
                    rtn.Exercises.Clear();
                    
                    foreach (ScheduledRoutine sr in srList.ToList())
                        context.ScheduledRoutines.DeleteObject(sr);
                    rtn.ScheduledRoutines.Clear();

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

    // return true if the routine contains the exercise
    public bool containsExercise(int routineID, int exerciseId)
    {
        using (var context = new Layer2Container())
        {
            bool rc = false;
            try
            {
                Routine rtn = context.Routines.Where(x => x.id == routineID).FirstOrDefault();
                Exercise exc = context.Exercises.Where(x => x.id == exerciseId).FirstOrDefault();
                if (rtn.Exercises.Contains(exc))
                    rc = true;
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

    public Routine addExerciseToRoutine(int routineID, int exerciseID)
    {
        using (var context = new Layer2Container())
        {
            Routine rc = new Routine();
            try
            {
                Routine rtn = context.Routines.Where(x => x.id == routineID).FirstOrDefault();
                Exercise exc = context.Exercises.Where(x => x.id == exerciseID).FirstOrDefault();
                if (rtn != null && exc != null && containsExercise(routineID, exerciseID) != true)
                {
                    rtn.Exercises.Add(exc);
                    context.Routines.ApplyCurrentValues(rtn);
                    context.SaveChanges();
                }
                rc = rtn;
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

    public Routine removeExerciseFromRoutine(int routineID, int exerciseID)
    {

        using (var context = new Layer2Container())
        {
            Routine rc = new Routine();
            try
            {
                Routine rtn = context.Routines.Where(x => x.id == routineID).FirstOrDefault();
                Exercise exc = context.Exercises.Where(x => x.id == exerciseID).FirstOrDefault();
                if (rtn != null && exc != null && containsExercise(routineID, exerciseID) == true)
                {
                    rtn.Exercises.Remove(exc);
                    exc.Routines.Remove(rtn);
                    context.Exercises.ApplyCurrentValues(exc);
                    context.Routines.ApplyCurrentValues(rtn);
                    context.SaveChanges();
                }
                rc = rtn;
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

    public Routine changeRoutineName(int routineID, string name)
    {
        using (var context = new Layer2Container())
        {
            Routine rc = new Routine();
            try
            {
                Routine rtn = context.Routines.Where(x => x.id == routineID).FirstOrDefault();
                if (rtn != null && rtn.name != name.Trim())
                {
                    rtn.name = name.Trim();
                    context.Routines.ApplyCurrentValues(rtn);
                    context.SaveChanges();
                }
                rc = rtn;
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

    public int getUserID(string username)
    {
        using (var context = new Layer2Container())
        {
            int rc = -1;

            rc = context.LimitBreakers.Where(x => x.username == username.Trim()).Select(x => x.id).FirstOrDefault();

            return rc;
        }
    }
}