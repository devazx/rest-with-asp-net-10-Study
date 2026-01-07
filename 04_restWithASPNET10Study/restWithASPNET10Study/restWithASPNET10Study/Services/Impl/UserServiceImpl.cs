using restWithASPNET10Study.Model;
using restWithASPNET10Study.Model.Context;
using restWithASPNET10Study.Repositories;

namespace restWithASPNET10Study.Services.Impl
{
    public class UserServiceImpl : IUserService
    {

        private IUserRepository _repository;

        public UserServiceImpl(IUserRepository repository)
        {
            _repository = repository;
        }

        public User Create(User user)
        {
            return _repository.Create(user);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<User> FindAll()
        {
            return _repository.FindAll();
        }

        public User FindById(long id)
        {
            var existUser = _repository.FindById(id);

            if (existUser == null)
            {
                return null;
            }
            return existUser;
        }

        public User Update(User user)
        {
            return _repository.Update(user);
        }
    }
}
