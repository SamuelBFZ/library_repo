using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sb.api.Library.Domain.Entities;

namespace sb.api.Library.Persistence.Configurations
{
    internal class AuthorConfig : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Authors");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.FirstName)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(a => a.LastName)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(a => a.Biography);

            builder.Property(a => a.BirthDate)
                   .HasColumnType("date");

            builder.HasIndex(a => a.LastName);
        }
    }
}
