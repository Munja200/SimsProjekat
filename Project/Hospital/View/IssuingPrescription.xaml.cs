using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
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
using Hospital.Model;
using Model;

namespace Hospital.View
{
    /// <summary>
    /// Interaction logic for IssuingPrescription.xaml
    /// </summary>
    public partial class IssuingPrescription : Window
    {
        private ExaminationController examinationController;
        private DrugController drugController;
        private Examination examination;
        public event PropertyChangedEventHandler PropertyChanged;
        private Prescription prescription;

        public Prescription Prescription 
        {
            get { return prescription; }
            set 
            {
                prescription = value;
                OnPropertyChanged(nameof(Prescription));
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public IssuingPrescription(Examination examination)
        {
            InitializeComponent();
            Prescription = new Prescription();
            this.DataContext = this;
            App app = Application.Current as App;
            var examinationW = Application.Current.Windows.OfType<ShowExamination>().FirstOrDefault();
            Examination = examination;
            examinationController = app.examinationController;
            drugController = app.drugController;
            Load();

        }

        public ObservableCollection<ComboItem<Drug>> Drugs { get; set; }
        public void Load()
        {
            Drugs = new ObservableCollection<ComboItem<Drug>>();
           
           foreach (Drug drug in drugController.GetAll())
            {
                Drugs.Add(new ComboItem<Drug> { Name = drug.Name, Value = drug });
            }
 

        }

        private void SubmitButton(object sender, RoutedEventArgs e)
        {
            var examinationW = Application.Current.Windows.OfType<ShowExamination>().FirstOrDefault();
            Examination examination = (Examination)examinationW.dataGridExaminations.SelectedItem;
            examination.Prescription = prescription;

            Regex agePattern = new Regex(@"^[1-9][0-9]?$"); // Age entered must be numeric characters only (0-9) and may only be two charaters long

            if (agePattern.IsMatch(frequency.Text) == false)
            {
                MessageBox.Show("Frequency must be in numeric format "); 
                return;
            }

            if (agePattern.IsMatch(interval.Text) == false)
            {
                MessageBox.Show("Frequency must be in numeric format ");
                return;
            }

            if (agePattern.IsMatch(duration.Text) == false)
            {
                MessageBox.Show("Frequency must be in numeric format ");
                return;
            }

            examinationController.EditExamination(examination.Id, examination.Appointment, examination.Report, examination.Prescription);
            this.Close();

        }

        public Examination Examination
        {
            get { return examination; }
            set
            {
                examination = value;
                OnPropertyChanged(nameof(Examination));
            }
        }
        
        private void CencelButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
    }
}
