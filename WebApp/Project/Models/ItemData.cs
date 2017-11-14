using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WMSNet.Model.Models
{
    public class ItemData : TrackableEntity
    {
        [Key]
        public int ItemDataID { get; set; }
        public string AdditionalContent { get; set; }
        public bool AdviceMandatory { get; set; }
        public int Depth { get; set; }
        public string Descr { get; set; }
        public int Height { get; set; }
        public bool LotMandatory { get; set; }
        public string LotSubstitutionType { get; set; }
        public string Name { get; set; }
        public string Item_nr { get; set; }
        public int Rest_Usage_gi { get; set; }
        public int SafetyStock { get; set; }
        public int Scale { get; set; }
        public string SerialRecType { get; set; }
        public string TradeGroup { get; set; }
        public decimal Volume { get; set; }
        public decimal Weight { get; set; }
        public decimal Width { get; set; }
        public int ClientID { get; set; }
        public int ZoneID { get; set; }
        public int DefaultTypeID { get; set; }
        public ICollection<StockUnit> StockUnits { get; set; }
        public virtual ItemUnit ItemUnit { get; set; }
        public virtual Zone Zone { get; set; }
        public virtual Client Client { get; set; }
        public virtual UnitLoadType UnitLoadType { get; set; }
        public virtual ICollection<AvisReq> AvisReq { get; set; }
        public virtual ICollection<BOM> BOM { get; set; }
        public virtual ICollection<CustomerPos> CustomerPos { get; set; }
        public virtual ICollection<FixAssgn> FixAssgn { get; set; }
        public virtual ICollection<ItemDataNumber> ItemDataNumber { get; set; }
        public virtual ICollection<Lot> Lot { get; set; }
        public virtual ICollection<PickingPos> PickingPos { get; set; }
        public virtual ICollection<ReplenishOrder> ReplenishOrder { get; set; }
        public virtual ICollection<StockUnit> StockUnit { get; set; }
        public virtual ICollection<UlAdvicePos> UlAdvicePos { get; set; }

        public ItemData()
        {

        }
    }
}
