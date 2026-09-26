using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sb.api.Library.Domain.Entities;

namespace sb.api.Library.Persistence.Configurations
{
    internal class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Title)
                   .HasMaxLength(256)
                   .IsRequired();

            builder.Property(b => b.Isbn)
                   .HasMaxLength(17);

            builder.Property(b => b.PublicationYear)
                   .HasColumnType("smallint");

            builder.Property(b => b.Publisher)
                   .HasMaxLength(256);

            builder.Property(b => b.Language)
                   .HasMaxLength(16);

            builder.Property(b => b.Synopsis);

            builder.Property(b => b.CreatedAt)
                   .IsRequired();

            builder.HasIndex(b => b.Title);

            builder.HasIndex(b => b.Isbn)
                   .IsUnique()
                   .HasFilter("[Isbn] IS NOT NULL");
        }
    }
}
