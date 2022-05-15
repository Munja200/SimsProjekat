using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Hospital.Controller;
using Hospital.Model;

namespace Hospital.View
{
    /// <summary>
    /// Interaction logic for WeekRequest.xaml
    /// </summary>
    public partial class ShowWeekRequest : Window
    {
        private WeekRequestController weekRequestController;
        private SpecialistController specialistController;

        public ShowWeekRequest()
        {
            InitializeComponent();
            this.DataContext = this;
            App app = Application.Current as App;

            weekRequestController = app.weekRequestController;
            specialistController = app.specialistController;

            Load();
        }
        public void Load()
        {
            List<WeekRequest> list = weekRequestController.GetAll();
            ObservableCollection<WeekRequest> collection = new ObservableCollection<WeekRequest>(list);
            dataGridRequest.ItemsSource = collection;
        }

        private void Click_Create(object sender, RoutedEventArgs e)
        {
            new CreateWeekRequest().ShowDialog();
            Load();
        }

        private void Click_Delete(object sender, RoutedEventArgs e)
        {
            var viewRequestsWindow = Application.Current.Windows.OfType<ShowWeekRequest>().FirstOrDefault();
            WeekRequest weekRequest = (WeekRequest)viewRequestsWindow.dataGridRequest.SelectedItem;

            if (weekRequest != null)
                weekRequestController.DeleteWeekRequest(weekRequest.Id);
            Load();
        }

        private void Click_Edit(object sender, RoutedEventArgs e)
        {
            var viewRequestsWindow = Application.Current.Windows.OfType<ShowWeekRequest>().FirstOrDefault();
            WeekRequest weekRequest = (WeekRequest)viewRequestsWindow.dataGridRequest.SelectedItem;

            if (weekRequest != null)
                new EditWeekRequest(weekRequest).ShowDialog();
        }

        private void Click_Reject(object sender, RoutedEventArgs e)
        {
            //new DoctorAddOperation().ShowDialog();
            Load();
        }

        private void Click_Approve(object sender, RoutedEventArgs e)
        {
            //new DoctorAddOperation().ShowDialog();
            Load();
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            new HomeDoctor().Show();
            this.Close();
        }


    }
}
