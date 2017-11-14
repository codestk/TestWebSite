using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WMSNet.Model.Models
{
    public partial class GoodsReceipt : TrackableEntity
    {
        [Key]
        public int GoodsReceiptID { get; set; }
        public string AdditionalContent { get; set; }
        public int Version { get; set; }
        public string DelNote { get; set; }
        public string DriverName { get; set; }
        public string Forwarder { get; set; }
        public string Gr_Number { get; set; }
        public string LicencePlate { get; set; }
        public Nullable<System.DateTime> ReceiptDate { get; set; }
        public string ReceiptState { get; set; }
        public string ReferenceNo { get; set; }
        public int ClientID { get; set; }
        public Nullable<int> OperatorID { get; set; }
        public Nullable<int> GoodsInLocationID { get; set; }
        public virtual User User { get; set; }
        public virtual Client Client { get; set; }
        public virtual StorLoc StorLoc { get; set; }
        public virtual ICollection<GoodsReceiptAvisReq> GoodsReceipt_AvisReq { get; set; }
        public virtual ICollection<GrrPosition> GrrPosition { get; set; }
    }
}
