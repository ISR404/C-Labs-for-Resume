using Business;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter
{
    public class EmployeePresenter
    {
        private IEmpBL model;
        private IEmployeeView view;

        public EmployeePresenter(IEmployeeView empview, IEmpBL empmodel)
        {
            model = empmodel;
            view = empview;

            view.EventEmployeeAddView += view_EmployeeAdd;
            view.EventEmployeeShowView += view_EventEmployeeShowView;

            model.EventEmployeeAddModel += model_EmployeeAdd;
        }

        private void model_EmployeeAdd(object sender, EmployeeEventArgs e)
        {
            view.AddEmployee(e.Employee);
        }

        private void view_EventEmployeeShowView(object sender, EmployeeEventArgs e)
        {
            view.ShowEmps(model.Repository.GetObjectsList());
        }

        private void view_EmployeeAdd(object sender, EmployeeEventArgs e)
        {
            model.AddEmployee(e.Employee);
        }
    }
}
