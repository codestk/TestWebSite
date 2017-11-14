using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WMSNet.Model.Models
{
    public partial class CustomerPos : TrackableEntity
    {
        [Key]
        public int CustomerPosID { get; set; }
        public string AdditionalContent { get; set; }
        public int Version { get; set; }
        public decimal Amount { get; set; }
        public decimal AmountPicked { get; set; }
        public string ExternalID { get; set; }
        public int Index { get; set; }
        public string Number { get; set; }
        public bool PartitionAllowed { get; set; }
        public string SerialNumber { get; set; }
        public int State { get; set; }
        public int ItemDataID { get; set; }
        public int OrderID { get; set; }
        public Nullable<int> LotID { get; set; }
        public int ClientID { get; set; }
        public virtual CustomerOrder CustomerOrder { get; set; }
        public virtual Client Client { get; set; }
        public virtual ItemData ItemData { get; set; }
        public virtual Lot Lot { get; set; }
        public virtual ICollection<PickingPos> PickingPos { get; set; }
    }
}
