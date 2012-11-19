using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for Class1
/// </summary>
public class AccordionPanelTemplate : ITemplate
{
    private string _text;

    public AccordionPanelTemplate(string text)
    {
        _text = text;
    }

    public void InstantiateIn(Control container)
    {
        LiteralControl l = new LiteralControl(_text);
        container.Controls.Add(l);
    }
}