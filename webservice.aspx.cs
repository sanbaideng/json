using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.Services;

public partial class webservice : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [WebMethod]
    public static string HelloWorld()
    {
        return "123--->456";
    }
    [WebMethod]
    public static string ABC(string ABC)
    {
        return ABC;
    }
    [WebMethod]
    public static string GetWish(string value1, string value2, string value3, int value4)
    {
        return string.Format("祝您在{3}年里 {0}、{1}、{2}", value1, value2, value3, value4);
    }
    /// <summary>
    /// 返回集合
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    [WebMethod]
    public static List<int> GetArray(int i)
    {
        List<int> list = new List<int>();

        while (i >= 0)
        {
            list.Add(i--);
        }

        return list;
    }

    /// <summary>
    /// 返回一个复合类型
    /// </summary>
    /// <returns></returns>
    [WebMethod]
    public static Class1 GetClass()
    {
        return new Class1 { ID = "1", Value = "牛年大吉" };
    }


    /// <summary>
    /// 返回XML
    /// </summary>
    /// <returns></returns>
    [WebMethod]
    public static DataSet GetDataSet()
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        dt.Columns.Add("ID", Type.GetType("System.String"));
        dt.Columns.Add("Value", Type.GetType("System.String"));
        DataRow dr = dt.NewRow();
        dr["ID"] = "1";
        dr["Value"] = "新年快乐";
        dt.Rows.Add(dr);
        dr = dt.NewRow();
        dr["ID"] = "2";
        dr["Value"] = "万事如意";
        dt.Rows.Add(dr);
        ds.Tables.Add(dt);
        return ds;
    }
    public class Class1
    {
        public string ID { get; set; }
        public string Value { get; set; }
    }

}
