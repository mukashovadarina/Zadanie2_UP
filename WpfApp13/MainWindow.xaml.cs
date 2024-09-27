using System;
using System.Collections.Generic;
using System.Windows;

namespace WpfApp13
{
    public partial class MainWindow : Window
    {
        public class Employee
        {
            public string FullName { get; set; }
            public string Position { get; set; }
            public DateTime DateOfBirth { get; set; }
            public DateTime HireDate { get; set; }
            public decimal Salary { get; set; }
            public string Department { get; set; }

            public string Contact { get; set; }
            public string Education { get; set; }
            public string MaritalStatus { get; set; }
        }
        private List<Employee> employees;

        public MainWindow()
        {
            InitializeComponent();
            employees = new List<Employee>();
            EmployeeListView.ItemsSource = employees;
        }

     

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var editor = new EmployeeEditor(null);
            if (editor.ShowDialog() == true)
            {
                employees.Add(editor.Employee);
                EmployeeListView.Items.Refresh();
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeListView.SelectedItem is Employee selectedEmployee)
            {
                var editor = new EmployeeEditor(selectedEmployee);
                if (editor.ShowDialog() == true)
                {
                    EmployeeListView.Items.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Выберите сотрудника для редактирования.");
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeListView.SelectedItem is Employee selectedEmployee)
            {
                employees.Remove(selectedEmployee);
                EmployeeListView.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Выберите сотрудника для удаления.");
            }
        }
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchTerm = SearchTextBox.Text.ToLower();
            var filteredEmployees = employees.FindAll(emp => emp.FullName.ToLower().Contains(searchTerm));

            EmployeeListView.ItemsSource = filteredEmployees;
        }


        private void GenerateButton_Click_1(object sender, RoutedEventArgs e)
        {
            employees = EmployeeGenerator.GenerateEmployees(100);
            EmployeeListView.ItemsSource = employees;
        }
    }
}
