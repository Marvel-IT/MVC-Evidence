using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcEvidence.Models;

namespace MvcEvidence.Data
{
    public class MvcOsobaContext : DbContext
    {
        public MvcOsobaContext (DbContextOptions<MvcOsobaContext> options)
            : base(options)
        {
        }

        public DbSet<MvcEvidence.Models.Osoba> Osoba { get; set; } = default!;
    }
}
