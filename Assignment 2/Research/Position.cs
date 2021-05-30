using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2.Research
{
    public enum EmploymentLevel { Student, A, B, C, D, E };
    public class Position
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public EmploymentLevel level { get; set; }

        public string Title { get { return ToTitle(level); } }

        public string ToTitle(EmploymentLevel l)
       {
            if (l == EmploymentLevel.A)
            {
                return "Postdoc";
            }
            else if (l == EmploymentLevel.B)
            {
                return "Lecturer";
            }
            else if (l == EmploymentLevel.C)
            {
                return "Senior Lecturer";
            }
            else if (l == EmploymentLevel.D)
            {
                return "Associate Professor";
            }
            else if (l == EmploymentLevel.E)
            {
                return "Professor";
            }
            else if (l == EmploymentLevel.Student)
            {
                return "Student";
            }
            else
            {
                return "No Title";
            }
        }
    }
}
