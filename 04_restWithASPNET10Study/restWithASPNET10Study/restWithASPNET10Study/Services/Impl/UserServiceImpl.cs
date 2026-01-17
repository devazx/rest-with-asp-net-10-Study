using restWithASPNET10Study.Model;
using restWithASPNET10Study.Model.Context;
using restWithASPNET10Study.Repositories;

namespace restWithASPNET10Study.Services.Impl
{
    public class UserServiceImpl : IUserService
    {

        private IRepository<Users> _repository;

        public UserServiceImpl(IRepository<Users> repository)
        {
            _repository = repository;
        }

        public Users Create(Users user)
        {
            return _repository.Create(user);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<Users> FindAll()
        {
            return _repository.FindAll();
        }

        public Users FindById(long id)
        {
            var existUser = _repository.FindById(id);

            if (existUser == null)
            {
                return null;
            }
            return existUser;
        }

        public Users Update(Users user)
        {
            return _repository.Update(user);
        }
    }
}
