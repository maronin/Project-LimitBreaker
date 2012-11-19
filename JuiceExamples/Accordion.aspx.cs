using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//INCLUDE THIS OR STUFF HAPPENS
using Juice.Framework;

public partial class Temp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Juice.AccordionPanel temp = new Juice.AccordionPanel();
        temp.Title = "lalalKdie";
        temp.PanelContent = new AccordionPanelTemplate("LOL");
        Accordion1.AccordionPanels.Add(temp);

    }
}