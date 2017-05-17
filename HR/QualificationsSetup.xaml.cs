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

namespace HR
{
    /// <summary>
    /// Interaction logic for QualificationsSetup.xaml
    /// </summary>
    public partial class QualificationsSetup : UserControl
    {
        
        List<Skill> SL = new List<Skill>();
        List<Education> EL = new List<Education>();
        List<Certification> CL = new List<Certification>();
        List<Language> LL = new List<Language>();

        string Gets(RichTextBox rtb)
        {
            return new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd).Text;
        }
        
        public QualificationsSetup()
        {
            InitializeComponent();
            SL = new SkillsServices().ListSkills();
            gridSkill.ItemsSource = SL;
            EL = new EducationServices().ListEducations();
            gridEdu.ItemsSource = EL;
            CL = new CertificationsServices().ListCertifications();
            gridCer.ItemsSource = CL;
            LL = new LanguagesServices().ListLanguages();
            gridLan.ItemsSource = LL;
        }
    }
}
