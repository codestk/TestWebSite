using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WMSNet.Model.Models
{
    public partial class UlAdvice : TrackableEntity
    {
        [Key]
        public int UlAdviceID { get; set; }
        public string AdditionalContent { get; set; }

        public int Version { get; set; }
        public string AdviceState { get; set; }
        public string AdviceType { get; set; }
        public string ExternalNumber { get; set; }
        public string LabelID { get; set; }
        public string Number { get; set; }
        public string ReasonForReturn { get; set; }
        public string SwitchStateInfo { get; set; }
        public int ClientID { get; set; }
        public Nullable<int> UnitLoadTypeID { get; set; }
        public Nullable<int> RelatedAdviceID { get; set; }
        public virtual UnitLoadType UnitLoadType { get; set; }
        public virtual Client Client { get; set; }
        public virtual AvisReq AvisReq { get; set; }
        public virtual ICollection<UlAdvicePos> UlAdvicePos { get; set; }
    }
}
