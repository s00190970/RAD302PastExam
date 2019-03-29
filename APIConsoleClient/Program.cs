using APIClientInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace APIConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            UserAuthentication.baseWebAddress = "http://localhost:56781/";
            bool logged = UserAuthentication.login("powell.paul@itsligo.ie", "itsPaul$1");
            if (logged)
            {
                Console.WriteLine("\nList of Students:");
                List<Student> students = UserAuthentication.GetStudents();
                foreach (Student student in students)
                {
                    Console.WriteLine(student.FirstName + " " + student.LastName);
                }
                Console.ReadKey();
            }
        }
    }
}
