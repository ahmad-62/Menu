using System;
using System.Collections;
using System.Runtime.CompilerServices;
using static Employeeclass.Emp;

namespace Employeeclass
{
    public class Human
    {
        public string Name;
        public int Age { get; set; }
        public Gender gender { get; set; }
        public override string ToString()
        {
            return $"The name is {Name},\nThe Age is {Age},The gender is {{gender}}\"";
        }
      
        public Human()
        {
            Name = "ahmad";
Age = 20;
            gender = Gender.Male;

        }



    }
    public class Emp : Human,IComparable
    {
        public static int Id;
        public float Salary;

        public void DisplayData()
        {
            Console.WriteLine($"The ID is {Id},\nThe name is {Name},\nThe salary is {Salary},\nThe Age is {Age},\nThe gender is {gender}");
        }
        int counter = 0;
        public Emp():base()
        {
            Id = ++counter;
            Salary = 0;
        }
        public static void DisplayAllEmployees(Emp[] Emps)
        {
            foreach (var emp in Emps)
            {
                emp.DisplayData();
            }
        }
        public override string ToString()
        {
            return $"The ID is {Id},\nThe name is {Name},\nThe salary is {Salary},\nThe Age is {Age},\nThe gender is {gender}";
        }

        public int CompareTo(object? obj)
        {
            Emp emp = obj as Emp;
            return this.Salary.CompareTo(emp.Salary);
        }

    }
    public enum Gender
    {
        Male,
        Female
    }
    public class sortbySalary <T>: IComparer<T>
    {

        public int Compare(T? x, T? y)
        {
            Emp emp1 = x as Emp;
            Emp emp2 = y as Emp;
            return emp1.Salary.CompareTo(emp2.Salary);
        }
    }

}
