using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ban_Roxana_Lab2.Models;

namespace Ban_Roxana_Lab2.Data
{
    public class Ban_Roxana_Lab2Context : DbContext
    {
        public Ban_Roxana_Lab2Context (DbContextOptions<Ban_Roxana_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Ban_Roxana_Lab2.Models.Book> Book { get; set; } = default!;

        public DbSet<Ban_Roxana_Lab2.Models.Publisher>? Publisher { get; set; }

        public DbSet<Ban_Roxana_Lab2.Models.Author>? Author { get; set; }
    }
}
