using sb.api.Library.Domain.Exceptions;

namespace sb.api.Library.Domain.Entities
{
    public sealed class Category
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;
        public string? Description { get; private set; }
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

            if (name.Trim().Length > 128)
            {
                throw new BussinesRuleException("El nombre de la categoría debe tener máximo 128 caracteres.");
            }

            if (description is not null && description.Length > 1024)
            {
                throw new BussinesRuleException("La descripción de la categoría debe tener máximo 1024 caracteres.");
            }

            Id = id;
            Name = name.Trim();
            Description = description;
        }
    }
}
