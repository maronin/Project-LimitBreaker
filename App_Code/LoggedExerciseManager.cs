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

    public List<SetAttributes> getSetAttributesFromLoggedExerciseFromUser(string userName, string exerciseName)
    {
        using (var context = new Layer2Container())
        {
            return context.LoggedExercises.Where(s => s.Exercise.name == exerciseName && s.LimitBreaker.username == userName).FirstOrDefault().SetAttributes.ToList();
        }
    }
}