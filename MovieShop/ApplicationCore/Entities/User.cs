using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class User
    {
        public int Id { get; set; }
#nullable enable
        public string? FirstName { get; set; }
#nullable enable
        public string? LastName { get; set; }
#nullable enable
        public DateTime? DateOfBirth { get; set; }
#nullable enable
        public string? Email { get; set; }
#nullable enable
        public string? HashedPassword { get; set; }
#nullable enable
        public string? Salt { get; set; }
#nullable enable
        public string? PhoneNumber { get; set; }
#nullable enable
        public int? TwoFactorEnabled { get; set; }
#nullable enable
        public DateTime? LockoutEndDate { get; set; }
#nullable enable
        public DateTime? LastLoginDateTime { get; set; }
        public int IsLocked  { get; set; }
#nullable enable
        public int? AccessFailedCount { get; set; }

        //foreign keys{ get; set; }
#nullable enable
        public ICollection<Review>? Reviews { get; set; }
#nullable enable
        public ICollection<Favorite>? Favorites { get; set; }
#nullable enable
        public ICollection<Purchase>? Purchases { get; set; }
        public string? ProfilePictureUrl { get; set; }
    }
}
