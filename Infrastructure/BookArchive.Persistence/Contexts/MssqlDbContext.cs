using BookArchive.Domain.Entities;
using BookArchive.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Reflection.Emit;

namespace BookArchive.Persistence.Contexts
{
    public class MssqlDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public MssqlDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public MssqlDbContext()
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
             .HasMany(u => u.Notes)
             .WithOne(n => n.User)
             .HasForeignKey(n => n.UserId)
             .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Note>()
                .HasOne(n => n.User)
                .WithMany(u => u.Notes)
                .HasForeignKey(n => n.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
