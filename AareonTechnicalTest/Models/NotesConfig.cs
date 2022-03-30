using Microsoft.EntityFrameworkCore;

namespace AareonTechnicalTest.Models
{
    public class NotesConfig
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>(
                entity =>
                {
                    entity.HasKey(e => e.Id);
                });

            modelBuilder.Entity<Person>(
                entity =>
                {
                    entity.HasKey(e => e.Id);
                });
        }
    }
}

