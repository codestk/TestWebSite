using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WMSNet.Model.Models
{
    public partial class Lot:TrackableEntity
    {
        [Key]
        public int LotID { get; set; }
        public string AdditionalContent { get; set; }

        public int Version { get; set; }
        public string Age { get; set; }
        public Nullable<System.DateTime> BestBeforeBnd { get; set; }
        public string Code { get; set; }
        public System.DateTime Lot_Date { get; set; }
        public Nullable<decimal> Depth { get; set; }
        public Nullable<decimal> Height { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> UseNotBefore { get; set; }
        public Nullable<decimal> Volume { get; set; }
        public Nullable<decimal> Weight { get; set; }
        public Nullable<decimal> Width { get; set; }
        public int ClientID { get; set; }
        public int StockUnitID { get; set; }
        public int ItemDataID { get; set; }
        public virtual Client Client { get; set; }
        public virtual ItemData ItemData { get; set; }
        public virtual ICollection<AvisReq> AvisReq { get; set; }
        public virtual ICollection<CustomerPos> CustomerPos { get; set; }
        public virtual ICollection<PickingPos> PickingPos { get; set; }
        public virtual ICollection<ReplenishOrder> ReplenishOrder { get; set; }
        public virtual ICollection<StockUnit> StockUnit { get; set; }
        public virtual ICollection<UlAdvicePos> UlAdvicePos { get; set; }
    }
}
