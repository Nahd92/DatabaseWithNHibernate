using NHibernate;
using System;


namespace SchoolTest
{
    public class CRUDHelpers
    {
        public static bool GetOneUserById(int studentId)
        {
            ISession session = NHibernateHelper.GetCurrentSession();
            try
            {
                using (var tx = session.BeginTransaction())
                {

                    var stdnt = session.Get<Student>(studentId);

                    if (stdnt == null)
                    {
                        Console.WriteLine("Theres not user with that ID, try again!");
                        return false;
                    }

                    Console.WriteLine("Retrieved by ID");
                    Console.WriteLine("{0} \t{1},\t{2}", stdnt.ID, stdnt.FirstName,
                            stdnt.LastName);


                    Console.WriteLine("\nFetch the complete list of again? Y/N");
                    string entireList = Console.ReadLine();

                    tx.Commit();
                    if (entireList == "Y".ToLower())
                    {
                        DisplayAllStudents();
                    }
                    else
                    {
                        Console.WriteLine("Hej då");
                    }
                    return true;
                }
            }
            finally
            {
                NHibernateHelper.CloseCurrentSession();
            }
        }

        public static bool DeleteUser(int id)
        {
            ISession session = NHibernateHelper.GetCurrentSession();

            try
            {
                using (var tx = session.BeginTransaction())
                {
                    var stdnt = session.Get<Student>(id);

                    if (stdnt == null)
                    {
                        Console.WriteLine("Theres not user with that ID, try again!");
                        return false;
                    }

                    Console.WriteLine("Retrieved by ID");
                    Console.WriteLine("{0} \t{1},\t{2}", stdnt.ID, stdnt.FirstName,
                            stdnt.LastName);

                    Console.WriteLine("\nFetch the complete list of again? Y/N");
                    string entireList = Console.ReadLine();

                    tx.Commit();
                    if (entireList == "Y".ToLower())
                    {
                        DisplayAllStudents();
                    }
                    else
                    {
                        Console.WriteLine("Hej då");
                    }
                    return true;
                }
            }
            finally
            {
                NHibernateHelper.CloseCurrentSession();
            }
        }

        public static bool UpdateStudent(int id)
        {
            ISession session = NHibernateHelper.GetCurrentSession();

            try
            {
                using (var tx = session.BeginTransaction())
                {
                    var stdnt = session.Get<Student>(id);

                    if (stdnt == null)
                    {
                        Console.WriteLine("Theres not user with that ID, try again!");
                        return false;
                    }
                    Console.WriteLine("Retrieved by ID");
                    Console.WriteLine("{0} \t{1},\t{2}", stdnt.ID, stdnt.FirstName,
                            stdnt.LastName);
                    System.Console.WriteLine();
                    Console.WriteLine("Update the last name of Id = {0}", stdnt.ID);
                    System.Console.WriteLine();
                    Console.WriteLine("Update firstname:  ");
                    string firstName = Console.ReadLine();
                    System.Console.WriteLine("Update LastName: ");
                    string lastName = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName))
                    {
                        stdnt.FirstName = firstName;
                        stdnt.LastName = lastName;
                    }
                    else if (!string.IsNullOrWhiteSpace(firstName) && string.IsNullOrWhiteSpace(lastName))
                    {
                        stdnt.FirstName = firstName;
                    }
                    else if (string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName))
                    {
                        stdnt.LastName = lastName;
                    }

                    session.Update(stdnt);

                    Console.WriteLine("\nFetch the complete list of again? Y/N");
                    string entireList = Console.ReadLine();

                    tx.Commit();
                    if (entireList == "Y".ToLower())
                    {
                        DisplayAllStudents();
                    }
                    return true;
                }
            }
            finally
            {
                NHibernateHelper.CloseCurrentSession();
            }
        }

        public static void CreateStudent()
        {
            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your lastname: ");
            string lastName = Console.ReadLine();

            var student = new Student()
            {
                FirstName = name,
                LastName = lastName
            };

            ISession session = NHibernateHelper.GetCurrentSession();

            try
            {
                using (var tx = session.BeginTransaction())
                {
                    session.Save(student);
                    tx.Commit();
                }
            }
            finally
            {
                NHibernateHelper.CloseCurrentSession();
            }
        }

        public static void DisplayAllStudents()
        {
            ISession session = NHibernateHelper.GetCurrentSession();

            try
            {
                using (var tx = session.BeginTransaction())
                {
                    var students = session.CreateCriteria<Student>().List<Student>();

                    foreach (var student in students)
                    {
                        Console.WriteLine("{0} \t{1}, \t{2}", student.ID, student.FirstName, student.LastName);
                    }
                    tx.Commit();
                }
                Console.ReadLine();
            }
            finally
            {
                NHibernateHelper.CloseCurrentSession();
            }
        }
    }
}