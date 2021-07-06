using Domain;
using Infrastructure;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2.Application.Service
{
    public class Query : RootExecute, IQuery
    {
        MagazineDbContext _db = new MagazineDbContext();


        /// <summary>
        ///  დააბრუნებს კონკრეტული სტუდენტის ქულებს
        /// </summary>
        /// <param name="idNumber"></param>
        #region
        public void GetPersonPoint(string idNumber)
        {
            var ResultItem = _db.Set<PersonSubject>()
                                                 .Where(x => x.IdNumber == idNumber)
                                                 .Select(x => new ResultItem { Point = x.Point })
                                                 .ToList();
            if (ResultItem.Count <= 0)
            {
                var exception = Fail(ErrorCode.IncorrectIdNumber);
                throw new NotImplementedException($"{exception.Code}");
            }

            foreach (var item in ResultItem)
            {
                Console.WriteLine(item.Point);
            }
        }
        #endregion


        /// <summary>
        ///     დააბრუნებს კონკრეტულ საგანში სტუდენტის  ინფორმაციას
        /// </summary>
        /// <param name="idNumber"></param>
        /// <param name="subjectName"></param>
        #region
        public void GetPersonPoint(string idNumber, string subjectName)
        {
            var ResultItem = _db.Set<PersonSubject>()
                                                 .Where(x => x.IdNumber == idNumber && x.SubjectName == subjectName)
                                                 .ToList();
            if (ResultItem.Count <= 0)
            {
                var exception = Fail(ErrorCode.IncorrectIdOrSubjectName);
                throw new NotImplementedException($"{exception.Code}");
            }

            foreach (var item in ResultItem)
            {
                Console.WriteLine($"{item.SubjectName} {item.Point}");
            }
        }
        #endregion


        /// <summary>
        ///    დააბრუნებს კონკრეტულ საგანში ყველა სტუდენტის ინფორმაციას
        /// </summary>
        /// <param name="subjectName"></param>
        #region
        public void GetPersonsPoint(string subjectName)
        {
            var PersonSubject = _db.Set<PersonSubject>()
                                                 .Where(x => x.SubjectName == subjectName)
                                                 .ToList();
            if (PersonSubject.Count <= 0)
            {
                var exception = Fail(ErrorCode.SuchSubjectDoesNotExist);
                throw new NotImplementedException($"{exception.Code}");
            }

            var result = PersonSubject
                                      .Join(_db.Set<Person>(), inner => inner.IdNumber, outer => outer.IdNumber, (person, subject) => new { Subject = person, Person = subject, })
                                      .Select(s => new ResultItem
                                      {
                                          IdNumber = s.Subject.IdNumber,
                                          Name = s.Person.Name,
                                          Point = s.Subject.Point
                                      })
                                      .ToList();

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Name} {item.IdNumber} {item.Point}");
            }
        }
        #endregion


        /// <summary>
        /// დააბრუნებს საგნების მიხედვით დაჯგუფებულ სტუნდების ინფორმაციას
        /// </summary>
        #region
        public void GetPersonsPoint()
        {

            var PersonSubject = _db.Set<PersonSubject>().ToList();

            var ResultItem = PersonSubject
                                     .Join(_db.Set<Person>(), inner => inner.IdNumber, outer => outer.IdNumber, (person, subject) => new { Subject = person, Person = subject, })
                                     .Select(s => new ResultItem
                                     {
                                         SubjectName = s.Subject.SubjectName,
                                         IdNumber = s.Subject.IdNumber,
                                         Name = s.Person.Name,
                                         Point = s.Subject.Point
                                     })
                                     .GroupBy(x => x.SubjectName)
                                     .ToList();

            foreach (var item in ResultItem)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine("");

                foreach (var person in item)
                {
                    Console.WriteLine($"{person.Name}-{person.IdNumber} point-{person.Point}");
                }
                Console.WriteLine("");
            }
        }
        #endregion
    }

    public class ResultItem
    {
        public string IdNumber { get; set; }

        public string Name { get; set; }

        public string SubjectName { get; set; }

        public decimal? Point { get; set; }
    }
}
