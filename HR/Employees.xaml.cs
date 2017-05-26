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
    /// 

    class ObjectGridView
    {
        public string Name { get; set; }
        public bool isChecked { get; set; }
    }

    public partial class Employees : UserControl
    {
        ///////////////////////// Employee de Info //////////////////
        private Employee _Employee = new Employee();
        ////////////////////////  Skill Chekbox /////////////////////



        private void FillGrid()
        {
            List<Skill> lSkills = new SkillsServices().ListSkills();
            List<Skill> Semployee = _Employee.Skills;
            List<ObjectGrid> LG = new List<ObjectGrid>();
            bool verf = false;
            foreach (var skill in lSkills)
            {
                foreach (var eSkill in Semployee)
                {
                    if(skill.Id == eSkill.id)
                    {
                        verf = true;
                        break;
                    }
                }
                if(verf)
                    LG.Add(new ObjectGrid { Name = skill.Name, isChecked = true });
                else
                    LG.Add(new ObjectGrid { Name = skill.Name, isChecked = false });  
            }
            gridMSkill.ItemsSource = LG;
        }
        



        bool isUpdate = false;
        int idEmployee;

        List<Employee> EL = new List<Employee>();
        EmployeesServices ES = new EmployeesServices();
        List<Status> SL = new List<Status>();
        StatusServices SS = new StatusServices();
        List<Nationality> NL = new List<Nationality>();
        NationalitiesServices NS = new NationalitiesServices();
        List<Job> JL = new List<Job>();
        JobsServices JS = new JobsServices();
        List<Departement> DL = new List<Departement>();
        DepatementsServices DS =new  DepatementsServices();
        List<PayGrade> PL = new List<PayGrade>();
        PayServices PS = new PayServices();


        public Employees()
        {
            InitializeComponent();
            EL = new EmployeesServices().ListEmployees();
            gridEmployee.ItemsSource = EL;


            /////// combo status
            SL = SS.ListStatus();
            combostatus.ItemsSource = SL;
            combostatus.DisplayMemberPath = "Name";
            combostatus.SelectedValuePath = "ID";

            ///// combo Nationality
            NL = NS.ListNationalities();
            combonat.ItemsSource = NL;
            combonat.DisplayMemberPath = "Name";
            combonat.SelectedValuePath = "Id";

            ///// combo Job
            JL = JS.ListJobs();
            combojob.ItemsSource = JL;
            combojob.DisplayMemberPath = "Name";
            combojob.SelectedValuePath = "code";

            ///// combo Departement 
            DL = DS.ListDepartements();
            comboDepa.ItemsSource = DL;
            comboDepa.DisplayMemberPath = "Name";
            comboDepa.SelectedValuePath = "Id";

            ///// combo Supervisor 
            EL = ES.ListEmployees();
            comboSuperV.ItemsSource = EL;
            comboSuperV.DisplayMemberPath = "FirstName";
            comboSuperV.SelectedValuePath = "Id";


        }

        public void Show(ScrollViewer show, ScrollViewer hide)
        {
            show.Visibility = Visibility.Visible;
            hide.Visibility = Visibility.Collapsed;
        }

        string Gets(RichTextBox rtb)
        {
            return new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd).Text;
        }

        private void baddEmployee_Click(object sender, RoutedEventArgs e)
        {
            Show(SaddEmployee, SgridEmployee);
        }

        private void cbms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void bSaveEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (!isUpdate)
            {
                ES.Add(
                   new Employee
                   {
                       FirstName = tfirstname.Text,
                       LastName = tlastname.Text,
                       Nation = NS.FindExisting((int)combonat.SelectedValue),
                       Datebirth = dob.SelectedDate.Value.Date,
                       Gender = cbgr.Text,
                       MaritalStatus = cbms.Text,
                       CIN = tcin.Text,
                       EpmloyeeStatus = tEstatus.Text,
                       Job = JS.FindExisting((int)combojob.SelectedValue),
                       Adress = Gets(tadress),
                       Phone = tphone.Text,
                       Email = temail.Text,
                       JoinDate = djoin.SelectedDate.Value.Date,
                       Dep = DS.FindExisting((int)comboDepa.SelectedValue),
                       Supervisor = ES.FindExisting((int)comboSuperV.SelectedValue),
                       Stat = SS.FindExisting((int)combostatus.SelectedValue),
                       pay = PS.FindExisting((int)comboPay.SelectedValue)
                   }
               );

            }
            else
            {
                ES.Update(
                    new Employee {
                        Id=idEmployee,
                        FirstName = tfirstname.Text,
                        LastName = tlastname.Text,
                        Nation = NS.FindExisting((int)combonat.SelectedValue),
                        Datebirth = dob.SelectedDate.Value.Date,
                        Gender = cbgr.Text,
                        MaritalStatus = cbms.Text,
                        CIN = tcin.Text,
                        EpmloyeeStatus = tEstatus.Text,
                        Job = JS.FindExisting((int)combojob.SelectedValue),
                        Adress = Gets(tadress),
                        Phone = tphone.Text,
                        Email = temail.Text,
                        JoinDate = djoin.SelectedDate.Value.Date,
                        Dep = DS.FindExisting((int)comboDepa.SelectedValue),
                        Supervisor = ES.FindExisting((int)comboSuperV.SelectedValue),
                        Stat = SS.FindExisting((int)combostatus.SelectedValue),
                        pay = PS.FindExisting((int)comboPay.SelectedValue)
                    }
                    );
                isUpdate = false;
            }
            ClearInputs();

        }

        private void ClearInputs() {
            tfirstname.Clear();
            tlastname.Clear();
            combonat.SelectedIndex = -1;
            dob.SelectedDate = DateTime.Now;
            cbgr.SelectedIndex = -1;
            cbms.SelectedIndex = -1;
            tcin.Clear();
            tEstatus.Clear();
            combojob.SelectedIndex = -1;
            tadress.Document.Blocks.Clear();
            tphone.Clear();
            temail.Clear();
            djoin.SelectedDate = DateTime.Now;
            comboDepa.SelectedIndex = -1;
            comboSuperV.SelectedIndex = -1;
            combostatus.SelectedIndex = -1;
            comboPay.SelectedIndex = -1;
        }

        private void bCancelEmployee_Click(object sender, RoutedEventArgs e)
        {
            ClearInputs();
            Show(SgridEmployee, SaddEmployee);
        }


        private void btInfo_Click(object sender, RoutedEventArgs e) {
            Employee ep = ((FrameworkElement)sender).DataContext as Employee;
            gridSkill.ItemsSource = ep.Skills;
            gridCer.ItemsSource = ep.Certifications;
            gridEdu.ItemsSource = ep.Educations;
            gridLan.ItemsSource = ep.Languages;
            Employee.Visibility = Visibility.Collapsed;
            TabMain.SelectedIndex = 1;
            Skills.Visibility = Visibility.Visible;
            Education.Visibility = Visibility.Visible;
            Languages.Visibility = Visibility.Visible;
            Certification.Visibility = Visibility.Visible;

        }

        private void btManageSkill_Click(object sender, RoutedEventArgs e)
        {
            MSkill.Visibility = Visibility.Visible;
            List<Skill> ls = new SkillsServices().ListSkills();
            List<ObjectGrid> LG = new List<ObjectGrid>();
            foreach (var skill in ls)
            {
                LG.Add(new ObjectGrid { Name = skill.Name, isChecked = false });
            }
            gridMSkill.ItemsSource = LG;
        }

        private void btManageEducation_Click(object sender, RoutedEventArgs e)
        {
            SMEducation.Visibility = Visibility.Visible;
            List<Education> ls = new EducationServices().ListEducations();
            List<ObjectGrid> LG = new List<ObjectGrid>();
            foreach (var education in ls)
            {
                LG.Add(new ObjectGrid { Name = education.Name, isChecked = false });
            }
            gridMEducation.ItemsSource = LG;
        }

        private void btManageCertification_Click(object sender, RoutedEventArgs e)
        {
            SMCertifica.Visibility = Visibility.Visible;
            List<Certification> ls = new CertificationsServices().ListCertifications();
            List<ObjectGrid> LG = new List<ObjectGrid>();
            foreach (var certicica in ls)
            {
                LG.Add(new ObjectGrid { Name = certicica.Name, isChecked = false });
            }
            gridMCertifica.ItemsSource = LG;
        }

        private void btManageLanguages_Click(object sender, RoutedEventArgs e)
        {
            SMLanguage.Visibility = Visibility.Visible;
            List<Language> ls = new LanguagesServices().ListLanguages();
            List<ObjectGrid> LG = new List<ObjectGrid>();
            foreach (var language in ls)
            {
                LG.Add(new ObjectGrid { Name = language.Name, isChecked = false });
            }
            gridMCertifica.ItemsSource = LG;
        }

        private void UpEmployee_Click(object sender, RoutedEventArgs e)
        {
            var employee = ((FrameworkElement)sender).DataContext as Employee;
            idEmployee = employee.Id;
            isUpdate = true;

            tfirstname.Text = employee.FirstName;
            tlastname.Text = employee.LastName;
            combonat.Text = employee.Nation.ToString();
            dob.SelectedDate = employee.Datebirth;
            cbgr.Text = employee.Gender;
            cbms.Text = employee.MaritalStatus;
            tcin.Text = employee.CIN;
            tEstatus.Text = employee.EpmloyeeStatus;
            combojob.Text = employee.Job.ToString();
            tadress.AppendText(employee.Adress);
            tphone.Text = employee.Phone;
            temail.Text = employee.Email;
            djoin.SelectedDate = employee.JoinDate;
            comboDepa.Text = employee.Dep.ToString();
            comboSuperV.Text = employee.Supervisor.ToString();
            combostatus.Text = employee.Stat.ToString();
            comboPay.Text = employee.pay.ToString();

            Show(SaddEmployee,SgridEmployee);
        }

        private void delEmployee_Click(object sender, RoutedEventArgs e)
        {
            var employee = ((FrameworkElement)sender).DataContext as Employee;
            ES.Delete(employee.Id);

        }

        private void SaveSkill_Click(object sender, RoutedEventArgs e)
        {
            MSkill.Visibility = Visibility.Collapsed;
        }

        private void CancelSkill_Click(object sender, RoutedEventArgs e)
        {
            MSkill.Visibility = Visibility.Collapsed;
        }
    }
}
