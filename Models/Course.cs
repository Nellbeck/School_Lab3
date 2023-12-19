using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace School_Lab3.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string? CourseName { get; set; }

    public string? CourseGradeSet { get; set; }

    public string? CourseGradeSetDate { get; set; }

    public int? FkWorkerNumber { get; set; }

    public int? FkStudenNumber { get; set; }

    public virtual Student? FkStudenNumberNavigation { get; set; }

    public virtual Worker? FkWorkerNumberNavigation { get; set; }

    public static void GetAllGradesLastMonth()
    {

        var date = DateTime.Today.AddMonths(-1);

        using (var db = new SchoolContext())
        {
            var student = db.Students.ToList();
            var gradeName = db.Courses.OrderBy(x => x.CourseName).ToList();
            foreach (var grade in gradeName)
            {
                var gradeDate = DateTime.Parse(grade.CourseGradeSetDate);
                foreach (var students in student)
                {
                    if (date <= gradeDate)
                    {
                        if (grade.FkStudenNumber == students.StudentNumber)
                        {
                            Console.WriteLine($"Name: {students.StudentFirstName} {students.StudentLastName} - Course Name: {grade.CourseName} - Grade: {grade.CourseGradeSet}");
                        }
                    }
                }
            }
        }
    }

    public static void GetAllGrades()
    {
        using (var db = new SchoolContext())
        {
            var course = db.Courses.GroupBy(x => x.CourseName);
            var courseGradeSorted = db.Courses.GroupBy(x => x.CourseGradeSet);
            var courseGrade = db.Courses.ToList();
            int sumGradeMath = 0;
            int sumGradeEnglish = 0;
            int subMath = 0;
            int subEnglish = 0;
            string highestMathGrade = "G";
            string lowestMathGrade = "G";
            string highestEnglishGrade = "G";
            string lowestEnglishGrade = "G";
            foreach (var coursesGrade in courseGrade)
            {

                if (coursesGrade.CourseName == "Math")
                {
                    subMath = subMath + 1;
                    if (coursesGrade.CourseGradeSet.Contains("MVG"))
                    {
                        sumGradeMath = sumGradeMath + 4;

                        if (highestMathGrade == "G" || highestMathGrade == "VG" || highestMathGrade == "IG")
                        {
                            highestMathGrade = coursesGrade.CourseGradeSet;
                        }
                        if (lowestMathGrade == "MVG")
                        {
                            lowestMathGrade = coursesGrade.CourseGradeSet;
                        }

                    }
                    else if (coursesGrade.CourseGradeSet.Contains("VG"))
                    {
                        sumGradeMath = sumGradeMath + 3;

                        if (highestMathGrade == "G" || highestMathGrade == "IG")
                        {
                            highestMathGrade = coursesGrade.CourseGradeSet;
                        }

                        if (lowestMathGrade == "MVG")
                        {
                            lowestMathGrade = coursesGrade.CourseGradeSet;
                        }
                    }

                    else if (coursesGrade.CourseGradeSet.Contains("IG"))
                    {
                        sumGradeMath = sumGradeMath + 1;

                        if (highestMathGrade == "IG")
                        {
                            highestMathGrade = coursesGrade.CourseGradeSet;
                        }

                        if (lowestMathGrade == "G" || lowestMathGrade == "VG" || lowestMathGrade == "MVG")
                        {
                            lowestMathGrade = coursesGrade.CourseGradeSet;
                        }
                    }

                    else if (coursesGrade.CourseGradeSet.Contains("G"))
                    {
                        sumGradeMath = sumGradeMath + 2;

                        if (highestMathGrade == "IG")
                        {
                            highestMathGrade = coursesGrade.CourseGradeSet;
                        }

                        if (lowestMathGrade == "VG" || lowestMathGrade == "MVG")
                        {
                            lowestMathGrade = coursesGrade.CourseGradeSet;
                        }
                    }

                }
                else if (coursesGrade.CourseName == "English")
                {
                    subEnglish = subEnglish + 1;
                    if (coursesGrade.CourseGradeSet.Contains("MVG"))
                    {
                        sumGradeEnglish = sumGradeEnglish + 4;
                        if (highestEnglishGrade == "G" || highestEnglishGrade == "VG" || highestEnglishGrade == "IG")
                        {
                            highestEnglishGrade = coursesGrade.CourseGradeSet;
                        }
                        if (lowestEnglishGrade == "MVG")
                        {
                            lowestEnglishGrade = coursesGrade.CourseGradeSet;
                        }
                    }

                    else if (coursesGrade.CourseGradeSet.Contains("VG"))
                    {
                        sumGradeEnglish = sumGradeEnglish + 3;

                        if (highestEnglishGrade == "G" || highestEnglishGrade == "IG")
                        {
                            highestEnglishGrade = coursesGrade.CourseGradeSet;
                        }

                        if (lowestEnglishGrade == "MVG")
                        {
                            lowestEnglishGrade = coursesGrade.CourseGradeSet;
                        }

                    }

                    else if (coursesGrade.CourseGradeSet.Contains("IG"))
                    {
                        sumGradeEnglish = sumGradeEnglish + 1;

                        if (highestEnglishGrade == "IG")
                        {
                            highestEnglishGrade = coursesGrade.CourseGradeSet;
                        }

                        if (lowestEnglishGrade == "G" || lowestEnglishGrade == "VG" || lowestEnglishGrade == "MVG")
                        {
                            lowestEnglishGrade = coursesGrade.CourseGradeSet;
                        }
                    }

                    else if (coursesGrade.CourseGradeSet.Contains("G"))
                    {
                        sumGradeEnglish = sumGradeEnglish + 2;

                        if (highestEnglishGrade == "IG")
                        {
                            highestEnglishGrade = coursesGrade.CourseGradeSet;

                            if (lowestEnglishGrade == "VG" || lowestEnglishGrade == "MVG")
                            {
                                lowestEnglishGrade = coursesGrade.CourseGradeSet;
                            }

                        }
                    }
                }
            }
                sumGradeEnglish = sumGradeEnglish / subEnglish;
                sumGradeMath = sumGradeMath / subMath;
                string gradeMath;
                string gradeEnglish;
                if (sumGradeMath == 2)
                {
                    gradeMath = "G";
                }
                else if (sumGradeMath == 3)
                {
                    gradeMath = "VG";
                }
                else if (sumGradeMath == 4)
                {
                    gradeMath = "MVG";
                }
                else
                {
                    gradeMath = "IG";
                }

                if (sumGradeEnglish == 2)
                {
                    gradeEnglish = "G";
                }
                else if (sumGradeEnglish == 3)
                {
                    gradeEnglish = "VG";
                }
                else if (sumGradeEnglish == 4)
                {
                    gradeEnglish = "MVG";
                }
                else
                {
                    gradeEnglish = "IG";
                }

                Console.Clear();
                foreach (var courses in course)
                {
                    if (courses.Key == "Math")
                        Console.WriteLine($"Course Name: {courses.Key} - Avg Grade: {gradeMath} - Highest grade: {highestMathGrade} - Lowest grade: {lowestMathGrade}");

                    else if (courses.Key == "English")
                    {
                        Console.WriteLine($"Course Name: {courses.Key} - Avg Grade: {gradeEnglish} - Highest grade: {highestEnglishGrade} - Lowest grade: {lowestEnglishGrade}");
                    }
                }
            
        }
    }
}

