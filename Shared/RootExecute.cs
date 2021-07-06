using Domain.Aggregates.PersonAggregate.Repositories;
using Domain.Aggregates.PersonSubjectAggregate.Repositories;
using Domain.Aggregates.SubjectAggregate.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Shared
{
    public abstract class RootExecute
    {
        protected ISubjectRepository SubjectRepository;
        protected IPersonRepository PersonRepository;
        protected IPersonSubjectRepository PersonSubjectRepository;
        protected IServiceProvider ServiceProvider;
        protected IConfiguration Configuration;


        public static Error Fail(ErrorCode errorCode, string errorMessage = null)
        {
            var result = new Error
            {
                Code = errorCode,
                Message = errorMessage ?? string.Empty
            };
            Console.WriteLine(result.Code);
            return result;
        }
    }
}
