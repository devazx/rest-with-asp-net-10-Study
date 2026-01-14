using restWithASPNET10Study.Model;
using restWithASPNET10Study.Model.Base;

namespace restWithASPNET10Study.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {

        T Create(T item);
        T FindById(long id);
        List<T> FindAll();
        T Update(T item);
        void Delete(long id);
        bool Exists(long id);

    }
}
