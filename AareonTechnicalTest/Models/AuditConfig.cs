using Microsoft.EntityFrameworkCore;

namespace AareonTechnicalTest.Models
{
    public static class AuditConfig
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Audit>(
                entity =>
                {
                    entity.HasKey(e => e.Id);
                });
        }
    }
}
