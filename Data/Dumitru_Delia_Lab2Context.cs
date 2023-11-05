using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dumitru_Delia_Lab2.Models;

namespace Dumitru_Delia_Lab2.Data
{
    public class Dumitru_Delia_Lab2Context : DbContext
    {
        public Dumitru_Delia_Lab2Context (DbContextOptions<Dumitru_Delia_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Dumitru_Delia_Lab2.Models.Book> Book { get; set; } = default!;

        public DbSet<Dumitru_Delia_Lab2.Models.Publisher>? Publisher { get; set; }

        public DbSet<Dumitru_Delia_Lab2.Models.Author>? Author { get; set; }

        public DbSet<Dumitru_Delia_Lab2.Models.Category>? Category { get; set; }
    }
}
