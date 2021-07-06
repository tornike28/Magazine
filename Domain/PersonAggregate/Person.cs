using Domain.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Person
    {

        public Person(
                      string idNumber,
                      string name,
                      int age,
                      Gender gender)
        {
            IdNumber = idNumber;
            Name = name;
            Age = age;
            Gender = gender;
            MemberSince = DateTimeOffset.Now;
        }

        [Key]
        public string IdNumber { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }

        public DateTimeOffset MemberSince { get; set; }
    }
}
