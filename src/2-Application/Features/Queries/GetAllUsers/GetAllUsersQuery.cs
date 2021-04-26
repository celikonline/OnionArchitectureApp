using AutoMapper;
using MediatR;
using Efactura.Application.Dtos;
using Efactura.Application.Interfaces.Repositories;
using Efactura.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Efactura.Application.Features.Queries.GetAllUsers
{
    public class GetAllUsersQuery: IRequest<ServiceResponse<List<UserViewDto>>>
    {


        public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, ServiceResponse<List<UserViewDto>>>
        {
            private readonly IUserRepository userRepository;
            private readonly IMapper mapper;

            public GetAllUsersQueryHandler(IUserRepository userRepository, IMapper mapper)
            {
                this.userRepository = userRepository;
                this.mapper = mapper;
            }


            public async Task<ServiceResponse<List<UserViewDto>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
            {
                var Users = await userRepository.GetAll();

                var viewModel = mapper.Map<List<UserViewDto>>(Users);

                return new ServiceResponse<List<UserViewDto>>(viewModel);
            }
        }
    }
}
