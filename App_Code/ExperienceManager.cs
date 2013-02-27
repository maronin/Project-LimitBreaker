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
    public int calculateLoggedExerciseExperience(string exerciseName, SetAttributes setAttributes)
    {
        ExerciseExp exerciseExp = getExerciseExpByExerciseName(exerciseName);
        int resultExp = (int)exerciseExp.baseExperience;

        resultExp += (int)(exerciseExp.distanceModifier * setAttributes.distance + exerciseExp.repModifier * setAttributes.reps + exerciseExp.timeModifier * setAttributes.time + exerciseExp.weightModifier * setAttributes.weight);

        return resultExp;
    }

    //gonna have to change this
    public int calculateLoggedRoutineExperience(List<Exercise> exerciseSet, string userName)
    {
        int resultExp = 0;
        LoggedExerciseManager setMngr = new LoggedExerciseManager();

        foreach (Exercise exer in exerciseSet)
        {
            //resultExp += calculateLoggedExerciseExperience(exer.name, setMngr.getSetAttributesFromLoggedExerciseFromUser(userName, exer.name));
        }

        return resultExp;
    }

    public int getRequiredExperienceForLevel(int level)
    {
        LevelFormula lvlForm = getLevelFormulaValues();
        return (int)((lvlForm.baseRequired * level) * lvlForm.expModifier);
    }

    public bool rewardExperienceToUser(int userID, int expGained) //returns true if the user levels up
    {
        using (var context = new Layer2Container())
        {
            bool leveled = false;
            LimitBreaker user = context.LimitBreakers.Where(s => s.id == userID).FirstOrDefault();
            int reqExp = getRequiredExperienceForLevel(user.Statistics.level);
            user.Statistics.experience += expGained;

            while (user.Statistics.experience >= reqExp)
            {
                user.Statistics.level += 1;
                user.Statistics.experience -= reqExp;
                leveled = true;
            }
        
            LimitBreaker saveUser = context.LimitBreakers.Where(s => s.username == user.username).FirstOrDefault();
            saveUser.Statistics.experience = user.Statistics.experience;
            saveUser.Statistics.level = user.Statistics.level;
            context.SaveChanges();

            return leveled;
        }
    }

    // Probably gonna have to make a function that uses the returned value from either 
    // calculateLoggedRoutineExperience() or calculateLoggedExerciseExperience() and gives it to the user that logged it
    // ^^^or when log exercise functionality for the system is done just call those methods in there
}