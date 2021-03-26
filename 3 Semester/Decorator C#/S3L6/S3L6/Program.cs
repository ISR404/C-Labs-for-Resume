using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3L6
{
    class Program
    {
        static void Main(string[] args)
        {
            Engineer eng = new Engineer("Семен");
            IntermediateEnglish inter = new IntermediateEnglish(eng);
            AcademicDegree academ = new AcademicDegree(inter);
            Scientist man = new Scientist("ЫЫЫЫЫЫ");
            AcademicDegree ac = new AcademicDegree(man);
            Console.WriteLine(academ.Name + ' ' + academ.Salary);
            Console.WriteLine(ac.Name + ' ' + ac.Salary);
            Console.ReadLine();
        }
    }
}
