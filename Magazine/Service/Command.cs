using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Models;
using Domain;
using Application.IService;
using Infrastructure;
using Shared;

namespace Application.Service
{
    public class Command : RootExecute, ICommand
    {
        MagazineDbContext _db = new MagazineDbContext();


        /// <summary>
        ///  AddPerson
        /// </summary>
        /// <param name="name"></param>
        /// <param name="idNumber"></param>
        /// <param name="age"></param>
        /// <param name="gender"></param>
        #region

        public void AddPerson(string idNumber, string name, int age, Gender gender)
        {

            if (string.IsNullOrEmpty(name.Trim()))
            {
                var exception = Fail(ErrorCode.PersonNameNotValid);
                throw new NotImplementedException($"{exception.Code}");
            }

            if (!RegExes.IdNumber.IsMatch(idNumber))
            {
                var exception = Fail(ErrorCode.IncorrectFormatIdNumber);
                throw new NotImplementedException($"{exception.Code}");
            }

            if (!RegExes.Age.IsMatch($"{age}"))
            {
                var exception = Fail(ErrorCode.IncorrectAge);
                throw new NotImplementedException($"{exception.Code}");
            }

            var newPerson = new Person(idNumber, name, age, gender);
            if (_db.Set<Person>().Any(x => x.IdNumber == idNumber))
            {
                var exception = Fail(ErrorCode.UserIdMustBeUnique);
                throw new NotImplementedException($"{exception.Code}");
            }

            _db.Set<Person>().Add(newPerson);
            _db.SaveChanges();
        }
        #endregion


        /// <summary>
        /// AddPersonToSubject
        /// </summary>
        /// <param name="subjectName"></param>
        /// <param name="idNumber"></param>
        #region
        public void AddPersonToSubject(string subjectName, string idNumber)
        {

            if (!_db.Set<Person>().Any(x => x.IdNumber == idNumber))
            {
                var exception = Fail(ErrorCode.SuchPersonDoesNotExist);
                throw new NotImplementedException($"{exception.Code}");
            }

            if (!_db.Set<Subject>().Any(x => x.Name == subjectName))
            {
                var exception = Fail(ErrorCode.SuchSubjectDoesNotExist);
                throw new NotImplementedException($"{exception.Code}");
            }

            if (_db.Set<PersonSubject>().Any(x => x.SubjectName == subjectName && x.IdNumber == idNumber))
            {
                var exception = Fail(ErrorCode.SuchRecordALreadyExist);
                throw new NotImplementedException($"{exception.Code}");
            }
            var personSubject = new PersonSubject(subjectName, idNumber);

            _db.Set<PersonSubject>().Add(personSubject);
            _db.SaveChanges();
        }
        #endregion


        /// <summary>
        /// AddSubjectb
        /// </summary>
        /// <param name="subjectName"></param>
        #region

        public void AddSubject(string subjectName)
        {
            if (string.IsNullOrEmpty(subjectName.Trim()))
            {
                var exception = Fail(ErrorCode.SubjectNameNotValid);
                throw new NotImplementedException($"{exception.Code}");
            }

            if (_db.Set<Subject>().Any(x => x.Name == subjectName))
            {
                var exception = Fail(ErrorCode.SubjectNameMustBeUnique);
                throw new NotImplementedException($"{exception.Code}");
            }

            var subject = new Subject(subjectName);

            _db.Set<Subject>().Add(subject);
            _db.SaveChanges();
        }
        #endregion


        /// <summary>
        /// RemovePerson
        /// </summary>
        /// <param name="idNumber"></param>
        #region

        public void RemovePerson(string idNumber)
        {

            if (!_db.Set<Person>().Any(x => x.IdNumber == idNumber))
            {
                var exception = Fail(ErrorCode.SuchPersonDoesNotExist);
                throw new NotImplementedException($"{exception.Code}");
            }

            var person = _db.Set<Person>().FirstOrDefault(x => x.IdNumber == idNumber);
            _db.Set<Person>().Remove(person);
            _db.SaveChanges();

        }
        #endregion


        /// <summary>
        /// SetPoint
        /// </summary>
        /// <param name="idNumber"></param>
        /// <param name="subjectName"></param>
        /// <param name="point"></param>
        #region
        public void SetPoint(string subjectName, string idNumber, int point)
        {
            var Person = _db.Set<PersonSubject>().FirstOrDefault(s => s.SubjectName == subjectName && s.IdNumber == idNumber);
            if (Person.IsNull())
            {
                var exception = Fail(ErrorCode.IncorrectIdOrSubjectName);
                throw new NotImplementedException($"{exception.Code}");
            }

            if (RegExes.Point.IsMatch($"{point}"))
            {
                var exception = Fail(ErrorCode.IncorrectPoint);
                throw new NotImplementedException($"{exception.Code}");
            }
            Person.UpdatePoint(point);

            _db.Update(Person);
            _db.SaveChanges();
        }
        #endregion
    }
}
