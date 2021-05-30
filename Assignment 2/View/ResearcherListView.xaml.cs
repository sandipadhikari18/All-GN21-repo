using Assignment_2.Control;
using Assignment_2.Research;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assignment_2.View
{
    /// <summary>
    /// Interaction logic for ResearcherListView.xaml
    /// </summary>
    /// 
    public partial class ResearcherListView : UserControl
    {
        private ResearcherController res;
        public ResearcherListView()
        {
            InitializeComponent();
            res = Application.Current.FindResource("researcherController") as ResearcherController;
        }


        private void reasearcherListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                Researcher resObj = (Researcher)e.AddedItems[0];
                res.LoadResearcherDetails(resObj);
            }
            
        }
    }
}
