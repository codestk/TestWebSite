using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WMSNet.Model.Models
{
    public class StorageLocationType : TrackableEntity
    {
        [Key]
        public int StorageLocationTypeID { get; set; }
        public string AdditionalContent { get; set; }

        public decimal Depth { get; set; }
        public int HandlingFlag { get; set; }
        public decimal Height { get; set; }
        public decimal LiftingCapacity { get; set; }
        public string SltName { get; set; }
        public decimal Volume { get; set; }
        public decimal Width { get; set; }
        public virtual ICollection<StorLoc> StorLoc { get; set; }
        public virtual ICollection<TypeCapacityConstraint> TypeCapacityConstraint { get; set; }
    }
}
