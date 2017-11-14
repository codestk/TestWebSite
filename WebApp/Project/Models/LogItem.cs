using System;
using System.ComponentModel.DataAnnotations;

namespace WMSNet.Model.Models
{
    public partial class LogItem : TrackableEntity
    {
        [Key]
        public int LogItemID { get; set; }
        public string AdditionalContent { get; set; }
        public int Version { get; set; }
        public string BundleResolver { get; set; }
        public string Host { get; set; }
        public string Message { get; set; }
        public byte[] MessageParameters { get; set; }
        public string MessageResourceKey { get; set; }
        public string ResourceBundleName { get; set; }
        public string Source { get; set; }
        public string Type { get; set; }
        public string User_ { get; set; }
        public int ClientID { get; set; }
        public virtual Client Client { get; set; }
    }
}
