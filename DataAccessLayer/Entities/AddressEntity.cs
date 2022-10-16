using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class AddressEntity
    {
        [Key]
        public int Id { get; set; }
        public PostalCodeEntity? PostalCode { get; set; }
        public string Country { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string HouseNumber { get; set; } = string.Empty;
        public string Floor { get; set; } = string.Empty;
        public string Door { get; set; } = string.Empty;
        public string Doorbell { get; set; } = string.Empty;
        public bool IsPrimary { get; set; }
        public bool IsDeleted { get; set; }
    }
}
