using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using Hospital.Controller;
using Hospital.Model;
using Model;

namespace Hospital.View
{
    /// <summary>
    /// Interaction logic for ExaminationEditReport.xaml
    /// </summary>
    public partial class ExaminationEditReport : Window
    {
        private ExaminationController examinationController;
        private Report report;

        private Examination examination;
        public event PropertyChangedEventHandler PropertyChanged;


        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public ExaminationEditReport(Examination examination)
        {
            InitializeComponent();
            this.DataContext = this;
            report = new Report();
            App app = Application.Current as App;
            var examinationW = Application.Current.Windows.OfType<ShowExamination>().FirstOrDefault();
            Examination = examination;

            descriptionO.Text = examination.Report.Description;
            writtenO.IsChecked = examination.Report.Written;
            examinationController = app.examinationController;

        }

        private void EditButton(object sender, RoutedEventArgs e)
        {
            var examinationW = Application.Current.Windows.OfType<ShowExamination>().FirstOrDefault();
            Examination examination = (Examination)examinationW.dataGridExaminations.SelectedItem;

            //validacija polja Description za izvestaj da nije null
            if(examination.Report.Description == null)
            {
                MessageBox.Show("Field value od report description must not be null", "Error");

            }

            examinationController.EditExamination(examination.Id, examination.Appointment, examination.Report, examination.Prescription);
            this.Close();

        }

        public Report Report
        {
            get { return report; }
            set
            {
                report = value;
                OnPropertyChanged(nameof(Report));
            }
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
