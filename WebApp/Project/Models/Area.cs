using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace WMSNet.Model.Models
{
    public partial class Area:TrackableEntity
    {

        public Area()
        {
            StorLoc = new List<StorLoc>();
        }

        [Key]
        public int AreaID { get; set; }
        public int Version { get; set; }
        public string Name { get; set; }
        public bool UseForGoodsIn { get; set; }
        public bool UseForGoodsOut { get; set; }
        public bool UseForPicking { get; set; }
        public bool UseForReplenish { get; set; }
        public bool UseForStorage { get; set; }
        public bool UseForTransfer { get; set; }
        public int ClientID { get; set; }
        public virtual Client Client { get; set; }
        public virtual ICollection<StorLoc> StorLoc { get; set; }
    }
}
