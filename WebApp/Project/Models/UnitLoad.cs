using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WMSNet.Model.Models
{
    public partial class UnitLoad : TrackableEntity
    {
        [Key]
        public string DType { get; set; }
        public int UnitLoadID { get; set; }
        public string AdditionalContent { get; set; }
    
        public int Version { get; set; }
        public Nullable<int> Location_Index { get; set; }
        public string LabelID { get; set; }
        public bool Carrier { get; set; }
        public Nullable<int> CarrierUnitLoadID { get; set; }
        public bool Opened { get; set; }
        public string PackageType { get; set; }
        public Nullable<System.DateTime> StockTakingDate { get; set; }
        public Nullable<decimal> Weight { get; set; }
        public Nullable<decimal> WeightCalculated { get; set; }
        public Nullable<decimal> WeightMeasure { get; set; }
        public int ClientID { get; set; }
        public int StorageLocationID { get; set; }
        public int TypeID { get; set; }
        public virtual UnitLoadType UnitLoadType { get; set; }
        public virtual Client Client { get; set; }
        public virtual StorLoc StorLoc { get; set; }
        public virtual ICollection<OutPos> OutPos { get; set; }
        public virtual ICollection<PickingUnitLoad> PickingUnitLoad { get; set; }
        public virtual ICollection<StockUnit> StockUnit { get; set; }
        public virtual ICollection<StorageReq> StorageReq { get; set; }
    }
}
