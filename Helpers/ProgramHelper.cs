using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using System;
using System.Reflection;

namespace SchoolTest
{
    public static class ProgramHelper
    {

        public static void WelcomeScreen()
        {
            while (true)
            {
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("------------------------");
                Console.WriteLine("1. See list of all students?");
                Console.WriteLine("2. Get one student?");
                Console.WriteLine("3. Delete one student?");
                Console.WriteLine("4. Update one student?");
                Console.WriteLine("5. Create one student?");
                Console.WriteLine("------------------------");
                Console.WriteLine("Teachers options!");
                Console.WriteLine("6. See list of all Teachers?");
                Console.WriteLine("7. Create one Teacher?");
                int input = int.Parse(Console.ReadLine());

                string checkIfContinue = "";

                switch (input)
                {
                    case 1:
                        CRUDHelpers.DisplayAllStudents();
                        Console.WriteLine("Continue? Y/N");
                        checkIfContinue = Console.ReadLine();
                        if (checkIfContinue == "N".ToLower())
                        {
                            System.Environment.Exit(1);
                        }
                        continue;
                    case 2:
                        Console.WriteLine("Enter an Id to get one student: ");
                        int studentId = int.Parse(Console.ReadLine());
                        CRUDHelpers.GetOneUserById(studentId);
                        checkIfContinue = Console.ReadLine();
                        if (checkIfContinue == "N".ToLower())
                        {
                            System.Environment.Exit(1);
                        }
                        continue;
                    case 3:
                        Console.WriteLine("Enter an Id to remove Student: ");
                        int id = int.Parse(Console.ReadLine());
                        CRUDHelpers.DeleteUser(id);
                        checkIfContinue = Console.ReadLine();
                        if (checkIfContinue == "N".ToLower())
                        {
                            System.Environment.Exit(1);
                        }
                        continue;
                    case 4:
                        Console.WriteLine("What student do you want update? Type ID!");
                        int position = int.Parse(Console.ReadLine());
                        CRUDHelpers.UpdateStudent(position);
                        checkIfContinue = Console.ReadLine();
                        if (checkIfContinue == "N".ToLower())
                        {
                            System.Environment.Exit(1);
                        }
                        continue;
                    case 5:
                        CRUDHelpers.CreateStudent();
                        Console.WriteLine("Continue? Y/N");
                        checkIfContinue = Console.ReadLine();
                        if (checkIfContinue == "N".ToLower())
                        {
                            System.Environment.Exit(1);
                        }
                        continue;
                    case 6:
                        CRUDHelpers.DisplayAllTeachers();
                        Console.WriteLine("Continue? Y/N");
                        checkIfContinue = Console.ReadLine();
                        if (checkIfContinue == "N".ToLower())
                        {
                            System.Environment.Exit(1);
                        }
                        continue;
                    case 7:
                        CRUDHelpers.CreateTeacher();
                        Console.WriteLine("Continue? Y/N");
                        checkIfContinue = Console.ReadLine();
                        if (checkIfContinue == "N".ToLower())
                        {
                            System.Environment.Exit(1);
                        }
                        continue;
                    default:
                        System.Environment.Exit(1);
                        break;
                }
            }
        }
    }
}