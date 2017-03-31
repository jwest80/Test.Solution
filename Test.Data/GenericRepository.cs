using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Test.Data;
using Test.Model;

namespace Test.Repo
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> Read();
        IQueryable<T> Read(Expression<Func<T, bool>> predicate);
        void Create(T entity);
        void Delete(T entity);
        void Update(T entity);
        void Save();
    }


    public class GenericRepository<T> :IGenericRepository<T> where T : class
    {
        private DbContext _context;

        public GenericRepository(DbContext context)
        {
            _context = context;
        }

        public virtual void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public virtual IQueryable<T> Read()
        {
            IQueryable<T> query = _context.Set<T>();
            return query;
        }

        public IQueryable<T> Read(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {

            IQueryable<T> query = _context.Set<T>().Where(predicate);
            return query;
        }

        public virtual void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public virtual void Save()
        {
            _context.SaveChanges();
        }
    }
}
