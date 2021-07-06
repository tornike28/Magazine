using Domain.Aggregates.PersonAggregate.Repositories;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IService
{
    public interface ICommand
    {
        public void AddPerson(string name, string idNumber, int age, Gender gender);

        public void RemovePerson(string idNumber);

        public void AddSubject(string subjectName);

        public void AddPersonToSubject(string subjectName, string idNumber);

        public void SetPoint(string idNumber, string subjectName, int point);
    }
}
