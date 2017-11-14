using System;
using System.ComponentModel.DataAnnotations;

namespace WMSNet.Model.Models
{
    public partial class Request : TrackableEntity
    {
        [Key]
        public int RequestID { get; set; }
        public string AdditionalContent { get; set; }
  
        public int Version { get; set; }
        public string Request_Nr { get; set; }
        public string ParentRequestNumber { get; set; }
        public int ClientID { get; set; }
        public virtual Client Client { get; set; }
    }
}
