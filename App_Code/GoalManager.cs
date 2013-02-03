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

    public List<ExerciseGoal> getAllExerciseGoalsFromUser(string userName)
    {
        using (var context = new Layer2Container())
        {
            return context.ExerciseGoals.Where(s => s.LimitBreaker.username == userName).ToList();
        }
    }
}