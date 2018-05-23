using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public static class GlobalVariables
{
    private static string _leagueName;
    private static int _numberOfTeams;
    private static string _teamIdList;
    private static string _teamNameList;
    private static int _numberOfRounds;
    private static bool _isDrafting;

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

    public static string TeamIdList
    {
        get
        {
            return _teamIdList;
        }
        set
        {
            _teamIdList = value;
        }
    }

    public static string TeamNameList
    {
        get
        {
            return _teamNameList;
        }
        set
        {
            _teamNameList = value;
        }
    }

    public static int NumberOfRounds
    {
        get
        {
            return _numberOfRounds;
        }
        set
        {
            _numberOfRounds = value;
        }
    }

    public static bool IsDrafting
    {
        get
        {
            return _isDrafting;
        }
        set
        {
            _isDrafting = value;
        }
    }

    public static void Instanstiate()
    {
        HttpContext.Current.Session["LeagueName"] = Constants.leagueName;
        HttpContext.Current.Session["NumberOfTeams"] = Constants.numberOfTeams;
        HttpContext.Current.Session["TeamIdList"] = Constants.teamIdList;
        HttpContext.Current.Session["TeamNameList"] = Constants.teamNameList;
        HttpContext.Current.Session["NumberOfRounds"] = Constants.numberOfRounds;
        HttpContext.Current.Session["IsDrafting"] = Constants.isDrafting;
    }
}