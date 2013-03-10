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
    string userName;

    protected void Page_Load(object sender, EventArgs e)
    {
        lbMngr = new LeaderboardManager();

        if (!Page.IsPostBack)
        {
            GridView1.Columns[2].Visible = true;
            GridView1.Columns[3].Visible = true;
            GridView1.Columns[4].Visible = false;
            GridView1.Columns[5].Visible = false;
        }

        HtmlGenericControl li = (HtmlGenericControl)this.Page.Master.FindControl("Ulnav").FindControl("liLeaderboards");
        li.Attributes.Add("class", "active");
        userName = User.Identity.Name;
        if (Request.IsAuthenticated)
        {
            userRankMultiView.ActiveViewIndex = 1;
            userNamelbl.Text = userName;

            //user's rank gridview databinding                               //***************   Probably going to change this so that it uses the values found within the first gridview   *********//
            LeaderBoardItem userItem = lbMngr.getUserValues(userName);
            List<LeaderBoardItem> userItemList = new List<LeaderBoardItem>();
            userItemList.Add(userItem);
            GridView2.DataSource = userItemList;
            GridView2.DataBind();

            GridView2.Columns[2].Visible = true;
            GridView2.Columns[3].Visible = true;
            GridView2.Columns[4].Visible = false;
            GridView2.Columns[5].Visible = false;
        }
        else
        {
            userRankMultiView.ActiveViewIndex = 0;
        }
    }

    protected void orderByddl_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Request.IsAuthenticated)
        {
            //user's rank gridview databinding
            LeaderBoardItem userItem = lbMngr.getUserValues(userName);
            List<LeaderBoardItem> userItemList = new List<LeaderBoardItem>();
            userItemList.Add(userItem);
            GridView2.DataSource = userItemList;
            GridView2.DataBind();
        }

        if (orderByddl.SelectedValue == "1")
        {
            GridView1.Columns[2].Visible = true;
            GridView1.Columns[3].Visible = true;
            GridView1.Columns[4].Visible = false;
            GridView1.Columns[5].Visible = false;

            if (Request.IsAuthenticated)
            {
                GridView2.Columns[2].Visible = true;
                GridView2.Columns[3].Visible = true;
                GridView2.Columns[4].Visible = false;
                GridView2.Columns[5].Visible = false;
            }
        }

        else if (orderByddl.SelectedValue == "2")
        {
            GridView1.Columns[2].Visible = false;
            GridView1.Columns[3].Visible = false;
            GridView1.Columns[4].Visible = true;
            GridView1.Columns[5].Visible = false;

            if (Request.IsAuthenticated)
            {
                GridView2.Columns[2].Visible = false;
                GridView2.Columns[3].Visible = false;
                GridView2.Columns[4].Visible = true;
                GridView2.Columns[5].Visible = false;
            }
        }

        else if (orderByddl.SelectedValue == "3")
        {
            GridView1.Columns[2].Visible = false;
            GridView1.Columns[3].Visible = false;
            GridView1.Columns[4].Visible = false;
            GridView1.Columns[5].Visible = true;

            if (Request.IsAuthenticated)
            {
                GridView2.Columns[2].Visible = false;
                GridView2.Columns[3].Visible = false;
                GridView2.Columns[4].Visible = false;
                GridView2.Columns[5].Visible = true;
            }
        }
    }

    protected void resultsddl_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView1.PageSize = Convert.ToInt32(resultsddl.SelectedValue);
    }
}