using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Confingurations
{
    public class PersonSubjectTypeConfiguration : IEntityTypeConfiguration<PersonSubject>
    {
        public void Configure(EntityTypeBuilder<PersonSubject> builder)
        {
        }
    }
}


