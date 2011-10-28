using System;
using System.Data.Linq;
using System.Linq;
using Chat.DataAccess.Interfaces;

namespace Chat.DataAccess.Data
{
    public class SqlRepository<T> : IRepository<T> where T : class
    {
        private readonly DataContext _context;

        public SqlRepository(DataContext context)
        {
            _context = context;
        }

        #region IRepository<T> Members

        public IQueryable<T> FindAll(Func<T, bool> exp)
        {
            return _context.GetTable<T>().Where(exp).AsQueryable();
        }

        public IQueryable<T> FindAll()
        {
            return _context.GetTable<T>();
        }

        public T FindOne(Func<T, bool> exp)
        {
            return FindAll(exp).FirstOrDefault();
        }

        public void Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Entity cannot be null");
            }
            _context.GetTable<T>().InsertOnSubmit(entity);
        }

        public void SaveAll()
        {
            _context.SubmitChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Entity cannot be null");
            }
            _context.GetTable<T>().DeleteOnSubmit(entity);
        }

        #endregion
    }
}
