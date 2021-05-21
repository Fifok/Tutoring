using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutoringLib.Models;

namespace TutoringLib
{
    public class TutoringContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Tutorial> Tutorials { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public TutoringContext(DbContextOptions<TutoringContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().Property(x => x.Firstname).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.Lastname).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.Email).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.Password).IsRequired();

        }
    }
}
