using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVVM
{
    public class EmployeeVM
    {
        private Employee _employee;

        public EmployeeVM(Employee emp)
        {
            _employee = emp;
        }

        public string Name
        {
            get { return _employee.Name; }
            set
            {
                _employee.Name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Company
        {
            get { return _employee.Company; }
            set
            {
                _employee.Company = value;
                OnPropertyChanged("Company");
            }
        }
        public int Cash
        {
            get { return _employee.Cash; }
            set
            {
                _employee.Cash = value;
                OnPropertyChanged("Cash");
            }
        }

        
        public void SendReady()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
