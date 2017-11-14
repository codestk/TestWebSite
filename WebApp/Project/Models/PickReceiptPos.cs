using System;
using System.ComponentModel.DataAnnotations;

namespace WMSNet.Model.Models
{
    public partial class PickReceiptPos : TrackableEntity
    {
        [Key]
        public int PickReceiptPosID { get; set; }
        public string AdditionalContent { get; set; }

        public int Version { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> AmountOrdered { get; set; }
        public string ArticleDescr { get; set; }
        public string ArticleRef { get; set; }
        public string LotRef { get; set; }
        public Nullable<int> ReceiptID { get; set; }
        public virtual PickReceipt PickReceipt { get; set; }
    }
}
