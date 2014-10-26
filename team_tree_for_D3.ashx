<%@ WebHandler Language="C#" Class="team_tree" %>

using System;
using System.Web;

public class team_tree : IHttpHandler {

    public static string connstr = System.Configuration.ConfigurationManager.ConnectionStrings["yyang"].ConnectionString;
    yyang.OraDbHelper data = new yyang.OraDbHelper(connstr);
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string s[] ;
        string sql_team_0 = "select * from app_team t where t.parent_team_id is null order by t.team_id";
        System.Data.DataTable dt = data.ExecuteDataTable(sql_team_0);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
          s[i] = combination(dt.Rows[i]["team_id"].ToString()); 
          //s = s+combination(dt.Rows[i]["team_id"].ToString()); 
        }
        
        context.Response.Write(s);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }
    public string combination(string id)
    {
        string s = "";
        string sql = "select t.team_id from app_team t where t.parent_team_id='" + id + "'";
        System.Data.DataTable dt = data.ExecuteDataTable(sql);
        int count = dt.Rows.Count;
        if (count==0)
        {
            s =  "{name:\"" + id + "\"}";
        }
        else
	    {
            //string sql_child = "select * from app_team t where t.parent_team_id='"++"'";
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                s = "name:\"" + dt.Rows[0]["team_id"].ToString() + "\",contents:[" + combination(dt.Rows[0]["team_id"].ToString()) + "]"; 
            }                     
	    } 
        return "{" + s + "}";
    }
}