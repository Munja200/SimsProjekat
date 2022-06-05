using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Hospital.Controller;
using Model;

namespace Hospital.View
{
    /// <summary>
    /// Interaction logic for ShowExamination.xaml
    /// </summary>
    public partial class ShowExamination : Window
    {
        private ExaminationController examinationController;
        public ShowExamination()
        {
            InitializeComponent();
            this.DataContext = this;
            App app = Application.Current as App;

            examinationController = app.examinationController;

            Load();
        }

        public void Load()
        {
            List<Examination> list = examinationController.GetAll();
            ObservableCollection<Examination> collection = new ObservableCollection<Examination>(list);
            dataGridExaminations.ItemsSource = collection;
        }

        private void CreateReport(object sender, RoutedEventArgs e)
        {
            var viewReportsWindow = Application.Current.Windows.OfType<ShowExamination>().FirstOrDefault();
            Examination examination = (Examination)viewReportsWindow.dataGridExaminations.SelectedItem;

            if (examination != null)
            {
                IsReportAlreadyWrittenCreate(examination);
            }

        }

        private void EditReport(object sender, RoutedEventArgs e)
        {
            var viewReportsWindow = Application.Current.Windows.OfType<ShowExamination>().FirstOrDefault();
            Examination examination = (Examination)viewReportsWindow.dataGridExaminations.SelectedItem;

            if (examination != null)
            {
                IsReportAlreadyWrittenEdit(examination);

            }

        }

        private void IssuingPrescription(object sender, RoutedEventArgs e)
        {
            var viewReportsWindow = Application.Current.Windows.OfType<ShowExamination>().FirstOrDefault();
            Examination examination = (Examination)viewReportsWindow.dataGridExaminations.SelectedItem;

            if (examination != null)
            {
                IsReportAlreadyWrittenPrescription(examination);
            }

        }

        private void IssuingInstructions(object sender, RoutedEventArgs e)
        {
            var viewReportsWindow = Application.Current.Windows.OfType<ShowExamination>().FirstOrDefault();
            Examination examination = (Examination)viewReportsWindow.dataGridExaminations.SelectedItem;

            if (examination != null)
            {

                new IssuingInstructions(examination).ShowDialog();
                Load();

            }

        }

        private void IsReportAlreadyWrittenCreate(Examination examination)
        {
            if (!examination.Report.Written)
            {
                new ExaminationEditReport(examination).ShowDialog();
            }
            else
            {
                MessageBox.Show("The report for this review has already been created!", "Error");
            }
        }

        private void IsReportAlreadyWrittenEdit(Examination examination)
        {
            if (examination.Report.Written)
            {
                new ExaminationEditReport(examination).ShowDialog();
            }
            else
            {
                MessageBox.Show("The report for this review cannot be modified because it has not yet been created!", "Error");
            }
        }

        private void IsReportAlreadyWrittenPrescription(Examination examination)
        {
            if (examination.Report.Written)
            {
                new IssuingPrescription(examination).ShowDialog();
                Load();

            }
            else
            {
                MessageBox.Show("The report for this review has not been written!", "Error");
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            new HomeDoctor().Show();
            this.Close();
        }

    }
}
