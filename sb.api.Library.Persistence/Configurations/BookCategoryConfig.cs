using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sb.api.Library.Domain.Entities;

namespace sb.api.Library.Persistence.Configurations
{
    internal class BookCategoryConfig : IEntityTypeConfiguration<BookCategory>
    {
        public void Configure(EntityTypeBuilder<BookCategory> builder)
        {
            builder.ToTable("BookCategories");

            builder.HasKey(bc => new { bc.BookId, bc.CategoryId });

            builder.HasOne(bc => bc.Book)
                   .WithMany(b => b.BookCategories)
                   .HasForeignKey(bc => bc.BookId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(bc => bc.Category)
                   .WithMany(c => c.BookCategories)
                   .HasForeignKey(bc => bc.CategoryId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
