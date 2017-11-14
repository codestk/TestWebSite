using System.ComponentModel.DataAnnotations;

namespace WMSNet.Model.Models
{
    public partial class GoodsReceiptAvisReq
    {
        [Key]
        public int GoodsReceiptAvisReqID { get; set; }
        public int AssignedAdvicesID { get; set; }
        public virtual GoodsReceipt GoodsReceipt { get; set; }
        public virtual AvisReq AvisReq { get; set; }
    }
}
