using sb.api.Library.Domain.Exceptions;

namespace sb.api.Library.Domain.Entities
{
    public sealed class Category
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;
        public string? Description { get; private set; }
        public ICollection<Book> Books { get; private set; } = new List<Book>();
        public ICollection<BookCategory> BookCategories { get; private set; } = new List<BookCategory>();

        private Category()
        {
        }

        public Category(string name, string? description = null)
            : this(Guid.CreateVersion7(), name, description)
        {
        }

        public Category(Guid id, string name, string? description = null)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new BussinesRuleException("El nombre de la categoría es requerido.");
            }

            Id = id;
            Name = name.Trim();
            Description = description;
        }
    }
}
