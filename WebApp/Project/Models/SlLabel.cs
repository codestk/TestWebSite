using System.ComponentModel.DataAnnotations;

namespace WMSNet.Model.Models
{
    public partial class SlLabel
    {
        [Key]
        public int SlLabelID { get; set; }
        public string LabelID { get; set; }
        public virtual Document Document { get; set; }
    }
}
