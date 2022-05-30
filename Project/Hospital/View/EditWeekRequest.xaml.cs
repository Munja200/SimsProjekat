using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using Controller;
using Hospital.Controller;
using Hospital.Model;
using Model;

namespace Hospital.View
{
    /// <summary>
    /// Interaction logic for EditWeekRequest.xaml
    /// </summary>
    public partial class EditWeekRequest : Window
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private WeekRequestController weekRequestController;
        private SpecialistController specialistController;
        private OperationController operationController;
        private ExaminationController examinationController;
        private WeekRequest weekRequest;
        public ObservableCollection<string> StateSS { get; set; }
        public ObservableCollection<ComboItem<Specialist>> Specialists { get; set; }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public WeekRequest WeekRequest
        {
            get { return weekRequest; }
            set
            {
                weekRequest = value;
                OnPropertyChanged(nameof(WeekRequest));
            }
        }

        public EditWeekRequest(WeekRequest weekRequest)
        {
            InitializeComponent();
            this.DataContext = this;
            App app = Application.Current as App;
            var requestW = Application.Current.Windows.OfType<ShowWeekRequest>().FirstOrDefault();
            WeekRequest = weekRequest;

            GetControllers(app);

            description.Text = weekRequest.Description;
            emergency.IsChecked = weekRequest.Emergency;

            Load();
        }

        public void GetControllers(App app)
        {
            weekRequestController = app.weekRequestController;
            specialistController = app.specialistController;
            operationController = app.operationController;
            examinationController = app.examinationController;
        }

        public void Load()
        {
            Specialists = new ObservableCollection<ComboItem<Specialist>>();
            StateSS = new ObservableCollection<string>();

            StateSS.Add("waiting");
            StateSS.Add("rejected");
            StateSS.Add("confirmed");
            state.SelectedValue = "waiting";

            GetAllSpecialists();

        }

        public void GetAllSpecialists()
        {
            foreach (Specialist specialist in specialistController.GetAll())
            {
                Specialists.Add(new ComboItem<Specialist> { Name = specialist.Speciality.ToString(), Value = specialist });
            }
        }

        private void EditButton(object sender, RoutedEventArgs e)
        {
            bool valid = true;

            if (!weekRequest.Emergency)
            {

                if (!RequestCreatedWhenOperationNoScheduled()) { valid = false; }
                if (!RequestCreatedMinTwoDaysEarlier()) { valid = false; }
                if (!RequestCreatedSameSpecialists()) { valid = false; }
                if (!RequestCreatedWhenExaminationNoScheduled()) { valid = false; }

            }

            if (valid)
            {
                weekRequestController.EditWeekRequest(weekRequest.Id, weekRequest.Specialist, weekRequest.StartTime, weekRequest.EndTime, weekRequest.Description, weekRequest.State, weekRequest.Emergency);
                this.Close();
            }

        }

        public bool RequestCreatedMinTwoDaysEarlier()
        {

            if (DateTime.Now > weekRequest.StartTime.AddDays(-2))
            {
                MessageBox.Show("The request must be submitted at least two days earlier!", "Error");
                return false;

            }
            return true;
        }

        public bool RequestCreatedWhenOperationNoScheduled()
        {

            foreach (Operation operation in operationController.GetAll())
            {
                if (operation.Specialist.CitizenId == weekRequest.Specialist.CitizenId &&
                    operation.Appointment.StartTime >= weekRequest.StartTime &&
                    operation.Appointment.EndTime <= weekRequest.EndTime)
                {
                    MessageBox.Show("The request must be submitted for days when no operations are scheduled!", "Error");
                    return false;
                }
            }
            return true;
        }

        public bool RequestCreatedWhenExaminationNoScheduled()
        {

            foreach (Examination examination in examinationController.GetAll())
            {
                if (examination.Appointment.Doctor == null)
                {
                    continue;
                }

                if (examination.Appointment.Doctor.CitizenId == weekRequest.Specialist.CitizenId &&
                     examination.Appointment.StartTime >= weekRequest.StartTime &&
                     examination.Appointment.EndTime <= weekRequest.EndTime)
                {
                    MessageBox.Show("The request must be submitted for days when no examinations are scheduled!", "Error");
                    return false;
                }
            }
            return true;
        }

        public bool RequestCreatedSameSpecialists()
        {

            int countSpecialists = CountSpecialists();
            int countSpecialistsForWeek = CountSpecialistsWeekRequests();

            if (countSpecialists == countSpecialistsForWeek)
            {
                MessageBox.Show("There must be at least one doctor of this specialty in the hospital!", "Error");
                return false;
            }
            return true;
        }

        public int CountSpecialists()
        {
            int specialistsInSystem = 0;

            foreach (Specialist spec in specialistController.GetAll())
            {
                if (spec.CitizenId != weekRequest.Specialist.CitizenId && spec.Speciality == weekRequest.Specialist.Speciality)
                {
                    specialistsInSystem++;
                }
            }

            return specialistsInSystem;
        }

        public int CountSpecialistsWeekRequests()
        {
            int specialistsForWeekRequest = 0;

            foreach (WeekRequest week in weekRequestController.GetAll())
            {
                if (week.Specialist.CitizenId != weekRequest.Specialist.CitizenId && week.Specialist.Speciality == weekRequest.Specialist.Speciality &&
                    weekRequest.StartTime >= week.StartTime && weekRequest.StartTime <= week.EndTime)
                {
                    specialistsForWeekRequest++;
                }
            }

            return specialistsForWeekRequest;
        }

        private void CancelButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }

}
