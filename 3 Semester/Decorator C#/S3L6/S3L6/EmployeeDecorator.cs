using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3L6
{
    public abstract class EmployeeDecorator : Employee
    {
        protected Employee Employee { get; set; }
        public EmployeeDecorator(Employee emp) : base(emp.Name)
        {
            Employee = emp ?? throw new ArgumentNullException(nameof(emp));
            Salary = emp.Salary;
        }
    }

    public class AcademicDegree : EmployeeDecorator
    {
        public AcademicDegree(Employee emp) : base(emp)
        {
            Salary += 5000;
            Name += " с ученой степенью";
        }
    }

    public class IntermediateEnglish : EmployeeDecorator
    {
        public IntermediateEnglish(Employee emp) : base(emp)
        {
            Salary += 3000;
            Name += " со знанием английского уровня Intermediate";
        }
    }
}
