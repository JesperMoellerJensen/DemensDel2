using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemensDel2API.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace DemensDel2API.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public UnitOfWork(DbContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
        }

        public IUserRepository Users { get; private set; }

        public int Complete()
        {
           return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
