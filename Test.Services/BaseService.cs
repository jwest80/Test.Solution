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
        // DISPOSING - This class does NOT specifically dispose DBContext b/c Entity Framework handles this
        // Still trying to decide if this should be handled here.
        //
        // Warning! - You must dispose DB context manually in the following two cases.
        // 1. The default automatic open/close behavior is relatively easy to override: you can assume 
        //      control of when the connection is opened and closed by manually opening the connection. Once you 
        //      start doing this in some part of your code, then forgetting to dipose the context becomes harmful, 
        //      because you might be leaking open connections.
        // 2. DbContext implements IDiposable following the recommended pattern, which includes exposing a virtual 
        //      protected Dispose method that derived types can override if for example the need to aggregate other 
        //      unmanaged resources into the lifetime of the context.
        //
        // Read More here: http://blog.jongallant.com/2012/10/do-i-have-to-call-dispose-on-dbcontext/

        // TODO: http://mehdi.me/ambient-dbcontext-in-ef6/
        // Managing DbContext the right way with Entity Framework 6: an in-depth guide

        private DbContext _context;
        private GenericRepository<M> _repo;

        public BaseService(DbContext context = null)
        {
            if (context == null)
            {
                _context = new BloggingContext();
            }
            
            _repo = (new GenericRepository<M>(_context));
        }

        public virtual int Create(M model)
        {
            //using (var scope = _context)
            //{
                _repo.Create(model);
                _repo.Save();
                return model.Id;
            //}   
        }

        public virtual List<M> Read()
        {
            //using (var scope = _context)
            //{
                var models = _repo.Read().ToList();
                return models;
            //}
        }

        public virtual List<M> Read(Expression<Func<M, bool>> predicate)
        {
            var models = _repo.Read(predicate).ToList();
            return models;
        }

        public virtual M ReadById(int id)
        {
            var model = _repo.Read(x => x.Id == id).FirstOrDefault();
            return model;
        }

        public virtual void Update(M model)
        {
            _repo.Update(model);
            _repo.Save();
        }

        public virtual void Delete(int id)
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
