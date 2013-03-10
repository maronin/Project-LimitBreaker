using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class User_leaderboards : System.Web.UI.Page
{
    LeaderboardManager lbMngr;

    protected void Page_Load(object sender, EventArgs e)
    {
        HtmlGenericControl li = (HtmlGenericControl)this.Page.Master.FindControl("Ulnav").FindControl("liLeaderboards");
        li.Attributes.Add("class", "active");

        if (!Page.IsPostBack)
        {
            lbMngr = new LeaderboardManager();
        }
    }

}