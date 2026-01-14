using restWithASPNET10Study.Model;
using restWithASPNET10Study.Model.Context;
using restWithASPNET10Study.Repositories;

namespace restWithASPNET10Study.Services.Impl
{
    public class BooksServiceImpl : IBooksService
    {

        private IRepository<Book> _repository;

        public BooksServiceImpl(IRepository<Book> repository)
        {
            _repository = repository;
        }

        public Book Create(Book books)
        {
            return _repository.Create(books);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<Book> FindAll()
        {
            return _repository.FindAll();
        }

        public Book FindById(long id)
        {
            var existBooks = _repository.FindById(id);

            if (existBooks == null)
            {
                return null;
            }
            return existBooks;
        }

        public Book Update(Book books)
        {
            return _repository.Update(books);
        }
    }
}
