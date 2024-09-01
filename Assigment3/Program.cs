using Employeeclass;
using System.Net.Http.Headers;
using System.Xml.Serialization;

namespace Assigment3
{
    internal class Program
    {
       
        struct Employee
        {
            public int Id;
            public string Name;
            public float salary;
            public Gender g;
         


            public void structDisplay()
            {
                Console.WriteLine($"The ID is {Id}\nThe name is {Name}\nThe salary is {salary}\nThe gender is {g}");
           

            }

        }

        static void Main(string[] args)
        {
            Employee[] emps = new Employee[3];
            Employeeclass1 emp=new Employeeclass1() ;
            Employeeclass1[] Emps=new Employeeclass1[3];

            int id = 0, number = 0; string name = " "; double salary = 0;
            string[] menu = { "New", "Display", "Exit" };
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
                                

                                for (int i = 0; i < 3; i++)
                                {
                                    Emps[i] = new Employeeclass1();
                                    addnewclass(Emps[i]);
                                }
                                Console.ReadLine();
                                break;
                            case 1:
                               // Employeeclass1.DisplayAllEmployees(Emps);
                               if (emps != null)
                                {
                                    for (int i = 0; i < 3; i++)
                                    {
                                        emps[i] ;
                                    }

                                }


                                Console.ReadLine();

                                    break;
                            case 2:
                                        looping = false;
                                        break;
                                    }
                                    break;
                                }
                        } while (looping) ;

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
        static Employee structadd( Employee emp)
        {
            Console.WriteLine("Enter The ID:");
            var s = Console.ReadLine();
            int.TryParse(s, out emp.Id);
            Console.WriteLine("Enter The name:");
           emp.Name = Console.ReadLine();
           Console.WriteLine("Enter The salary:");
           s = Console.ReadLine();
            float.TryParse(s, out emp.salary);
            Console.WriteLine("Enter The Gender:");
            s = Console.ReadLine();
            if (s == "male")
                emp.g = Gender.Male;
            else
             emp.g = Gender.Female;
            return emp;

        }
        //static void structDisplay(Employee emp)
        //{
        //    Console.WriteLine($"The ID is {emp.Id}\nThe name is {emp.Name}\nThe salary is {emp.salary}\nThe gender is {emp}");
        //    while (Console.ReadKey().Key != ConsoleKey.Enter)
        //    {
        //    }

        //}
        public static void addnewclass( Employeeclass1 emp)
        {
      
            Console.WriteLine("Enter The name:");
            emp.Name = Console.ReadLine();
            Console.WriteLine("Enter The salary:");
            var s = Console.ReadLine();
            float.TryParse(s, out emp.Salary);
            Console.WriteLine("Enter The Age:");
             s = Console.ReadLine();
            int.TryParse(s, out int age);
            emp.Age = age;
            Console.WriteLine("Enter The Gender:");
            s= Console.ReadLine();  
            if (s.Equals("male", StringComparison.OrdinalIgnoreCase))
                emp.gender = Gender.Male;
            else
                emp.gender = Gender.Female;








        }
    }
}
    


