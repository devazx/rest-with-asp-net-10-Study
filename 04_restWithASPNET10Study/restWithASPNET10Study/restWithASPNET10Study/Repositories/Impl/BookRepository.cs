using restWithASPNET10Study.Model;
using restWithASPNET10Study.Model.Context;

namespace restWithASPNET10Study.Repositories.Impl
{
    public class BooksRepository : IBooksRepository
    {
        private MSSQLContext _context;

        public BooksRepository(MSSQLContext context)
        {
            _context = context;
        }

        public Book Create(Book books)
        {
            _context.Add(books);
            _context.SaveChanges();
            return books;
        }

        public void Delete(long id)
        {
            var existingUser = _context.Books.Find(id);
            if (existingUser == null) return;

            _context.Books.Remove(existingUser);
            _context.SaveChanges();
        }

        public List<Book> FindAll()
        {
            return _context.Books.ToList();
        }

        public Book FindById(long id)
        {
            var existBooks = _context.Books.Find(id);

            if (existBooks == null)
            {
                return null;
            }
            return existBooks;
        }

        public Book Update(Book books)
        {
            var existingbooks = _context.Books.Find(books.Id);
            if (existingbooks == null) return null;

            _context.Entry(existingbooks).CurrentValues.SetValues(books);
            _context.SaveChanges();
            return books;
        }
    }
}

