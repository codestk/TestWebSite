using System.ComponentModel.DataAnnotations;

namespace WMSNet.Model.Models
{
    public partial class SuLabel
    {
        [Key]
        public int SuLabelID { get; set; }
        public decimal Amount { get; set; }
        public string ClientRef { get; set; }
        public string DateRef { get; set; }
        public string ItemUnit { get; set; }
        public string ItemDataRef { get; set; }
        public string LabelID { get; set; }
        public string LotRef { get; set; }
        public int Scale { get; set; }
        public virtual Document Document { get; set; }
    }
}
