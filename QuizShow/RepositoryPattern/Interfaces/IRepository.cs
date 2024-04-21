using QuizShow.Models;
using System.Linq.Expressions;

namespace QuizShow.RepositoryPattern.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {

        List<T> GetAll();
        List<T> GetAvailable();
        void Add(T item);
        void Update(T item);
        void Delete(int id);
        void HardDelete(int id);
        bool Any(Expression<Func<T,bool>> exp );
        List<T> GetByFilter(Expression<Func<T, bool>> exp);
        List<T> GetByAvailableLimit(int count);
        T FindById(int id); 
    }
}
