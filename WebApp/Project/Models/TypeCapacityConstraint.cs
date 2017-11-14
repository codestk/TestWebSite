using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WMSNet.Model.Models
{
    public partial class TypeCapacityConstraint : TrackableEntity
    {
        [Key]
        public int TypeCapacityConstraintID { get; set; }
        public string AdditionalContent { get; set; }

        public int Version { get; set; }
        public decimal Allocation { get; set; }
        public int AllocationType { get; set; }
        public int UnitLoadTypeID { get; set; }
        public int StorageLocationTypeID { get; set; }
        public virtual UnitLoadType UnitLoadType { get; set; }
        public virtual StorageLocationType StorageLocationType { get; set; }
        public virtual ICollection<StorLoc> StorLoc { get; set; }
    }
}
