using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using XML_Operations.Models;

namespace XML_Operations.ViewModels
{
    class EmployeeViewModel
    {
        private List<Employee> employeesListData = new List<Employee>();

        public List<Employee>  EmployeesList
        {
            get { return employeesListData; }
        }

        public EmployeeViewModel()
        {

            GetEmployees();


        }
        public void GetEmployees()
        {


            XmlDocument document = new XmlDocument();
            document.Load("library.xml");

            XmlNode library = document.FirstChild;

            XmlNodeList employees = document.GetElementsByTagName("Employee");

            foreach (var item in employees)
            {
                XmlNode currNode = (XmlNode)item;
                XmlNodeList elements = currNode.ChildNodes;
                if (elements.Count == 6)
                    employeesListData.Add(new Employee(elements.Item(0).InnerText, elements.Item(1).InnerText, int.Parse(elements.Item(2).InnerText), int.Parse(elements.Item(3).InnerText), elements.Item(4).InnerText, elements.Item(5).InnerText));
                else
                    employeesListData.Add(new Employee(elements.Item(0).InnerText, elements.Item(1).InnerText, int.Parse(elements.Item(2).InnerText), int.Parse(elements.Item(3).InnerText), elements.Item(4).InnerText, "Not specified"));

            }
        }
    }
}
