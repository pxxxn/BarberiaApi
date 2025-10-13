using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Barberia.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Barberia.Infrastructure.Context
{
    public class BarberiaDbContext : DbContext
    {
        public BarberiaDbContext(DbContextOptions<BarberiaDbContext> options)
           : base(options)
        {
        }
     
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
