using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Cash { get; set; }
        public int Pay { get; set; }
        

        public override string ToString()
        {
            return "Имя: " + Name + " Возраст:" + Age + " Наличные:" + Cash + " Зарплата:" + Pay;
        }
    }
}
