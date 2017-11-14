using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WMSNet.Model.Models
{
    public partial class WorkingArea : TrackableEntity
    {
        [Key]
        public int WorkingAreaID { get; set; }
        public string AdditionalContent { get; set; }

        public int Version { get; set; }
        public string Name { get; set; }
        public virtual ICollection<WorkingAreaPos> WorkingAreaPos { get; set; }
    }
}
