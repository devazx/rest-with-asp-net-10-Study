using restWithASPNET10Study.Data.Converter.Contract;
using restWithASPNET10Study.Data.Dto;
using restWithASPNET10Study.Model;

namespace restWithASPNET10Study.Data.Converter.Impl
{
    public interface BookConverter : IBook<Book, BookDto>, IBook<BookDto, Book>
    {
        public Book Parse(BookDto origin)
        {
            if (origin == null) return null;
            return new Book
            {
                Id = origin.Id,
                Title = origin.Title,
                Author = origin.Author,
                Price = origin.Price,
                Launch_date = origin.Launch_date
            };
        }

        public BookDto Parse(Book origin)
        {
            if(origin == null) return null;
            return new BookDto
            {
                Id = origin.Id,
                Title = origin.Title,
                Author = origin.Author,
                Price = origin.Price,
                Launch_date = origin.Launch_date
            };
        }

        public List<Book> ParseList(List<BookDto> origin)
        {
            if(origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
        public List<BookDto> ParseList(List<Book> origin)
        {
            if(origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
