using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutoring.Models.Db.Models;

namespace TutoringLib
{
    public class TutoringContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Tutorial> Tutorials { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public TutoringContext()
        {
        }
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

            modelBuilder.Entity<Tutorial>().Property(x => x.Title).IsRequired().HasMaxLength(256);

            modelBuilder.Entity<User>().HasMany(x => x.CreatedTutorials)
                .WithOne(x => x.Author)
                .HasForeignKey(x => x.AuthorId);

            modelBuilder.Entity<TutorialTag>().HasKey(x => new { x.TutorialId, x.TagId });

            modelBuilder.Entity<TutorialTag>()
                .HasOne(x => x.Tutorial)
                .WithMany(x => x.Tags)
                .HasForeignKey(x => x.TutorialId);

            modelBuilder.Entity<TutorialTag>()
                .HasOne(x => x.Tag)
                .WithMany(x => x.Tutorials)
                .HasForeignKey(x => x.TagId);

            modelBuilder.Entity<Page>()
                .HasMany(x => x.Content)
                .WithOne(x => x.Page)
                .HasForeignKey(x => x.PageId);

            modelBuilder.Entity<ContentItem>().HasKey(x => x.Id);

            modelBuilder.Entity<Page>()
                .HasMany(x => x.Comments)
                .WithOne(x => x.Page)
                .HasForeignKey(x => x.PageId);

            modelBuilder.Entity<User>()
                .HasMany(x => x.Comments)
                .WithOne(x => x.Author)
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
