using MediatR;
using Efactura.Application.Dtos;
using Efactura.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Efactura.Application.Features.Queries.GetUserById
{
    public class GetUserByIdQuery: IRequest<ServiceResponse<GetUserByIdViewModel>>
    {
        public Guid Id { get; set; }

    }
}
