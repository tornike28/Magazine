using Application.IService;
using Application.Service;
using ConsoleApp2.Application.Service;
using Domain.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class ConsoleHelper : RootExecute
    {
        ICommand command = new Command();
        IQuery query = new Query();

        string Continue = "No";
        public void Execute()
        {

            do
            {
                Console.WriteLine("1 - Commands");
                Console.WriteLine("2 - Queries");
                int input = Convert.ToInt32(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        Console.WriteLine("1 - AddPerson");
                        Console.WriteLine("2 - AddSubject");
                        Console.WriteLine("3 - AddPersonToSubject");
                        Console.WriteLine("4 - RemovePerson");
                        Console.WriteLine("5 - SetPoint");

                        int commandName = Convert.ToInt32(Console.ReadLine());

                        if (!RegExes.CommandName.IsMatch($"{commandName}"))
                        {
                            var exception = Fail(ErrorCode.ThereIsNoSuchCommand);
                            throw new NotImplementedException($"{exception.Code}");
                        }

                        switch (commandName)
                        {
                            case 1:
                                Console.WriteLine("Student Id Number");
                                var idNumber = Console.ReadLine();

                                Console.WriteLine("Student Full Name");
                                var studentName = Console.ReadLine();



                                Console.WriteLine("Student Age");
                                var age = Convert.ToInt32(Console.ReadLine());


                                Console.WriteLine("Choose gemder:");
                                Console.WriteLine("Male - 1");
                                Console.WriteLine("Female - 2");
                                var gender = Convert.ToInt32(Console.ReadLine()) == 1 ? Gender.Male : Gender.Female
;
                                command.AddPerson(idNumber, studentName, age, gender);

                                Console.WriteLine("Student has been added");

                                Console.WriteLine("For a repeat operation, enter: Yes");
                                Continue = Console.ReadLine();

                                break;
                            case 2:

                                Console.WriteLine("Subject Name");
                                var subjectName = Console.ReadLine();

                                command.AddSubject(subjectName);
                                Console.WriteLine("Subject has been added");

                                Console.WriteLine("For a repeat operation, enter: Yes");
                                Continue = Console.ReadLine();

                                break;
                            case 3:

                                Console.WriteLine("Subject Name");
                                var name = Console.ReadLine();

                                Console.WriteLine("ID number");
                                var id = Console.ReadLine();

                                command.AddPersonToSubject(name, id);
                                Console.WriteLine("Student has been added");

                                Console.WriteLine("For a repeat operation, enter: Yes");
                                Continue = Console.ReadLine();

                                break;
                            case 4:

                                Console.WriteLine("ID number");
                                var studentId = Console.ReadLine();


                                Console.WriteLine("Are you sure you want to delete?");
                                Console.WriteLine("Yes or No");

                                bool Delete = Console.ReadLine().ToLower() == "yes" ? true : false;
                                if (Delete)
                                {
                                    command.RemovePerson(studentId);
                                    Console.WriteLine("Student has been deleted");
                                }


                                Console.WriteLine("For a repeat operation, enter: Yes");
                                Continue = Console.ReadLine();

                                break;
                            case 5:
                                Console.WriteLine("Subject Name");
                                var nameOfSubject = Console.ReadLine();

                                Console.WriteLine("ID number");
                                var IdOfStudent = Console.ReadLine();

                                Console.WriteLine("Point");
                                var point = Convert.ToInt32(Console.ReadLine());

                                command.SetPoint(nameOfSubject, IdOfStudent, point);

                                Console.WriteLine("For a repeat operation, enter: Yes");
                                Continue = Console.ReadLine();
                                break;
                        }
                        break;
                    case 2:
                        Console.WriteLine("1 - GetPersonPoint(Returns points for a specific student");
                        Console.WriteLine("2 - GetPersonPoint(Returns student information in a specific subject)");
                        Console.WriteLine("3 - GetPersonsPoint(Returns all student information in a specific subject)");
                        Console.WriteLine("4 - GetPersonsPoint(Returns the information of the students grouped by subjects)");

                        int queryName = Convert.ToInt32(Console.ReadLine());

                        if (!RegExes.QueryName.IsMatch($"{queryName}"))
                        {
                            var exception = Fail(ErrorCode.ThereIsNoSuchQuery);
                            throw new NotImplementedException($"{exception.Code}");
                        }
                        switch (queryName)
                        {
                            case 1:

                                Console.WriteLine("student Id Number");
                                var studentId = Console.ReadLine();
                                query.GetPersonPoint(studentId);

                                Console.WriteLine("For a repeat operation, enter: Yes");
                                Continue = Console.ReadLine();

                                break;
                            case 2:

                                Console.WriteLine("student Id Number");
                                var id = Console.ReadLine();

                                Console.WriteLine("Subject Name");
                                var subjectName = Console.ReadLine();

                                query.GetPersonPoint(id, subjectName);

                                Console.WriteLine("For a repeat operation, enter: Yes");
                                Continue = Console.ReadLine();

                                break;
                            case 3:

                                Console.WriteLine("Subject Name");
                                var nameOfSubject = Console.ReadLine();

                                query.GetPersonsPoint(nameOfSubject);

                                Console.WriteLine("For a repeat operation, enter: Yes");
                                Continue = Console.ReadLine();

                                break;

                            case 4:

                                query.GetPersonsPoint();

                                Console.WriteLine("For a repeat operation, enter: Yes");
                                Continue = Console.ReadLine();

                                break;
                        }
                        break;
                }
            } while (Continue.ToLower() == "yes");
        }
    }
}
