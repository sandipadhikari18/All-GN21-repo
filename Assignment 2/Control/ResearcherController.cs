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
        private List<Researcher> researchers;

        private ObservableCollection<Researcher> visibleResearchers;


        private ResearcherDetailsView detailsView = null;
        private ResearcherDetailsView DetailsView { get { if (detailsView == null) { detailsView = (Application.Current.MainWindow as Main).ResearcherDetailsView; } return detailsView;}}

        private string filterLowerName = "";
        private EmploymentLevel filterEmploymentLevel = EmploymentLevel.Any;
        public static List<Researcher> Generate()
        {
            return new List<Researcher>() {
                new Student { GivenName = "Jane", FamilyName = "Doe", ResearcherPosition = new Position { level = EmploymentLevel.Student } },
                new Student { GivenName = "John", FamilyName = "Doe", ResearcherPosition = new Position { level = EmploymentLevel.Student } },
            };
        }
        public ResearcherController()
        {
            // Calls fetchbasicresearcherdetails, returns values to researcherlistview

            researchers = ERDAdapter.fetchBasicResearcherDetails();
            //researchers = Generate();
            visibleResearchers = new ObservableCollection<Researcher>(researchers); //this list we will modify later

        }

        public ObservableCollection<Researcher> GetViewableList()
        {
            return visibleResearchers;
        }



        public void FilterBy(EmploymentLevel level)
        {
            filterEmploymentLevel = level;
            RunFilter();
        }

        public void FilterByName(string name)
        {
            filterLowerName = name.ToLower();
            RunFilter();
        }

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
        public void LoadResearcherDetails(Researcher r)
        {
            r = ERDAdapter.fetchFullResearcherDetails(r);
            DetailsView.FillOutDetails(r);
        }
    }
}
