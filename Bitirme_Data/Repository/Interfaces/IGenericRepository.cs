using Bitirme_Model.Entities.Base;
using System.Linq.Expressions;

namespace Bitirme_Data.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : class /*BaseEntity*/
    {
        bool Add(T model);
        bool Update(T model);
        T GetById(int id);
        IEnumerable<T> GetAll();
        bool Delete(T model);
        void Include<TProperty>(Expression<Func<T, TProperty>> navigationProperty);
        IQueryable<T> GetQuery();
    }
}
