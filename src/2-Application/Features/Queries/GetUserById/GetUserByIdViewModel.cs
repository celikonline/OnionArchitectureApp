using System;
using System.Collections.Generic;
using System.Text;

namespace Efactura.Application.Features.Queries.GetUserById
{
    public class GetUserByIdViewModel 
    {
        public String Name { get; set; }
        public String Surname { get; set; }
        public DateTime Birthday { get; set; }
        public String Address { get; set; }
        public String TCKN { get; set; }
    }
}
