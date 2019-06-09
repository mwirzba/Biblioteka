using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Xml;

namespace XML_Operations
{
    /// <summary>
    /// Interaction logic for NewEmployee.xaml
    /// </summary>
    public partial class NewEmployee : UserControl
    {
        public NewEmployee()
        {
            InitializeComponent();
        }

        private void AddNewEmployee(object sender, RoutedEventArgs e)
        {

            if (Validate())
            {
                userMessage.Content = "Wrong input data!";
            }
            else
            {
                XmlDocument document = new XmlDocument();
                document.Load("library.xml");

                XmlNodeList libraryList = document.GetElementsByTagName("Library");

                XmlNode library = libraryList.Item(0);

                XmlNode employees = library.FirstChild.NextSibling.NextSibling.NextSibling;


                XmlElement employee = document.CreateElement("Employee");
                XmlElement name = document.CreateElement("Name");
                name.InnerText = nameBox.Text;
                XmlElement surname = document.CreateElement("Surname");
                surname.InnerText = surnameBox.Text;
                XmlElement salary = document.CreateElement("Salary");
                salary.InnerText = salaryBox.Text;

                XmlElement email = document.CreateElement("Email");
                email.InnerText = emailBox.Text;

                XmlElement bonus = document.CreateElement("Bonus");
                bonus.InnerText = bonusBox.Text;


                employee.AppendChild(name);
                employee.AppendChild(surname);
                employee.AppendChild(salary);
                employee.AppendChild(bonus);
                employee.AppendChild(email);

                if (!string.IsNullOrEmpty(peselBox.Text))
                {
                    XmlElement pesel = document.CreateElement("Pesel");
                    pesel.InnerText = peselBox.Text;
                    employee.AppendChild(pesel);
                }

                employees.AppendChild(employee);
                userMessage.Content = "Employee has been added.";

                document.Save("library.xml");
            }
        }

        private bool Validate()
        {
            int salary, bonus;
            return (string.IsNullOrEmpty(nameBox.Text) || string.IsNullOrEmpty(surnameBox.Text) || string.IsNullOrEmpty(salaryBox.Text) ||
                            string.IsNullOrEmpty(emailBox.Text) || (!Regex.IsMatch(emailBox.Text, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")) ||
                            string.IsNullOrEmpty(bonusBox.Text) || (!string.IsNullOrEmpty(peselBox.Text) && peselBox.Text.Length != 11 ||
                            !int.TryParse(salaryBox.Text,out salary) || !int.TryParse(bonusBox.Text, out bonus)
                            ));
        }
    }
}
