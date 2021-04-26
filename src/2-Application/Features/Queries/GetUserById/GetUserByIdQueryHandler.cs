using AutoMapper;
using MediatR;
using Efactura.Application.Dtos;
using Efactura.Application.Interfaces.Repositories;
using Efactura.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Efactura.Application.Features.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ServiceResponse<GetUserByIdViewModel>>
    {
        IUserRepository userRepository;
        private readonly IMapper mapper;

        public GetUserByIdQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<ServiceResponse<GetUserByIdViewModel>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetById(request.Id);
            var dto = mapper.Map<GetUserByIdViewModel>(user);

            return new ServiceResponse<GetUserByIdViewModel>(dto);
        }
    }
}
