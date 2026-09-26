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
            BookId = bookId;
            CategoryId = categoryId;
        }
    }
}
