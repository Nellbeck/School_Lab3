using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace School_Lab3.Models;

public partial class Class
{
    public int ClassId { get; set; }

    public string? ClassName { get; set; }

    public int? FkStudenNumber { get; set; }

    public int? FkWorkerNumber { get; set; }

    public virtual Student? FkStudenNumberNavigation { get; set; }

    public virtual Worker? FkWorkerNumberNavigation { get; set; }

    public static void GetStudentsInClass() 
    {
        using (var db = new SchoolContext())
        {
            var studentClassGroup = db.Classes.GroupBy(x =>x.ClassName);
            var studentsInClass = db.Classes.ToList();
            var students = db.Students.ToList();
            foreach (var group in studentClassGroup)
            {
                Console.WriteLine($"{group.Key}");
            }
            Console.WriteLine("\nChoose a class to see all students in that class.");
            string userInput = Console.ReadLine().ToUpper();

            foreach (var std in studentsInClass) 
            {
                foreach (var id in students)
                {
                    if (std.ClassName == userInput)
                    {
                        if (std.FkStudenNumber == id.StudentNumber)
                        {
                            Console.WriteLine($"{id.StudentFirstName} {id.StudentLastName}");
                        }
                    }
                }
            }
        }
    }
}
