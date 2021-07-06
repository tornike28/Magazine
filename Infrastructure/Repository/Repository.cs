using Domain.Repository;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class Repository<TContext, TRoot> : IRepository<TRoot>
        where TContext : DbContext
        where TRoot : class
    {
        TContext _context;
        public Repository(TContext context)
        {
            _context = context;
        }
        public async Task Delete(TRoot aggregateRoot)
        {
            _context.Set<TRoot>().Remove(aggregateRoot);

            await _context.SaveChangesAsync();
        }

        public async Task<TRoot> OfId(string id)
        {
            return await _context.Set<TRoot>().FindAsync(id);
        }

        public IQueryable<TRoot> Query(Expression<Func<TRoot, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public async Task Save(TRoot aggregateRoot)
        {
            _context.Set<TRoot>().Add(aggregateRoot);
        }
    }
}
