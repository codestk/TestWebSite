using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WMSNet.Model.Models
{
    public partial class User : TrackableEntity
    {
        [Key]
        public int UserID { get; set; }
        public string AdditionalContent { get; set; }

        public int Version { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Locale { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public int ClientID { get; set; }
        public virtual Client Client { get; set; }
        public virtual ICollection<GoodsReceipt> GoodsReceipt { get; set; }
        public virtual ICollection<GrrPosition> GrrPosition { get; set; }
        public virtual ICollection<PickingOrder> PickingOrder { get; set; }
        public virtual ICollection<ReplenishOrder> ReplenishOrder { get; set; }
        public virtual ICollection<User_Role> User_Role { get; set; }
    }
}
