using System;
using System.Collections.Generic;
using System.Net.WebSockets;

namespace School_Lab3.Models;

public partial class Student
{
    public int StudentNumber { get; set; }

    public string StudentBirthDate { get; set; } = null!;

    public string StudentFirstName { get; set; } = null!;

    public string StudentLastName { get; set; } = null!;

    public int? StudentAge { get; set; }

    public string? StudentGender { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
    public static void GetStudentsFirstName()
    {
        Console.WriteLine("Do you want descending list? yes or no");
        string userInput = Console.ReadLine().ToLower();
        if (userInput == "yes")
        {
            using (var db = new SchoolContext())
            {
                var students = db.Students.OrderByDescending(x => x.StudentFirstName).ToList();
                foreach (var student in students)
                {
                    Console.WriteLine($"{student.StudentFirstName} {student.StudentLastName}");
                }
            }
        }
        else
        {
            using (var db = new SchoolContext())
            {
                var students = db.Students.OrderBy(x => x.StudentFirstName).ToList();
                foreach (var student in students)
                {
                    Console.WriteLine($"{student.StudentFirstName} {student.StudentLastName}");
                }
            }
        }
    }
    public static void GetStudentsLastName()
    {
        Console.WriteLine("1. Descending list. \n2. Ascending list.");
        int.TryParse(Console.ReadLine(), out int userInput);
        if (userInput == 1)
        {
            using (var db = new SchoolContext())
            {
                var students = db.Students.OrderByDescending(x => x.StudentLastName).ToList();
                foreach (var student in students)
                {
                    Console.WriteLine($"{student.StudentLastName} {student.StudentFirstName}");
                }
            }
        }
        else if (userInput == 2) 
        {
            using (var db = new SchoolContext())
            {
                var students = db.Students.OrderBy(x => x.StudentLastName).ToList();
                foreach (var student in students)
                {
                    Console.WriteLine($"{student.StudentLastName} {student.StudentFirstName}");
                }
            }
        }
    }
    public static void AddStudent() 
    {
        Console.WriteLine("First name: ");
        string userInputFirstName = Console.ReadLine();

        Console.WriteLine("Last name: ");
        string userInputLastName = Console.ReadLine();

        Console.WriteLine("Birth date (YYYYMMDDNNNN): ");
        string userInputBirthDate = Console.ReadLine();

        using (var db = new SchoolContext())
        {
            var student = new Student()
            {
                StudentFirstName = userInputFirstName,
                StudentLastName = userInputLastName,
                StudentBirthDate = userInputBirthDate

            };
            db.Students.Add(student);
            db.SaveChanges();
            Console.WriteLine("Task Succesful.");
        }
    }
}
