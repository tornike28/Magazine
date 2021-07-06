using Domain;
using Domain.Aggregates.PersonSubjectAggregate.Repositories;
using Infrastructure.Repository;

namespace Infrastructure.Repositories
{
    public class PersonSubjectRepository : Repository<MagazineDbContext, PersonSubject>, IPersonSubjectRepository
    {
        public PersonSubjectRepository(MagazineDbContext context)
            : base(context)
        {

        }
    }
}
