using System;
using System.Collections.Generic;

#nullable disable

namespace WebCoreMVC31.Models
{
    public partial class User
    {
        public User()
        {
            RegisterdUsers = new HashSet<RegisterdUser>();
        }

        public int Id { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<RegisterdUser> RegisterdUsers { get; set; }
    }
}
