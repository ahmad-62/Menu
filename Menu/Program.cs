using Employeeclass;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Reflection;
using System.Xml.Serialization;
using static Employeeclass.Emp;

namespace Assigment3
{
    public delegate int mydel(Emp e1,Emp e2);
    internal class Program
    {


        static void Main(string[] args)
        {
          List<Emp> list = new List<Emp>();
            int id = 0, number = 0; string name = " "; double salary = 0;
            string[] menu = { "New", "Display","Sort","Search", "Exit" };
            int colshift = Console.WindowWidth / 2;
            int rawshift = Console.WindowHeight / (menu.Length + 1);
            int Highlight = 0;
            var looping = true;
            do
            {
                Console.ResetColor();
                Console.Clear();
                for (int i = 0; i < menu.Length; i++)
                {
                    if (i == Highlight)
                        Console.BackgroundColor = ConsoleColor.Blue;
                    else
                        Console.BackgroundColor = ConsoleColor.Black;

                    Console.SetCursorPosition(colshift, (i + 1) * rawshift);
                    Console.WriteLine(menu[i]);
                }

                Console.ResetColor();

                ConsoleKeyInfo k = Console.ReadKey();
                switch (k.Key)
                {
                    case ConsoleKey.DownArrow:
                        Highlight++;
                        if (Highlight >= menu.Length)
                            Highlight = 0;
                        break;
                    case ConsoleKey.UpArrow:
                        Highlight--;
                        if (Highlight < 0)
                            Highlight = menu.Length - 1;
                        break;
                    case ConsoleKey.Home:
                        Highlight = 0;
                        break;
                    case ConsoleKey.End:
                        Highlight = 2;
                        break;
                    case ConsoleKey.Escape:
                        looping = false;
                        break;


                    case ConsoleKey.Enter:
                        Console.Clear();
                        switch (Highlight)
                        {


                            case 0:

                                Emp emp = new Emp();

                                addnewclass(emp);
                                list.Add(emp);
                                Console.ReadLine();
                                break;
                            case 1:
                                if (list != null)
                                {
                                    for (int i = 0; i < list.Count; i++)
                                    {
                                        Console.WriteLine("-----");
                                        Console.WriteLine($"Employee {i + 1}");
                                        Console.WriteLine("------------------------------------------------");
                                        Emp employee = list[i] as Emp;
                                        employee.DisplayData();
                                    }

                                }

    
                                Console.ReadLine();

                                break;
                            case 2:
                                //Array.Sort(Emps);
                               // list.Sort(new sortbySalary<Emp>());
                                Console.WriteLine("Sort by: 1. Name 2. Salary");
                                int sortOption = int.Parse(Console.ReadLine());

                                Console.WriteLine("Order: 1. Ascending 2. Descending");
                                int orderOption = int.Parse(Console.ReadLine());

                                Comparison<Emp> comparison = null;

                                if (sortOption == 1)
                                {
                                    if (orderOption == 1)
                                    {
                                        comparison =  ( e1,  e2)=>
                                        
                                             e1.Name.CompareTo(e2.Name);
                                        
                                    }
                                    else
                                    {
                                        comparison = delegate (Emp e1, Emp e2)
                                        {
                                            return e2.Name.CompareTo(e1.Name);
                                        };
                                    }
                                }
                                else if (sortOption == 2)
                                {
                                    if (orderOption == 1)
                                    {
                                        comparison = delegate (Emp e1, Emp e2)
                                        {
                                            return e1.Salary.CompareTo(e2.Salary);
                                        };
                                    }
                                    else
                                    {
                                        comparison = delegate (Emp e1, Emp e2)
                                        {
                                            return e2.Salary.CompareTo(e1.Salary);
                                        };
                                    }
                                }

                                if (comparison != null)
                                {
                                    list.Sort(comparison);
                                    Console.WriteLine("Employees sorted successfully.");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid sort option.");
                                }

                                Console.ReadLine();
                                break;
                            case 3:
                                Console.WriteLine("Enter The Name:");
                                var emp1 = SearchByName(Console.ReadLine(), list);
                                emp1.DisplayData();
                                Console.ReadLine() ;    
                                break;
                            case 4:
                                looping = false;
                                break;
                        }
                        break;
                }
            } while (looping);

        }
        public static void addnew(ref int id, ref string name, ref double salary)
        {
            Console.WriteLine("Enter The ID:");
            var s = Console.ReadLine();
            int.TryParse(s, out id);
            Console.WriteLine("Enter The name:");
            name = Console.ReadLine();
            Console.WriteLine("Enter The salary:");
            s = Console.ReadLine();
            double.TryParse(s, out salary);





        }
        public static void Display(int id, string name, double salary)
        {
            Console.WriteLine($"The id is {id}\nThe name is {name}\nThe salary is {salary}");
            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
            }
        }
        
        public static void addnewclass(Emp emp)
        {
            var Validate=false;
            var s = "";
            do
            {
                Console.WriteLine("Enter The name:");
                 s = Console.ReadLine();
                if (string.IsNullOrEmpty(s) || (s.Length <= 3 || s.Length > 30))
                    Console.WriteLine("Enter The Valid Name");
                else
                {
                    emp.Name=s;
                    Validate = true;
                }

            } while (!Validate);

            //emp.Name = Console.ReadLine();
            Console.WriteLine("Enter The salary:");
              s = Console.ReadLine();
           
       //     float.TryParse(s, out emp.Salary);
            while (Validate)
            {
                try
                {
                    emp.Salary = int.Parse(s);
                    Validate = false;
                }
                catch
                {
                    Console.WriteLine("Invalid salary. Please enter a valid number.");
                    Console.WriteLine("Enter The salary:");
                    s= Console.ReadLine();

                }
            }
            Console.WriteLine("Enter The Age:");
            s = Console.ReadLine();
            int.TryParse(s, out int age);
            emp.Age = age;
            Console.WriteLine("Enter The Gender:");
            s = Console.ReadLine();
            if (s.Equals("male", StringComparison.OrdinalIgnoreCase))
                emp.gender = Gender.Male;
            else
                emp.gender = Gender.Female;








        }
        public static Emp SearchByName(string name,List<Emp> Emps)
        {
            foreach(Emp emp in Emps)
            {
                if(emp.Name ==name)
                {
                    return emp;
                    break;
                }    
            }
            return null;
        }
        public static int sortbysalary(Emp e1,Emp e2)
        {
            return e1.Salary.CompareTo(e2.Salary);
        }
        public static int sortbyname(Emp e1, Emp e2)
        {
            return e1.Name.CompareTo(e2.Name);
        }
    }
}



