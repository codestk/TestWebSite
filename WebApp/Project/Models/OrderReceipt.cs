using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WMSNet.Model.Models
{
    public partial class OrderReceipt 
    {
        [Key]
        public int OrderReceiptID { get; set; }
        public System.DateTime Date { get; set; }
        public string Destination { get; set; }
        public string OrderNumber { get; set; }
        public string OrderReference { get; set; }
        public string OrderType { get; set; }
        public string State { get; set; }
        public string User_ { get; set; }
        public virtual Document Document { get; set; }
        public virtual ICollection<OrderReceiptPos> OrderReceiptPos { get; set; }
    }
}
