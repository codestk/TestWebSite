using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WMSNet.Model.Models
{
    /// <summary>
    /// Classifies the owner of the entity, The client refers to the multi-warehouse abilities of WMSNet.
    /// </summary>
    public class Client : TrackableEntity
    {
        [Key]
        public int ClientID { get; set; }
        public string AdditionalContent { get; set; }
        public string Cl_Code { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string Name { get; set; }
        public int Cl_Nr { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<Area> Area { get; set; }
        public virtual ICollection<AvisReq> AvisReq { get; set; }
        public virtual ICollection<ClearingItem> ClearingItem { get; set; }
        public virtual ICollection<CustomerOrder> CustomerOrder { get; set; }
        public virtual ICollection<CustomerPos> CustomerPos { get; set; }
        public virtual ICollection<Document> Document { get; set; }
        public virtual ICollection<GoodsReceipt> GoodsReceipt { get; set; }
        public virtual ICollection<GrrPosition> GrrPosition { get; set; }
        public virtual ICollection<ItemData> ItemData { get; set; }
        public virtual ICollection<ItemDataNumber> ItemDataNumber { get; set; }
        public virtual ICollection<LogItem> LogItem { get; set; }
        public virtual ICollection<Lot> Lot { get; set; }
        public virtual ICollection<OrderReceiptPos> OrderReceiptPos { get; set; }
        public virtual ICollection<OrderStrat> OrderStrat { get; set; }
        public virtual ICollection<OutReq> OutReq { get; set; }
        public virtual ICollection<PickingOrder> PickingOrder { get; set; }
        public virtual ICollection<PickingPos> PickingPos { get; set; }
        public virtual ICollection<PickingUnitLoad> PickingUnitLoad { get; set; }
        public virtual ICollection<PlugInConfig> PlugInConfig { get; set; }
        public virtual ICollection<Rack> Rack { get; set; }
        public virtual ICollection<ReplenishOrder> ReplenishOrder { get; set; }
        public virtual ICollection<Request> Request { get; set; }
        public virtual ICollection<ServiceConf> ServiceConf { get; set; }
        public virtual ICollection<StockRecord> StockRecord { get; set; }
        public virtual ICollection<StockUnit> StockUnit { get; set; }
        public virtual ICollection<StorageReq> StorageReq { get; set; }
        public virtual ICollection<StorLoc> StorLoc { get; set; }
        public virtual ICollection<SysProp> SysProp { get; set; }
        public virtual ICollection<UlAdvice> UlAdvice { get; set; }
        public virtual ICollection<UlAdvicePos> UlAdvicePos { get; set; }
        public virtual ICollection<UlRecord> UlRecord { get; set; }
        public virtual ICollection<UnitLoad> UnitLoad { get; set; }
        public virtual ICollection<User> User { get; set; }
        public virtual ICollection<Zone> Zone { get; set; }
    }
}
