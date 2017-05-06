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
using HRuwp.Entities;
using HR.Managment;

namespace HR
{
    /// <summary>
    /// Interaction logic for UC_AddEmpl.xaml
    /// </summary>
    public partial class UC_AddEmpl : UserControl
    {
        public bool IsUpdate { get; set; }
        public int EmployeeId;
        EmployeesServices ES = new EmployeesServices();
        public UC_AddEmpl()
        {
            InitializeComponent();
            this.cbnat.DataContext = new NationalitiesServices().ListNationalities();
            this.cbdep.DataContext = new DepatementsServices().ListDepartements();
        }



        private void BSave_Click(object sender, RoutedEventArgs e)
        {
            if (IsUpdate)
            {
                Employee E = new Employee()
                {
                    Id=EmployeeId,
                    FirstName = tfirstname.Text,
                    LastName = tlastname.Text,


                };
                ES.Update(E);
            }
            else
            {
                Employee E = new Employee()
                {
                    FirstName = tfirstname.Text,
                    LastName = tlastname.Text,


                };
                ES.Add(E);
            }
        }

        public void CurrentEmployee(Employee E)
        {
            tfirstname.Text = E.FirstName;
            EmployeeId = E.Id;
        }

        private void BCancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
