using LibraryManagementSystemWebApplication.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace LibraryManagementSystemWebApplication.GenericRepository
{
    public interface IGenericRepositoryLMS<T>
    {
        bool Create(T entity);

        List<T> Read();

        bool Update(T entity);

        bool Delete(T entity);
    }

    public class GenericRepositoryLMS<T> : IGenericRepositoryLMS<T> where T : class
    {
        private readonly LibraryDBContext _DBContext;

        public GenericRepositoryLMS(LibraryDBContext DbContext)
        {
            this._DBContext = DbContext;
        }


        public bool Create(T entity)
        {
             bool IsCreated = false;

            _DBContext.Set<T>().Add(entity);
            _DBContext.SaveChanges();
			IsCreated = true;
			return IsCreated;
        }


        public List<T> Read()
        {
            List<T> Resultlist = new List<T>();

            Resultlist = _DBContext.Set<T>().ToList();

            return Resultlist;
        }

        public bool Update(T entity)
        {
            {
                _DBContext.Set<T>().Update(entity);
                _DBContext.SaveChanges();
                return true;
            }
		}

        public bool Delete(T entity)
        {
            bool IsDeleted = false;
            //using (var obj = new LibraryDBContext(new DbContextOptions<LibraryDBContext>() { }))
                _DBContext.Set<T>().Remove(entity);
				_DBContext.SaveChanges();
                IsDeleted = true;
            
            return IsDeleted;
		}

    }
}
