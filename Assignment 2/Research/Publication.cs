using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2.Research
{
    public enum OutputType { Conference, Journal, Other };
    public class Publication
    {
        private string DOI { get; set; }
        private string Title { get; set; }
        private string Authors { get; set; }
        private DateTime Year { get; set; }
        private OutputType Type { get; set; }
        private string CiteAs { get; set; }
        private DateTime Available { get; set; }

        //public int Age()
        //{

        //}


    }
}
