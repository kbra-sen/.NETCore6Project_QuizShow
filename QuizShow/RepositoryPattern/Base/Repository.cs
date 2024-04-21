using Microsoft.EntityFrameworkCore;
using QuizShow.Context;
using QuizShow.Models;
using QuizShow.RepositoryPattern.Interfaces;
using System.Linq.Expressions;

namespace QuizShow.RepositoryPattern.Base
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
       
        protected DbSet<T> table; // Tablolar
        MyDbContext _db; // Veritabanı
        public Repository(MyDbContext db)
        {
            _db = db;
            table = db.Set<T>();
        }
        public void Save()
        {
            _db.SaveChanges();
        }
        public void Add(T item)
        {
            table.Add(item);
            Save();
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return table.Any(exp);
        }

        public void Delete(int id)
        {
            T item = FindById(id);
            item.State= Enums.State.Deleted;
            item.ModifiedDate = DateTime.Now;
            table.Update(item);
            Save();
        }

        public T FindById(int id)
        {
            return table.Find(id);
        }

        public List<T> GetAll()
        {
            return table.ToList();
        }

        public List<T> GetAvailable()
        {
            return table.Where(x => x.State != Enums.State.Deleted).ToList();
        }

        public List<T> GetByAvailableLimit(int count)
        {
            return table.Where(x => x.State != Enums.State.Deleted).Take(count).ToList();
        }

        public List<T> GetByFilter(Expression<Func<T, bool>> exp)
        {
            return table.Where(exp).ToList();
        }

        public void HardDelete(int id)
        {
            T item = FindById(id);
            table.Remove(item);
            Save();

        }

        public void Update(T item)
        {
            item.ModifiedDate= DateTime.Now;
            item.State = Enums.State.Updated;
            table.Update(item);
            Save();
        }
    }
}
