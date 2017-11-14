using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WMSNet.Model.Models
{
    public partial class Document:TrackableEntity
    {
        [Key]
        public int DocumentID { get; set; }
        public string AdditionalContent { get; set; }
        public int Version { get; set; }
        public int dcmnt { get; set; }
        public string Name { get; set; }
        public Nullable<int> Document_Size { get; set; }
        public string Type { get; set; }
        public int ClientID { get; set; }
        public virtual Client Client { get; set; }
        public virtual ICollection<OrderReceipt> OrderReceipt { get; set; }
        public virtual ICollection<PickReceipt> PickReceipt { get; set; }
        public virtual ICollection<SlLabel> SlLabel { get; set; }
        public virtual ICollection<SuLabel> SuLabel { get; set; }
    }
}
