using System;
using System.ComponentModel.DataAnnotations;

namespace WMSNet.Model.Models
{
    public partial class PickingPos : TrackableEntity
    {
        [Key]
        public int PickingPosID { get; set; }
        public string AdditionalContent { get; set; }

        public int Version { get; set; }
        public decimal Amount { get; set; }
        public decimal AmountPicked { get; set; }
        public string PickFromLocationName { get; set; }
        public string PickOromUnitLoadLabel { get; set; }
        public string PickingOrderNumber { get; set; }
        public int PickingType { get; set; }
        public int State { get; set; }
        public int StrategyID { get; set; }
        public Nullable<int> PickingOrderID { get; set; }
        public int ClientID { get; set; }
        public Nullable<int> PickFromStockUnitID { get; set; }
        public Nullable<int> CustomerOrderPositionID { get; set; }
        public Nullable<int> LotPickedID { get; set; }
        public int ItemDataID { get; set; }
        public Nullable<int> PickToUnitLoadID { get; set; }
        public virtual Lot Lot { get; set; }
        public virtual Client Client { get; set; }
        public virtual StockUnit StockUnit { get; set; }
        public virtual PickingUnitLoad PickingUnitLoad { get; set; }
        public virtual OrderStrat OrderStrat { get; set; }
        public virtual PickingOrder PickingOrder { get; set; }
        public virtual CustomerPos CustomerPos { get; set; }
        public virtual ItemData ItemData { get; set; }
    }
}
