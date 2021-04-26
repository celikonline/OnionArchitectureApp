using System;
using System.Collections.Generic;
using System.Text;

namespace Efactura.Application.Wrappers
{
    public class BaseResponse
    {
        public Guid Id { get => Guid.NewGuid(); }

        public String Message { get; set; }

        public bool IsSuccess { get; set; } = true;
    }
}
