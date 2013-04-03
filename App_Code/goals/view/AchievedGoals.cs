using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AchievedGoals
/// </summary>
public class AchievedGoals : ViewUserGoalsTemplate
{
	public AchievedGoals()
	{
	}

    public override List<ExerciseGoal> achievedGoals(List<ExerciseGoal> goalSet)
    {
        return goalSet.Where(s => s.achieved == true).ToList();
    }

    public override List<ExerciseGoal> unachievedGoals(List<ExerciseGoal> goalSet)
    {
        return goalSet;
    }
}