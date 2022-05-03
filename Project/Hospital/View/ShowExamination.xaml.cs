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

            if (examination != null)
            {

                //ako izvestaj nije napisan, onda on moze da se kreira, ali ne moze da se edituje
                if (examination.Report.Written == false)
                {

                    if ((DateTime.Now.Hour > examination.Appointment.StartTime.Hour && DateTime.Now.Hour < examination.Appointment.EndTime.Hour))
                    {
                        //izvestaj moze da se kreira u toku termina pregleda
                        new ExaminationEditReport(examination).ShowDialog();
                    }
                    else
                    {
                        if (DateTime.Now.Hour > examination.Appointment.EndTime.Hour)
                        {
                            //izvestaj moze da se kreira posle termina pregleda
                            new ExaminationEditReport(examination).ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("The report can be created only after or during the examination!", "Error");
                        }
                    }


                }
                else
                {
                    MessageBox.Show("The report for this review has already been created!", "Error");
                }


            }

        }

        private void EditReport(object sender, RoutedEventArgs e)
        {
            var viewReportsWindow = Application.Current.Windows.OfType<ShowExamination>().FirstOrDefault();
            Examination examination = (Examination)viewReportsWindow.dataGridExaminations.SelectedItem;

            if (examination != null)
            {

                //ako je izvestaj napisan, onda on moze da se izmeni, ali ne moze da se kreira
                if (examination.Report.Written == true)
                {


                    if ((DateTime.Now.Hour > examination.Appointment.StartTime.Hour && DateTime.Now.Hour < examination.Appointment.EndTime.Hour))
                    {
                        //izvestaj moze da se izmeni u toku termina pregleda
                        new ExaminationEditReport(examination).ShowDialog();
                    }
                    else
                    {
                        if (DateTime.Now.Hour > examination.Appointment.EndTime.Hour)
                        {
                            //izvestaj moze da se izmeni posle termina pregleda
                            new ExaminationEditReport(examination).ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("The report can be changed only after or during the examination!", "Error");
                        }
                    }


                }
                else
                {
                    MessageBox.Show("The report for this review cannot be modified because it has not yet been created!", "Error");
                }


            }


        }

        private void IssuingPrescription(object sender, RoutedEventArgs e)
        {
            var viewReportsWindow = Application.Current.Windows.OfType<ShowExamination>().FirstOrDefault();
            Examination examination = (Examination)viewReportsWindow.dataGridExaminations.SelectedItem;

            if (examination != null)
            {

                //za izvestaj koji nije napisan ne moze da se izda lek
                if (examination.Report.Written == true)
                {

                    if ((DateTime.Now.Hour > examination.Appointment.StartTime.Hour && DateTime.Now.Hour < examination.Appointment.EndTime.Hour))
                    {
                        //recept moze da se izda u toku pregleda
                        new IssuingPrescription(examination).ShowDialog();
                        Load();
                    }
                    else
                    {
                        if (DateTime.Now.Hour > examination.Appointment.EndTime.Hour)
                        {
                            //recept moze da se izda nakon pregleda
                            new IssuingPrescription(examination).ShowDialog();
                            Load();
                        }
                        else
                        {
                            MessageBox.Show("The prescription can be issuing only during or after the review date!", "Error");
                        }
                    }


                }else
                {
                    MessageBox.Show("The report for this review has not been written!", "Error");
                }


            }

        }
    }
}
