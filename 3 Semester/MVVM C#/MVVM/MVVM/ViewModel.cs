using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVVM
{
    public class ViewModel : INotifyPropertyChanged
    {
        private Employee _selectedEmployee;

        public ObservableCollection<Employee> Employees { get; set; }
        public Employee SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged("SelectedEmployee");
            }
        }

        public ViewModel()
        {
            Employees = new ObservableCollection<Employee>
            {
                new Employee { Name="Mark", Company="IKIT", Cash=56000 },
                new Employee { Name="Stew", Company="SibDev", Cash =60000 },
                new Employee { Name="Anna", Company="Google", Cash=56000 },
                new Employee { Name="Rayan", Company="KrasCvetMet", Cash=35000 },
                new Employee { Name="Snickers", Company="AutoTrans", Cash=20000 },
                new Employee { Name="Noname", Company="sss", Cash=999 }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }

    
}
