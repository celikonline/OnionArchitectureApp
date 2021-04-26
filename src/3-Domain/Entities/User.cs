using Efactura.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Efactura.Domain.Entities
{
    public class User : BaseEntity
    {
        [Required]
        public String TCKN { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String Surname { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        public String Address { get; set; }

    }
}
