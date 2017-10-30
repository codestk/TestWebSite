using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for StkTableProperties
/// </summary>
public class StkRepeaterExten: System.Web.UI.Page
{
    public int PageSize = 20;

    public StkRepeaterExten()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    protected string _SortExpression
    {
        get
        {
            return ViewState["SortExpression"] as string;
        }
        set
        {
            ViewState["SortExpression"] = value;
        }
    }

    protected SortDirection _SortDirection
    {
        get
        {
            object o = ViewState["SortDirection"];
            if (o == null)
                return SortDirection.Ascending;
            //return (SortDirection)o.ToString();
            return (SortDirection)o;
        }
        set
        {
            ViewState["SortDirection"] = value;
        }
    }

    protected int CurrentPage
    {
        get
        {
            int _CurrentPage;
            if (ViewState["CurrentPage"] == null)
            {
                _CurrentPage = 1;
            }
            else
            {
                _CurrentPage = Convert.ToInt32(ViewState["CurrentPage"]);
            }
            return _CurrentPage;
        }
        set
        {
            ViewState["CurrentPage"] = value;
        }
    }

    protected int RecordCount
    {
        get
        {
            int _CurrentPage;
            if (ViewState["recordCount"] == null)
            {
                _CurrentPage = 1;
            }
            else
            {
                _CurrentPage = Convert.ToInt32(ViewState["recordCount"]);
            }
            return _CurrentPage;
        }
        set
        {
            ViewState["recordCount"] = value;
        }
    }

    protected void Sort_Click(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandSource.GetType() == typeof(LinkButton))
        {
            if (e.CommandName == _SortExpression)
            {
                if (_SortDirection == SortDirection.Ascending)
                    _SortDirection = SortDirection.Descending;
                else
                    _SortDirection = SortDirection.Ascending;
            }
            else
            {
               

                // SortExpression == e.CommandName;
                _SortExpression = e.CommandName;
                _SortDirection = SortDirection.Ascending;
            }
        }

        Bind();
    }

    virtual protected void Bind()
    {
        //for over ride
    }

    protected void Page_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        ViewState["CurrentPage"] = pageIndex;
        Bind();
    }

    protected List<ListItem> PopulatePager(int recordCount, int currentPage)
    {
        double dblPageCount = (double)((decimal)recordCount / (PageSize));
        int pageCount = (int)Math.Ceiling(dblPageCount); List<ListItem> pages = new List<ListItem>();
        if (pageCount > 0)
        {
            //ListItem First = new ListItem("<i class='material-icons'>chevron_left</i>", "1", currentPage > 1);
            ListItem First = new ListItem("<i class=''><</i>", "1", currentPage > 1);
            pages.Add(First);
            for (int i = 1; i <= pageCount; i++)
            {
                pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
            }
            //pages.Add(new ListItem("<i class='material-icons'>chevron_right</i>", pageCount.ToString(), currentPage < pageCount));
            pages.Add(new ListItem("<i class=''>></i>", pageCount.ToString(), currentPage < pageCount));
        }
        //rptSTK_USERPagger.DataSource = pages;
        //rptSTK_USERPagger.DataBind();
        return pages;
    }

    public string PaggerClass(object Enabled, object Value)
    {
        string output = "";
        Boolean isfirst = Value.ToString().ToLower().Contains("chevron_left");
        Boolean isend = Value.ToString().ToLower().Contains("chevron_right");
        if ((isfirst == true) && (Enabled.ToString().ToLower() == "false"))
        {
            return "disabled";
        }
        if ((isend == true) && (Enabled.ToString().ToLower() == "false"))
        {
            return "disabled";
        }

        string classLidisabled = "active";
        string classpageitem = "waves-effect";
        if (Enabled.ToString().ToLower() == "false")
        {
            output = classLidisabled;
        }
        else
        { output = classpageitem; }
        return output;
    }

    public string TagCheck(Object val)
    {
        string status = "";
        if (val == null)
        {
            return "";
        }

        if (Convert.ToBoolean(val) == true)
        {
           
            status = "checked";
        }
        else
        {
            status = "";
        }
        return status;
    }

    protected void rptSTK_USERData_ItemCreated(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Header)
        {
            if (_SortExpression != null)
            {
                foreach (object a in e.Item.Controls)
                {
                    if (a is LinkButton)
                    {
                        LinkButton lnk = (LinkButton)a;

                        if (lnk.CommandName == _SortExpression)
                        {
                            string icon = "";
         
                            if (_SortDirection == SortDirection.Ascending)
                            {
                                icon = "<i class=\"Small material-icons\">arrow_drop_up</i>";
                            }
                            else
                            {
                                icon = "<i class=\"Small material-icons\">arrow_drop_down</i>";
                            }
                            //<i class="Small material-icons">keyboard_arrow_up</i>
                            //<i class="Small material-icons">keyboard_arrow_down</i>

                            lnk.Text =   lnk.CommandName + " " + icon;
                        }
                        else
                        {
                            lnk.Text = lnk.CommandName;
                        }
                    }
                }
            }
        }
    }
}