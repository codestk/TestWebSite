using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WMSNet.Model.Models
{
    public partial class OrderStrat:TrackableEntity
    {
        [Key]
        public int OrderStratID { get; set; }
        public string AdditionalContent { get; set; }
      
        public int Version { get; set; }
        public bool CreateFollowUpPicks { get; set; }
        public bool CreateGoodsOutOrder { get; set; }
        public int ManualCreationIndex { get; set; }
        public string Name { get; set; }
        public bool PreferMatchingStock { get; set; }
        public bool PreferUnopened { get; set; }
        public bool UseLockedLot { get; set; }
        public bool UseLockedStock { get; set; }
        public int ClientID { get; set; }
        public Nullable<int> DefaultDestinationID { get; set; }
        public virtual Client Client { get; set; }
        public virtual StorLoc StorLoc { get; set; }
        public virtual ICollection<CustomerOrder> CustomerOrder { get; set; }
        public virtual ICollection<PickingOrder> PickingOrder { get; set; }
        public virtual ICollection<PickingPos> PickingPos { get; set; }
    }
}
