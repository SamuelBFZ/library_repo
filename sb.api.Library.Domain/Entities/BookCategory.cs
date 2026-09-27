using sb.api.Library.Domain.Exceptions;

namespace sb.api.Library.Domain.Entities
{
    public sealed class BookCategory
    {
        public Guid BookId { get; private set; }
        public Book Book { get; private set; } = null!;
        public Guid CategoryId { get; private set; }
        public Category Category { get; private set; } = null!;

        private BookCategory()
        {
        }

        public BookCategory(Guid bookId, Guid categoryId)
        {
            if (bookId == Guid.Empty)
            {
                throw new BussinesRuleException("El identificador del libro es requerido.");
            }

            if (categoryId == Guid.Empty)
            {
                throw new BussinesRuleException("El identificador de la categoría es requerido.");
            }

            BookId = bookId;
            CategoryId = categoryId;
        }
    }
}
