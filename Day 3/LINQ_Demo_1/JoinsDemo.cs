using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_Demo_1
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
    }

    internal class JoinsDemo
    {
        // List of students
        IList<Student> studentList = new List<Student>()
        {
            new Student() { StudentId = 1, Name = "Gem", Age = 18 ,CourseId = 31},
            new Student() { StudentId = 2, Name = "Julie", Age = 15 ,CourseId = 32},
            new Student() { StudentId = 3, Name = "Harsh", Age = 25 ,CourseId = 33},
            new Student() { StudentId = 4, Name = "Raj", Age = 20 ,CourseId = 31},
            new Student() { StudentId = 5, Name = "Raju", Age = 15 ,CourseId = 32},
            new Student() { StudentId = 6, Name = "Somu", Age = 18 ,CourseId = 33},
            new Student() { StudentId = 7, Name = "Monu", Age = 25 ,CourseId = 32},
            new Student() { StudentId = 8, Name = "Chintu", Age = 20 ,CourseId = 32}
        };

        // List of courses
        IList<Course> courseList = new List<Course>()
        {
            new Course() {CourseId = 31, CourseName = "AWS"},
            new Course() {CourseId = 32, CourseName = "Azure"},
            new Course() {CourseId = 33, CourseName = "NodeJs"}
        };

        // Method to join students and courses
        public void Join()
        {
            // Performing the join between students and courses
            var joinedResult = studentList.Join(
                courseList,
                student => student.CourseId,
                course => course.CourseId,
                (student, course) => new
                {
                    studentName = student.Name,
                    studentAge = student.Age,
                    studentCourse = course.CourseName
                });

            // Displaying the joined results
            Console.WriteLine("\nData from Student and Course lists:");
            foreach (var studentInfo in joinedResult)
            {
                // Adding spaces between the fields
                Console.WriteLine($"{studentInfo.studentName} {studentInfo.studentAge} {studentInfo.studentCourse}");
            }
        }
    }
}
