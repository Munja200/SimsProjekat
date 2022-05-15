﻿using System.Collections.ObjectModel;
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
    /// Interaction logic for IssuingInstructions.xaml
    /// </summary>
    public partial class IssuingInstructions : Window
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ExaminationController examinationController;
        private InstructionsController instructionsController;
        private SpecialistController specialistController;
        private Examination examination;
        private Instructions instructions;

        public ObservableCollection<ComboItem<Specialist>> Specialists { get; set; }
        public ObservableCollection<string> PurposeT { get; set; }

        public Instructions Instructions
        {
            get { return instructions; }
            set
            {
                instructions = value;
                OnPropertyChanged(nameof(Instructions));
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

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public IssuingInstructions(Examination examination)
        {
            InitializeComponent();
            this.DataContext = this;
            Instructions = new Instructions();
            App app = Application.Current as App;
            var examinationW = Application.Current.Windows.OfType<ShowExamination>().FirstOrDefault();
            Examination = examination;

            examinationController = app.examinationController;
            instructionsController = app.instructionsController;
            specialistController = app.specialistController;

            PurposeT = new ObservableCollection<string>();
            PurposeT.Add("Operation");
            PurposeT.Add("Examination");

            Load();
        }

        public void Load()
        {
            Specialists = new ObservableCollection<ComboItem<Specialist>>();

            foreach (Specialist specialist in specialistController.GetAll())
            {

                Specialists.Add(new ComboItem<Specialist> { Name = specialist.Speciality.ToString(), Value = specialist });

            }
        }

        private void SubmitButton(object sender, RoutedEventArgs e)
        {
            var examinationW = Application.Current.Windows.OfType<ShowExamination>().FirstOrDefault();
            Examination examination = (Examination)examinationW.dataGridExaminations.SelectedItem;
            examination.Instructions = instructions;

            examinationController.EditExamination(examination.Id, examination.Appointment, examination.Report, examination.Prescription, examination.Instructions);
            this.Close();

        }


        private void CancelButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
