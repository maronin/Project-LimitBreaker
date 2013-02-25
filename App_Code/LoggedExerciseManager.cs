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

    
}