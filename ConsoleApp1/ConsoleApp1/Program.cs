using System;
using System.Collections.Generic;

public class Employee
{
    public string Name { get; set; }
    public int EmployeeId { get; set; }
    public string Position { get; set; }

    public Employee(string name, int employeeId, string position)
    {
        Name = name;
        EmployeeId = employeeId;
        Position = position;
    }
    
    public virtual decimal CalculateSalary()
    {
        return 0;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Сотрудник: {Name}, ID: {EmployeeId}, Должность: {Position}, Зарплата: {CalculateSalary():C}");
    }
}

public class Worker : Employee
{
    public decimal HourlyRate { get; set; }
    public int HoursWorked { get; set; }

    public Worker(string name, int employeeId, decimal hourlyRate, int hoursWorked)
        : base(name, employeeId, "Рабочий")
    {
        HourlyRate = hourlyRate;
        HoursWorked = hoursWorked;
    }
    
    public override decimal CalculateSalary()
    {
        return HourlyRate * HoursWorked;
    }
}

public class Manager : Employee
{
    public decimal FixedSalary { get; set; }
    public decimal Bonus { get; set; }

    public Manager(string name, int employeeId, decimal fixedSalary, decimal bonus)
        : base(name, employeeId, "Менеджер")
    {
        FixedSalary = fixedSalary;
        Bonus = bonus;
    }
    
    public override decimal CalculateSalary()
    {
        return FixedSalary + Bonus;
    }
}

public class EmployeeManagementSystem
{
    private List<Employee> employees = new List<Employee>();
    
    public void AddEmployee(Employee employee)
    {
        employees.Add(employee);
        Console.WriteLine($"Сотрудник {employee.Name} добавлен в систему.");
    }
    
    public void DisplaySalaries()
    {
        foreach (var employee in employees)
        {
            employee.DisplayInfo();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        EmployeeManagementSystem system = new EmployeeManagementSystem();
        
        Worker worker1 = new Worker("Саша", 101, 20m, 160);
        Worker worker2 = new Worker("Абай", 102, 25m, 150);
        Manager manager1 = new Manager("Куаныш", 201, 3000m, 500m);
        
        system.AddEmployee(worker1);
        system.AddEmployee(worker2);
        system.AddEmployee(manager1);
        
        system.DisplaySalaries();
    }
}