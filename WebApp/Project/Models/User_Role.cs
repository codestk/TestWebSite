using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WMSNet.Model.Models
{
    public partial class User_Role
    {
        [Key]
        public int UserID { get; set; }
        public int RolesID { get; set; }
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<OutReq> OutReq { get; set; }
    }
}
