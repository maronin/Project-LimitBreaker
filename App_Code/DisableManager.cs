using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for disableManager
/// </summary>
public class disableManager
{
	public disableManager()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public List<Exercise> getExercises()
    {
        using (var context = new Layer2Container())
        {
            return context.Exercises.OrderBy(s => s.name).ToList();
        }
    }

    public bool disableExerciseById(int id)
    {
        bool result = true;

        using (var context = new Layer2Container())
        {
            try
            {
                Exercise exercise = context.Exercises.Where(s => s.id == id).FirstOrDefault();
                exercise.enabled = false;
                context.SaveChanges();
            }

            catch (Exception e)
            {
                result = false;
            }

            return result;
        }
    }

    public bool disableExerciseByName(string name)
    {
        bool result = true;

        using (var context = new Layer2Container())
        {
            try
            {
                Exercise exercise = context.Exercises.Where(s => s.name == name).FirstOrDefault();
                exercise.enabled = false;
                context.SaveChanges();
            }

            catch (Exception e)
            {
                result = false;
            }

            return result;
        }
    }

    public bool enableExerciseById(int id)
    {
        bool result = true;

        using (var context = new Layer2Container())
        {
            try
            {
                Exercise exercise = context.Exercises.Where(s => s.id == id).FirstOrDefault();
                exercise.enabled = true;
                context.SaveChanges();
            }

            catch (Exception e)
            {
                result = false;
            }

            return result;
        }
    }

    public bool enableExerciseByName(string name)
    {
        bool result = true;

        using (var context = new Layer2Container())
        {
            try
            {
                Exercise exercise = context.Exercises.Where(s => s.name == name).FirstOrDefault();
                exercise.enabled = true;
                context.SaveChanges();
            }

            catch (Exception e)
            {
                result = false;
            }

            return result;
        }
    }

    public bool getExerciseEnabledValueById(int id)
    {
        using (var context = new Layer2Container())
        {
            return context.Exercises.Where(s => s.id == id).FirstOrDefault().enabled;
        }
    }
}