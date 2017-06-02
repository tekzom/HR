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



    public partial class Employees : UserControl
    {
        ///////////////////////// Employee de Info //////////////////
        private Employee _Employee { get; set; }
        ////////////////////////  Skill Chekbox /////////////////////
        private bool IsLoading { get; set; }



        //private void FillGrid()
        //{
        //    List<Skill> lSkills = new SkillsServices().ListSkills();
        //    List<Skill> Semployee = _Employee.Skills;
        //    List<ObjectGrid> LG = new List<ObjectGrid>();
        //    bool verf = false;
        //    foreach (var skill in lSkills)
        //    {
        //        foreach (var eSkill in Semployee)
        //        {
        //            if(skill.Id == eSkill.Id)
        //            {
        //                verf = true;
        //                break;
        //            }
        //        }
        //        if(verf)
        //            LG.Add(new ObjectGrid { Name = skill.Name, isChecked = true });
        //        else
        //            LG.Add(new ObjectGrid { Name = skill.Name, isChecked = false });  
        //    }
        //    gridMSkill.ItemsSource = LG;
        //}




        bool isUpdate = false;
        int idEmployee;

        List<Employee> EL = new List<Employee>();
        EmployeesServices ES = new EmployeesServices();
        List<Status> SL = new List<Status>();
        StatusServices SS = new StatusServices();
        SkillsServices SkillS = new SkillsServices();
        EducationServices EduS = new EducationServices();
        CertificationsServices CS = new CertificationsServices();
        LanguagesServices LS = new LanguagesServices();
        List<Nationality> NL = new List<Nationality>();
        NationalitiesServices NS = new NationalitiesServices();
        List<Job> JL = new List<Job>();
        JobsServices JS = new JobsServices();
        List<Departement> DL = new List<Departement>();
        DepatementsServices DS = new DepatementsServices();
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

            ///// combo Paygrid
            PL = PS.ListPaygrades();
            comboPay.ItemsSource = PL;
            comboPay.DisplayMemberPath = "Name";
            comboPay.SelectedValuePath = "Code";

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
                    new Employee
                    {
                        Id = idEmployee,
                        FirstName = tfirstname.Text,
                        LastName = tlastname.Text,
                        Nation = NS.FindExisting((int)combonat.SelectedValue),
                        Datebirth = dob.SelectedDate.Value.Date,
                        Gender = cbgr.Text,
                        MaritalStatus = cbms.Text,
                        CIN = tcin.Text,
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

        private void ClearInputs()
        {
            tfirstname.Clear();
            tlastname.Clear();
            combonat.SelectedIndex = -1;
            dob.SelectedDate = DateTime.Now;
            cbgr.SelectedIndex = -1;
            cbms.SelectedIndex = -1;
            tcin.Clear();
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


        private void btInfo_Click(object sender, RoutedEventArgs e)
        {
            var Emp = ((FrameworkElement)sender).DataContext as Employee;
            _Employee = ES.FindExisting(Emp.Id);
            gridSkill.ItemsSource = _Employee.Skills;
            gridCer.ItemsSource = _Employee.Certifications;
            gridEdu.ItemsSource = _Employee.Educations;
            gridLan.ItemsSource = _Employee.Languages;
            Employee.Visibility = Visibility.Collapsed;
            TabMain.SelectedIndex = 1;
            Skills.Visibility = Visibility.Visible;
            Education.Visibility = Visibility.Visible;
            Languages.Visibility = Visibility.Visible;
            Certification.Visibility = Visibility.Visible;

        }

         //////////////////// SKill /////////////////////////////

        private void btManageSkill_Click(object sender, RoutedEventArgs e)
        {
            IsLoading = true;
            MSkill.Visibility = Visibility.Visible;

            List<Skill> lSkills = new SkillsServices().ListSkills();
            List<Skill> Semployee = _Employee.Skills;
            List<ObjectGrid> LG = new List<ObjectGrid>();
            bool verf = false;
            foreach (var skill in lSkills)
            {
                foreach (var eSkill in Semployee)
                {
                    if (skill.Id == eSkill.Id)
                    {
                        verf = true;
                        break;
                    }
                }
                if (verf)
                    LG.Add(new ObjectGrid { IdO = skill.Id, Name = skill.Name, isChecked = true });
                else
                    LG.Add(new ObjectGrid { IdO = skill.Id, Name = skill.Name, isChecked = false });
                verf = false;
            }
            gridMSkill.ItemsSource = LG;
            IsLoading = false;
        }

        private void Check_Checked(object sender, RoutedEventArgs e)
        {
            var Obj = gridMSkill.CurrentItem as ObjectGrid;
            if (Obj != null)
            {
                var Skill = SkillS.FindExisting(Obj.IdO);
                _Employee.Skills.Add(Skill);
            }
        }
        
        private void Check_Unchecked(object sender, RoutedEventArgs e)
        {
            var Obj = gridMSkill.CurrentItem as ObjectGrid;
            if (Obj != null)
            {
                var Skill = SkillS.FindExisting(Obj.IdO);
                _Employee.Skills.Remove(Skill);
                
            }
        }

        private void SaveSkill_Click(object sender, RoutedEventArgs e)
        {
            gridSkill.ItemsSource = null;
            gridSkill.ItemsSource = _Employee.Skills;
            DataBaseService.SaveChanges();
        }

        private void CancelSkill_Click(object sender, RoutedEventArgs e)
        {
            MSkill.Visibility = Visibility.Collapsed;
        }

        //////////////////// Education /////////////////////////////

        private void btManageEducation_Click(object sender, RoutedEventArgs e)
        {
            IsLoading = true;
            SMEducation.Visibility = Visibility.Visible;

            List<Education> leducation = new EducationServices().ListEducations();
            List<Education> Eemployee = _Employee.Educations;
            List<ObjectGrid> LG = new List<ObjectGrid>();
            bool verf = false;
            foreach (var education in leducation)
            {
                foreach (var eEducation in Eemployee)
                {
                    if (education.Id == eEducation.Id)
                    {
                        verf = true;
                        break;
                    }
                }
                if (verf)
                    LG.Add(new ObjectGrid { IdO = education.Id, Name = education.Name, isChecked = true });
                else
                    LG.Add(new ObjectGrid { IdO = education.Id, Name = education.Name, isChecked = false });
                verf = false;
            }
            gridMEducation.ItemsSource = LG;
            IsLoading = true;

        }

        private void ECheck_Checked(object sender, RoutedEventArgs e)
        {
            var Obj = gridMEducation.CurrentItem as ObjectGrid;
            if (Obj != null)
            {
                var education = EduS.FindExisting(Obj.IdO);
                _Employee.Educations.Add(education);
            }
        }

        private void ECheck_Unchecked(object sender, RoutedEventArgs e)
        {
            var Obj = gridMEducation.CurrentItem as ObjectGrid;
            if (Obj != null)
            {
                var education = EduS.FindExisting(Obj.IdO);
                _Employee.Educations.Remove(education);
            }
        }

        private void SaveEducation_Click(object sender, RoutedEventArgs e)
        {
            gridEdu.ItemsSource = null;
            gridEdu.ItemsSource = _Employee.Educations;
            DataBaseService.SaveChanges();
        }

        //////////////////// Certification /////////////////////////////

        private void btManageCertification_Click(object sender, RoutedEventArgs e)
        {

            SMCertifica.Visibility = Visibility.Visible;

            List<Certification> lCertification = new CertificationsServices().ListCertifications();
            List<Certification> Cemployee = _Employee.Certifications;
            List<ObjectGrid> LG = new List<ObjectGrid>();
            bool verf = false;
            foreach (var Certification in lCertification)
            {
                foreach (var eCertification in Cemployee)
                {
                    if (Certification.Id == eCertification.Id)
                    {
                        verf = true;
                        break;
                    }
                }
                if (verf)
                    LG.Add(new ObjectGrid { IdO = Certification.Id, Name = Certification.Name, isChecked = true });
                else
                    LG.Add(new ObjectGrid { IdO = Certification.Id, Name = Certification.Name, isChecked = false });
                verf = false;
            }
            gridMCertifica.ItemsSource = LG;

        }

        private void CCheck_Checked(object sender, RoutedEventArgs e)
        {
            var Obj = gridMCertifica.CurrentItem as ObjectGrid;
            if (Obj != null)
            {
                var certifica = CS.FindExisting(Obj.IdO);
                _Employee.Certifications.Add(certifica);
            }
        }

        private void CCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            var Obj = gridMCertifica.CurrentItem as ObjectGrid;
            if (Obj != null)
            {
                var certifica = CS.FindExisting(Obj.IdO);
                _Employee.Certifications.Remove(certifica);
            }
        }
        //////////////////// Language /////////////////////////////

        private void btManageLanguages_Click(object sender, RoutedEventArgs e)
        {
            SMLanguage.Visibility = Visibility.Visible;

            List<Language> lLanguage = new LanguagesServices().ListLanguages();
            List<Language> Lemployee = _Employee.Languages;
            List<ObjectGrid> LG = new List<ObjectGrid>();
            bool verf = false;
            foreach (var language in lLanguage)
            {
                foreach (var eLanguage in Lemployee)
                {
                    if (language.Id == eLanguage.Id)
                    {
                        verf = true;
                        break;
                    }
                }
                if (verf)
                    LG.Add(new ObjectGrid { IdO = language.Id, Name = language.Name, isChecked = true });
                else
                    LG.Add(new ObjectGrid { IdO = language.Id, Name = language.Name, isChecked = false });
                verf = false;
            }
            gridMLanguage.ItemsSource = LG;
        }

        private void LCheck_Checked(object sender, RoutedEventArgs e)
        {
            var Obj = gridMLanguage.CurrentItem as ObjectGrid;
            if (Obj != null)
            {
                var language = LS.FindExisting(Obj.IdO);
                _Employee.Languages.Add(language);
            }
        }

        private void LCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            var Obj = gridMLanguage.CurrentItem as ObjectGrid;
            if (Obj != null)
            {
                var language = LS.FindExisting(Obj.IdO);
                _Employee.Languages.Remove(language);
            }
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
            combojob.Text = employee.Job.ToString();
            tadress.AppendText(employee.Adress);
            tphone.Text = employee.Phone;
            temail.Text = employee.Email;
            djoin.SelectedDate = employee.JoinDate;
            comboDepa.Text = employee.Dep.ToString();
            comboSuperV.Text = employee.Supervisor.ToString();
            combostatus.Text = employee.Stat.ToString();
            comboPay.Text = employee.pay.ToString();

            Show(SaddEmployee, SgridEmployee);
        }

        private void delEmployee_Click(object sender, RoutedEventArgs e)
        {
            var employee = ((FrameworkElement)sender).DataContext as Employee;
            ES.Delete(employee.Id);

        }
        
        private void SaveCertifica_Click(object sender, RoutedEventArgs e)
        {
            gridCer.ItemsSource = null;
            gridCer.ItemsSource = _Employee.Certifications;
            DataBaseService.SaveChanges();
        }

        private void SaveLanguage_Click(object sender, RoutedEventArgs e)
        {
            gridLan.ItemsSource = null;
            gridLan.ItemsSource = _Employee.Languages;
            DataBaseService.SaveChanges();
        }




    }
}
