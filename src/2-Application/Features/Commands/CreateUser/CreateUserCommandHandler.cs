using AutoMapper;
using MediatR;
using Efactura.Application.Interfaces.Repositories;
using Efactura.Application.Wrappers;
using System;
using System.Threading;
using System.Threading.Tasks;
using Efactura.Application.Dtos;
using Efactura.Application.Service;

namespace Efactura.Application.Features.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ServiceResponse<Guid>>
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        private readonly ITcknService tcknService;

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper, ITcknService tcknService)
        {
            this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.tcknService = tcknService ?? throw new ArgumentNullException(nameof(tcknService));
        }

        public async Task<ServiceResponse<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var user = mapper.Map<Domain.Entities.User>(request);
            
            user.TCKN = this.tcknService.GetUniqueNewTckn();

            await userRepository.AddAsync(user);

            return new ServiceResponse<Guid>(user.Id)
            {
                IsSuccess = true
            };

        }
    }
}
