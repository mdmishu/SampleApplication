using SampleApplication.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SampleApplication.Model
{
    class ModelClass
    {
        /// <summary>
        /// This is the model class for get data from database or webApi/Webservice call. Doing all the business logics here.
        /// </summary>
        private string _model;

        private DataAccessClass _data;

        public ModelClass()
        {
            _data = new DataAccessClass();
        }

        public List<EmployeeList> GetDataSet()
        {
            return _data.GetEmployeeInfo();
        }

        public List<EmployeeList> SearchData(string firstName)
        {
            string fName = firstName;
            var list = _data.GetEmployeeInfo();
            var results = list.Where(x => x.FirstName.Contains(fName));
            if (results.Count() != 0)
            {
                return results.ToList();
            }
            var resultLast = list.Where(x => x.LastName.Contains(fName));
            return resultLast.ToList();
        }

    }
}
