using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3L6
{
    public abstract class Employee
    {
        public string Name { get; protected set; }

        public int Salary { get; protected set; }

        public Employee(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(nameof(name));
            }

            Name = name;
            Salary = 10000;
        }
    }

    public class Engineer : Employee
    {
        public Engineer(string name) : base(name + " - инженер")
        {
            
        }
    }

    public class Manager : Employee
    {
        public Manager(string name) : base(name + " - менеджер")
        {
            Salary += 4000;
        }
    }

    public class Scientist : Employee
    {
        public Scientist(string name) : base(name + " - ученый")
        {
            Salary += 7000;
        }
    }


}
