using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WMSNet.Model.Models
{
    public partial class OutReq : TrackableEntity
    {
        [Key]
        public int OutReqID { get; set; }
        public string AdditionalContent { get; set; }

        public int Version { get; set; }
        public string Courier { get; set; }
        public string ExternalNumber { get; set; }
        public string GroupName { get; set; }
        public string Number { get; set; }
        public string OutState { get; set; }
        public Nullable<System.DateTime> ShippingDate { get; set; }
        public Nullable<int> CustomerOrderID { get; set; }
        public Nullable<int> OutLocationID { get; set; }
        public int ClientID { get; set; }
        public Nullable<int> OperatorID { get; set; }
        public virtual CustomerOrder CustomerOrder { get; set; }
        public virtual User User { get; set; }
        public virtual Client Client { get; set; }
        public virtual StorLoc StorLoc { get; set; }
        public virtual ICollection<OutPos> OutPos { get; set; }

    }
}
