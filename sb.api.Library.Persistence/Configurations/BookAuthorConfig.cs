using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sb.api.Library.Domain.Entities;

namespace sb.api.Library.Persistence.Configurations
{
    internal class BookAuthorConfig : IEntityTypeConfiguration<BookAuthor>
    {
        public void Configure(EntityTypeBuilder<BookAuthor> builder)
        {
            builder.ToTable("BookAuthors");

            builder.HasKey(ba => new { ba.BookId, ba.AuthorId });

            builder.Property(ba => ba.DisplayOrder)
                   .IsRequired();
        }
    }
}
