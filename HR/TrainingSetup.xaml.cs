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

namespace HR
{
    /// <summary>
    /// Interaction logic for TrainingSetup.xaml
    /// </summary>
    public partial class TrainingSetup : UserControl
    {
        public TrainingSetup()
        {
            InitializeComponent();
        }

        private void addC_Click(object sender, RoutedEventArgs e)
        {
            Sgridcours.Visibility = Visibility.Collapsed;
            Saddcours.Visibility = Visibility.Visible;
        }
    }
}
