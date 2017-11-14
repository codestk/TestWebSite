using System;
using System.ComponentModel.DataAnnotations;

namespace WMSNet.Model.Models
{
    public partial class ReplenishOrder : TrackableEntity
    {
        [Key]
        public int ReplenishOrderID { get; set; }
        public string AdditionalContent { get; set; }

        public int Version { get; set; }
        public string Number { get; set; }
        public int Prio { get; set; }
        public Nullable<decimal> RequestedAmount { get; set; }
        public string SourceLocationName { get; set; }
        public int State { get; set; }
        public Nullable<int> OperatorID { get; set; }
        public Nullable<int> StockUnitID { get; set; }
        public Nullable<int> RequestedLocationID { get; set; }
        public int ItemDataID { get; set; }
        public int ClientID { get; set; }
        public Nullable<int> RequestedRackID { get; set; }
        public Nullable<int> LotID { get; set; }
        public Nullable<int> DestinationID { get; set; }
        public virtual StorLoc StorLoc { get; set; }
        public virtual User User { get; set; }
        public virtual Client Client { get; set; }
        public virtual Rack Rack { get; set; }
        public virtual ItemData ItemData { get; set; }
        public virtual StockUnit StockUnit { get; set; }
        public virtual Lot Lot { get; set; }
    }
}
