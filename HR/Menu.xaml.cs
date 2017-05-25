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
        public Menu() {
            InitializeComponent();
            MainPanel.Children.Clear();
            var w = new Test();
            MainPanel.Children.Add(w);
        }


        private void ClickableMenuItem_Checked(object sender, RoutedEventArgs e)
        {
            MainPanel.Children.Clear();
            var w = new JobDetailsSetup();
            //w.IsUpdate = false;
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

        private void ClickableMenuItem_Checked_1(object sender, RoutedEventArgs e)
        {
            MainPanel.Children.Clear();
            var w = new TrainingSetup();
            //w.IsUpdate = false;
            MainPanel.Children.Add(w);
        }


        private void ClickableMenuItem_Checked_2(object sender, RoutedEventArgs e)
        {
            MainPanel.Children.Clear();
            var w = new JobDetailsSetup();
            //w.IsUpdate = false;
            MainPanel.Children.Add(w);
        }

        private void PCS_Click(object sender, RoutedEventArgs e)
        {
            MainPanel.Children.Clear();
            var w = new ProjectsClientSetup();
            //w.IsUpdate = false;
            MainPanel.Children.Add(w);
        }

        private void Qualification_Click(object sender, RoutedEventArgs e)
        {
            MainPanel.Children.Clear();
            var w = new QualificationsSetup();
            //w.IsUpdate = false;
            MainPanel.Children.Add(w);
        }

        private void ClickableMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Employee_Click(object sender, RoutedEventArgs e)
        {
            MainPanel.Children.Clear();
            var w = new Employees();
            //w.IsUpdate = false;
            MainPanel.Children.Add(w);
        }
    }
}
