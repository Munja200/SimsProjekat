using System.Windows;
using Hospital.Controller;
using Hospital.View;
using Model;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LogInController logInController;

        public MainWindow()
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
            else
            {
                valid.Visibility = Visibility.Hidden;
                app.Password = app.Employee.Password;
                app.Username = app.Employee.Username;
                if (app.Employee.role.Equals(EmployeeRole.doctor))
                {
                    new IntroductionDoctor().Show();
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
