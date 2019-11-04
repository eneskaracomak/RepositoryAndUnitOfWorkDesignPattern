using System;
using RepveUOW.Data.Repositories;

namespace RepveUOW.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class;
        int SaveChanges();
    }
}