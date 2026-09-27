using sb.api.Library.Domain.Exceptions;

namespace sb.api.Library.Domain.Entities
{
    public sealed class BookAuthor
    {
        public Guid BookId { get; private set; }
        public Book Book { get; private set; } = null!;
        public Guid AuthorId { get; private set; }
        public Author Author { get; private set; } = null!;
        public int DisplayOrder { get; private set; }

        private BookAuthor()
        {
        }

        public BookAuthor(Guid bookId, Guid authorId, int displayOrder)
        {
            if (bookId == Guid.Empty)
            {
                throw new BussinesRuleException("El identificador del libro es requerido.");
            }

            if (authorId == Guid.Empty)
            {
                throw new BussinesRuleException("El identificador del autor es requerido.");
            }

            if (displayOrder < 1)
            {
                throw new BussinesRuleException("El orden de visualización del autor debe ser mayor o igual a 1.");
            }

            BookId = bookId;
            AuthorId = authorId;
            DisplayOrder = displayOrder;
        }
    }
}
