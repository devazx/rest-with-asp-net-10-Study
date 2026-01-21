using restWithASPNET10Study.Data.Converter.Impl;
using restWithASPNET10Study.Data.Dto;
using restWithASPNET10Study.Model;
using restWithASPNET10Study.Model.Context;
using restWithASPNET10Study.Repositories;

namespace restWithASPNET10Study.Services.Impl
{
    public class UserServiceImpl : IUserService
    {

        private IRepository<Users> _repository;

        private readonly UserConverter _converter;

        public UserServiceImpl(IRepository<Users> repository)
        {
            _repository = repository;
            _converter = new UserConverter();
        }

        public UsersDto Create(UsersDto user)
        {
            var entity = _converter.Parse(user);
            entity = _repository.Create(entity);
            return _converter.Parse(entity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<UsersDto> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        public UsersDto FindById(long id)
        {
            var existUser = _converter.Parse(_repository.FindById(id));

            if (existUser == null)
            {
                return null;
            }
            return existUser;
        }

        public UsersDto Update(UsersDto user)
        {
            var entity = _converter.Parse(user);
            entity = _repository.Update(entity);
            return _converter.Parse(entity);
        }
    }
}
