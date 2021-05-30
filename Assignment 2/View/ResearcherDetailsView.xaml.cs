﻿using Assignment_2.Research;
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
    /// Interaction logic for ResearcherDetailsView.xaml
    /// </summary>
    public partial class ResearcherDetailsView : UserControl
    {
        public ResearcherDetailsView()
        {
            InitializeComponent();
        }

        // Used to update the datacontext of the view so the values of the selected researcher are displayed
        public void FillOutDetails(Researcher r)
        {
            this.DataContext = r;
        }

    }
}
