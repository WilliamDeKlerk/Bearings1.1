using System;
using System.Collections.Generic;

namespace Bearings2000.Portal.Web.Models
{
    public partial class UserStatus
    {
        public UserStatus()
        {
            Users = new HashSet<User>();
        }

        public int UserStatusId { get; set; }
        public string? UserStatus1 { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
