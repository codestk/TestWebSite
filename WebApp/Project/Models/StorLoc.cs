using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WMSNet.Model.Models
{
    public partial class StorLoc : TrackableEntity
    {
        [Key]
        public int StorLocID { get; set; }
        public string AdditionalContent { get; set; }

        public int Version { get; set; }
        public int Xpos { get; set; }
        public int Ypos { get; set; }
        public int Zpos { get; set; }
        public decimal Allocation { get; set; }
        public int AllocationState { get; set; }
        public string Field { get; set; }
        public int FieldIndex { get; set; }
        public string Name { get; set; }
        public int OrderIndex { get; set; }
        public string PlcCode { get; set; }
        public string ScanCode { get; set; }
        public Nullable<System.DateTime> StockTakingDate { get; set; }
        public int AreaID { get; set; }
        public int TypeID { get; set; }
        public Nullable<int> Currenttcc { get; set; }
        public Nullable<int> ZoneID { get; set; }
        public Nullable<int> RackID { get; set; }
        public int ClientID { get; set; }
        public Nullable<int> ClusterID { get; set; }
        public virtual StorageLocationType StorageLocationType { get; set; }
        public virtual LocationCluster LocationCluster { get; set; }
        public virtual Zone Zone { get; set; }
        public virtual Rack Rack { get; set; }
        public virtual Client Client { get; set; }
        public virtual Area Area { get; set; }
        public virtual TypeCapacityConstraint TypeCapacityConstraint { get; set; }
        public virtual ICollection<CustomerOrder> CustomerOrder { get; set; }
        public virtual ICollection<FixAssgn> FixAssgn { get; set; }
        public virtual ICollection<GoodsReceipt> GoodsReceipt { get; set; }
        public virtual ICollection<OrderStrat> OrderStrat { get; set; }
        public virtual ICollection<OutReq> OutReq { get; set; }
        public virtual ICollection<PickingOrder> PickingOrder { get; set; }
        public virtual ICollection<ReplenishOrder> ReplenishOrder { get; set; }
        public virtual ICollection<StorageReq> StorageReq { get; set; }
        public virtual ICollection<UnitLoad> UnitLoad { get; set; }
    }
}
