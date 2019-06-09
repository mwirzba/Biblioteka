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
using System.Xml;

namespace XML_Operations
{
    /// <summary>
    /// Interaction logic for EditEmployee.xaml
    /// </summary>
    public partial class EditEmployee : UserControl
    {

        XmlElement elEmp = null;
        private string name;
        private string surname;

        public EditEmployee(string name, string surname)
        {
            InitializeComponent();
            this.name = name;
            this.surname = surname;
            XmlDocument document = new XmlDocument();
            document.Load("library.xml");
         
            XmlElement library = document.DocumentElement;
            XmlElement employees = (XmlElement)library.LastChild.PreviousSibling;
            XmlNodeList employeesList = employees.ChildNodes;
            for (int i = 0; i < employeesList.Count; i++)
            {
                elEmp = (XmlElement)employeesList.Item(i);
                if (elEmp.FirstChild.InnerText == name && elEmp.FirstChild.NextSibling.InnerText == surname)
                    break;
            }

            if (elEmp != null)
            {
                XmlNodeList properties = elEmp.ChildNodes;
                nameBox.Text = properties.Item(0).InnerText;
                surnameBox.Text = properties.Item(1).InnerText;
                salaryBox.Text = properties.Item(2).InnerText;
                bonusBox.Text = properties.Item(3).InnerText;
                emailBox.Text = properties.Item(4).InnerText;
                if (elEmp.GetElementsByTagName("Pesel").Count!=0)
                    peselBox.Text = elEmp.LastChild.InnerText;
            }


        }

        private void Update(object sender, RoutedEventArgs e)
        {
            XmlDocument document = new XmlDocument();
            document.Load("library.xml");


            XmlElement library = document.DocumentElement;
            XmlElement employees = (XmlElement)library.LastChild.PreviousSibling;

            
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
            XmlNodeList empList = employees.ChildNodes;
            for (int i = 0; i < empList.Count; i++)
            {
                elEmp = (XmlElement)empList.Item(i);
                if (elEmp.FirstChild.InnerText == this.name && elEmp.FirstChild.NextSibling.InnerText == this.surname)
                    break;
            }
                employees.ReplaceChild(employee,elEmp);
            document.Save("library.xml");
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            this.name = name;
            this.surname = surname;
            XmlDocument document = new XmlDocument();
            document.Load("library.xml");

            XmlElement library = document.DocumentElement;
            XmlElement employees = (XmlElement)library.LastChild.PreviousSibling;
            XmlNodeList employeesList = employees.ChildNodes;
            for (int i = 0; i < employeesList.Count; i++)
            {
                elEmp = (XmlElement)employeesList.Item(i);
                if (elEmp.FirstChild.InnerText == name && elEmp.FirstChild.NextSibling.InnerText == surname)
                    break;
            }

            if (elEmp != null)
            {

                employees.RemoveChild(elEmp);
            }
            document.Save("library.xml");
        }
    }
}
