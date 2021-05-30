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

        }

        public void FilterByName(string name)
        {

        }
        public void LoadResearcherDetails(Researcher r)
        {
            r = ERDAdapter.fetchFullResearcherDetails(r);
            DetailsView.FillOutDetails(r);
        }
    }
}
