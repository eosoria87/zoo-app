using ZooApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ZooApp.Infrastructure.Persistence.Configurations
{
    public class AnimalConfiguration : IEntityTypeConfiguration<AnimalEntity>
    {
        public void Configure(EntityTypeBuilder<AnimalEntity> builder)
        {
            builder.Ignore(e => e.DomainEvents);

            builder.Property(t => t.Nombre)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(t => t.Raza)
          .HasMaxLength(50)
          .IsRequired();
        }
    }
}