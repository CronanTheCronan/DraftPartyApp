using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public static class GlobalVariables
{
    private static string _leagueName;
    private static int _numberOfTeams;

    public static string LeagueName
    {
        get
        {
            return _leagueName;
        }
        set
        {
            _leagueName = value;
        }
    }

    public static int NumberOfTeams
    {
        get
        {
            return _numberOfTeams;
        }
        set
        {
            _numberOfTeams = value;
        }
    }

    public static void Instanstiate()
    {
        HttpContext.Current.Session["LeagueName"] = Constants.leagueName;
        HttpContext.Current.Session["NumberOfTeams"] = Constants.numberOfTeams;
    }
}