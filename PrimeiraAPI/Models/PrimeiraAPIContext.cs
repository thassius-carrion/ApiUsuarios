using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeiraAPI.Models
{
    public class PrimeiraAPIContext : DbContext
    {
        public PrimeiraAPIContext(DbContextOptions<PrimeiraAPIContext> option) : base(option)
        {

        }

        public DbSet<Usuario> Usuario { get; set; }
    }
}
