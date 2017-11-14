using System;
using System.ComponentModel.DataAnnotations;

namespace WMSNet.Model.Models
{
    public partial class WorkingAreaPos : TrackableEntity
    {
        [Key]
        public int WorkingAreaPosID { get; set; }
        public string AdditionalContent { get; set; }
 
        public int Version { get; set; }
        public int WorkingAreaID { get; set; }
        public int ClusterID { get; set; }
        public virtual LocationCluster LocationCluster { get; set; }
        public virtual WorkingArea WorkingArea { get; set; }
    }
}
