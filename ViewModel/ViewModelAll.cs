using SampleApplication.DataAccess;
using SampleApplication.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SampleApplication.ViewModel
{
    class ViewModelAll : ViewModelBase, INotifyPropertyChanged
    {
        /// <summary>
        /// ViewModel is handling all the controls and User Interface logics here.
        /// </summary>

        private ModelClass _model;

        public ViewModelAll()
        {
            _canExecute = true;
            _model = new ModelClass();

            var getdata = _model.GetDataSet();
            DataList = getdata;

        }

        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged("FirstName");
            }

        }

        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged("LastName");
            }

        }

        private List<EmployeeList> _dataList;
        public List<EmployeeList> DataList
        {
            get { return _dataList; }
            set
            {
                _dataList = value;
                OnPropertyChanged("DataList");
            }

        }

        private bool _canExecute;

        private ICommand _submitCommand;

        public ICommand SubmitCommand
        {
            get { return _submitCommand ?? (_submitCommand = new CommandHandler(() => MyAction(), _canExecute)); }
        }

        private ICommand _closeCommand;

        public ICommand CloseCommand
        {
            get { return _closeCommand ?? (_closeCommand = new CommandHandler(() => MyClose(), _canExecute)); }
        }

        private ICommand _reloadCommand;

        public ICommand ReLoadCommand
        {
            get { return _reloadCommand ?? (_reloadCommand = new CommandHandler(() => MyReload(), _canExecute)); }
        }

        private ICommand _clearCommand;

        public ICommand ClearCommand
        {
            get { return _clearCommand ?? (_clearCommand = new CommandHandler(() => MyClear(), _canExecute)); }
        }

        private void MyClear()
        {
            FirstName = string.Empty;
            OnPropertyChanged("FirstName");
            DataList = null;
            OnPropertyChanged("DataList");
        }

        private void MyReload()
        {
            var getdata = _model.GetDataSet();
            DataList = getdata;
        }

        private void MyClose()
        {
            Application.Current.MainWindow.Close();
        }

        public void MyAction()
        {
            if (FirstName == string.Empty)
            {
                MessageBox.Show("Please Enter FirstName to Perform Search");
            }
            else
            {
                var getresult = _model.SearchData(FirstName);
                if (getresult.Count() == 0)
                {                    
                    MessageBox.Show("No result found.");
                }
                DataList = getresult;
            }
        }

    }
}
