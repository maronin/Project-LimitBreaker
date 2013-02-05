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

    public ExerciseGoal getExerciseGoalByExerciseName(string name)
    {
        using (var context = new Layer2Container())
        {
            return context.ExerciseGoals.Where(s => s.Exercise.name == name).FirstOrDefault();
        }
    }
}