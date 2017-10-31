using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ControlsProperties
/// </summary>
public class SelectInputProperties
{
    //
    public string text { get; set; }

    public string value { get; set; }

    public static List<SelectInputProperties> DataSetToList(DataSet ds)
    {
        EnumerableRowCollection<SelectInputProperties> q = (from temp in ds.Tables[0].AsEnumerable()
                                                            select new SelectInputProperties
                                                            {
                                                                value = temp.Field<Object>(0).ToString(),
                                                                text = temp.Field<Object>(1).ToString()
                                                                //Data = temp.Field<object>[0],
                                                                //Value = temp.Field<object>[1]
                                                            });
        return q.ToList();
    }
}