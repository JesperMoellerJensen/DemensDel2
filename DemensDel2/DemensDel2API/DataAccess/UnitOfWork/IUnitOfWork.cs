using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemensDel2API.DataAccess.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }

        int Complete();  //Save method
    }
}
