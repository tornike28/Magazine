using Domain;
using Domain.Aggregates.PersonAggregate.Repositories;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PersonRepository : Repository<MagazineDbContext, Person>, IPersonRepository
    {
        public PersonRepository(MagazineDbContext context)
            : base(context)
        {

        }
    }
}
