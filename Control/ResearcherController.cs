using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_2.Database;
using System.Collections.ObjectModel;

namespace Assignment_2.Control
{
    class ResearcherController
    {
        private List<Researcher> researchers;

        private ObservableCollection<Researcher> visibleResearchers;

        public ResearcherController()
        {
            // Calls fetchbasicresearcherdetails, returns values to researcherlistview
 
            researchers = ERDAdapter.fetchBasicResearcherDetails();
            visibleResearchers = new ObservableCollection<Researcher>(researchers); //this list we will modify later

        }

        public ObservableCollection<Researcher> GetViewableList()
        {
            return visibleResearchers;
        }



        public void FilterBy(EmploymentLevel level)
        {

        }

        public void FilterByName(string name)
        {

        }
        public void LoadResearcherDetails()
        {

        }
    }
}
