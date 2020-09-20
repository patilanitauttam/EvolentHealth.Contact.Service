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
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId)
                     .HasName("PK__Users__UserId");

                entity.ToTable("Users", "user");
            });
        }
    }
}
