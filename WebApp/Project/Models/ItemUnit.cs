using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WMSNet.Model.Models
{
    public class ItemUnit : TrackableEntity
    {
        [Key]
        public int ItemUnitID { get; set; }
        public string AdditionalContent { get; set; }
        public int BaseFactor { get; set; }
        public string UnitName { get; set; }
        public string UnitType { get; set; }
        public int ClientID { get; set; }
        public virtual ICollection<ItemData> ItemData { get; set; }
    }
}
