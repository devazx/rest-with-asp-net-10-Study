using restWithASPNET10Study.Data.Dto;

namespace restWithASPNET10Study.Services
{
    public interface IUserService
    {
        UsersDto Create(UsersDto user);
        UsersDto FindById(long id);
        List<UsersDto> FindAll();
        UsersDto Update(UsersDto user);
        void Delete(long id);

    }
}
