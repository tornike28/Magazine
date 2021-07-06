using Domain;
using Domain.Aggregates.SubjectAggregate.Repositories;
using Infrastructure.Repository;

namespace Infrastructure.Repositories
{
    public class SubjectRepository : Repository<MagazineDbContext, Subject>, ISubjectRepository
    {
        public SubjectRepository(MagazineDbContext context)
            : base(context)
        {

        }
    }
}
