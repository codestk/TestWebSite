using System;
using System.ComponentModel.DataAnnotations;

namespace WMSNet.Model.Models
{
    public partial class StorageStrat : TrackableEntity
    {
        [Key]
        public int StorageStratID { get; set; }
        public string AdditionalContent { get; set; }

        public int Version { get; set; }
        public int ClientMode { get; set; }
        public bool MixClient { get; set; }
        public bool MixItem { get; set; }
        public string Name { get; set; }
        public int OrderbyMode { get; set; }
        public bool UseItemZone { get; set; }
        public int UsePicking { get; set; }
        public int UseStorage { get; set; }
        public Nullable<int> ZoneID { get; set; }
        public virtual Zone Zone { get; set; }
    }
}
