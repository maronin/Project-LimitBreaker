using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;

/// <summary>
/// Summary description for Layer2Manager
/// </summary>
public class Layer2Manager
{
    System.Web.HttpApplication _context;

    public Layer2Manager()
    {
        _context = System.Web.HttpContext.Current.ApplicationInstance;
    }

    public List<ExerciseBase> getAllExercises()
    {
        using (var context = new Layer2Container())
        {
            return context.ExerciseBases.OrderBy(o => o.id).ToList();
        }
    }

    public List<string> getExerciseNames()
    {
        List<string> rc = new List<string>(new string[] { "GS500F", "R1", "R6", "GSXR-600", "Fireblade", "CB1000R", "ZX-6R", "ZX-1R", "Ninja 250", "Ninja 1000", "SV650", "Hayabusa" });
        /* actual legit code 
         using (var context = new Layer2Container())
         {
             return context.ExerciseBases.Select(x => x.name).ToList();
         }
         * */

        return rc;
    }

}