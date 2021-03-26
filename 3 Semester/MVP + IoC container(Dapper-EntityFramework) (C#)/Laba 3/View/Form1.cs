using Business;
using Domain;
using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class Form1 : Form, IEmployeeView
    {
        public Form1()
        {
            InitializeComponent();
        }

        public event EventHandler<EmployeeEventArgs> EventEmployeeAddView;
        public event EventHandler<EmployeeEventArgs> EventEmployeeShowView;

        public void AddEmployee(Employee emp)
        {
            MessageBox.Show(emp.Name + " - был добавлен");
        }

        public void ShowEmps(IEnumerable<Employee> employees)
        {
            foreach (Employee emp in employees)
            {
                listBox1.Items.Add(emp);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            EventEmployeeAddView(this, new EmployeeEventArgs(new Employee { Name = "Новенький" }));
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            EventEmployeeShowView(this, null);
        }
    }
}
