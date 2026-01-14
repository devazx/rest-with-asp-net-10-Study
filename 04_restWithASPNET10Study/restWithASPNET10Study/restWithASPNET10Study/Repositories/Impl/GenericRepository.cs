using Microsoft.EntityFrameworkCore;
using restWithASPNET10Study.Model;
using restWithASPNET10Study.Model.Base;
using restWithASPNET10Study.Model.Context;

namespace restWithASPNET10Study.Repositories.Impl
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private MSSQLContext _context;
        private DbSet<T> _dataset;

        public GenericRepository(MSSQLContext context)
        {
            _context = context;
            _dataset = context.Set<T>();
        }

        public T Create(T item)
        {
            _context.Add(item);
            _context.SaveChanges();
            return item;
        }

        public void Delete(long id)
        {
            var existingItem = _dataset.Find(id);
            if (existingItem == null) return;

            _context.Remove(existingItem);
            _context.SaveChanges();
        }

        public bool Exists(long id)
        {
            return _dataset.Any(e => e.Id == id);
        }

        public List<T> FindAll()
        {
            return _dataset.ToList();
        }

        public T FindById(long id)
        {
            var existItem = _dataset.Find(id);

            if (existItem == null)
            {
                return null;
            }
            return existItem;
        }

        public T Update(T item)
        {
            var existingbooks = _dataset.Find(item.Id);
            if (existingbooks == null) return null;

            _context.Entry(existingbooks).CurrentValues.SetValues(item);
            _context.SaveChanges();
            return item;
        }
    }
}
