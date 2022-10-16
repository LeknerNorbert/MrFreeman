using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Models
{
    public class UserModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string Firstname { get; set; } = string.Empty;
        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string Lastname { get; set; } = string.Empty;
        [Required]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$")]
        public string Password { get; set; } = string.Empty;
        public bool IsEmailConfirmed { get; set; }
    }
}
