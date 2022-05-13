using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
        private WeekRequestController weekRequestController;
        private SpecialistController specialistController;
        private OperationController operationController;
        private ExaminationController examinationController;
        private WeekRequest weekRequest;
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<string> StateSS { get; set; }
        public ObservableCollection<ComboItem<Specialist>> Specialists { get; set; }

        public WeekRequest WeekRequest
        {
            get { return weekRequest; }
            set
            {
                weekRequest = value;
                OnPropertyChanged(nameof(WeekRequest));
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public EditWeekRequest(WeekRequest weekRequest)
        {
            InitializeComponent();
            this.DataContext = this;
            App app = Application.Current as App;
            var requestW = Application.Current.Windows.OfType<ShowWeekRequest>().FirstOrDefault();
            WeekRequest = weekRequest;

            weekRequestController = app.weekRequestController;
            specialistController = app.specialistController;
            operationController = app.operationController;
            examinationController = app.examinationController;    


            description.Text = weekRequest.Description;
            emergency.IsChecked = weekRequest.Emergency;

            Load();
        }

        public void Load()
        {
            Specialists = new ObservableCollection<ComboItem<Specialist>>();
            StateSS = new ObservableCollection<string>();

            StateSS.Add("waiting");
            StateSS.Add("rejected");
            StateSS.Add("confirmed");
            state.SelectedValue = "waiting";

            foreach (Specialist specialist in specialistController.GetAll())
            {
                Specialists.Add(new ComboItem<Specialist> { Name = specialist.Speciality.ToString(), Value = specialist });
            }

        }

        private void EditButton(object sender, RoutedEventArgs e)
        {
            // bool canAdd = true;
            bool valid = true;


            //ako zahtev nije hitan
            if (!weekRequest.Emergency)
            {

                if (!RequestCreatedWhenOperationNoScheduled()) { valid = false; }
                if (!RequestCreatedMinTwoDaysEarlier()) { valid = false; }
                if (!RequestCreatedSameSpecialists()) { valid = false; }
                if (!RequestCreatedWhenExaminationNoScheduled()) { valid = false; }

            }
            //ako je zahtev hitan onda ga kreiraj odmah bez obzira na sva ogranicenja

            if (valid)
            {
                weekRequestController.EditWeekRequest(weekRequest.Id, weekRequest.Specialist, weekRequest.StartTime, weekRequest.EndTime, weekRequest.Description, weekRequest.State, weekRequest.Emergency);
                this.Close();
            }
          
        }

        public bool RequestCreatedMinTwoDaysEarlier()
        {

            //dva dana ranije
            if (DateTime.Now > weekRequest.StartTime.AddDays(-2))
            {
                MessageBox.Show("The request must be submitted at least two days earlier!", "Error");
                return false;

            }
            return true;
        }

        public bool RequestCreatedWhenOperationNoScheduled()
        {

            //za termine zakazanih operacija
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

            //za termine zakazanih pregleda
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

            // da postoji barem jedan specijalista jedne specijalnosti
            int specCount = 0;
            int specCountWeek = 0;

            foreach (Specialist spec in specialistController.GetAll())
            {
                if (spec.CitizenId != weekRequest.Specialist.CitizenId && spec.Speciality == weekRequest.Specialist.Speciality)
                {
                    specCount++;
                }
            }

            foreach (WeekRequest week in weekRequestController.GetAll())
            {
                if (week.Specialist.CitizenId != weekRequest.Specialist.CitizenId && week.Specialist.Speciality == weekRequest.Specialist.Speciality &&
                    weekRequest.StartTime >= week.StartTime && weekRequest.StartTime <= week.EndTime)
                {
                    specCountWeek++;
                }
            }

            if (specCount == specCountWeek)
            {
                MessageBox.Show("There must be at least one doctor of this specialty in the hospital!", "Error");
                return false;
            }

            return true;

        }


        private void CancelButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }

}
