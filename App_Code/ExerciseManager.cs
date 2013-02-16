using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ExerciseManager
/// </summary>
public class ExerciseManager
{
	public ExerciseManager()
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

    public Exercise getExerciseById(int ID)
    {
        using (var context = new Layer2Container())
        {
            return context.Exercises.Where(e => e.id == ID).FirstOrDefault();
        }
    }

    public bool deleteExerciseById(int id)
    {
        bool result = true;
        using (var context = new Layer2Container())
        {
            try
            {
                var exercise = context.Exercises.Where(s => s.id == id).FirstOrDefault();

                //var exp = context.ExerciseExps.Where(s => s.Exercise.id == id).FirstOrDefault(); // Make it so it only works when there is a related ExerciseExp
                //context.ExerciseExps.DeleteObject(exp);

                exercise.LoggedExercise.Clear();
                exercise.ScheduledExercises.Clear();
                //ExerciseGoal doesn't have a navigation property

                context.Exercises.DeleteObject(exercise);
                context.SaveChanges();
            }

            catch (Exception e)
            {
                result = false;
            }
        }

        return result;
    }

    //BIG FUCKING ISSUE WITH THIS FUNCTION ON LINE 68!! This is a note for future reference.
    //The logic fault is that if you clear a LoggedExercise's refernece to an exercise and the exercise still exists, then wtf?! Solution: deleting an exercise is NOT allowed, only disabling
    public bool deleteExerciseByName(string name)
    {
        bool result = true;
        using (var context = new Layer2Container())
        {
            try
            {
                var exercise = context.Exercises.Where(s => s.name == name).FirstOrDefault();

                //var exp = context.ExerciseExps.Where(s => s.Exercise.id == id).FirstOrDefault(); // Make it so it only works when there is a related ExerciseExp
                //context.ExerciseExps.DeleteObject(exp);

                exercise.LoggedExercise.Clear();
                exercise.ScheduledExercises.Clear();
                //ExerciseGoal doesn't have a navigation property

                context.Exercises.DeleteObject(exercise);
                context.SaveChanges();
            }

            catch (Exception e)
            {
                result = false;
            }
        }

        return result;
    }

    public String[] splitMuscleGroups(String muscleGroups)
    {
        String[] rc = new String[0];

        rc = muscleGroups.Split(null);

        for (int i = 0; i < rc.Length; i++)
            rc[i] = rc[i].Trim();

        return rc;
    }
}