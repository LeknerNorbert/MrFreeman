using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class RoleEntity
    {
        [Key]
        public int Id { get; set; }
        public List<UserEntity>? Users { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
