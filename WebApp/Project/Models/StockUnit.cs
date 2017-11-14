using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WMSNet.Model.Models
{
    public class StockUnit:TrackableEntity
    {
        [Key]
        public int StockUnitID { get; set; }
        public string AdditionalContent { get; set; }
        public decimal Amount { get; set; }
        public string LabelID { get; set; }
        public decimal ReservedAmount { get; set; }
        public string SerialNumber { get; set; }
        public DateTime StrategyDate { get; set; }
        public int UnitLoadID { get; set; }
        public int LotID { get; set; }
        public int ItemDataID { get; set; }
        public int ClientID { get; set; }
        public virtual Client Client { get; set; }
        public virtual UnitLoad UnitLoad { get; set; }
        public virtual ItemData ItemData { get; set; }
        public virtual Lot Lot { get; set; }
        public virtual ICollection<GrrPosition> GoodsReceipt { get; set; }
        public virtual ICollection<PickingPos> PickingPos { get; set; }
        public virtual ICollection<ReplenishOrder> ReplenishOrder { get; set; }
    }
}
