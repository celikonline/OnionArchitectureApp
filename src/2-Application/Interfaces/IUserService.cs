using Efactura.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Efactura.Application.Interfaces
{
    public interface IUserService
    {
        Task<List<UserViewDto>> GetAllUsers();
    }
}
