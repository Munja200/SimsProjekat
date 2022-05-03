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
using Hospital.Controller;
using Hospital.Model;
using Model;

namespace Hospital.View
{
    /// <summary>
    /// Interaction logic for ExaminationAddReport.xaml
    /// </summary>
    public partial class ExaminationAddReport : Window
    {
        private ExaminationController examinationController;
        private ReportController reportController;
        private Report report;

        private Examination examination;
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public ExaminationAddReport(Examination examination)
        {
            InitializeComponent();
            this.DataContext = this;
            report = new Report();
            App app = Application.Current as App;
            var examinationW = Application.Current.Windows.OfType<ShowExamination>().FirstOrDefault();
            Examination = examination;
            examinationController = app.examinationController;

        }

        private void AddButton(object sender, RoutedEventArgs e)
        {
            var examinationW = Application.Current.Windows.OfType<ShowExamination>().FirstOrDefault();
            Examination examination = (Examination)examinationW.dataGridExaminations.SelectedItem;

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
