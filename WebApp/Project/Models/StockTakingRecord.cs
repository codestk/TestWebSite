using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WMSNet.Model.Models
{
    public partial class StockTakingRecord : TrackableEntity
    {
        [Key]
        public int StockTakingRecordID { get; set; }
        public string AdditionalContent { get; set; }

        public int Version { get; set; }
        public string ClientNo { get; set; }
        public Nullable<decimal> CountedQuantity { get; set; }
        public Nullable<int> CountedStockID { get; set; }
        public string ItemNo { get; set; }
        public string LocationName { get; set; }
        public string LotNo { get; set; }
        public Nullable<decimal> PlannedQuantity { get; set; }
        public string SerialNo { get; set; }
        public Nullable<int> State { get; set; }
        public string UlTypeNo { get; set; }
        public string UnitLoadLabel { get; set; }
        public Nullable<int> StockTakingOrderID { get; set; }
        public virtual ICollection<StockTakingOrder> StockTakingOrder { get; set; }
    }
}
