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
            ApplyNameRules(firstName, "El nombre del autor es requerido.", "El nombre del autor");
            ApplyNameRules(lastName, "El apellido del autor es requerido.", "El apellido del autor");

            Id = id;
            FirstName = firstName.Trim();
            LastName = lastName.Trim();
            Biography = biography;
            BirthDate = birthDate;
        }

        private static void ApplyNameRules(string value, string requiredMessage, string lengthPrefix)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new BussinesRuleException(requiredMessage);
            }

            if (value.Trim().Length > 100)
            {
                throw new BussinesRuleException($"{lengthPrefix} debe tener máximo 100 caracteres.");
            }
        }
    }
}
