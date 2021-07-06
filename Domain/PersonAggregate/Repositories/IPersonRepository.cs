using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.PersonAggregate.Repositories
{
    public interface IPersonRepository : IRepository<Person>
    {

    }
}
