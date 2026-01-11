using Microsoft.AspNetCore.Identity;
using restWithASPNET10Study.Model;

namespace restWithASPNET10Study.Services
{
    public interface IUserService
    {
        Users Create(Users user);
        Users FindById(long id);
        List<Users> FindAll();
        Users Update(Users user);
        void Delete(long id);

    }
}
