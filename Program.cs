using School_Lab3.Models;
using System.ComponentModel.Design;
using System.Data.SqlClient;

namespace School_Lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=DESKTOP-FPHO4OK;Initial Catalog=School;Integrated Security=True";
            SqlConnection connection = null;
            SqlCommand command = null;
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to school 'Trolla med Troll' \nMake a choice. \n1. List of Workers. \n2. List of Students. \n3. List of Classes \n4. Get last months grades \n5. Get all courses. \n6. Add student. \n7. Add worker. \n0. Exit program.");
            
                int.TryParse(Console.ReadLine(), out int userInput);

                if (userInput == 0)
                {
                    Environment.Exit(0);
                }
                switch (userInput)
                {

                    case 1:
                        {
                            do
                            {
                                Console.Clear();
                                try
                                {
                                    Console.WriteLine("1. Show only Teachers. \n2. Show all Workers.");

                                    string input = "";

                                    int.TryParse(Console.ReadLine(), out int userChoice);

                                    if (userChoice == 1)
                                    {
                                        input = "WHERE WorkerProfession = 'Teacher'";
                                    }

                                    connection = new SqlConnection(connectionString);
                                    connection.Open();

                                    SqlDataReader reader = null;
                                    command = new SqlCommand($"SELECT WorkerProfession, WorkerFirstName, WorkerLastName FROM Workers {input} ORDER BY WorkerLastName", connection);
                                    reader = command.ExecuteReader();

                                    while (reader.Read())
                                    {
                                        Console.WriteLine($"Name: {reader["WorkerLastName"]} {reader["WorkerFirstName"]} - {reader["WorkerProfession"]}\n");
                                    }

                                    connection.Close();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                finally
                                {
                                    if (connection != null)
                                        connection.Dispose();
                                    if (command != null)
                                        command.Dispose();
                                }
                                break;
                            } while (true);
                            break;
                        }
                    case 2:
                        {
                            do
                            {
                                Console.Clear();

                                Console.WriteLine("1. Order by first name. \n2. Order by last name.");

                                int.TryParse(Console.ReadLine(), out userInput);

                                if (userInput == 1)
                                {
                                    Console.Clear();
                                    Student.GetStudentsFirstName();
                                    break;
                                }
                                else if (userInput == 2)
                                {
                                    Console.Clear();
                                    Student.GetStudentsLastName();
                                    break;
                                }

                            } while (true);
                        }
                        break;
                    case 3: 
                        {
                            Class.GetStudentsInClass();
                        }
                        break;
                    case 4: 
                        {
                            Course.GetAllGradesLastMonth();
                        }
                        break;
                    case 5: 
                        {
                            Course.GetAllGrades();
                        }
                        break;
                    case 6: 
                        {
                            Student.AddStudent();
                        }
                        break;
                    case 7:
                        {
                            Worker.AddWorker();
                        }
                        break;
                }
                Console.ReadLine();
            } while (true);
        }
    }
}