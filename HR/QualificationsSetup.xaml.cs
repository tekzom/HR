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
        bool isUpdate = false;
        int idskill, ideducation, idcertifica, idlanguage;
        List<Skill> SL = new List<Skill>();
        List<Education> EL = new List<Education>();
        List<Certification> CL = new List<Certification>();
        List<Language> LL = new List<Language>();
        SkillsServices SS = new SkillsServices();
        EducationServices ES = new EducationServices();
        CertificationsServices CS = new CertificationsServices();
        LanguagesServices LS = new LanguagesServices();

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

        public void Show(ScrollViewer show, ScrollViewer hide)
        {
            show.Visibility = Visibility.Visible;
            hide.Visibility = Visibility.Collapsed;
        }

        ///////////////////// Skill /////////////////////////////////

        private void baddSkill_Click(object sender, RoutedEventArgs e)
        {
            Show(SaddSkill,SgridSkill);
        }

        private void bcancelS_Click(object sender, RoutedEventArgs e)
        {
            Show(SgridSkill, SaddSkill);
        }

        private void BsaveS_Click(object sender, RoutedEventArgs e)
        {
            if (!isUpdate)
            {
                SS.Add(
                    new Skill
                    {
                        Name = tnameS.Text,
                        Description = Gets(tdesS),
                   }
               );

            }
            else
            {
                SS.Update(new Skill
                {
                    Id = idskill,
                    Name = tnameS.Text,
                    Description = Gets(tdesS),
                });
                isUpdate = false;
            }
            tdesS.Document.Blocks.Clear();
            SL.Clear();
            SL = SS.ListSkills();
            gridSkill.ItemsSource = SL;
            Show(SgridSkill, SaddSkill);
        }

        private void upskill_Click(object sender, RoutedEventArgs e)
        {
            var skill = ((FrameworkElement)sender).DataContext as Skill;
            idskill = skill.Id;
            isUpdate = true;
            tnameS.Text = skill.Name;
            tdesS.AppendText(skill.Description);
            Show(SaddSkill, SgridSkill);
        }

        private void delskill_Click(object sender, RoutedEventArgs e)
        {
            var skill = ((FrameworkElement)sender).DataContext as Skill;
            SS.Delete(skill.Id);
        }

        ///////////////////// Education /////////////////////////////////

        private void baddEdu_Click(object sender, RoutedEventArgs e)
        {
            Show(SaddEduc, SgridEdu);
        }

        private void bcancelEdu_Click(object sender, RoutedEventArgs e)
        {
            Show(SgridEdu, SaddEduc);

        }

        private void delEdu_Click(object sender, RoutedEventArgs e)
        {
            var education = ((FrameworkElement)sender).DataContext as Education;
            ES.Delete(education.Id);
        }

        private void upEdu_Click(object sender, RoutedEventArgs e)
        {
            var education = ((FrameworkElement)sender).DataContext as Education;
            ideducation = education.Id;
            isUpdate = true;
            tnameEdu.Text = education.Name;
            tdesEdu.AppendText(education.Description);
            Show(SaddEduc, SgridEdu);
        }

        private void BsaveEdu_Click(object sender, RoutedEventArgs e)
        {
            if (!isUpdate)
            {
                ES.Add(
                    new Education
                    {
                        Name = tnameEdu.Text,
                        Description = Gets(tdesEdu),
                    }
               );

            }
            else
            {
                ES.Update(new Education
                {
                     Id= ideducation,
                    Name = tnameEdu.Text,
                    Description = Gets(tdesEdu),
                });
                isUpdate = false;
            }
            tdesEdu.Document.Blocks.Clear();
            EL.Clear();
            EL = ES.ListEducations();
            gridEdu.ItemsSource = EL;
            Show(SgridEdu, SaddEduc);
        }

        ///////////////////// Certifications /////////////////////////////////

        private void baddCer_Click(object sender, RoutedEventArgs e)
        {
            Show(SaddCer, SgridCer);
        }

        private void bcancelCer_Click(object sender, RoutedEventArgs e)
        {
            Show(SgridCer, SaddCer);
        }

        private void BsaveCer_Click(object sender, RoutedEventArgs e)
        {
            if (!isUpdate)
            {
                CS.Add(
                    new Certification
                    {
                        Name = tnameCer.Text,
                        Description = Gets(tdesCer),
                    }
               );

            }
            else
            {
                CS.Update(new Certification
                {
                    Id = idcertifica,
                    Name = tnameCer.Text,
                    Description = Gets(tdesCer),
                });
                isUpdate = false;
            }
            tdesCer.Document.Blocks.Clear();
            CL.Clear();
            CL = CS.ListCertifications();
            gridCer.ItemsSource = CL;
            Show(SgridCer, SaddCer);
        }

        private void delcer_Click(object sender, RoutedEventArgs e)
        {
            var certifica = ((FrameworkElement)sender).DataContext as Certification;
            CS.Delete(certifica.Id);
        }

        private void upcer_Click(object sender, RoutedEventArgs e)
        {
            var certifica = ((FrameworkElement)sender).DataContext as Certification;
            idcertifica = certifica.Id;
            isUpdate = true;
            tnameCer.Text = certifica.Name;
            tdesCer.AppendText(certifica.Description);
            Show(SaddCer, SgridCer);
        }

        ///////////////////// Language /////////////////////////////////


        private void baddLan_Click(object sender, RoutedEventArgs e)
        {
            Show(SaddLan, SgridLan);
        }

        private void bcancelLan_Click(object sender, RoutedEventArgs e)
        {
            Show(SgridLan, SaddLan);
        }

        private void dellang_Click(object sender, RoutedEventArgs e)
        {
            var language = ((FrameworkElement)sender).DataContext as Language;
            LS.Delete(language.Id);
        }

        private void uplang_Click(object sender, RoutedEventArgs e)
        {
            var language = ((FrameworkElement)sender).DataContext as Language;
            idlanguage = language.Id;
            isUpdate = true;
            tnameLan.Text = language.Name;
            tdesLan.AppendText(language.Description);
            Show(SaddLan, SgridLan);
        }

        private void BsaveLan_Click(object sender, RoutedEventArgs e)
        {

            if (!isUpdate)
            {
                LS.Add(
                    new Language
                    {
                        Name = tnameEdu.Text,
                        Description = Gets(tdesLan),
                    }
               );

            }
            else
            {
                LS.Update(new Language
                {
                    Id = idlanguage,
                    Name = tnameEdu.Text,
                    Description = Gets(tdesLan),
                });
                isUpdate = false;
            }
            tdesLan.Document.Blocks.Clear();
            LL.Clear();
            LL = LS.ListLanguages();
            gridLan.ItemsSource = LL;
            Show(SgridLan, SaddLan);
        }
        
    }
}
