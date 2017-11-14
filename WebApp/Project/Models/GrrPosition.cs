using System;
using System.ComponentModel.DataAnnotations;

namespace WMSNet.Model.Models
{
    public partial class GrrPosition : TrackableEntity
    {
        [Key]
        public int GrrPositionID { get; set; }
        public string AdditionalContent { get; set; }
        public int Version { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string ItemData { get; set; }
        public string Lot { get; set; }
        public string OrderReference { get; set; }
        public string PositionNumber { get; set; }
        public string Qafault { get; set; }
        public int Qalock { get; set; }
        public string ReceiptType { get; set; }
        public int Scale { get; set; }
        public Nullable<int> State { get; set; }
        public string StockUnitStr { get; set; }
        public string UnitLoad { get; set; }
        public int ClientID { get; set; }
        public Nullable<int> GoodsReceiptID { get; set; }
        public Nullable<int> OperatorID { get; set; }
        public Nullable<int> StockUnitID { get; set; }
        public Nullable<int> RelatedAdviceID { get; set; }
        public virtual User User { get; set; }
        public virtual Client Client { get; set; }
        public virtual GoodsReceipt GoodsReceipt { get; set; }
        public virtual AvisReq AvisReq { get; set; }
        public virtual StockUnit StockUnit { get; set; }
    }
}
