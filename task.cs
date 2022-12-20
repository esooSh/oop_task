
using System;

namespace Section_9;
public class Person
{
    public string Name;
    public int Age;

    public Person(string name, int age)
    {
        if (name == null || name == "" || name.Length >= 32)
        {
            throw new Exception("Invalid name");
        }
        if (age <= 0 || age > 128)
        {
            throw new Exception("Invalid age");
        }
        Name = name;
        Age = age;
    }
    public virtual void Print()
    {
        Console.WriteLine
       ($"Name: {Name}, Age: {Age}");
    }
}
public class Student : Person
{
    public int Year;
    public float Gpa;
    
    public void SetYear(int year)
    {
        if (year < 1 || year > 5)
        {
            throw new Exception("Invaild Year");
        }
        _year = year;
    }
    public void SetGpa(float gpa)
    {
        if (gpa < 0 || gpa > 4)
        {
            throw new Exception("Invaild GPA");
        }
        _gpa = gpa;
    }
    
    public Student(string name, int age, int year, float gpa) : base(name, age)
    {
        SetYear(year);
        SetGpa(gpa);
        Year = year;
        Gpa = gpa;
    }
    public override void Print()
    {
        Console.WriteLine
        ($"Name: {Name}, Age: {Age}, Gpa: {Gpa}");
    }
}

public class Staff : Person
{

    public double Salary;
    public int JoinYear;

    public void SetSalary(double salary)
    {
        if (salary < 0 || salary > 120000)
        {
            throw new Exception("Invaild Salary");
        }
        _salary = salary;
    }
    public void SetJoinYear(int joinYear)
    {
        if (joinYear - GetAge() < 21)
        {
            throw new Exception("Invaild JoinYear ");
        }
        _joinYear = joinYear;
    }

    public Staff(string name, int age, double salary, int joinyear) : base(name, age)
    {
        SetSalary(salary);
        SetJoinYear(joinyear);
        Salary = salary;
        JoinYear = joinyear;
    }
    public override void Print()
    {
        Console.WriteLine
        ($"Name: {Name}, Age: {Age}, Salary: {Salary} , JoinYear : {JoinYear}");
    }

}
public class Database
{
    private int _currentIndex;
    public Person[] People = new Person[50];
    public void AddStudent(Student student)
    {
        People[_currentIndex++] = student;
    }
    public void AddStaff(Staff staff)
    {
        People[_currentIndex++] = staff;
    }
    public void AddPerson(Person person)
    {
        People[_currentIndex++] = person;
    }
    public void PrintAll()
    {
        for (int i = 0; i < _currentIndex; i++) { People[i].Print(); }
    }

}

public class Program
{
    private static void Main()
    {
        var database = new Database();

        

        Console.WriteLine("Enter options\n1=> Add Student: \n2=> Add Staff :\n3=> Add people :\n4=> print all:\n0--> to End:");
        var option = Convert.ToInt32(Console.ReadLine());
        while (true)
        {
            switch (option)
            {
                case 0:
                    Console.WriteLine("GodBye !");
                    return;
                case 1:
                    Console.Write("Name: ");
                    var name = Console.ReadLine();
                    Console.Write("Age: ");
                    var age = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Year: ");
                    var year = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Gpa: ");
                    var gpa = Convert.ToSingle(Console.ReadLine());

                    try
                    {
                        var student = new Student(name, age, year, gpa);
                        database.AddStudent(student);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    
                    Console.WriteLine("Enter options\n1=> Add Student: \n2=> Add Staff :\n3=> Add people :\n4=> print all:\n0--> to End:");
                    option = Convert.ToInt32(Console.ReadLine());
                    break;
                case 2:
                    Console.Write("Name: ");
                    name = Console.ReadLine();
                    Console.Write("Age: ");
                    age = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Slary: ");
                    var salary = Convert.ToInt32(Console.ReadLine());
                    Console.Write("JoinYear: ");
                    var joinyear = Convert.ToInt32(Console.ReadLine());
                    try
                    {
                        var staff = new Staff(name, age, salary, joinyear);
                        database.AddStaff(staff);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    
                    }

                   
                    Console.WriteLine("Enter options\n1=> Add Student: \n2=> Add Staff :\n3=> Add people :\n4=> print all:\n0==> to End:"); option = Convert.ToInt32(Console.ReadLine());
                    break;
                case 3:
                    Console.Write("Name: ");
                    name = Console.ReadLine();
                    Console.Write("Age: ");
                    age = Convert.ToInt32(Console.ReadLine());
                    var person = new Person(name, age);
                    database.AddPerson(person);
                    Console.WriteLine("Enter options\n1=> Add Student: \n2=> Add Staff :\n3=> Add people :\n4=> print all:\n0==> to End:"); option = Convert.ToInt32(Console.ReadLine());
                    try
                    {
                        person = new Person(name, age);
                        database.AddPerson(person);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
                case 4:
                    database.PrintAll();
                    Console.WriteLine("Enter options\n1=> Add Student: \n2=> Add Staff :\n3=> Add people :\n4=> print all:\n0==> to End:"); option = Convert.ToInt32(Console.ReadLine());
                    break;

                default:
                    return;

            }
        }

    }
}


