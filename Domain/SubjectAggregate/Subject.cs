using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Subject
    {

        public Subject(string name)
        {
            Name = name;
            CreateDate = DateTimeOffset.Now;
        }

        [Key]
        public string Name { get; set; }

        public DateTimeOffset CreateDate { get; set; }
    }
}
