using Bitirme_Data.Context;
using Bitirme_Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Bitirme_Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class /*BaseEntity*/
    {
        private ShoppingListDbContext _context;
        DbSet<T> _entity = null;

        public GenericRepository(ShoppingListDbContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }
        public bool Add(T model)
        {
            try
            {
                _entity.Add(model);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(T model)
        {
            try
            {
                _entity.Remove(model);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<T> GetAll()
        {
            return _entity.ToList();
        }

        public T GetById(int id)
        {
            return _entity.Find(id);
        }

        public IQueryable<T> GetQuery()
        {
            return _entity;
        }

        public void Include<TProperty>(Expression<Func<T, TProperty>> navigationProperty)
        {
            _entity.Include(navigationProperty);
        }

        public bool Update(T model)
        {
            try
            {
                _entity.Update(model);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
