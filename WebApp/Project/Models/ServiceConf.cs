using System;
using System.ComponentModel.DataAnnotations;

namespace WMSNet.Model.Models
{
    public partial class ServiceConf : TrackableEntity
    {
        [Key]
        public int ServiceConfID { get; set; }
        public string AdditionalContent { get; set; }
        public int Version { get; set; }
        public string ServKey { get; set; }
        public string Service { get; set; }
        public string SubKey { get; set; }
        public string ServValue { get; set; }
        public int ClientID { get; set; }
        public virtual Client Client { get; set; }
    }
}
