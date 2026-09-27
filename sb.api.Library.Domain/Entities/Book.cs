using sb.api.Library.Domain.Exceptions;

namespace sb.api.Library.Domain.Entities
{
    public sealed class Book
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; } = null!;
        public string? Isbn { get; private set; }
        public short? PublicationYear { get; private set; }
        public string? Publisher { get; private set; }
        public string? Language { get; private set; }
        public string? Synopsis { get; private set; }
        public ICollection<Author> Authors { get; private set; } = new List<Author>();
        public ICollection<Category> Categories { get; private set; } = new List<Category>();
        public ICollection<BookAuthor> BookAuthors { get; private set; } = new List<BookAuthor>();
        public ICollection<BookCategory> BookCategories { get; private set; } = new List<BookCategory>();

        private Book()
        {
        }

        public Book(
            string title,
            string? isbn = null,
            short? publicationYear = null,
            string? publisher = null,
            string? language = null,
            string? synopsis = null)
            : this(Guid.CreateVersion7(), title, isbn, publicationYear, publisher, language, synopsis)
        {
        }

        public Book(
            Guid id,
            string title,
            string? isbn = null,
            short? publicationYear = null,
            string? publisher = null,
            string? language = null,
            string? synopsis = null)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new BussinesRuleException("El título del libro es requerido.");
            }

            Id = id;
            Title = title.Trim();
            Isbn = isbn;
            PublicationYear = publicationYear;
            Publisher = publisher;
            Language = language;
            Synopsis = synopsis;
        }

        public void AddAuthor(Author author, int displayOrder)
        {
            if (author is null)
            {
                throw new BussinesRuleException("El autor es requerido.");
            }

            if (displayOrder < 1)
            {
                throw new BussinesRuleException("El orden de visualización del autor debe ser mayor o igual a 1.");
            }

            if (BookAuthors.Any(ba => ba.AuthorId == author.Id) || Authors.Any(a => a.Id == author.Id))
            {
                throw new BussinesRuleException("El autor ya está asociado al libro.");
            }

            BookAuthors.Add(new BookAuthor(Id, author.Id, displayOrder));
            Authors.Add(author);
        }

        public void AddCategory(Category category)
        {
            if (category is null)
            {
                throw new BussinesRuleException("La categoría es requerida.");
            }

            if (BookCategories.Any(bc => bc.CategoryId == category.Id) || Categories.Any(c => c.Id == category.Id))
            {
                throw new BussinesRuleException("La categoría ya está asociada al libro.");
            }

            BookCategories.Add(new BookCategory(Id, category.Id));
            Categories.Add(category);
        }

        public void EnsureHasAuthorsAndCategories()
        {
            if (Authors.Count == 0 && BookAuthors.Count == 0)
            {
                throw new BussinesRuleException("El libro debe tener al menos un autor.");
            }

            if (Categories.Count == 0 && BookCategories.Count == 0)
            {
                throw new BussinesRuleException("El libro debe pertenecer a al menos una categoría.");
            }
        }
    }
}
