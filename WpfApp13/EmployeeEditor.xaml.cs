using System;
using System.Windows;
using static WpfApp13.MainWindow;

namespace WpfApp13
{
    public partial class EmployeeEditor : Window
    {
        public Employee Employee { get; private set; }

        public EmployeeEditor(Employee employee)
        {
            InitializeComponent();
            Employee = employee ?? new Employee();

            FullNameTextBox.Text = Employee.FullName;
            PositionTextBox.Text = Employee.Position;
            DateOfBirthPicker.SelectedDate = Employee.DateOfBirth;
            HireDatePicker.SelectedDate = Employee.HireDate;
            SalaryTextBox.Text = Employee.Salary.ToString();
            DepartmentTextBox.Text = Employee.Department;
            ContactTextBox.Text = Employee.Contact;
            EducationTextBox.Text = Employee.Education;
            MaritalStatusTextBox.Text = Employee.MaritalStatus;

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Employee.FullName = FullNameTextBox.Text;
            Employee.Position = PositionTextBox.Text;
            Employee.DateOfBirth = DateOfBirthPicker.SelectedDate ?? DateTime.Now;
            Employee.HireDate = HireDatePicker.SelectedDate ?? DateTime.Now;

            if (decimal.TryParse(SalaryTextBox.Text, out decimal salary))
            {
                Employee.Salary = salary;
                Employee.Department = DepartmentTextBox.Text;

                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Введите корректную зарплату.");
            }
            Employee.Contact = ContactTextBox.Text;
            Employee.Education = EducationTextBox.Text;
            Employee.MaritalStatus = MaritalStatusTextBox.Text;

        }
    }
}