using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class User_profile : System.Web.UI.Page
{
    UserManager manager = new UserManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.Name != "")
        {
            String username = Membership.GetUser().UserName;
            Statistics userStats = manager.getStats(username);
            alias.Text = username;
            level.Text = Convert.ToString(userStats.level);
            exp.Text = Convert.ToString(Math.Round(userStats.experience, 2));
            weight.Text = Convert.ToString(Math.Round(userStats.weight, 2)) + " lb";
            height.Text = Convert.ToString(Math.Round(userStats.height, 2)) + " cm";
            double tempRmr = userStats.rmr;
            double tempBmi = userStats.bmi;
            double tempVmax = userStats.vo2MAX;
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
            if (tempVmax > 1)
            {
                vmax.Text = Convert.ToString(Math.Round(tempVmax, 2));
            }
            else
            {
                vmax.Text = "<a href=\"updateStats.aspx\">Update Stats</a>";
            }
        }
        else
        {
            Response.Redirect("../login.aspx");
        }
    }
}