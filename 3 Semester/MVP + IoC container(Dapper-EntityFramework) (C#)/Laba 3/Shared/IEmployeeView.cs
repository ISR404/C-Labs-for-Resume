using Business;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IEmployeeView
    {
        void AddEmployee(Employee emp);

        void ShowEmps(IEnumerable<Employee> listemps);

        event EventHandler<EmployeeEventArgs> EventEmployeeAddView;
        event EventHandler<EmployeeEventArgs> EventEmployeeShowView;
    }
}
