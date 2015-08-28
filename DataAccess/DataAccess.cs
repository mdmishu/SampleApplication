using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApplication.DataAccess
{
    class DataAccessClass
    {
        readonly List<EmployeeList> _employeeList;

        /// <summary>
        /// We can create WebApi or Webservice call from this DataAcceess Class. For Now, I have created a list of employees.
        /// </summary>

        public DataAccessClass()
        {
            if (_employeeList == null)
            {
                _employeeList = new List<EmployeeList>();
            }
            _employeeList.Add(EmployeeList.CreateEmployee("MD", "Mishu", "M", "72000","Developer"));
            _employeeList.Add(EmployeeList.CreateEmployee("MD", "Mou", "F", "82000","Manager"));
            _employeeList.Add(EmployeeList.CreateEmployee("Jack", "Jill", "M", "92000","VP"));
            _employeeList.Add(EmployeeList.CreateEmployee("John", "Smith", "M", "85000","Senior Developer"));
            _employeeList.Add(EmployeeList.CreateEmployee("Amanda", "Scholl", "F", "49000","Adminstrator"));
            _employeeList.Add(EmployeeList.CreateEmployee("Jason", "Person", "M", "74000","Database Designer"));
            _employeeList.Add(EmployeeList.CreateEmployee("Gail", "Aris", "F", "82000","Manager"));
            _employeeList.Add(EmployeeList.CreateEmployee("Ashley", "Simpson", "F", "92000","System Admin"));
            _employeeList.Add(EmployeeList.CreateEmployee("Tracy", "Bain", "F", "85000","Developer"));
            _employeeList.Add(EmployeeList.CreateEmployee("Rishad", "Zaman", "M", "69000","Accountant"));

        }

        public List<EmployeeList> GetEmployeeInfo()

        {
            return new List<EmployeeList>(_employeeList);

        }

    }

    internal class EmployeeList
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Gender { get; private set; }
        public string Salary { get; private set; }
        public string Title { get; private set; }

        public static EmployeeList CreateEmployee(string firstName, string lastname, string gender, string salary,string title)
        {
            return new EmployeeList
            { FirstName = firstName, LastName = lastname, Gender = gender, Salary = salary, Title = title};
        }
    }
}
