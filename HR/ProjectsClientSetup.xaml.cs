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
using HR.Entities;
using HR.Managment;
using HRuwp;
using HRuwp.Entities;

namespace HR
{
    /// <summary>
    /// Interaction logic for ProjectsClientSetup.xaml
    /// </summary>
    public partial class ProjectsClientSetup : UserControl
    {
        bool isUpdate = false;
        int proid;

        ClientsServices CS = new ClientsServices();
        List<Client> CL = new List<Client>();

        List<Project> PL = new List<Project>();
        ProjectsServices PS = new ProjectsServices();

        EmployeesServices ES = new EmployeesServices();
        List<Employee> EL = new List<Employee>(); 

        public ProjectsClientSetup()
        {
            InitializeComponent();

            ////////////////// Client ///////////////////////////
            //GridView
            CL = CS.ListClients();
            gridClie.ItemsSource = CL;


            ////////////////// Project ///////////////////////////
            //GridView
            PL = PS.ListProjects();
            gridProj.ItemsSource = PL;
            //Combo Client
            comboClie.ItemsSource = CL;
            comboClie.DisplayMemberPath = "Name";
            comboClie.SelectedValuePath = "Id";

            ////////////////// Employee Project ///////////////////////////
                   // Combo Project
            //comboEPProject.ItemsSource = PL;
            //comboEPProject.DisplayMemberPath = "Name";
            //comboEPProject.SelectedValuePath = "Id";
                   // Combo Employee
            //ComboEPEmployee.ItemsSource = EL;
            //ComboEPEmployee.DisplayMemberPath = "FirstName";
            //ComboEPEmployee.SelectedValuePath = "Id";
        }

        string Gets(RichTextBox rtb)
        {
            return new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd).Text;
        }

        public void Show(ScrollViewer show, ScrollViewer hide)
        {
            show.Visibility = Visibility.Visible;
            hide.Visibility = Visibility.Collapsed;
        }

        private void baddClie_Click(object sender, RoutedEventArgs e)
        {
            Show(SaddClie, SgridClie);
        }

        private void baddProj_Click(object sender, RoutedEventArgs e)
        {
            Show(SaddProj, SgridProj);
        }

        private void baddEP_Click(object sender, RoutedEventArgs e)
        {
            Show(SaddEP, SgridEP);
        }

        private void bcancelEP_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BsaveEP_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bcancelPro_Click(object sender, RoutedEventArgs e)
        {
            Show(SgridProj,SaddProj);

        }

        private void BsavePro_Click(object sender, RoutedEventArgs e)
        {
            if (!isUpdate)
            {
                PS.Add(
                   new Project
                   {
                       Name = tnamePro.Text,
                       Clie = CS.FindExisting((int)comboClie.SelectedValue),
                       Details = Gets(tdetPro),
                       Status = ComboStatu.Text
                   }
               );

            }
            else
            {
                PS.Update(new Project
                {
                    Id = proid,
                    Name = tnamePro.Text,
                    Clie = CS.FindExisting((int)comboClie.SelectedValue),
                    Details = Gets(tdetPro),
                    Status = ComboStatu.Text
                });
                isUpdate = false;
            }
            tdetPro.Document.Blocks.Clear();
            PL.Clear();
            PL = PS.ListProjects();
            gridProj.ItemsSource = PL;

            Show(SgridProj, SaddProj);
        }

        private void bcancelClie_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BsaveClie_Click(object sender, RoutedEventArgs e)
        {
            if (!isUpdate)
            {
                CS.Add(
                   new Client
                   {
                       Name = tnameClie.Text,
                       Details = Gets(tdetailC),
                       Address = Gets(tadrC),
                       ContactNumber = tcontactNum.Text,
                       ContactEmail = tcontactEmail.Text,
                       CompanyUrl = tcompanyUrl.Text,
                       Status = comboClie.Text,
                       FirstContact = DFristCont.SelectedDate.Value.Date
                   }
               );

            }
            //else
            //{
            //    PS.Update(new Project
            //    {
            //        Id = proid,
            //        Name = tnamePro.Text,
            //        Clie = CS.FindExisting((int)comboClie.SelectedValue),
            //        Details = Gets(tdetPro),
            //        Status = ComboStatu.Text
            //    });
            //    isUpdate = false;
            //}
            tdetailC.Document.Blocks.Clear();
            CL.Clear();
            CL = CS.ListClients();
            gridClie.ItemsSource = CL;

            Show(SgridClie, SaddClie);
        }

        private void DelProj_Click(object sender, RoutedEventArgs e)
        {
            var project = ((FrameworkElement)sender).DataContext as Project;
            PS.Delete(project.Id);
        }

        private void UpdProje_Click(object sender, RoutedEventArgs e)
        {
            var project = ((FrameworkElement)sender).DataContext as Project;
            proid = project.Id;
            isUpdate = true;
            tnamePro.Text = project.Name;
            comboClie.Text = project.Clie.ToString();
            tdetPro.AppendText(project.Details);
            ComboStatu.Text = project.Status;
        }

        private void delClie_Click(object sender, RoutedEventArgs e)
        {
            var client = ((FrameworkElement)sender).DataContext as Client;
            CS.Delete(client.Id);
        }
    }
}
