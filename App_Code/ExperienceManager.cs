using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ExperienceManager
/// </summary>
public class ExperienceManager
{
	public ExperienceManager()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public bool createNewExerciseExp(int exerciseID, double baseExp, double weightMod, double repMod, double distanceMod, double timeMod)
    {
        bool rc = false;

        using (var context = new Layer2Container())
        {
            try
            {
                ExerciseExp newExerciseExp = new ExerciseExp();
                Exercise exercise = context.Exercises.Where(s => s.id == exerciseID).FirstOrDefault();

                newExerciseExp.Exercise = exercise;
                newExerciseExp.baseExperience = baseExp;
                newExerciseExp.weightModifier = weightMod;
                newExerciseExp.repModifier = repMod;
                newExerciseExp.distanceModifier = distanceMod;
                newExerciseExp.timeModifier = timeMod;

                context.SaveChanges();
                rc = true;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message + Environment.NewLine + e.StackTrace);
            }
        }

        return rc;
    }
}