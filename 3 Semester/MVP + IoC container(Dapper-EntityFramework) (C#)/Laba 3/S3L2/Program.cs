using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL;
using Domain;
using Business;
using Ninject;

namespace S3L2
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel ninjectKernel = new StandardKernel(new SimpleConfigModule());

            BL business = ninjectKernel.Get<BL>();
            Employee e1 = new Employee() { Name = "Guy", Cash = 400, Age = 56, Pay = 400 };

            var list = business.Repository.GetObjectsList();
            foreach (var i in list)
            {
                Console.WriteLine("{0} {1}, Возраст: {2}, Деньги: {3}, Зарплата: {4}", i.Id, i.Name, i.Age, i.Cash, i.Pay);
            }
            Console.WriteLine();
            Console.ReadLine();


        }
    }
}
