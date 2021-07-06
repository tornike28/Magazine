
namespace Domain
{
    public class PersonSubject
    {

        public PersonSubject(string subjectName, string idNumber)
        {
            SubjectName = subjectName;
            IdNumber = idNumber;
        }

        public int Id { get; set; }
        public string SubjectName { get; set; }
        public string IdNumber { get; set; }
        public int Point { get; set; }

        public void UpdatePoint(int point)
        {
            Point = point;
        }
    }
}
