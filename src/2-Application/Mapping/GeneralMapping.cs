using AutoMapper;
using Efactura.Application.Features.Commands.CreateUser;
using Efactura.Application.Features.Queries.GetUserById;
using System;
using System.Collections.Generic;
using System.Text;

namespace Efactura.Application.Mapping
{
    public class GeneralMapping: Profile
    {

        public GeneralMapping()
        {
            CreateMap<Domain.Entities.User, Dtos.UserViewDto>()
                .ReverseMap();

            CreateMap<Domain.Entities.User, CreateUserCommand>()
                .ReverseMap();

            CreateMap<Domain.Entities.User, GetUserByIdViewModel>()
                .ReverseMap();
        }

    }
}
