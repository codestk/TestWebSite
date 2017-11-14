using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WMSNet.Model.Models
{
    public partial class Role : TrackableEntity
    {
        [Key]
        public int RoleID { get; set; }
        public string AdditionalContent { get; set; }

        public int Version { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public virtual ICollection<User_Role> User_Role { get; set; }
    }
}
