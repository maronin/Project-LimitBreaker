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

    //database retrieval and setting functions
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

    //non-database related experience functions
    public int calculateLoggedExerciseExperience(string exerciseName, List<SetAttributes> setAttributesSet)
    {
        ExerciseExp exerciseExp = getExerciseExpByExerciseName(exerciseName);
        int resultExp = (int)exerciseExp.baseExperience;

        foreach (SetAttributes sa in setAttributesSet)
        {
            resultExp += (int)(exerciseExp.distanceModifier * sa.distance + exerciseExp.repModifier * sa.reps + exerciseExp.timeModifier * sa.time + exerciseExp.weightModifier * sa.weight);
        }

        return resultExp;
    }

    public int calculateLoggedRoutineExperience(int routineId)  //can also just pass in a  List<Exercise> exerciseSet
    {
        int resultExp = 0;
        /*
        routineManager rm = new routineManager();
        List<Exercise> exerciseSet = rm.getExercisesInRoutineById(routineId);

        foreach (Exercise exer in exerciseSet)
        {
            resultExp += calculateLoggedExerciseExperience(exer.name, exer.LoggedExercise.SetAttributes.ToList());
        }
        */
        return resultExp;
    }

    public int getRequiredExperienceForLevel(int level)
    {
        LevelFormula lvlForm = getLevelFormulaValues();
        return (int)Math.Pow((lvlForm.baseRequired * level), lvlForm.expModifier);
    }

    public bool rewardExperienceToUser(LimitBreaker user, int expGained) //returns true if the user levels up
    {
        bool leveled = false;
        int reqExp = getRequiredExperienceForLevel(user.Statistics.level);

        user.Statistics.experience += expGained;

        if (user.Statistics.experience >= reqExp)
        {
            user.Statistics.level += 1;
            user.Statistics.experience -= reqExp;
            leveled = true;
        }

        //Not sure if code below will work
        using (var context = new Layer2Container()) 
        {
            LimitBreaker saveUser = user;
            context.SaveChanges();
        }

        return leveled;
    }




    // Probably gonna have to make a function that uses the returned value from either 
    // calculateLoggedRoutineExperience() or calculateLoggedExerciseExperience() and gives it to the user that logged it
    // ^^^or when log exercise functionality for the system is done just call those methods in there
}