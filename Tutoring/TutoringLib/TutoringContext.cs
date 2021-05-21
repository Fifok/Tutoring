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
    }
}
