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
    ExperienceManager expMngr;
    string userName;

    protected void Page_Load(object sender, EventArgs e)
    {
        lbMngr = new LeaderboardManager();
        expMngr = new ExperienceManager();
        List<LeaderBoardItem> userItemSet = lbMngr.getLeaderBoardValues(1);

        if (!Page.IsPostBack)
        {
            GridView1.Columns[2].Visible = true;
            GridView1.Columns[3].Visible = true;
            GridView1.Columns[4].Visible = false;
            GridView1.Columns[5].Visible = false;

            GridView1.DataSource = userItemSet;
            GridView1.DataBind();
        }

        HtmlGenericControl li = (HtmlGenericControl)this.Page.Master.FindControl("Ulnav").FindControl("liLeaderboards");
        li.Attributes.Add("class", "active");
        userName = User.Identity.Name;

        if (Request.IsAuthenticated)
        {
            userRankMultiView.ActiveViewIndex = 1;

            //user's rank gridview databinding
            LeaderBoardItem userItem = lbMngr.getUserValues(userName);
            List<LeaderBoardItem> userItemList = new List<LeaderBoardItem>();
            userItemList.Add(userItem);
            GridView2.DataSource = userItemList;
            GridView2.DataBind();

            GridView2.Columns[2].Visible = true;
            GridView2.Columns[3].Visible = true;
            GridView2.Columns[4].Visible = false;
            GridView2.Columns[5].Visible = false;

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (GridView1.Rows[i].Cells[1].Text == userName)
                {
                    GridView1.Rows[i].BorderWidth = 1;
                    GridView1.Rows[i].BorderColor = System.Drawing.Color.Green;
                }
            }

            foreach (LeaderBoardItem lbi in userItemSet)
            {
                if (lbi.userName == userName)
                    GridView2.Rows[0].Cells[0].Text = lbi.rank.ToString();
            }
        }
        else
        {
            userRankMultiView.ActiveViewIndex = 0;
        }
    }

    protected void orderByddl_SelectedIndexChanged(object sender, EventArgs e)
    {
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

        List<LeaderBoardItem> userItemSet = lbMngr.getLeaderBoardValues(Convert.ToInt32(orderByddl.SelectedValue));
        GridView1.DataSource = userItemSet;
        GridView1.DataBind();

        if (Request.IsAuthenticated)
        {
            //user's rank gridview databinding
            LeaderBoardItem userItem = lbMngr.getUserValues(userName);
            List<LeaderBoardItem> userItemList = new List<LeaderBoardItem>();
            userItemList.Add(userItem);
            GridView2.DataSource = userItemList;
            GridView2.DataBind();

            foreach (LeaderBoardItem lbi in userItemSet)
            {
                if (lbi.userName == userName)
                    GridView2.Rows[0].Cells[0].Text = lbi.rank.ToString();
            }
        }
    }

    protected void resultsddl_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView1.PageSize = Convert.ToInt32(resultsddl.SelectedValue);
        orderByddl_SelectedIndexChanged(sender, e);
    }

    protected void GridView1_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (Request.IsAuthenticated)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "userName")) == userName)
                {
                    e.Row.BorderWidth = 1;
                    e.Row.BorderColor = System.Drawing.Color.Green;
                }
            }
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();

        resultsddl_SelectedIndexChanged(sender, e);
        orderByddl_SelectedIndexChanged(sender, e);
    }
}