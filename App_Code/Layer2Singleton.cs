using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Layer2Singleton
/// </summary>
public class Layer2Singleton
{
    private static Layer2Singleton singleton=null;
    private Layer2Container context;

	protected Layer2Singleton()
	{
        context = new Layer2Container();
	}

    public static Layer2Singleton instance()
    {
        if (singleton==null)
        {
            singleton = new Layer2Singleton();
        }
        return singleton;
    }
    public Layer2Container getContainer()
    {
        return context;
    }
}