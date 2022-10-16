using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class PriceEntity
    {
        [Key]
        public int Id { get; set; }
        public FoodEntity? Food { get; set; }
        public int Price { get; set; }
        public DateTime ValidFrom { get; set; }
    }
}
