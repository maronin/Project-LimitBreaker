using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    Layer2Manager manager = new Layer2Manager();

    protected void Page_Load(object sender, EventArgs e)
    {
        exerciseAutoComplete.SourceList = manager.getExerciseNamesAC();
    }
}