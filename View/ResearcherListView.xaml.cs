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
using Assignment_2.Control;

namespace Assignment_2.View
{
    /// <summary>
    /// Interaction logic for ResearcherListView.xaml
    /// </summary>
    

    public partial class ResearcherListView : UserControl
    {


        private ResearcherController resControl;
        public ResearcherListView()
        {
            InitializeComponent();
            // This should link to the researcher controller but if you uncomment the whole thing dies
            //resControl = Application.Current.FindResource("researchercontroller") as ResearcherController;
        }
    }
}
