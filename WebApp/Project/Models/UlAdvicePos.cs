using System;
using System.ComponentModel.DataAnnotations;

namespace WMSNet.Model.Models
{
    public partial class UlAdvicePos : TrackableEntity
    {
        [Key]
        public int UlAdvicePosID { get; set; }
        public string AdditionalContent { get; set; }

        public int Version { get; set; }
        public decimal NotifiedAmount { get; set; }
        public string PositionNumber { get; set; }
        public int ClientID { get; set; }
        public int ItemDataID { get; set; }
        public Nullable<int> LotID { get; set; }
        public int UnitLoadAdviceID { get; set; }
        public virtual UlAdvice UlAdvice { get; set; }
        public virtual Client Client { get; set; }
        public virtual ItemData ItemData { get; set; }
        public virtual Lot Lot { get; set; }
    }
}
