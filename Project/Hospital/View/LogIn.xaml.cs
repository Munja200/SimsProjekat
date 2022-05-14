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
using Hospital.Controller;
using Model;

namespace Hospital.View
{
    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        private LogInController logInController;
        public LogIn()
        {
            InitializeComponent();
            this.DataContext = this;
            App app = Application.Current as App;
            logInController = app.logInController;
            app.Employee = null;
            app.Password = null;
            app.Username = null;
        }

        public void LogIn_Click(object sender, RoutedEventArgs e)
        {
            App app = Application.Current as App;
            app.Employee = logInController.LogIn(usernamee.Text, passwordd.Password);
            if (app.Employee == null)
            {
                valid.Content = "Incorrect username or password";
                valid.Visibility = Visibility.Visible;
            }
            else {
                valid.Visibility = Visibility.Hidden;
                app.Password = app.Employee.Password;
                app.Username = app.Employee.Username;
                if (app.Employee.role.Equals(EmployeeRole.doctor))
                {
                    new MainWindow().Show();
                    this.Close();
                }
                else
                {
                    new DirectorRoomWindow().Show();
                    this.Close();
                }
            }
        }
    }
}
