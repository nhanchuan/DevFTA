using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using DataAccessLayer;

/// <summary>
/// Summary description for ClsSession
/// </summary>
public static class ClsSession
{
    public static void SetCurrentUser(this HttpSessionState session, UserAdmin user)
    {
        session["currentUser"] = user;
    }
    public static UserAdmin GetCurrentUser(this HttpSessionState session)
    {
        return session["currentUser"] as UserAdmin;
    }
    //session URL
    public static void SetCurrentURL(this HttpSessionState session, string url)
    {
        session["currentURL"] = url;
    }
    public static string GetCurrentURL(this HttpSessionState session)
    {
        return session["currentURL"] as String;
    }
}