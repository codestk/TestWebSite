using System;
using System.ComponentModel.DataAnnotations;

namespace WMSNet.Model.Models
{
    public partial class UlRecord : TrackableEntity
    {
        [Key]
        public int UlRecordID { get; set; }
        public string AdditionalContent { get; set; }

        public int Version { get; set; }
        public string ActivityCode { get; set; }
        public string FromLocation { get; set; }
        public string Label { get; set; }
        public string Operator { get; set; }
        public string RecordType { get; set; }
        public string ToLocation { get; set; }
        public string UnitLoadType { get; set; }
        public int ClientID { get; set; }
        public virtual Client Client { get; set; }
    }
}
