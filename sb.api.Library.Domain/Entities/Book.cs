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
        public DateTime CreatedAt { get; private set; }
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

            if (title.Trim().Length > 256)
            {
                throw new BussinesRuleException("El título del libro debe tener máximo 256 caracteres.");
            }

            if (isbn is not null && isbn.Length > 17)
            {
                throw new BussinesRuleException("El ISBN debe tener máximo 17 caracteres.");
            }

            Id = id;
            Title = title.Trim();
            Isbn = isbn;
            PublicationYear = publicationYear;
            Publisher = publisher;
            Language = language;
            Synopsis = synopsis;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
