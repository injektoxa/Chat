using System;
using System.Linq;

namespace Chat.DataAccess.Interfaces
{
    /// <summary>
    /// Generic repository pattern interface for data persistance
    /// </summary>
    public interface IRepository<T> where T : class 
    {
        IQueryable<T> FindAll(Func<T, bool> exp);
        IQueryable<T> FindAll();
        T FindOne(Func<T, bool> exp);
        void Add(T entity);
        void SaveAll();
        void Delete(T entity);
    }
}