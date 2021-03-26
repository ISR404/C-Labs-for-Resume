using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using DAL;

namespace Business
{
    public class EmployeeEventArgs : EventArgs
    {
        public Employee Employee { get; set; }

        public EmployeeEventArgs(Employee emp)
        {
            Employee = emp;
        }
    }

    public interface IEmpBL
    {
        void AddEmployee(Employee emp);

        event EventHandler<EmployeeEventArgs> EventEmployeeAddModel;
        IRepository<Employee> Repository { get; set; }
    }

    public class BL : IEmpBL
    {
        public BL(IRepository<Employee> reposit)
        {
            Repository = reposit;
        }
        public IRepository<Employee> Repository { get; set; }

        public event EventHandler<EmployeeEventArgs> EventEmployeeAddModel;

        public void AddEmployee(Employee emp)
        {
            Repository.Create(emp);
            EventEmployeeAddModel(this, new EmployeeEventArgs(emp));
        }

    }
}
