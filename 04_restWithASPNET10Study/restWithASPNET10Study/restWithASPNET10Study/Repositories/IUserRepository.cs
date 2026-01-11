using restWithASPNET10Study.Model;

namespace restWithASPNET10Study.Repositories
{
    public interface IUserRepository
    {
        Users Create(Users user);
        Users FindById(long id);
        List<Users> FindAll();
        Users Update(Users user);
        void Delete(long id);

    }
}
