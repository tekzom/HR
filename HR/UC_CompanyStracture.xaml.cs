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
    /// Interaction logic for UC_CompanyStracture.xaml
    /// </summary>
    public partial class UC_CompanyStracture : UserControl
    {
        DepatementsServices Ds = new DepatementsServices();
        NationalitiesServices Ns = new NationalitiesServices();
        List<Departement> LD = new List<Departement>();
        List<Nationality> LN = new List<Nationality>();
        public UC_CompanyStracture()
        {
            InitializeComponent();

            LD = Ds.ListDepartements();
            dgCompany.ItemsSource = LD;
            //comboparent
            cbParent.ItemsSource = LD;
            cbParent.DisplayMemberPath = "Name";
            cbParent.SelectedValuePath = "Id";

            //combocontry

            LN = Ns.ListNationalities();
            cbContry.ItemsSource = LN;
            cbContry.DisplayMemberPath = "Name";
            cbContry.SelectedValuePath = "Id";


            Scompany.Visibility = Visibility.Visible;
            Sadd.Visibility = Visibility.Collapsed;
        }

        private void Badd_Click(object sender, RoutedEventArgs e)
        {
            Scompany.Visibility = Visibility.Collapsed;
            Sadd.Visibility = Visibility.Visible;
        }

        private void bcancel_Click(object sender, RoutedEventArgs e)
        {
            Scompany.Visibility = Visibility.Visible;
            Sadd.Visibility = Visibility.Collapsed;
        }
        string gets(RichTextBox rtb)
        {
            return new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd).Text;
        }

        private void bsave_Click(object sender, RoutedEventArgs e)
        {
            Ds.Add(
                    new Departement
                    {
                        Name = tName.Text,
                        Adress = gets(tbAddress),
                        Type = cbType.Text,
                        Contry = Ns.FindExisting((int)cbContry.SelectedValue),
                        ParentDepartment = Ds.FindExisting((int)cbParent.SelectedValue),
                    }
                );
            Scompany.Visibility = Visibility.Visible;
            Sadd.Visibility = Visibility.Collapsed;
        }
    }
}
