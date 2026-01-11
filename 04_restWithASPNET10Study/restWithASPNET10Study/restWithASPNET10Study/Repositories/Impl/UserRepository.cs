using restWithASPNET10Study.Model;
using restWithASPNET10Study.Model.Context;

namespace restWithASPNET10Study.Repositories.Impl
{
    public class UserRepository : IUserRepository
    {
        private MSSQLContext _context;

        public UserRepository(MSSQLContext context)
        {
            _context = context;
        }

        public Users Create(Users user)
        {
            _context.Add(user);
            _context.SaveChanges();
            return user;
        }

        public void Delete(long id)
        {
            var existingUser = _context.Users.Find(id);
            if (existingUser == null) return;

            _context.Users.Remove(existingUser);
            _context.SaveChanges();
        }

        public List<Users> FindAll()
        {
            return _context.Users.ToList();
        }

        public Users FindById(long id)
        {
            var existUser = _context.Users.Find(id);

            if (existUser == null)
            {
                return null;
            }
            return existUser;
        }

        public Users Update(Users user)
        {
            var existingUser = _context.Users.Find((object)user.Id);
            if (existingUser == null) return null;

            _context.Entry(existingUser).CurrentValues.SetValues(user);
            _context.SaveChanges();
            return user;
        }
    }
}

