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
using HR.Entities;

namespace HR
{
    /// <summary>
    /// Interaction logic for JobDetailsSetup.xaml
    /// </summary>
    public partial class JobDetailsSetup : UserControl
    {
        bool isUpdate = false;
        int jobid,payid, Statuid;
        JobsServices JS = new JobsServices();
        PayServices PS = new PayServices();
        StatusServices SS = new StatusServices();
        List<Job> JL = new List<Job>();
        List<PayGrade> PL = new List<PayGrade>();
        List<Status> SL = new List<Status>();
        

        string Gets(RichTextBox rtb)
        {
            return new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd).Text;
        }

        public JobDetailsSetup()
        {
            InitializeComponent();
            Sgrid.Visibility = Visibility.Visible;
            SaddJ.Visibility = Visibility.Collapsed;
            JL = new JobsServices().ListJobs();
            dgJobt.ItemsSource = JL;
            PL = new PayServices().ListPaygrades();
            dgpay.ItemsSource = PL;
            SL = new StatusServices().ListStatus();
            Sstatu.ItemsSource = SL;
        }

        ///////////// JOB /////////////////

        private void bsave_Click(object sender, RoutedEventArgs e)
        {
            if (!isUpdate)
            {
                JS.Add(
                   new Job
                   {
                       Name = tname.Text,
                       TiteleCode = tcode.Text,
                       Discription = Gets(tdes),
                       Specification = Gets(tspec),
                   }
               );
               
            }
            else
            {
                JS.Update(new Job
                {
                    Code = jobid,
                    Name = tname.Text,
                    TiteleCode = tcode.Text,
                    Discription = Gets(tdes),
                    Specification = Gets(tspec),
                });
                isUpdate = false;
            }
            tdes.Document.Blocks.Clear();
            JL.Clear();
            JL = JS.ListJobs();
            dgJobt.ItemsSource = JL;

            Sgrid.Visibility = Visibility.Visible;
            SaddJ.Visibility = Visibility.Collapsed;
        }

        private void bdel_Click(object sender, RoutedEventArgs e)
        {
            var job = ((FrameworkElement)sender).DataContext as Job;
            JS.Delete(job.Code);
        }


        private void bup_Click(object sender, RoutedEventArgs e)
        {
            var job = ((FrameworkElement)sender).DataContext as Job;
            jobid = job.Code;
            isUpdate = true;
            tcode.Text = job.TiteleCode;
            tname.Text = job.Name;
            tdes.AppendText(job.Discription);
            SaddJ.Visibility = Visibility.Visible;
            Sgrid.Visibility = Visibility.Collapsed;
        }

        private void bcanc_Click(object sender, RoutedEventArgs e)
        {
            Sgrid.Visibility = Visibility.Visible;
            SaddJ.Visibility = Visibility.Collapsed;
        }

        private void Badd_Click(object sender, RoutedEventArgs e)
        {
            Sgrid.Visibility = Visibility.Collapsed;
            SaddJ.Visibility = Visibility.Visible;
        }

        /////////////////// PayGrade //////////////////

        private void bsavepay_Click(object sender, RoutedEventArgs e)
        {
            if (!isUpdate)
            {
                PS.Add(
                   new PayGrade
                   {
                       Name = tnamep.Text,
                       Salary = int.Parse(tsalary.Text),
                   }
               );

            }
            else
            {
                PS.Update(new PayGrade
                {
                    Code = payid,
                    Name = tnamep.Text,
                    Salary = int.Parse(tsalary.Text),
                });
                isUpdate = false;
            }
            tdes.Document.Blocks.Clear();
            PL.Clear();
            PL = PS.ListPaygrades();
            dgpay.ItemsSource = PL;

            SaddP.Visibility = Visibility.Collapsed;
            sgpay.Visibility = Visibility.Visible;

        }


        private void bdelPay_Click(object sender, RoutedEventArgs e)
        {
            var Pay = ((FrameworkElement)sender).DataContext as PayGrade;
            PS.Delete(Pay.Code);
        }

        private void bupPay_Click(object sender, RoutedEventArgs e)
        {
            var Pay = ((FrameworkElement)sender).DataContext as PayGrade;
            payid = Pay.Code;
            isUpdate = true;
            tnamep.Text = Pay.Name;
            tsalary.Text = Pay.Salary.ToString();
            SaddP.Visibility = Visibility.Visible;
            sgpay.Visibility = Visibility.Collapsed;

        }

        private void bcancelpay_Click(object sender, RoutedEventArgs e)
        {
            SaddP.Visibility = Visibility.Collapsed;
            sgpay.Visibility = Visibility.Visible;
        }

        private void baddpay_Click(object sender, RoutedEventArgs e)
        {
            SaddP.Visibility = Visibility.Visible;
            sgpay.Visibility = Visibility.Collapsed;
        }
        /////////////////////// EStatus ////////////////////


        private void BsaveE_Click(object sender, RoutedEventArgs e)
        {
            if (!isUpdate)
            {
                SS.Add(
                   new Status
                   {
                       Name = tnameE.Text,
                       Description = Gets(tdesE),
                   }
               );

            }
            else
            {
                SS.Update(new Status
                {
                    ID = Statuid,
                    Name = tnameE.Text,
                    Description = Gets(tdesE),
                });
                isUpdate = false;
            }
            tdesE.Document.Blocks.Clear();
            SL.Clear();
            SL = SS.ListStatus();
            Sstatu.ItemsSource = SL;


            SaddE.Visibility = Visibility.Collapsed;
            SgridE.Visibility = Visibility.Visible;

        }

        private void bcancelE_Click(object sender, RoutedEventArgs e)
        {
            SaddE.Visibility = Visibility.Collapsed;
            SgridE.Visibility = Visibility.Visible;
        }

        private void dgJobt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void baddES_Click(object sender, RoutedEventArgs e)
        {
            SaddE.Visibility = Visibility.Visible;
            SgridE.Visibility = Visibility.Collapsed;
        }

        private void bdelE_Click(object sender, RoutedEventArgs e)
        {
            var Statu = ((FrameworkElement)sender).DataContext as Status;
            SS.Delete(Statu.ID);
        }

        private void bupE_Click(object sender, RoutedEventArgs e)
        {
            var Statu = ((FrameworkElement)sender).DataContext as Status;
            Statuid = Statu.ID;
            isUpdate = true;
            tnameE.Text = Statu.Name;
            tdesE.AppendText(Statu.Description);
            SaddP.Visibility = Visibility.Visible;
            sgpay.Visibility = Visibility.Collapsed;
        }
    }
}
