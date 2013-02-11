using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserManager
/// </summary>
public class UserManager
{
    System.Web.HttpApplication _context;
    public UserManager()
    {
        //Reference to curent application instance
        _context = System.Web.HttpContext.Current.ApplicationInstance;
    }

    //rc status: 1 failure due to servers, 2 name already taken, 0 success
    public int createNewLimitBreaker(String username, String email, String gender, DateTime birthday, Double weight, Double height)
    {
        int rc = 1;

        using (var context = new Layer2Container())
        {
            LimitBreaker newLimitBreaker = new LimitBreaker();
            try
            {
                if ((context.LimitBreakers.FirstOrDefault(limitbreaker => limitbreaker.username == username).username == username) ||
                    (context.LimitBreakers.FirstOrDefault(limitbreaker => limitbreaker.email == email).email == email))
                {
                    rc = 2;
                    return rc;
                }
            }
            catch (NullReferenceException e)
            {
                newLimitBreaker.username = username;
                newLimitBreaker.gender = gender;
                newLimitBreaker.dateOfBirth = birthday;
                newLimitBreaker.email = email;
                newLimitBreaker.verified = false;
                newLimitBreaker.deactivated = false;

                context.LimitBreakers.AddObject(newLimitBreaker);

                if (createNewStats(weight, height, newLimitBreaker))
                {
                    rc = 0;
                }

            }
            return rc;
        }
    }

    public bool createNewStats(Double weight, Double height, LimitBreaker user)
    {
        bool rc = false;
        using (var context = new Layer2Container())
        {
            Statistics stats = new Statistics();

            stats.level = 1;
            stats.experience = 1;
            stats.weight = weight;
            stats.height = height;
            stats.rmr = 0;
            stats.bmi = 0;
            stats.vo2MAX = 0;

            stats.LimitBreaker = user;

            context.Statistics.AddObject(stats);
            context.SaveChanges();
            rc = true;
        }
        return rc;
    }

    public double convertHeightToMetric(Double foot, Double inches)
    {
        return foot * 30.48 + inches * 2.54;
    }

    public int getUserID(string username)
    {
        using (var context = new Layer2Container())
        {
            int rc = -1;

            rc = context.LimitBreakers.Where(x => x.username == username.Trim()).Select(x => x.id).FirstOrDefault();

            return rc;
        }
    }

    public Statistics getStats(String username)
    {
        using (var context = new Layer2Container())
        {
            var query = (from user in context.LimitBreakers
                         where user.username == username
                         select user.Statistics);
            //context.LoadProperty(query, "Statistics");
            return query.FirstOrDefault();
        }
    }

    public LimitBreaker getLimitBreaker(String username)
    {
        using (var context = new Layer2Container())
        {
            var query = (from user in context.LimitBreakers
                         where user.username == username
                         select user);
            //context.LoadProperty(query, "Statistics");
            return query.FirstOrDefault();
        }
    }
    public void updateRMR(String username)
    {
        using (var context = new Layer2Container())
        {
            LimitBreaker user = context.LimitBreakers.FirstOrDefault(limitbreaker => limitbreaker.username == username);
            context.LoadProperty(user, "Statistics"); ;

            if (user.gender == "Male")
            {
                user.Statistics.rmr = user.Statistics.weight * 0.4535 * 10 +
                      user.Statistics.height * 6.25 -
                      (DateTime.Now.Year - user.dateOfBirth.Year) * 6.76 +
                      66;
            }
            else
            {
                user.Statistics.rmr = user.Statistics.weight * 0.4535 * 9.56 +
                      user.Statistics.height * 1.85 -
                      (DateTime.Now.Year - user.dateOfBirth.Year) * 4.68 +
                      655;
            }
            context.SaveChanges();
        }
    }
}