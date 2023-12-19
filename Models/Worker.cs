using System;
using System.Collections.Generic;

namespace School_Lab3.Models;

public partial class Worker
{
    public int WorkerNumber { get; set; }

    public string WorkerBirthDate { get; set; } = null!;

    public string WorkerFirstName { get; set; } = null!;

    public string WorkerLastName { get; set; } = null!;

    public string WorkerProfession { get; set; } = null!;

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public static void AddWorker() 
    {
        Console.WriteLine("First name: ");
        string userInputFirstName = Console.ReadLine();

        Console.WriteLine("Last name: ");
        string userInputLastName = Console.ReadLine();

        Console.WriteLine("Birth date (YYYYMMDDNNNN): ");
        string userInputBirthDate = Console.ReadLine();

        Console.WriteLine("Profession: ");
        string userInputProfesssion = Console.ReadLine();

        using (var db = new SchoolContext())
        {
            var worker = new Worker()
            {
                WorkerFirstName = userInputFirstName,
                WorkerLastName = userInputLastName,
                WorkerBirthDate = userInputBirthDate,
                WorkerProfession = userInputProfesssion
            };
            db.Workers.Add(worker);
            db.SaveChanges();
            Console.WriteLine("Task Succesful.");
        }
    }
}
