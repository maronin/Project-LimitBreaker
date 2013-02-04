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

    public bool createNewLimitBreaker(String username, String email, String gender, DateTime birthday, Double weight, Double height)
    {
        bool rc = false;

        using (var context = new Layer2Container())
        {
            LimitBreaker newLimitBreaker = new LimitBreaker();
            try
            {
                if ((context.LimitBreakers.FirstOrDefault(limitbreaker => limitbreaker.username == username).username == username))
                    rc = false;
            }
            catch (NullReferenceException e)
            {
                newLimitBreaker.username = username;
                newLimitBreaker.gender = gender;
                newLimitBreaker.dateOfBirth = birthday;
                newLimitBreaker.email = email;
                newLimitBreaker.verified = false;
                newLimitBreaker.deactivated = false;

                if (createNewStats(weight, height))
                {
                    context.LimitBreakers.AddObject(newLimitBreaker);
                    context.SaveChanges();
                    rc = true;
                }
            }
            return rc;
        }
    }

    public bool createNewStats(Double weight, Double height)
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
        }
        return rc;
    }

    public double convertHeightToMetric(Double foot, Double inches)
    {
        return foot * 30.48 + inches * 2.54;
    }
}