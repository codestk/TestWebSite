using System;
using System.ComponentModel.DataAnnotations;

namespace WMSNet.Model.Models
{
    public partial class OrderReceiptPos:TrackableEntity
    {
        [Key]
        public int OrderReceiptPosID { get; set; }
        public string AdditionalContent { get; set; }
        public int Version { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> AmountOrdered { get; set; }
        public string ArticleDescr { get; set; }
        public string ArticleRef { get; set; }
        public int ArticleScale { get; set; }
        public string LotRef { get; set; }
        public int Pos { get; set; }
        public int ClientID { get; set; }
        public Nullable<int> ReceiptID { get; set; }
        public virtual OrderReceipt OrderReceipt { get; set; }
        public virtual Client Client { get; set; }
    }
}
