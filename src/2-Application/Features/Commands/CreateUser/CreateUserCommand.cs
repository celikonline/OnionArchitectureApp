using MediatR;
using Efactura.Application.Wrappers;
using System;
using FluentValidation;
using Efactura.Application.Dtos;

namespace Efactura.Application.Features.Commands.CreateUser
{
    public partial class CreateUserCommand : IRequest<ServiceResponse<Guid>>
    {
        public String Name { get; set; }
        public String Surname { get; set; }
        public DateTime Birthday { get; set; }
        public String Address { get; set; }

        public class CreateUserValidator : AbstractValidator<CreateUserCommand>
        {
            public CreateUserValidator()
            {
                RuleFor(e => e.Name).NotEmpty().WithMessage("Name is required");

                RuleFor(e => e.Surname).NotEmpty().WithMessage("Surname is required");

                RuleFor(e => e.Birthday).NotEmpty().WithMessage("Birthday is required");

                RuleFor(e => e.Address).NotEmpty().WithMessage("Address is required");

            }
        }
    }
}
