using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Persistence
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<UserContact> Contacts { get; set; }
        public DatabaseContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserContact>(b =>
            {
                b.HasKey(k => new {k.UserId, k.ContactId});

                b.HasOne(uc => uc.User)
                    .WithMany(u => u.Contacts)
                    .HasForeignKey(uc => uc.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne(uc => uc.Contact)
                    .WithMany(u => u.InContacts)
                    .HasForeignKey(u => u.ContactId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}