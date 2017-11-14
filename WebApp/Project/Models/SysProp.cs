using System;
using System.ComponentModel.DataAnnotations;

namespace WMSNet.Model.Models
{
    public partial class SysProp : TrackableEntity
    {
        [Key]
        public int SysPropID { get; set; }
        public string AdditionalContent { get; set; }

        public int Version { get; set; }
        public string Description { get; set; }
        public string GroupName { get; set; }
        public bool Hidden { get; set; }
        public string SysKey { get; set; }
        public string SysValue { get; set; }
        public string WorkStation { get; set; }
        public int ClientID { get; set; }
        public virtual Client Client { get; set; }
    }
}
