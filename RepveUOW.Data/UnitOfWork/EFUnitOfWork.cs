using System;
using RepveUOW.Data.Repositories;
using System.Data.Entity;

namespace RepveUOW.Data.UnitOfWork
{
    /// <summary>
    /// EntityFramework için oluşturmuş olduğumuz UnitOfWork.
    /// EFRepository'de olduğu gibi bu şekilde tasarlamamızın ana sebebi ise veritabanına independent(bağımsız) bir durumda kalabilmek. Örneğin MongoDB için ise ilgili provider'ı aracılığı ile MongoDBOfWork tasarlayabiliriz.
    /// </summary>
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly EFBlogContext _dbContext;

        public EFUnitOfWork(EFBlogContext dbContext)
        {
            Database.SetInitializer<EFBlogContext>(null);

            if (dbContext == null)
                throw new ArgumentNullException("dbContext can not be null.");

            _dbContext = dbContext;

            // Buradan istediğiniz gibi EntityFramework'ü konfigure edebilirsiniz.
            //_dbContext.Configuration.LazyLoadingEnabled = false;
            //_dbContext.Configuration.ValidateOnSaveEnabled = false;
            //_dbContext.Configuration.ProxyCreationEnabled = false;
        }

        #region IUnitOfWork Members
        public IRepository<T> GetRepository<T>() where T : class
        {
            return new EFRepository<T>(_dbContext);
        }

        public int SaveChanges()
        {
            try
            {
                return _dbContext.SaveChanges();
            }
            catch
            {
                // Burada DbEntityValidationException hatalarını handle edebiliriz.
                throw;
            }
        }
        #endregion

        #region IDisposable Members
        // Burada IUnitOfWork arayüzüne implemente ettiğimiz IDisposable arayüzünün Dispose Patternini implemente ediyoruz.
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }

            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}