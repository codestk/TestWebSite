using System;
using System.ComponentModel.DataAnnotations;

namespace WMSNet.Model.Models
{
    public partial class PlugInConfig : TrackableEntity
    {
        [Key]
        public int PlugInConfigID { get; set; }
        public string AdditionalContent { get; set; }

        public int Version { get; set; }
        public string Plugin_Mode { get; set; }
        public string PluginClass { get; set; }
        public string PluginName { get; set; }
        public int ClientID { get; set; }
        public virtual Client Client { get; set; }
    }
}
