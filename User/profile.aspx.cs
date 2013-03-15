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

    public string JSyears = "";
    public string JSmonths = "";
    public string JSdays = "";
    public string JSweights = "";

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
            populateMedals(username);
            populateWeightChart(username);

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

        populateWeightChart(username);
    }

    public void populateMedals(string userName)
    {
        List<LeaderBoardItem> expTop3 = ldrMngr.getLeaderBoardValues(1, true);
        List<LeaderBoardItem> goalsTop3 = ldrMngr.getLeaderBoardValues(2, true);
        List<LeaderBoardItem> loggedTop3 = ldrMngr.getLeaderBoardValues(3, true);
        expRankPanel.Visible = false;
        goalsRankPanel.Visible = false;
        loggedRankPanel.Visible = false;

        for (int i = 1; i < 4; i++)
        {
            if (expTop3[i - 1].userName.ToLower() == userName.ToLower())
            {
                expRankPanel.Visible = true;
                expRankImg.ImageUrl = "~/ui/images/rank" + i + ".png";
            }

            if (goalsTop3[i-1].userName == userName)
            {
                goalsRankPanel.Visible = true;
                goalsRankImg.ImageUrl = "~/ui/images/rank" + i + ".png";
            }

            if (loggedTop3[i-1].userName == userName)
            {
                loggedRankPanel.Visible = true;
                loggedRankImg.ImageUrl = "~/ui/images/rank" + i + ".png";
            }
        }
    }

    public void populateWeightChart(string userName)
    {
        //Date format is dd/mm/yyyy  eg: 14/03/2013
        List<OldWeight> weightList = manager.getAllOldWeights(userName);
        int size = weightList.Count;
        string[] tempFull;
        string[] tempDate;

        for (int i = 0; i < size; i++)
        {
            if (i < size - 1)
            {
                JSweights += weightList[i].weight.ToString() + ",";
                tempFull = weightList[i].date.ToString().Split(' ');
                tempDate = tempFull[0].Split('/');
                JSdays += tempDate[0] + ",";
                JSmonths += tempDate[1] + ",";
                JSyears += tempDate[2] + ",";
            }
            else
            {
                JSweights += weightList[i].weight.ToString();
                tempFull = weightList[i].date.ToString().Split(' ');
                tempDate = tempFull[0].Split('/');
                JSdays += tempDate[0];
                JSmonths += tempDate[1];
                JSyears += tempDate[2];
            }
        }

        ClientScript.RegisterStartupScript(GetType(), "hwa", "load();", true);
    }
}