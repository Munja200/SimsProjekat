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
        public Employee employee; 
        public string password;
        public string username;

        public LogIn()
        {
            InitializeComponent();
            this.DataContext = this;
            App app = Application.Current as App;
            logInController = app.logInController;
            employee = null;
            password = null;
            username = null;
        }

        public void LogIn_Click(object sender, RoutedEventArgs e)
        {
            employee = logInController.LogIn(usernamee.Text, passwordd.Password);

        }
    }
}
