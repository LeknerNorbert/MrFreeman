using DataAccessLayer.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class OrderEntity
    {
        [Key]
        public int Id { get; set; }
        public UserEntity? User { get; set; }
        public List<FoodEntity>? Foods { get; set; }
        public string Comment { get; set; } = string.Empty;
        public PaymentTypes PaymentType { get; set; }
        public DateTime Created { get; set; }
    }
}
