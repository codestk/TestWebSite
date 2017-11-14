using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WMSNet.Model.Models
{
    public partial class LocationCluster : TrackableEntity
    {
        [Key]
        public int LocationClusterID { get; set; }
        public string AdditionalContent { get; set; }
        public int Version { get; set; }
        public Nullable<int> Level { get; set; }
        public string Name { get; set; }
        public virtual ICollection<StorLoc> StorLoc { get; set; }
        public virtual ICollection<WorkingAreaPos> WorkingAreaPos { get; set; }
    }
}
