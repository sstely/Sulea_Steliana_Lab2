using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sulea_Steliana_Lab2.Models;

namespace Sulea_Steliana_Lab2.Data
{
    public class Sulea_Steliana_Lab2Context : DbContext
    {
        public Sulea_Steliana_Lab2Context (DbContextOptions<Sulea_Steliana_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Sulea_Steliana_Lab2.Models.Book> Book { get; set; } = default!;

        public DbSet<Sulea_Steliana_Lab2.Models.Publisher>? Publisher { get; set; }

        public DbSet<Sulea_Steliana_Lab2.Models.Author>? Author { get; set; }
    }
}
