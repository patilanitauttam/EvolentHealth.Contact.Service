using System.Threading.Tasks;

namespace EvolentHealth.Contact.DataAccess.Interface
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        Task<int> Add(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(T entity);
    }
}
