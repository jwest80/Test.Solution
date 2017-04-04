using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Test.Data;
using Test.Model;
using Test.Repo;

namespace Test.Services
{
    public interface IService<M> where M : class, IEntity<int>
    {
        List<M> Read();
        List<M> Read(Expression<Func<M, bool>> predicate);

        M ReadById(int id);
        int Create(M model);
        void Delete(int id);
        void Update(M model);
    }

    /// <summary>
    /// The generic service allows for Entity... 
    /// No Mapping (accepts and return Entity)
    /// </summary>
    /// <typeparam name="M">Entity of type IEntity</typeparam>
    /// <seealso cref="System.IDisposable" />
    /// <seealso cref="Services.IService{M}" />
    public class BaseService<M> : IDisposable,
        IService<M> where M : class, IEntity<int>
    {

        private DbContext _context;
        private GenericRepository<M> _repo;

        public BaseService(DbContext context = null)
        {
            _context = new BloggingContext();
            _repo = (new GenericRepository<M>(_context));
        }

        public int Create(M model)
        {
            _repo.Create(model);
            _repo.Save();
            return model.Id;
        }

        public List<M> Read()
        {
            var models = _repo.Read().ToList();
            return models;
        }

        public List<M> Read(Expression<Func<M, bool>> predicate)
        {
            var models = _repo.Read(predicate).ToList();
            return models;
        }

        public M ReadById(int id)
        {
            var model = _repo.Read(x => x.Id == id).FirstOrDefault();
            return model;
        }

        public void Update(M model)
        {
            _repo.Update(model);
            _repo.Save();
        }

        public void Delete(int id)
        {
            var modelToDelete = _repo.Read(x => x.Id == id).FirstOrDefault();
            _repo.Delete(modelToDelete);
            _repo.Save();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
