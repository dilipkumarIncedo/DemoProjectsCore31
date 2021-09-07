using System;
using System.Collections.Generic;

#nullable disable

namespace WebCoreMVC31.Models
{
    public partial class Role
    {
        public Role()
        {
            RegisterdUsers = new HashSet<RegisterdUser>();
        }

        public int Id { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<RegisterdUser> RegisterdUsers { get; set; }
    }
}
