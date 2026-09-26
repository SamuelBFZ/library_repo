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
            BookId = bookId;
            AuthorId = authorId;
            DisplayOrder = displayOrder;
        }
    }
}
