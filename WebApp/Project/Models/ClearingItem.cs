using System;
using System.ComponentModel.DataAnnotations;

namespace WMSNet.Model.Models
{
    public partial class ClearingItem : TrackableEntity
    {
        [Key]
        public int ClearingItemID { get; set; }
        public string AdditionalContent { get; set; }
        public int Version { get; set; }
        public Nullable<int> BundleResolver { get; set; }
        public string Host { get; set; }
        public byte[] MessageParameters { get; set; }
        public string MessageResourcekey { get; set; }
        public int Options { get; set; }
        public byte[] PropertyMap { get; set; }
        public string ResourceBundleName { get; set; }
        public byte[] ShortMessageParameters { get; set; }
        public string ShortMessageResourceKey { get; set; }
        public Nullable<int> Solution { get; set; }
        public string Solver { get; set; }
        public string Source { get; set; }
        public string User_ { get; set; }
        public int ClientID { get; set; }
        public virtual Client Client { get; set; }
    }
}
