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

            builder.Property<DateTime>("CreatedAt")
                   .IsRequired();

            builder.HasIndex(b => b.Title);

            builder.HasIndex(b => b.Isbn)
                   .IsUnique()
                   .HasFilter("[Isbn] IS NOT NULL");

            builder.HasMany(b => b.Authors)
                   .WithMany(a => a.Books)
                   .UsingEntity<BookAuthor>(
                       j => j.HasOne(ba => ba.Author)
                             .WithMany(a => a.BookAuthors)
                             .HasForeignKey(ba => ba.AuthorId)
                             .OnDelete(DeleteBehavior.NoAction),
                       j => j.HasOne(ba => ba.Book)
                             .WithMany(b => b.BookAuthors)
                             .HasForeignKey(ba => ba.BookId)
                             .OnDelete(DeleteBehavior.NoAction));

            builder.HasMany(b => b.Categories)
                   .WithMany(c => c.Books)
                   .UsingEntity<BookCategory>(
                       j => j.HasOne(bc => bc.Category)
                             .WithMany(c => c.BookCategories)
                             .HasForeignKey(bc => bc.CategoryId)
                             .OnDelete(DeleteBehavior.NoAction),
                       j => j.HasOne(bc => bc.Book)
                             .WithMany(b => b.BookCategories)
                             .HasForeignKey(bc => bc.BookId)
                             .OnDelete(DeleteBehavior.NoAction));
        }
    }
}
