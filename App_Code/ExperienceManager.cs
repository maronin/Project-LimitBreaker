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

    public bool createNewExerciseExp(string exerciseName, double baseExp, double weightMod, double repMod, double distanceMod, double timeMod)
    {
        bool rc = false;

        using (var context = new Layer2Container())
        {
            try
            {
                ExerciseExp newExerciseExp = new ExerciseExp();
                Exercise exercise = context.Exercises.Where(s => s.name == exerciseName).FirstOrDefault();

                newExerciseExp.Exercise = exercise;
                newExerciseExp.baseExperience = baseExp;
                newExerciseExp.weightModifier = weightMod;
                newExerciseExp.repModifier = repMod;
                newExerciseExp.distanceModifier = distanceMod;
                newExerciseExp.timeModifier = timeMod;

                context.ExerciseExps.AddObject(newExerciseExp);
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

    public bool modifyExerciseExpByName(string exerciseName, double baseExp, double weightMod, double repMod, double distanceMod, double timeMod)
    {
        bool rc = false;

        using (var context = new Layer2Container())
        {
            try
            {
                ExerciseExp exerciseExp = context.ExerciseExps.Where(s => s.Exercise.name == exerciseName).FirstOrDefault();

                exerciseExp.baseExperience = baseExp;
                exerciseExp.weightModifier = weightMod;
                exerciseExp.repModifier = repMod;
                exerciseExp.distanceModifier = distanceMod;
                exerciseExp.timeModifier = timeMod;

                context.SaveChanges();
                rc = true;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        return rc;
    }

    public ExerciseExp getExerciseExpByExerciseName(string name)
    {
        using (var context = new Layer2Container())
        {
            return context.ExerciseExps.Where(s => s.Exercise.name == name).FirstOrDefault();
        }
    }

    public bool modifyExperienceAtrophy(int days, int loss)
    {
        bool rc = false;

        using (var context = new Layer2Container())
        {
            try
            {
                ExperienceAtrophy expAtrophy = context.ExperienceAtrophies.FirstOrDefault();

                expAtrophy.graceDays = days;
                expAtrophy.baseLoss = loss;

                context.SaveChanges();
                rc = true;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        return rc;
    }

    public ExperienceAtrophy getExperienceAtrophy()
    {
        using (var context = new Layer2Container())
        {
            return context.ExperienceAtrophies.FirstOrDefault();
        }
    }

    public LevelFormula getLevelFormulaValues()
    {
        using (var context = new Layer2Container())
        {
            return context.LevelFormulas.FirstOrDefault();
        }
    }

    public bool modifyLevelFormula(int maxLvl, double expMod, int baseReq)
    {
        bool rc = false;

        using (var context = new Layer2Container())
        {
            try
            {
                LevelFormula lvlForm = context.LevelFormulas.FirstOrDefault();

                lvlForm.maxLevel = maxLvl;
                lvlForm.expModifier = expMod;
                lvlForm.baseRequired = baseReq;

                context.SaveChanges();
                rc = true;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        return rc;
    }

    public int calculateLoggedExerciseExperience(string exerciseName, List<SetAttributes> setValues)
    {
        int resultExp = 0;
        ExerciseExp exerciseExp = getExerciseExpByExerciseName(exerciseName);

        //use modifiers in exerciseExp and the values in setValues to calculate the exp and store it in resultExp
        //eg exerciseExp.timeModifer * setValues.set1.time

        return resultExp;
    }

    public int calculateLoggedRoutineExperience(int routineId)
    {
        int resultExp = 0;
        routineManager rm = new routineManager();
        List<LoggedExercise> loggedExerciseSet = rm.getLoggedExercisesInRoutineById(routineId);

        foreach (LoggedExercise le in loggedExerciseSet)
        {
            resultExp += calculateLoggedExerciseExperience(le.ExerciseBase.name, le.SetAttributes.ToList());
        }

        return resultExp;
    }
}