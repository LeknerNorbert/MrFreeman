using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }
        public List<OrderEntity>? Orders { get; set; }
        public List<AddressEntity>? Addresses { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public RoleEntity? Role { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public string? VerificationToken { get; set; }
        public DateTime VerifiedAt { get; set; }
        public string? PasswordResetToken {get; set; }
        public DateTime? PasswordResetExpires { get; set; }
        public DateTime? RegisterDate { get; set; } = DateTime.Now;
    }
}
