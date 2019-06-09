using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using XML_Operations.ViewModels;

namespace XML_Operations
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void ShowBooks(object sender, RoutedEventArgs e)
        {
            this.mainGrid.Children.Clear();
            this.mainGrid.Children.Add(new BooksUserControll());

        }


        private void ShowEmployees(object sender, RoutedEventArgs e)
        {
            this.mainGrid.Children.Clear();
            this.mainGrid.Children.Add(new EmployeesUserControl());
        }

        private void AddBook(object sender, RoutedEventArgs e)
        {
            this.mainGrid.Children.Clear();
            this.mainGrid.Children.Add(new NewBook());
        }

        private void AddEmployee(object sender, RoutedEventArgs e)
        {
            this.mainGrid.Children.Clear();
            this.mainGrid.Children.Add(new NewEmployee());
        }

        private void EditEmployee(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(this.empName.Text) || string.IsNullOrEmpty(this.empSurName.Text) )
            {

            }
            else
            {
                EmployeeViewModel employeeViewModel = new EmployeeViewModel();
                var employees = employeeViewModel.EmployeesList.Where(emp => emp.Name == empName.Text && emp.Surname == empSurName.Text).FirstOrDefault();
                if (employees == null)
                {

                }
                else
                {
                    this.mainGrid.Children.Clear();
                    this.mainGrid.Children.Add(new EditEmployee(empName.Text,empSurName.Text));
                }


            }

        }
    }
}
