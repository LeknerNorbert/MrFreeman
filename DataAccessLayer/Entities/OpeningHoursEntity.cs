using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class OpeningHoursEntity
    {
        [Key]
        public int Id { get; set; }
        public List<DayEntity>? Days { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsDeleted { get; set; }
    }
}
