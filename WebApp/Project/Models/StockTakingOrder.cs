using System;
using System.ComponentModel.DataAnnotations;

namespace WMSNet.Model.Models
{
    public partial class StockTakingOrder : TrackableEntity
    {
        [Key]
        public int StockTakingOrderID { get; set; }
        public string AdditionalContent { get; set; }

        public int Version { get; set; }
        public string AreaName { get; set; }
        public Nullable<System.DateTime> CountingDate { get; set; }
        public string LocationName { get; set; }
        public string Operator { get; set; }
        public Nullable<int> State { get; set; }
        public string UnitLoadLabel { get; set; }
        public Nullable<int> StockTakingID { get; set; }
        public virtual StockTaking StockTaking { get; set; }
    }
}
