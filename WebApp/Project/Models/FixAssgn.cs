using System;
using System.ComponentModel.DataAnnotations;

namespace WMSNet.Model.Models
{
    public partial class FixAssgn : TrackableEntity
    {
        [Key]
        public int FixAssgnID { get; set; }
        public string AdditionalContent { get; set; }
        public int Version { get; set; }
        public decimal DesiredAmount { get; set; }
        public int ItemDataID { get; set; }
        public int AssignedLocationID { get; set; }
        public virtual StorLoc StorLoc { get; set; }
        public virtual ItemData ItemData { get; set; }
    }
}
