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
using HR;
using HR.Entities;
using HRuwp.Entities;
using HR.Managment;

namespace HR
{
    /// <summary>
    /// Interaction logic for Employees.xaml
    /// </summary>
    public partial class Employees : UserControl
    {
        List<Employee> EL = new List<Employee>();
        EmployeesServices ES = new EmployeesServices();

        public Employees()
        {
            InitializeComponent();
            EL = new EmployeesServices().ListEmployees();
            gridEmployee.ItemsSource = EL;

        }

        public void Show(ScrollViewer show, ScrollViewer hide)
        {
            show.Visibility = Visibility.Visible;
            hide.Visibility = Visibility.Collapsed;

        }

        private void baddEmployee_Click(object sender, RoutedEventArgs e)
        {
            Show(SaddEmployee, SgridEmployee);
        }
    }
}
