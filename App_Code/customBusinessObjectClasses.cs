using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for customBusinessObjectClasses
/// </summary>
public class scheduledItem
{
    public scheduledItem()
    {

    }

    public virtual string itemName
    {
        get;
        set;
    }

    public virtual DateTime startTime
    {
        get;
        set;
    }
    public virtual LimitBreaker user
    {
        get;
        set;
    }


}