using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
public class SearchUtility
{
    #region GenWhere Condition

    public static string SqlContain(string words)
    {
        string code = "";

        if (words != "")
        {
           
            code = "Where ";
          
            code += SearchUtility.GenWordfilter(words);
        }
        return code;
    }
    public static string GenWordfilter(string str)
    {



        string sql = "";

        str = str.Trim();
        str = RemoveSomeStringCode(str);
        //For "bang mod "
        var reg = new Regex("\".*?\"");
        var matches = reg.Matches(str);
        foreach (var item in matches)
        {
            if (item == "")
            {
                continue;
            }

            sql += "contains(*,'" + item.ToString() + "') and ";
            //Console.WriteLine(item.ToString());
        }

        //Remove Words in A "NNN BBBB" VVV
        str = Regex.Replace(str, "\".*?\"", "");

        //For A B C D
        string[] words = str.Split(' ');
        foreach (string word in words)
        {
            if (word == "")
            {
                continue;
            }


            sql += "contains(*,'" + word + "') and ";
        }

        sql = sql.Trim();
        sql = TrimTextEnd(sql, "and");

        return sql;
    }

    //public static string GenServicesfilter(string str)
    //{
    //    string sql = "";

    //    str = str.Trim();
    //    str = RemoveSomeStringCode(str);

    //    //For A B C D
    //    string[] words = str.Split(' ');
    //    foreach (string word in words)
    //    {
    //        if (word == "")
    //        {
    //            continue;
    //        }


    //        sql += " ([" + word + "] ='x')  and  ";
    //    }

    //    sql = sql.Trim();
    //    sql = TrimTextEnd(sql, "and");
    //    if (sql != "")
    //    {
    //        sql = "(" + sql + ")";
    //    }
    //    return sql;
    //}



    public static string RemoveSomeStringCode(string str)
    {
        char tab = '\u0009';
        String line = str.Replace(tab.ToString(), " ");
        return line;
    }

    public static  string TrimTextEnd(string source, string value)
    {
        if (!source.EndsWith(value))
            return source;

        return source.Remove(source.LastIndexOf(value));
    }
    #endregion

}