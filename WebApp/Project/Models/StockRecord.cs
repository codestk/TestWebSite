using System;
using System.ComponentModel.DataAnnotations;

namespace WMSNet.Model.Models
{
    public partial class StockRecord : TrackableEntity
    {
        [Key]
        public int StockRecordID { get; set; }
        public string AdditionalContent { get; set; }

        public int Version { get; set; }
        public string ActivityCode { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> AmountStock { get; set; }
        public string FromStockUnitIdentity { get; set; }
        public string FromStoragelocation { get; set; }
        public string FromUnitload { get; set; }
        public string ItemData { get; set; }
        public string Lot { get; set; }
        public string Operator { get; set; }
        public int Scale { get; set; }
        public string SerialNumber { get; set; }
        public string ToStockUnitIdentity { get; set; }
        public string ToStorageLocation { get; set; }
        public string ToUnitLoad { get; set; }
        public string Type { get; set; }
        public string UnitLoadType { get; set; }
        public int ClientID { get; set; }
        public virtual Client Client { get; set; }
    }
}
