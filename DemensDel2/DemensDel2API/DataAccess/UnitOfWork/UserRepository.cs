using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemensDel2.Models;
using Microsoft.EntityFrameworkCore;

namespace DemensDel2API.DataAccess.UnitOfWork
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {

        }

    }
}
