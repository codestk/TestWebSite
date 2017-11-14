using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WMSNet.Model.Models
{
    public class AvisReq : TrackableEntity
    {
        public AvisReq()
        {
            this.GoodsReceipt_AvisReq = new List<GoodsReceiptAvisReq>();
            this.GoodsReceipt = new List<GrrPosition>();
            this.UlAdvice = new List<UlAdvice>();
        }

        [Key]
        public int AvisReqID { get; set; }
        public string AdditionalContent { get; set; }
        public int Version { get; set; }
        public string AdviceNumber { get; set; }
        public string AdviceState { get; set; }
        public Nullable<System.DateTime> ExpectedDelivery { get; set; }
        public bool ExpireBatch { get; set; }
        public string ExternalNo { get; set; }
        public string ExternalID { get; set; }
        public Nullable<System.DateTime> FinishDate { get; set; }
        public Nullable<decimal> NotifiedAmount { get; set; }
        public Nullable<System.DateTime> ProcessDate { get; set; }
        public Nullable<decimal> ReceiptAmount { get; set; }
        public int ItemDataID { get; set; }
        public Nullable<int> LotID { get; set; }
        public int ClientID { get; set; }
        public virtual Client Client { get; set; }
        public virtual ItemData ItemData { get; set; }
        public virtual Lot Lot { get; set; }
        public virtual ICollection<GoodsReceiptAvisReq> GoodsReceipt_AvisReq { get; set; }
        public virtual ICollection<GrrPosition> GoodsReceipt { get; set; }
        public virtual ICollection<UlAdvice> UlAdvice { get; set; }
    }
}
