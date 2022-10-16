using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class FoodEntity
    {
        [Key]
        public int Id { get; set; }
        public CategoryEntity? Category { get; set; }
        public List<PriceEntity>? Prices { get; set; }
        public List<OrderEntity>? Orders { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string PicturePath { get; set; } = string.Empty;
        public bool IsInStock { get; set; }
        public bool IsDeleted { get; set; }
    }
}
