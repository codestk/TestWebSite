using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WMSNet.Model.Models
{
    public partial class StockTaking : TrackableEntity
    {
        [Key]
        public int StockTakingID { get; set; }
        public string AdditionalContent { get; set; }

        public int Version { get; set; }
        public Nullable<System.DateTime> Ended { get; set; }
        public Nullable<System.DateTime> Started { get; set; }
        public string StockTakingNumber { get; set; }
        public string StockTakingType { get; set; }
        public virtual ICollection<StockTakingOrder> StockTakingOrder { get; set; }
    }
}
