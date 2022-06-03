using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Hospital.Controller;
using Hospital.Model;
using Model;

namespace Hospital.View
{
    /// <summary>
    /// Interaction logic for WeekRequest.xaml
    /// </summary>
    public partial class ShowWeekRequest : Window
    {
        private WeekRequestController weekRequestController;
        private SpecialistController specialistController;
        public ObservableCollection<WeekRequest> weekRequests;

        public ObservableCollection<ComboItem<Specialist>> Specialists { get; set; }

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
            weekRequests = new ObservableCollection<WeekRequest>(list);

            Specialists = new ObservableCollection<ComboItem<Specialist>>();
            dataGridRequest.ItemsSource = weekRequests;

            GetAllSpecialists();
        }

        
        public void GetAllSpecialists()
        {
            foreach (Specialist specialist in specialistController.GetAll())
            {
                Specialists.Add(new ComboItem<Specialist> { Name =specialist.Name.ToString() + ", " + specialist.Speciality.ToString(),
                    CitizenId = specialist.CitizenId,  Value = specialist });
            }
        }

        private void ImageLoupe(object sender, RoutedEventArgs e)
        {
            ComboItem<Specialist> specialistId = (ComboItem<Specialist>)idSpecialists.SelectedItem;
            int id = specialistId.CitizenId;

            weekRequests.Clear();

            foreach (WeekRequest weekRequest in weekRequestController.GetBySpecialistsCitizenId(id))
            {
                weekRequests.Add(weekRequest);
            }
            return;

        }

        private void ImageReset(object sender, RoutedEventArgs e)
        {
            List<WeekRequest> list = weekRequestController.GetAll();
            weekRequests = new ObservableCollection<WeekRequest>(list);
            dataGridRequest.ItemsSource = weekRequests;
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

        private void Back(object sender, RoutedEventArgs e)
        {
            new HomeDoctor().Show();
            this.Close();
        }

    }
}
