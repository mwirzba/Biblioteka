using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_Operations.Models
{
    class Employee
    {

        public string  Name { get; set; }
        public string Surname { get; set; }
        public int  Salary { get; set; }
        public int Bonus { get; set; }
        public string Email { get; set; }

        public string Pesel { get; set; }

        public Employee(string name, string surname, int salary, int bonus, string email, string pesel)
        {
            Name = name;
            Surname = surname;
            Salary = salary;
            Bonus = bonus;
            Email = email;
            Pesel = pesel;
        }
    }
}
