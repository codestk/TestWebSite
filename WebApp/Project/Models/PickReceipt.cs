using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WMSNet.Model.Models
{
    public partial class PickReceipt
    {
        [Key]
        public int PickReceiptID { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string LabelID { get; set; }
        public string OrderNumber { get; set; }
        public string PickNumber { get; set; }
        public string State { get; set; }
        public virtual Document Document { get; set; }
        public virtual ICollection<PickReceiptPos> PickReceiptPos { get; set; }
    }
}
