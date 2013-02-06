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
        String username = Membership.GetUser().UserName;
        Statistics userStats = manager.getStats(username);
        alias.Text = username;
        level.Text = Convert.ToString(userStats.level);
    }
}