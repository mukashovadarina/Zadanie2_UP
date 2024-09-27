using System;
using System.Collections.Generic;
using System.Windows;
using static WpfApp13.MainWindow;

namespace WpfApp13
{
    public static class EmployeeGenerator
    {
        public static List<Employee> GenerateEmployees(int count)
        {
            var employees = new List<Employee>();
            var random = new Random();

            for (int i = 0; i < count; i++)
            {
                employees.Add(new Employee
                {
                    FullName = $"Сотрудник {i + 1}",
                    Position = "Должность " + (i % 5 + 1),
                    DateOfBirth = DateTime.Now.AddYears(-random.Next(20, 50)),
                    HireDate = DateTime.Now.AddDays(-random.Next(1, 365)),
                    Salary = random.Next(30000, 100000),
                    Department = "Отдел " + (i % 3 + 1),
                    Contact = $"user{i+1}@mail.ru",
                    Education = "Образование " + (i % 5 + 1),
                    MaritalStatus = random.Next(2) == 0 ? "Женат" : "Не женат",
                });
            }

            return employees;
        }
    }
}