using System;
using System.Linq;
using System.Linq.Expressions;

namespace RepveUOW.Data.Repositories
{
    /// <summary>
    /// Model katmanımızda bulunan her T tipi için aşağıda tanımladığımız fonksiyonları gerçekleştirebilecek generic bir repository tanımlıyoruz.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate); // LINQ desteği sunabilmek içinde expression'ları kullanıyoruz.
        T GetById(int id);
        T Get(Expression<Func<T, bool>> predicate);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
    }
}