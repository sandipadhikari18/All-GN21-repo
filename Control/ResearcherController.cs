using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_2.Database; 

namespace Assignment_2.Control
{
    class ResearcherController
    {

        public void LoadResearchers()
        {
            // Calls fetchbasicresearcherdetails, returns values to researcherlistview

            List<Researcher> researcherList; 
            researcherList = ERDAdapter.fetchBasicResearcherDetails();
        }

        public void FilterBy(EmploymentLevel level)
        {

        }

        public void FilterByName(string name)
        {

        }
        public void LoadReearcherDetails()
        {

        }
    }
}
