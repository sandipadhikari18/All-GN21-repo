using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace Assignment_2.Research
{
    public class Researcher
    {
        
        public int id { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string Title { get; set; }
        public string School { get; set; }
        public string Campus { get; set; }
        public string Email { get; set; }

        public string Photo { get; set; }
        public Position ResearcherPosition { get; set; }
        public DateTime EarliestStartDate { get; set; }
        // Returns the start date of the currently assigned position
        public DateTime CurrentStartDate { get { return ResearcherPosition.Start; } }
        // Returns the title of the current position
        public string CurrentJobTitle { get { return ResearcherPosition.Title;  } }
        // Returns a calculated tenure
        public double Tenure { get { return CalcTenure(); } }

        // Used to calculate the Tenure as a double based on the time since employment to the local computers current time
        public double CalcTenure()
        {
            DateTime localDate = DateTime.Now;
            TimeSpan t = localDate.Subtract(EarliestStartDate);
            double tenureD = Math.Round(t.Days / 365.0, 1) ;

            return tenureD;
        }

        //public int PublicationsCount()
        //{

        //}

        // ToString so the ResearcherListView will display each researcher in the correct format
        public override string ToString()
        {
            return string.Format("{0}, {1} ({2})", FamilyName, GivenName, Title);
        }
    }
}
