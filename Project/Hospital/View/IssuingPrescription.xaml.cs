using System;
using System.Collections.Generic;
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
using Hospital.Controller;
using Model;

namespace Hospital.View
{
    /// <summary>
    /// Interaction logic for IssuingPrescription.xaml
    /// </summary>
    public partial class IssuingPrescription : Window
    {
        private ExaminationController examinationController;
        private Examination examination;
        public event PropertyChangedEventHandler PropertyChanged;


        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public IssuingPrescription(Examination examination)
        {
            InitializeComponent();
            this.DataContext = this;
            App app = Application.Current as App;
            var examinationW = Application.Current.Windows.OfType<ShowExamination>().FirstOrDefault();
            Examination = examination;
            examinationController = app.examinationController;

        }

        private void SubmitButton(object sender, RoutedEventArgs e)
        {
            var examinationW = Application.Current.Windows.OfType<ShowExamination>().FirstOrDefault();
            Examination examination = (Examination)examinationW.dataGridExaminations.SelectedItem;

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
