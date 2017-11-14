using System;
using System.ComponentModel.DataAnnotations;

namespace WMSNet.Model.Models
{
    public partial class ItemDataNumber : TrackableEntity
    {
        [Key]
        public int ItemDataNumberID { get; set; }
        public string AdditionalContent { get; set; }
        public int Version { get; set; }
        public int Index { get; set; }
        public string ManufacturerName { get; set; }
        public string Number { get; set; }
        public int ClientID { get; set; }
        public int ItemDataID { get; set; }
        public virtual Client Client { get; set; }
        public virtual ItemData ItemData { get; set; }

    }
}
