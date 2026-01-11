using Microsoft.AspNetCore.Identity;
using restWithASPNET10Study.Model;

namespace restWithASPNET10Study.Services
{
    public interface IBooksService
    {
        Book Create(Book books);
        Book FindById(long id);
        List<Book> FindAll();
        Book Update(Book books);
        void Delete(long id);

    }
}
