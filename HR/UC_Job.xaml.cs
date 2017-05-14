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
using HR.Managment;
using HRuwp.Entities;

namespace HR
{
    /// <summary>
    /// Interaction logic for UC_Job.xaml
    /// </summary>
    public partial class UC_Job : UserControl
    {
        List<Job> LJ = new List<Job>();
        public UC_Job()
        {
            InitializeComponent();
            LJ = new JobsServices().ListJobs();
            dgJob.ItemsSource = LJ;
            
        }
    }
}
