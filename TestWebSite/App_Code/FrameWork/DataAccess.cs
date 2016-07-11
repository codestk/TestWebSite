using CoreDb;
using System.Web.UI.WebControls;

public class DataAccess
{
    public DataAccessLayer Db;

    public DataAccess()
    {
        if (Config.ConnectionString() == null)
        {
            throw new System.Exception("Connection Error");
        }

        var connecStionstring = Config.ConnectionString();
        Db = new DataBaseSql(connecStionstring);
        //Db = new DataBaseFireBird(connecStionstring);
    }

    //=====================================================================================================

    /// <summary>
    ///  Utility Sort
    /// </summary>
    /// <param name="sortAscending"></param>
    /// <param name="sortExpression"></param>
    /// <returns></returns>
    public string GenSort(SortDirection _SortDirection, string _SortExpression)
    {
        bool sortAscending = _SortDirection == SortDirection.Ascending;
        var sort = "";
        if (_SortExpression == null)
        {
            //sort += "order by 1 asc";
            throw new System.Exception("Error");
        }
        else
        {
            sort += string.Format(" order by {0}", _SortExpression);
            sort += (sortAscending ? "" : " desc");
        }

        return sort;
    }
}