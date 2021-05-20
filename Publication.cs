using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    public enum OutputType { Conference, Journal, Other };
    class Publication
    {
        private string DOI;
        private string Title;
        private string Authors;
        private DateTime Year;
        private OutputType Type;
        private string CiteAs;
        private DateTime Available;



    }
}
