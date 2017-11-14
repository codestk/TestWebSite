using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WMSNet.Model.Models
{
    public partial class UnitLoadType : TrackableEntity
    {
        [Key]
        public int UnitLoadTypeID { get; set; }
        public string AdditionalContent { get; set; }

        public int Version { get; set; }
        public Nullable<decimal> Depth { get; set; }
        public Nullable<decimal> Height { get; set; }
        public Nullable<decimal> LiftingCapacity { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> Volume { get; set; }
        public Nullable<decimal> Weight { get; set; }
        public Nullable<decimal> Width { get; set; }
        public virtual ICollection<ItemData> ItemData { get; set; }
        public virtual ICollection<TypeCapacityConstraint> TypeCapacityConstraint { get; set; }
        public virtual ICollection<UlAdvice> UlAdvice { get; set; }
        public virtual ICollection<UnitLoad> UnitLoad { get; set; }
    }
}
