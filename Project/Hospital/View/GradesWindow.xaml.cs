using Hospital.Controller;
using Hospital.Model;
using Model;
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

namespace Hospital.View
{
    /// <summary>
    /// Interaction logic for GradesWindow.xaml
    /// </summary>
    public partial class GradesWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<Results> results;
        private QuestionController questionController;
        private EmployeeController employeeController;
        private String doctorSurname;
        private String doctorName;
        private float totalGrade;
        public ObservableCollection<string> ShowType { get; set; }

        public GradesWindow()
        {
            InitializeComponent();
            App app = Application.Current as App;

            results = new ObservableCollection<Results>();
            questionController = app.questionController;
            employeeController = app.employeeController;
            //Employee employee = employeeController.GetById(2);
            //if (employee != null)
            foreach (Results result in questionController.GetResultsForHospital()) results.Add(result); 

            dataGridInvalidDrug.ItemsSource = results;
            total.Content = questionController.GetTotalGrade(results.ToList());
            ShowType = new ObservableCollection<string>();
            ShowType.Add("Bolnica");
            ShowType.Add("Doktori");
            DoctorsOrHospital.ItemsSource = ShowType;
            DoctorsOrHospital.SelectedValue = "Bolnica";
            Doctors.ItemsSource = employeeController.GetAll();
            Doctors.Visibility = Visibility.Hidden;
        }

        public String DoctorSurname
        {
            get => doctorSurname;
            set
            {
                if (doctorSurname != value)
                {
                    doctorSurname = value;
                    OnPropertyChanged();
                }
            }
        }


        public String DoctorName
        {
            get => doctorName;
            set
            {
                if (doctorName != value)
                {
                    doctorName = value;
                    OnPropertyChanged();
                }
            }
        }
        public float TotalGrade
        {
            get => totalGrade;
            set
            {
                if (totalGrade != value)
                {
                    totalGrade = value;
                    OnPropertyChanged();
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void DoctorsSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Employee employee = employeeController.GetById((int)Doctors.SelectedValue);
            if (employee != null)
            {
                results.Clear();
                foreach (Results result in questionController.GetResultsForOneEmployee(employee)) results.Add(result);
                total.Content = questionController.GetTotalGrade(results.ToList());
            }
        }

        private void DoctorsOrHospitalSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String type = (string) DoctorsOrHospital.SelectedValue;
            if (type == "Doktori") {
                Doctors.Visibility = Visibility.Visible;
            }
            else {
                Doctors.Visibility = Visibility.Hidden;
            }

        }
    }
}
