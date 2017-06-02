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
using System.Windows.Shapes;
using HR.Managment;
using HR.Json;
using System.IO;
using Newtonsoft.Json;

namespace HR
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        Option option = new Option();
        public LoginPage()
        {
            InitializeComponent();

            // deserialize JSON directly from a file
            using (StreamReader file = File.OpenText(@"Option.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                option = (Option)serializer.Deserialize(file, typeof(Option));
            }
        }


        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var s = value as string;
            return string.IsNullOrEmpty(s);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Tuser.Text != "")
                Luser.Visibility = Visibility.Collapsed;
            else Luser.Visibility = Visibility.Visible;
        }



        private void Tpass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            

            if (Tpass.Password != "")
                Lpass.Visibility = Visibility.Collapsed;
            else Lpass.Visibility = Visibility.Visible;
        }

        private void bLogin_Click(object sender, RoutedEventArgs e)
        {
            EmployeesServices ES = new EmployeesServices();

            errorPass.Visibility = Visibility.Collapsed;
            errorUser.Visibility = Visibility.Collapsed;

            if (option.AutoSave && option.username == Tuser.Text)
            {
                Menu M = new Menu();
                this.Hide();
                M.Show();
            }
            else
            {
                if (ES.FindUser(Tuser.Text))
                    if (ES.FindPass(Tuser.Text, Tpass.Password))
                    {
                        if ((bool)SavePassword.IsChecked)
                        {
                            option.AutoSave = true;
                            option.username = Tuser.Text;
                            option.Password = Tpass.Password;
                        }
                        Menu M = new Menu();
                        this.Hide();
                        M.Show();
                    }
                    else
                        errorPass.Visibility = Visibility.Visible;
                else
                    errorUser.Visibility = Visibility.Visible;

                using (StreamWriter file = File.CreateText(@"Option.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, option);
                }
            }
            

            

        }

        private void Tpass_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
