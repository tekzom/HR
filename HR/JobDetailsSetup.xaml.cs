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
        int jobid;
        JobsServices JS = new JobsServices();
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



        private void dgJobt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                ////Delete
                //int id = Convert.ToInt32(MedsGrid.Rows[e.RowIndex].Cells["MedID"].Value);
                //Medicament med = Meds.FindExisted(id);
                //if (e.ColumnIndex == MedsGrid.Columns["Remove"].Index && e.RowIndex > 0)
                //{
                //    if (DialogResult.Yes == MessageBox.Show("Are You sure..!", "Deleting Medicament", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                //    {

                //        Meds.Delete(med.MedID);
                //        this.Refrech();
                //    }

                //}
                ////Edite
                //if (e.ColumnIndex == MedsGrid.Columns["Edit"].Index && e.RowIndex > 0)
                //{
                //    CRUD_Medicament form = new CRUD_Medicament()
                //    {
                //        IsUpdate = true,
                //        Meds = Meds
                //    };
                //    form.Current(med);
                //    form.ShowDialog();
                //    this.Refrech();
                //}
        }

        private void bcancelpay_Click(object sender, RoutedEventArgs e)
        {
            SaddP.Visibility = Visibility.Collapsed;
            sgpay.Visibility = Visibility.Visible;
        }

        private void bsavepay_Click(object sender, RoutedEventArgs e)
        {
            PL.Add(
                   new PayGrade
                   {
                       Name = tnamep.Text,
                       Salary=int.Parse(tsalary.Text),
                   }
               );
            PL.Clear();
            PL = new PayServices().ListPaygrades();
            dgpay.ItemsSource = PL;
            SaddP.Visibility = Visibility.Collapsed;
            sgpay.Visibility = Visibility.Visible;

        }

        private void baddpay_Click(object sender, RoutedEventArgs e)
        {
            SaddP.Visibility = Visibility.Visible;
            sgpay.Visibility = Visibility.Collapsed;
        }

        private void BsaveE_Click(object sender, RoutedEventArgs e)
        {
            
            SL.Add(
                  new Status
                  {
                      Name = tnameE.Text,
                      Description = Gets(tdesE),
                  }
              );
            SL.Clear();
            SL = new StatusServices().ListStatus();
            Sstatu.ItemsSource = SL;
            SaddE.Visibility = Visibility.Collapsed;
            SgridE.Visibility = Visibility.Visible;

        }

        private void bcancelE_Click(object sender, RoutedEventArgs e)
        {
            SaddE.Visibility = Visibility.Collapsed;
            SgridE.Visibility = Visibility.Visible;
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
    }
}
