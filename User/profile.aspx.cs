using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.UI.HtmlControls;

public partial class User_profile : System.Web.UI.Page
{
    UserManager manager = new UserManager();
    ExperienceManager expMngr = new ExperienceManager();
    LeaderboardManager ldrMngr = new LeaderboardManager();


    protected void Page_Load(object sender, EventArgs e)
    {

        HtmlGenericControl li = (HtmlGenericControl)this.Page.Master.FindControl("Ulnav").FindControl("liprofile");
        li.Attributes.Add("class", "active");

        if (User.Identity.Name != "")
        {
            String username = User.Identity.Name;
            Statistics userStats = manager.getStats(username);
            alias.Text = username;
            double tempRmr = userStats.rmr;
            double tempBmi = userStats.bmi;
            double tempVmax = userStats.vo2MAX;
            string reqExp = Convert.ToString(expMngr.getRequiredExperienceForLevel(userStats.level));
            string curExp = Convert.ToString(userStats.experience);
            levelLbl.Text = "Level: " + Convert.ToString(userStats.level);
            currentExpLbl.Text = curExp;
            reqExpLbl.Text = "  /  " + reqExp + "  Experience";
            expBar.Attributes.Add("value", curExp);
            expBar.Attributes.Add("max", reqExp);
            expBar.Attributes.Add("title", Convert.ToString(Math.Round(Convert.ToDouble(curExp)/Convert.ToDouble(reqExp)*100, 1)) + "% through the current level");
            LeaderBoardItem userItem = ldrMngr.getUserValues(username);
            achievedGoalslbl.Text = userItem.numGoals.ToString();
            loggedExerciseslbl.Text = userItem.numLogged.ToString();

            if (!Page.IsPostBack)
            {
                newWeight.Text = Convert.ToString(Math.Round(userStats.weight, 2));
                newHeight.Text = Convert.ToString(Math.Round(userStats.height, 2));
            }

            if (tempRmr > 1)
            {
                rmr.Text = Convert.ToString(Math.Round(tempRmr, 2));
            }
            else
            {
                rmr.Text = "<a href=\"updateStats.aspx\">Update Stats</a>";
            }
            if (tempBmi > 1)
            {
                bmi.Text = Convert.ToString(Math.Round(tempBmi, 2));
            }
            else
            {
                bmi.Text = "<a href=\"updateStats.aspx\">Update Stats</a>";
            }
        }
        else
        { 
            Response.Redirect("../login.aspx");
        }
    }
    protected void updateStats_Click(object sender, EventArgs e)
    {
        String username = User.Identity.Name;
        if (manager.updateWeight(username, Convert.ToDouble(newWeight.Text)))
        {
            updateResultLbl.Text = "You have successfully updated your profile!";
        }
        else
        {
            updateResultLbl.Text = "Please wait 24 hours before updating your profile again";
        }
        manager.updateHeight(username, Convert.ToDouble(newHeight.Text));
        manager.updateRMR(username);
        manager.updateBMI(username);
        Statistics userStats = manager.getStats(username);
        newWeight.Text = Convert.ToString(Math.Round(userStats.weight, 2));
        newHeight.Text = Convert.ToString(Math.Round(userStats.height, 2));
        rmr.Text = Convert.ToString(Math.Round(userStats.rmr, 2));
        bmi.Text = Convert.ToString(Math.Round(userStats.bmi, 2));
        
    }
}