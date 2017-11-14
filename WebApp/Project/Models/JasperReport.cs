using System;
using System.ComponentModel.DataAnnotations;

namespace WMSNet.Model.Models
{
    public partial class JasperReport
    {
        [Key]
        public long JasperReportID { get; set; }
        public string AdditionalContent { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public Nullable<int> Entity_Lock { get; set; }
        public Nullable<System.DateTime> Modified { get; set; }
        public int Version { get; set; }
        public Nullable<long> CompiledDocument { get; set; }
        public string Name { get; set; }
        public string SourceDocument { get; set; }
        public long ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}
