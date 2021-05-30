using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2.Research
{
    public enum EmploymentLevel { Student, A, B, C, D, E };
    class Position
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public EmploymentLevel level { get; set; }

        //public string Title()
        //{

        //}

        //public string ToTitle(EmploymentLevel l)
        //{

        //}
    }
}
