using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WMSNet.Model.Models
{
    public partial class PickingUnitLoad : TrackableEntity
    {
        [Key]
        public int PickingUnitLoadID { get; set; }
        public string AdditionalContent { get; set; }

        public int Version { get; set; }
        public string CustomerOrderNumber { get; set; }
        public int PositionIndex { get; set; }
        public int State { get; set; }
        public Nullable<int> UnitLoadID { get; set; }
        public int ClientID { get; set; }
        public int PickingOrderID { get; set; }
        public virtual Client Client { get; set; }
        public virtual UnitLoad UnitLoad { get; set; }
        public virtual PickingOrder PickingOrder { get; set; }
        public virtual ICollection<PickingPos> PickingPos { get; set; }
    }
}
