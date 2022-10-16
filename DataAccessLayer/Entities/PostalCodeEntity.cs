using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class PostalCodeEntity
    {
        [Key]
        public int Id { get; set; }
        public int PostalCode { get; set; }
        public List<AddressEntity>? Addresses { get; set; }
        public int DeliveryCosts { get; set; }
        public bool IsDeleted { get; set; }
    }
}
