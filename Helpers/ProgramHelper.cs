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
                        Console.WriteLine("Vilken ID vill du updatera i databasen");
                        int position = int.Parse(Console.ReadLine());
                        CRUDHelpers.UpdateStudent(position);
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