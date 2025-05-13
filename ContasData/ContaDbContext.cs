using ContasLib.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ContasData
{
    public class ContaDbContext : DbContext
    {
        public ContaDbContext(DbContextOptions<ContaDbContext> options) : base(options) { }

        public DbSet<Conta> Contas { get; set; }
    }
}
