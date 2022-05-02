using System;
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

            //ako izvestaj nije napisan, onda on moze da se kreira, ali ne moze da se edituje
            if (examination != null)
            {
                if (examination.Report.Written == false)
                {
                    //izvestaj moze da se kreira samo u toku ili nakon termina pregleda
                    if ((examination.Appointment.StartTime.Hour > DateTime.Now.Hour &&
                        examination.Appointment.EndTime.Hour < DateTime.Now.Hour) || examination.Appointment.EndTime.Hour > DateTime.Now.Hour)
                    {
                        MessageBox.Show("The report can be created only during or after the review date!", "Error");
                    }
                    else
                    {
                        new ExaminationEditReport(examination).ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("A report for this review has already been created!", "Error");
                }
            }

        }

        private void EditReport(object sender, RoutedEventArgs e)
        {
            var viewReportsWindow = Application.Current.Windows.OfType<ShowExamination>().FirstOrDefault();
            Examination examination = (Examination)viewReportsWindow.dataGridExaminations.SelectedItem;

            //ako je izvestaj napisan, onda on moze da se izmeni, ali ne moze da se kreira
            if (examination != null)
            {
                if (examination.Report.Written == true)
                {
                    //izvestaj moze da se edituje samo u toku ili nakon termina pregleda
                    if ((examination.Appointment.StartTime.Hour > DateTime.Now.Hour &&
                         examination.Appointment.EndTime.Hour < DateTime.Now.Hour) || examination.Appointment.EndTime.Hour > DateTime.Now.Hour)
                    {
                        MessageBox.Show("The report can be changed only during or after the review date!", "Error");
                    }
                    else
                    {
                        new ExaminationEditReport(examination).ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("The report for this review cannot be modified because it has not yet been created!", "Error");
                }
            }


        }
    }
}
