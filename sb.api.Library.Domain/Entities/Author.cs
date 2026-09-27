using sb.api.Library.Domain.Exceptions;

namespace sb.api.Library.Domain.Entities
{
    public sealed class Author
    {
        public Guid Id { get; private set; }
        public string FirstName { get; private set; } = null!;
        public string LastName { get; private set; } = null!;
        public string? Biography { get; private set; }
        public DateOnly? BirthDate { get; private set; }
        public ICollection<Book> Books { get; private set; } = new List<Book>();
        public ICollection<BookAuthor> BookAuthors { get; private set; } = new List<BookAuthor>();

        private Author()
        {
        }

        public Author(string firstName, string lastName, string? biography = null, DateOnly? birthDate = null)
            : this(Guid.CreateVersion7(), firstName, lastName, biography, birthDate)
        {
        }

        public Author(Guid id, string firstName, string lastName, string? biography = null, DateOnly? birthDate = null)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new BussinesRuleException("El nombre del autor es requerido.");
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new BussinesRuleException("El apellido del autor es requerido.");
            }

            Id = id;
            FirstName = firstName.Trim();
            LastName = lastName.Trim();
            Biography = biography;
            BirthDate = birthDate;
        }
    }
}
