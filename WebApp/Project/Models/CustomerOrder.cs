using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WMSNet.Model.Models
{
    public partial class CustomerOrder : TrackableEntity
    {
        public CustomerOrder()
        {
            this.CustomerPos = new List<CustomerPos>();
            this.OutReq = new List<OutReq>();
        }

        [Key]
        public int CustomerOrderID { get; set; }
        public string AdditionalContent { get; set; }
        public int Version { get; set; }
        public string CustomerName { get; set; }
        public string CustomerNumber { get; set; }
        public Nullable<System.DateTime> Delivery { get; set; }
        public string DocumentUrl { get; set; }
        public string Dtype { get; set; }
        public string ExternalID { get; set; }
        public string ExternalNumber { get; set; }
        public string LabelUrl { get; set; }
        public string Number { get; set; }
        public int Prio { get; set; }
        public int State { get; set; }
        public Nullable<int> DestinationID { get; set; }
        public int ClientID { get; set; }
        public int SrategyID { get; set; }
        public virtual OrderStrat OrderStrat { get; set; }
        public virtual Client Client { get; set; }
        public virtual StorLoc StorLoc { get; set; }
        public virtual ICollection<CustomerPos> CustomerPos { get; set; }
        public virtual ICollection<OutReq> OutReq { get; set; }
    }
}
