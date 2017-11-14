using System;
using System.Collections.Generic;

namespace WMSNet.Model.Models
{
    public class Zone : TrackableEntity
    {
        public int ZoneID { get; set; }
        public string AdditionalContent { get; set; }

        public string Name { get; set; }
        public int ClientID { get; set; }
        public virtual Client Client { get; set; }
        public virtual ICollection<ItemData> ItemData { get; set; }
        public virtual ICollection<StorageStrat> StorageStrat { get; set; }
        public virtual ICollection<StorLoc> StorLoc { get; set; }
    }
}
