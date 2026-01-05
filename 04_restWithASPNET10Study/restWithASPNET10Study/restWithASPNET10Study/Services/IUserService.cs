using Microsoft.AspNetCore.Identity;
using restWithASPNET10Study.Model;

namespace restWithASPNET10Study.Services
{
    public interface IUserService
    {
        User Create(User user);
        User FindById(int id);
        List<User> FindAll();
        User Update(User user);
        void Delete(int id);

    }
}
