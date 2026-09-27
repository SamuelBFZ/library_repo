using Microsoft.EntityFrameworkCore;
using sb.api.Library.Domain.Entities;

namespace sb.api.Library.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            SetCreatedAt();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            SetCreatedAt();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetCreatedAt();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            SetCreatedAt();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void SetCreatedAt()
        {
            foreach (var entry in ChangeTracker.Entries<Book>())
            {
                if (entry.State != EntityState.Added)
                {
                    continue;
                }

                var createdAt = entry.Property("CreatedAt");
                if (createdAt.CurrentValue is DateTime value && value != default)
                {
                    continue;
                }

                createdAt.CurrentValue = DateTime.UtcNow;
            }
        }
    }
}
