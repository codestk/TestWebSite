using System;
using System.ComponentModel.DataAnnotations;

namespace WMSNet.Model.Models
{
    public partial class OutPos:TrackableEntity
    {
        [Key]
        public int OutPosID { get; set; }
        public string AdditionalContent { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public Nullable<int> Entity_Lock { get; set; }
        public Nullable<System.DateTime> Modified { get; set; }
        public int Version { get; set; }
        public string OutState { get; set; }
        public int GoodsOutRequestID { get; set; }
        public int SourceID { get; set; }
        public virtual UnitLoad UnitLoad { get; set; }
        public virtual OutReq OutReq { get; set; }
    }
}
