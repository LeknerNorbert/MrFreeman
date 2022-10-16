using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class DayEntity
    {
        [Key]
        public int Id { get; set; }
        public OpeningHoursEntity? OpeningHours { get; set; }
        public DayOfWeek Day { get; set; }
        public bool Status { get; set; }
        public DateTime? OpenTime { get; set; }
        public DateTime? CloseTime { get; set; }
    }
}
