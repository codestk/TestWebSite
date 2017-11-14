using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WMSNet.Model.Models
{
    public partial class Rack : TrackableEntity
    {
        [Key]
        public int RackID { get; set; }
        public string AdditionalContent { get; set; }

        public int Version { get; set; }
        public string Aisle { get; set; }
        public Nullable<int> LabelOffSet { get; set; }
        public string RName { get; set; }
        public int NumberOfColumns { get; set; }
        public int NumberOfRows { get; set; }
        public int ClientID { get; set; }
        public virtual Client Client { get; set; }
        public virtual ICollection<ReplenishOrder> ReplenishOrder { get; set; }
        public virtual ICollection<StorLoc> StorLoc { get; set; }
    }
}
