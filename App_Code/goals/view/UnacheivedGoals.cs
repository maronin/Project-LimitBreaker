using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UnacheivedGoals
/// </summary>
public class UnacheivedGoals : ViewUserGoalsTemplate
{
	public UnacheivedGoals()
	{
	}

    public override List<ExerciseGoal> achievedGoals(List<ExerciseGoal> goalSet)
    {
        return goalSet;
    }

    public override List<ExerciseGoal> unachievedGoals(List<ExerciseGoal> goalSet)
    {
        return goalSet.Where(s => s.achieved == false).ToList();
    }
}