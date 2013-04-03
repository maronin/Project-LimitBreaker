using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ViewUserGoalsTemplate
/// </summary>
public abstract class ViewUserGoalsTemplate
{
    public abstract List<ExerciseGoal> unachievedGoals(List<ExerciseGoal> goalSet);
    public abstract List<ExerciseGoal> achievedGoals(List<ExerciseGoal> goalSet);

    public List<ExerciseGoal> getGoalsForUser(string userName, int orderBy, string muscleGroup)
    {
        using (var context = new Layer2Container())
        {
            List<ExerciseGoal> goalSet;
            goalSet = context.ExerciseGoals.Where(s => s.LimitBreaker.username == userName).ToList();
           
            goalSet = achievedGoals(goalSet);
            goalSet = unachievedGoals(goalSet);

            if (muscleGroup != "All Groups")
            {
                switch (orderBy)
                {
                    case 0:
                        goalSet = goalSet.Where(s => s.Exercise.muscleGroups.Contains(muscleGroup)).OrderBy(o => o.Exercise.name).ToList(); 
                        break;
                    case 1:
                        goalSet = goalSet.Where(s => s.Exercise.muscleGroups.Contains(muscleGroup)).OrderBy(o => o.id).ToList();
                        break;
                    default:
                        goalSet = goalSet.Where(s => s.Exercise.muscleGroups.Contains(muscleGroup)).ToList();
                        break;
                }
            }

            else
            {
                switch (orderBy)
                {
                    case 0:
                        goalSet = goalSet.OrderBy(o => o.Exercise.name).ToList();
                        break;
                    case 1:
                        goalSet = goalSet.OrderBy(o => o.id).ToList();
                        break;
                    default:
                        goalSet = goalSet.ToList();
                        break;
                }
            }

            foreach (ExerciseGoal eg in goalSet)
            {
                context.LoadProperty(eg, "Exercise");
            }

            return goalSet;
        }
    }
}