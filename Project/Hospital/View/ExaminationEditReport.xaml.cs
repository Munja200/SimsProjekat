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
        public event PropertyChangedEventHandler PropertyChanged;

        private ExaminationController examinationController;
        private Report report;
        private Examination examination;


        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
            bool valid = true;

            if (!ReportDuringTheExaminationPeriod()) { valid = false; }

            if (valid)
            {
                examinationController.EditExamination(examination.Id, examination.Appointment, examination.Report, examination.Prescription, examination.Instructions);
                this.Close();
            }

        }

        public bool ReportAfterExaminationPeriod()
        {
            if (DateTime.Now >= examination.Appointment.EndTime)
            {
                return true;
            }
            else
            {
                MessageBox.Show("The report can be created/changed only after or during the examination!", "Error");
                return false;
            }
        }

        public bool ReportDuringTheExaminationPeriod()
        {
            if ((DateTime.Now >= examination.Appointment.StartTime && DateTime.Now <= examination.Appointment.EndTime))
            {
                return true;
            }
            else
            {
                return ReportAfterExaminationPeriod();
            }
        }

        private void CancelButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }

}
