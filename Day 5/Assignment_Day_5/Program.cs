using Assignment_Day_5.Interface;
using Assignment_Day_5.Repository;
using Assignment_Day_5.Service;

namespace Assignment_Day_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welome to Library Management System!");

            var studentRepository = new StudentRepository();
            var teacherRepository = new TeacherRepository();
            var librarianRepository = new LibrarianRepository();

            var studentSystem = new LibraryManagementSystem(studentRepository);
            studentSystem.BorrowBook("C# Programming ");
            studentSystem.ReserveBook("C# Programming "); // Permission not allowed 

            var teacherSystem = new LibraryManagementSystem(teacherRepository, teacherRepository);
            teacherSystem.BorrowBook("Javascript programmingg");
            teacherSystem.ReserveBook("Javascript programmingg");

            var librarianSystem = new LibraryManagementSystem(librarianRepository, librarianRepository, librarianRepository);
            librarianSystem.BorrowBook("Python Programming");
            librarianSystem.ReserveBook("Python Programming");
            librarianSystem.AddBook("New DotNet Programming");
            librarianSystem.RemoveBook("Old DotNet Programming");

            Console.ReadKey();
        }
    }
}
