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
using System.Windows.Shapes;
using HRuwp.Entities;

namespace HR
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
            
            //s1.Visibility = Visibility.Collapsed;
            //s2.Visibility = Visibility.Collapsed;

        }

        private void M1_Click(object sender, RoutedEventArgs e)
        {
            //s1.Visibility = Visibility.Visible;
            //s2.Visibility = Visibility.Collapsed;

        }

        private void M2_Click(object sender, RoutedEventArgs e)
        {
            //s2.Visibility = Visibility.Visible;
            //s1.Visibility = Visibility.Collapsed;

        }

        private void ClickableMenuItem_Checked(object sender, RoutedEventArgs e)
        {
            var w = new UC_AddEmpl();
            w.IsUpdate = false;
            MainPanel.Children.Add(w);
        }

        private void Modifie(object sender, RoutedEventArgs e)
        {
            MainPanel.Children.Clear();
            var u = new UC_AddEmpl();
            u.IsUpdate = true;
            var Employee = new Employee()
            {
                FirstName = "Mohamed"
            };
            u.CurrentEmployee(Employee);
            MainPanel.Children.Add(u);
        }
    }
}
