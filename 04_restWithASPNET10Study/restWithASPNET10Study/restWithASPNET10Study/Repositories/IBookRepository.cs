using restWithASPNET10Study.Model;

namespace restWithASPNET10Study.Repositories
{
    public interface IUserRepository
    {
        User Create(User user);
        User FindById(long id);
        List<User> FindAll();
        User Update(User user);
        void Delete(long id);

    }
}
