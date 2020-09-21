using EvolentHealth.Contact.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace EvolentHealth.Contact.DataAccess
{
    public class ContactDBContext : DbContext
    {
        public ContactDBContext()
        {

        }

        public ContactDBContext(DbContextOptions<ContactDBContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contacts>(entity =>
            {
                entity.HasKey(e => e.ContactId)
                     .HasName("PK__Contacts__ContactId");

                entity.ToTable("Contacts", "contact");
            });
        }
    }
}
