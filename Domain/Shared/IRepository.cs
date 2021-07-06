using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IRepository<TRoot> where TRoot : class
    {
        Task<TRoot> OfId(string id);

        Task Delete(TRoot aggregateRoot);

        Task Save(TRoot aggregateRoot);

        IQueryable<TRoot> Query(Expression<Func<TRoot, bool>> expression = null);
    }
}
