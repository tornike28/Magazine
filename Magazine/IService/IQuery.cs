namespace ConsoleApp2.Application.Service
{
    public interface IQuery
    {
        public void GetPersonPoint(string idNumber);

        public void GetPersonPoint(string idNumber, string subjectName);

        public void GetPersonsPoint(string subjectName);

        public void GetPersonsPoint();

    }
}