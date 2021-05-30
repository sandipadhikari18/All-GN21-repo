using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_2.Database;
using Assignment_2.Research;
using System.Collections.ObjectModel;
using Assignment_2.View;
using System.Windows;

namespace Assignment_2.Control
{
    class ResearcherController
    {
        // This is the private list of all researchers retrieved at the start of the program
        private List<Researcher> researchers;
        // This is the observable collection of researchers that is visible to the Views and is linked to what is displayed in ResearcherListView
        private ObservableCollection<Researcher> visibleResearchers;
           
        // Had to initialise the ResearcherDetailsView so that we could pass the researcher to display to it
        private ResearcherDetailsView detailsView = null;
        private ResearcherDetailsView DetailsView { get { if (detailsView == null) { detailsView = (Application.Current.MainWindow as Main).ResearcherDetailsView; } return detailsView;}}

        // Variables that handle how the ResearcherListView is filtered
        private string filterLowerName = "";
        private EmploymentLevel filterEmploymentLevel = EmploymentLevel.Any;

        // Generates the observable list of researchers by calling fetchBasicResearcherDetails from the ERDAdapter
        public ResearcherController()
        {
            // Calls fetchbasicresearcherdetails, returns values to researcherlistview

            researchers = ERDAdapter.fetchBasicResearcherDetails();
            visibleResearchers = new ObservableCollection<Researcher>(researchers); //this list we will modify later

        }
        // Needed for the view to get the opbservable list
        public ObservableCollection<Researcher> GetViewableList()
        {
            return visibleResearchers;
        }


        // FilterBy is called when changing the "Level" filter and calls the RunFilter function after setting the filter employment level
        public void FilterBy(EmploymentLevel level)
        {
            filterEmploymentLevel = level;
            RunFilter();
        }
        // FilterByName is used to change the searched for researcher name
        // Had to use ToLower so the search box wouldn't be case sensitive as thats kind of a pain
        public void FilterByName(string name)
        {
            filterLowerName = name.ToLower();
            RunFilter();
        }

        // This calls the LINQ expressions to actually filter the list and update the observable list to this new filtered one
        public void RunFilter()
        {
            // Im sure theres a better way to do this instead of writing basically same linq twice
            if (filterEmploymentLevel == EmploymentLevel.Any)
            {
                var selected = from r in researchers
                               where (r.GivenName.ToLower().Contains(filterLowerName) || r.FamilyName.ToLower().Contains(filterLowerName))
                               select r;
                visibleResearchers.Clear();
                selected.ToList().ForEach(visibleResearchers.Add);
            }
            else
            {
                var selected = from r in researchers
                               where r.ResearcherPosition.level == filterEmploymentLevel && (r.GivenName.ToLower().Contains(filterLowerName) || r.FamilyName.ToLower().Contains(filterLowerName))
                               select r;
                visibleResearchers.Clear();
                selected.ToList().ForEach(visibleResearchers.Add);
            }
        }
        // Loads the full details for the given researcher and passes them off to the ResearcherDetailsView
        public void LoadResearcherDetails(Researcher r)
        {
            r = ERDAdapter.fetchFullResearcherDetails(r);
            DetailsView.FillOutDetails(r);
        }
    }
}
