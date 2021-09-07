using System;
using System.Collections.Generic;

#nullable disable

namespace WebCoreMVC31.Models
{
    public partial class RegisterdUser
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
