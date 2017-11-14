using System;
using System.ComponentModel.DataAnnotations;

namespace WMSNet.Model.Models
{
    public partial class StorageReq : TrackableEntity
    {
        [Key]
        public int StorageReqID { get; set; }
        public string AdditionalContent { get; set; }

        public int Version { get; set; }
        public string Number { get; set; }
        public string RequestState { get; set; }
        public Nullable<int> DestinationID { get; set; }
        public Nullable<int> UnitLoadID { get; set; }
        public int ClientID { get; set; }
        public virtual Client Client { get; set; }
        public virtual StorLoc StorLoc { get; set; }
        public virtual UnitLoad UnitLoad { get; set; }
    }
}
