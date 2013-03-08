/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserManager
/// </summary>
public class UserManager
{
    Layer2Singleton context;
    public UserManager()
    {
        context = Layer2Singleton.instance();
    }

    //rc status: 1 failure due to servers, 2 name already taken, 0 success
    public int createNewLimitBreaker(String username, String email, String gender, DateTime birthday, Double weight, Double height)
    {
        int rc = 1;
        LimitBreaker newLimitBreaker = new LimitBreaker();
        try
        {
            if ((context.getContainer().LimitBreakers.FirstOrDefault(limitbreaker => limitbreaker.username == username).username == username) ||
                (context.getContainer().LimitBreakers.FirstOrDefault(limitbreaker => limitbreaker.email == email).email == email))
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

            context.getContainer().LimitBreakers.AddObject(newLimitBreaker);

            if (createNewStats(weight, height, newLimitBreaker))
            {
                rc = 0;
            }

        }
        return rc;

    }

    public bool createNewStats(Double weight, Double height, LimitBreaker user)
    {
        bool rc = false;
        Statistics stats = new Statistics();

        stats.level = 1;
        stats.experience = 0;
        stats.weight = weight;
        stats.height = height;
        stats.rmr = 0;
        stats.bmi = 0;
        stats.vo2MAX = 0;

        stats.LimitBreaker = user;

        context.getContainer().Statistics.AddObject(stats);
        context.getContainer().SaveChanges();
        rc = true;
        return rc;
    }

    public double convertHeightToMetric(Double foot, Double inches)
    {
        return foot * 30.48 + inches * 2.54;
    }

    public int getUserID(string username)
    {

        int rc = -1;

        rc = context.getContainer().LimitBreakers.Where(x => x.username == username.Trim()).Select(x => x.id).FirstOrDefault();

        return rc;

    }

    public Statistics getStats(String username)
    {
        var query = (from user in context.getContainer().LimitBreakers
                     where user.username == username
                     select user.Statistics);
        //context.LoadProperty(query, "Statistics");
        return query.FirstOrDefault();
    }

    public LimitBreaker getLimitBreaker(String username)
    {
        var query = (from user in context.getContainer().LimitBreakers
                     where user.username == username
                     select user);
        //context.LoadProperty(query, "Statistics");
        return query.FirstOrDefault();
    }

    public void updateRMR(String username)
    {

        LimitBreaker user = context.getContainer().LimitBreakers.FirstOrDefault(limitbreaker => limitbreaker.username == username);
        context.getContainer().LoadProperty(user, "Statistics");

        if (user.gender == "Male")
        {
            user.Statistics.rmr = user.Statistics.weight * 10 +
                  user.Statistics.height * 6.25 -
                  (DateTime.Now.Year - user.dateOfBirth.Year) * 6.76 +
                  66;
        }
        else
        {
            user.Statistics.rmr = user.Statistics.weight * 9.56 +
                  user.Statistics.height * 1.85 -
                  (DateTime.Now.Year - user.dateOfBirth.Year) * 4.68 +
                  655;
        }
        context.getContainer().SaveChanges();

    }

    public void updateBMI(String username)
    {

        LimitBreaker user = context.getContainer().LimitBreakers.FirstOrDefault(limitbreaker => limitbreaker.username == username);
        context.getContainer().LoadProperty(user, "Statistics");

        user.Statistics.bmi = (user.Statistics.weight) / Math.Pow(user.Statistics.height / 100, 2);

        context.getContainer().SaveChanges();

    }

    public bool updateWeight(String username, Double newWeight)
    {

        LimitBreaker user = context.getContainer().LimitBreakers.FirstOrDefault(limitbreaker => limitbreaker.username == username);
        context.getContainer().LoadProperty(user, "Statistics");
        context.getContainer().LoadProperty(user, "OldWeights");

        //To avoid accessing null
        if (user.OldWeights.Count > 0)
        {
            //Return false (do not update weight) if old weight exists and the update day was less than 24 hours
            if (DateTime.Now.Subtract(user.OldWeights.LastOrDefault().date).Days < 1)
            {
                return false;
            }
            recordOldWeight(user, user.Statistics.weight);
        }
        else
        {
            recordOldWeight(user, user.Statistics.weight);
        }
        user.Statistics.weight = newWeight;
        context.getContainer().SaveChanges();
        return true;
    }

    public void recordOldWeight(LimitBreaker user, Double weight)
    {

        OldWeight oldWeight = new OldWeight();
        oldWeight.LimitBreaker = user;
        oldWeight.date = DateTime.Now;
        oldWeight.weight = weight;

        context.getContainer().OldWeights.AddObject(oldWeight);

        context.getContainer().SaveChanges();

    }
    public void updateHeight(String username, Double newHeight)
    {

        LimitBreaker user = context.getContainer().LimitBreakers.FirstOrDefault(limitbreaker => limitbreaker.username == username);
        context.getContainer().LoadProperty(user, "Statistics");

        user.Statistics.height = newHeight;

        context.getContainer().SaveChanges();

    }
}
*/
//without singleton
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

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
            stats.experience = 0;
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
                user.Statistics.rmr = user.Statistics.weight * 10 +
                      user.Statistics.height * 6.25 -
                      (DateTime.Now.Year - user.dateOfBirth.Year) * 6.76 +
                      66;
            }
            else
            {
                user.Statistics.rmr = user.Statistics.weight * 9.56 +
                      user.Statistics.height * 1.85 -
                      (DateTime.Now.Year - user.dateOfBirth.Year) * 4.68 +
                      655;
            }
            context.SaveChanges();
        }
    }

    public void updateBMI(String username)
    {
        using (var context = new Layer2Container())
        {
            LimitBreaker user = context.LimitBreakers.FirstOrDefault(limitbreaker => limitbreaker.username == username);
            context.LoadProperty(user, "Statistics");

            user.Statistics.bmi = (user.Statistics.weight) / Math.Pow(user.Statistics.height / 100, 2);

            context.SaveChanges();
        }
    }

    public bool updateWeight(String username, Double newWeight)
    {
        using (var context = new Layer2Container())
        {
            LimitBreaker user = context.LimitBreakers.FirstOrDefault(limitbreaker => limitbreaker.username == username);
            context.LoadProperty(user, "Statistics");
            context.LoadProperty(user, "OldWeights");

            //To avoid accessing null
            if (user.OldWeights.Count > 0)
            {
                //Return false (do not update weight) if old weight exists and the update day was less than 24 hours
                if (DateTime.Now.Subtract(user.OldWeights.LastOrDefault().date).Days < 1)
                {
                    return false;
                }
                recordOldWeight(user, user.Statistics.weight, context);
            }
            else
            {
                recordOldWeight(user, user.Statistics.weight, context);
            }
            user.Statistics.weight = newWeight;
            context.SaveChanges();
            return true;
        }
    }
    public void recordOldWeight(LimitBreaker user, Double weight, Layer2Container context)
    {

        OldWeight oldWeight = new OldWeight();
        oldWeight.LimitBreaker = user;
        oldWeight.date = DateTime.Now;
        oldWeight.weight = weight;

        context.OldWeights.AddObject(oldWeight);

        context.SaveChanges();

    }
    public void updateHeight(String username, Double newHeight)
    {
        using (var context = new Layer2Container())
        {
            LimitBreaker user = context.LimitBreakers.FirstOrDefault(limitbreaker => limitbreaker.username == username);
            context.LoadProperty(user, "Statistics");

            user.Statistics.height = newHeight;

            context.SaveChanges();
        }
    }

    public void updateEmail(string username, string email)
    {
        using (var context = new Layer2Container())
        {
            LimitBreaker user = context.LimitBreakers.FirstOrDefault(limitbreaker => limitbreaker.username == username);

            user.email = email;

            context.SaveChanges();
        }
        MembershipUser aspUser = Membership.GetUser(username);
        aspUser.Email = email;
        Membership.UpdateUser(aspUser);
    }
}