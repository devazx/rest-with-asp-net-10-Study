using restWithASPNET10Study.Model;
using restWithASPNET10Study.Model.Context;

namespace restWithASPNET10Study.Services.Impl
{
    public class UserServiceImpl : IUserService
    {
        private MSSQLContext _context;

        public UserServiceImpl(MSSQLContext context)
        {
            _context = context;
        }

        public User Create(User user)
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

        public List<User> FindAll()
        {
            return _context.Users.ToList();
        }

        public User FindById(long id)
        {
            var existUser = _context.Users.Find(id);

            if (existUser == null)
            {
                return null;
            }
            return existUser;
        }

        public User Update(User user)
        {
            var existingUser = _context.Users.Find(user.Id);
            if (existingUser == null) return null;
            
            _context.Entry(existingUser).CurrentValues.SetValues(user);
            _context.SaveChanges();
            return user;
        }
    }
}
