using restWithASPNET10Study.Data.Converter.Contract;
using restWithASPNET10Study.Data.Dto;
using restWithASPNET10Study.Model;

namespace restWithASPNET10Study.Data.Converter.Impl
{
    public class UserConverter : IUsers<Users, UsersDto>, IUsers<UsersDto, Users>
    {
        public Users Parse(UsersDto origin)
        {
            if (origin == null) return null;
            return new Users
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender
            };
        }

        public UsersDto Parse(Users origin)
        {
            if (origin == null) return null;
            return new UsersDto
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender
            };
        }

        public List<Users> ParseList(List<UsersDto> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<UsersDto> ParseList(List<Users> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
