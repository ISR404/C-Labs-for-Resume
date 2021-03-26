using Business;
using DAL;
using Ninject;
using Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form1 view = new Form1();
            IKernel ninjectKernel = new StandardKernel(new SimpleConfigModule());
            BL model = ninjectKernel.Get<BL>();
            EmployeePresenter presenter = new EmployeePresenter(view, model);
            Application.Run(new Form1());
        }
    }
}
