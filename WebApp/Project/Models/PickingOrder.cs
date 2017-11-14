using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WMSNet.Model.Models
{
    public partial class PickingOrder : TrackableEntity
    {
        [Key]
        public int PickingOrderID { get; set; }
        public string AdditionalContent { get; set; }

        public int Version { get; set; }
        public string CustomerOrderNumber { get; set; }
        public bool ManualCreation { get; set; }
        public string Number { get; set; }
        public int Prio { get; set; }
        public int State { get; set; }
        public int ClientID { get; set; }
        public Nullable<int> DestinationID { get; set; }
        public Nullable<int> OperatorID { get; set; }
        public int StrategyID { get; set; }
        public virtual StorLoc StorLoc { get; set; }
        public virtual User User { get; set; }
        public virtual Client Client { get; set; }
        public virtual OrderStrat OrderStrat { get; set; }
        public virtual ICollection<PickingPos> PickingPos { get; set; }
        public virtual ICollection<PickingUnitLoad> PickingUnitLoad { get; set; }

    }
}
