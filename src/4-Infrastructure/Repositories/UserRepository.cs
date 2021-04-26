using Efactura.Application.Interfaces.Repositories;
using Efactura.Domain.Entities;
using Efactura.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Efactura.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext): base(dbContext)
        {

        }
    }
}
