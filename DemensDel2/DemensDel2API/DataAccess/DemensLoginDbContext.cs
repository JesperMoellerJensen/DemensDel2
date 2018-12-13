using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemensDel2API.DataAccess
{
    public class DemensLoginDbContext : IdentityDbContext<IdentityUser>
    {
        public DemensLoginDbContext(DbContextOptions<DemensLoginDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
