using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ComponentModel.DataAnnotations;

namespace WMSNet.Model.Models
{
    public partial class SequenceNumber
    {
        [Key]
        public string ClassName { get; set; }
        public int SeqNumber { get; set; }
        public int Version { get; set; }
    }
}
