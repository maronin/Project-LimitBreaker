using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GoalManager
/// </summary>
public class GoalManager
{
	public GoalManager()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public List<ExerciseGoal> getUnachievedExerciseGoalsFromUser(string userName, int orderBy)
    {
        using (var context = new Layer2Container())
        {
            List<ExerciseGoal> goalSet;

            switch (orderBy)
            {
                case 0:
                    goalSet = context.ExerciseGoals.Where(s => s.LimitBreaker.username == userName && s.achieved == false).OrderBy(o => o.Exercise.name).ToList();
                    break;
                case 1:
                    goalSet = context.ExerciseGoals.Where(s => s.LimitBreaker.username == userName && s.achieved == false).OrderBy(o => o.id).ToList();
                    break;
                default:
                    goalSet = context.ExerciseGoals.Where(s => s.LimitBreaker.username == userName && s.achieved == false).ToList();
                    break;
            }

            foreach (ExerciseGoal eg in goalSet)
            {
                context.LoadProperty(eg, "Exercise");
            }

            return goalSet;
        }
    }

    public ExerciseGoal getExerciseGoalByExerciseNameAndUserName(string name, string userName)
    {
        using (var context = new Layer2Container())
        {
            return context.ExerciseGoals.Where(s => s.Exercise.name == name && s.LimitBreaker.username == userName).FirstOrDefault();
        }
    }

    public bool addNewExerciseGoal(int weight, int distance, int time, int reps, string userName, string exerciseName)
    {
        bool rc = false;

        using (var context = new Layer2Container())
        {
            try
            {
                ExerciseGoal newExerciseGoal = new ExerciseGoal();
                Exercise exercise = context.Exercises.Where(s => s.name == exerciseName).FirstOrDefault();
                LimitBreaker user = context.LimitBreakers.Where(s => s.username == userName).FirstOrDefault();

                newExerciseGoal.LimitBreaker = user;
                newExerciseGoal.Exercise = exercise;
                newExerciseGoal.weight = weight;
                newExerciseGoal.distance = distance;
                newExerciseGoal.time = time;
                newExerciseGoal.reps = reps;

                context.ExerciseGoals.AddObject(newExerciseGoal);
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
}