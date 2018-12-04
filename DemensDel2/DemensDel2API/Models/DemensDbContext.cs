using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DemensDel2.Models;

namespace DemensDel2API.Models
{
    public class DemensDbContext : DbContext
    {
        public DemensDbContext(DbContextOptions<DemensDbContext> options) : base(options) 
        {
            //Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }
    }
}
