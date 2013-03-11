using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LeaderboardManager
/// </summary>
public class LeaderboardManager
{

	public LeaderboardManager()
	{
        
	}

    public List<LeaderBoardItem> getLeaderBoardValues(int orderBy)
    {
        using (var context = new Layer2Container())
        {
            List<LimitBreaker> lbSet;
            List<LeaderBoardItem> leaderBoardItemSet = new List<LeaderBoardItem>();

            switch (orderBy)
            {
                //order by level then experience
                case 1:
                    lbSet = context.LimitBreakers.OrderByDescending(l => l.Statistics.level).ThenByDescending(l => l.Statistics.experience).ThenBy(l => l.username).ToList();
                    break;
                //order by number of achieved goals
                case 2:
                    lbSet = context.LimitBreakers.OrderByDescending(l => l.ExerciseGoals.Where(g => g.achieved == true).Count()).ThenBy(l => l.username).ToList();
                    break;
                //order by number of logged exercises
                case 3:
                    lbSet = context.LimitBreakers.OrderByDescending(l => l.LoggedExercises.Count()).ThenBy(l => l.username).ToList();
                    break;
                default:
                    lbSet = context.LimitBreakers.OrderByDescending(l => l.Statistics.level).ThenByDescending(l => l.Statistics.experience).ThenBy(l => l.username).ToList();
                    break;
            }

            int i = 1;
            foreach (LimitBreaker lb in lbSet)
            {
                context.LoadProperty(lb, "ExerciseGoals");
                context.LoadProperty(lb, "Statistics");
                context.LoadProperty(lb, "LoggedExercises");
                leaderBoardItemSet.Add(new LeaderBoardItem(i, lb.username, lb.Statistics.level, Convert.ToInt32(lb.Statistics.experience), lb.ExerciseGoals.Where(g => g.achieved == true).Count(), lb.LoggedExercises.Count()));
                i++;
            }

            return leaderBoardItemSet;
        }
    }

    public LeaderBoardItem getUserValues(string userName)
    {
        using (var context = new Layer2Container())
        {
            LimitBreaker lb = context.LimitBreakers.Where(l => l.username == userName).FirstOrDefault();

            context.LoadProperty(lb, "ExerciseGoals");
            context.LoadProperty(lb, "Statistics");
            context.LoadProperty(lb, "LoggedExercises");

            return new LeaderBoardItem(1, userName, lb.Statistics.level, Convert.ToInt32(lb.Statistics.experience), lb.ExerciseGoals.Where(g => g.achieved == true).Count(), lb.LoggedExercises.Count());
        }
    }
}

public class LeaderBoardItem
{
    public virtual int rank
    {
        get;
        set;
    }
    public virtual string userName
    {
        get;
        set;
    }
    public virtual int level
    {
        get;
        set;
    }
    public virtual int experience
    {
        get;
        set;
    }
    public virtual int numGoals
    {
        get;
        set;
    }
    public virtual int numLogged
    {
        get;
        set;
    }

    public LeaderBoardItem(int rnk, string name, int lvl, int exp, int goals, int logged)
    {
        rank = rnk;
        userName = name;
        level = lvl;
        experience = exp;
        numGoals = goals;
        numLogged = logged;
    }
}