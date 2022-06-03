using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;
using Controller;
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
        public event PropertyChangedEventHandler PropertyChanged;

        private PatientAccountController patientAccountController;
        private ExaminationController examinationController;
        private DrugController drugController;

        private Examination examination;
        private Prescription prescription;

        public ObservableCollection<ComboItem<Drug>> Drugs { get; set; }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Prescription Prescription
        {
            get { return prescription; }
            set
            {
                prescription = value;
                OnPropertyChanged(nameof(Prescription));
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

        public IssuingPrescription(Examination examination)
        {
            InitializeComponent();
            Prescription = new Prescription();
            this.DataContext = this;
            App app = Application.Current as App;
            var examinationW = Application.Current.Windows.OfType<ShowExamination>().FirstOrDefault();
            Examination = examination;

            GetControllers(app);

            Load();

        }

        public void GetControllers(App app) 
        {
            examinationController = app.examinationController;
            drugController = app.drugController;
            patientAccountController = app.patientAccountController;
        }

        public void Load()
        {
            Drugs = new ObservableCollection<ComboItem<Drug>>();

            foreach (Drug drug in drugController.GetAll())
            {
                Drugs.Add(new ComboItem<Drug> { Name = drug.Equipment.Name, Ingredients = drug.Ingredients, Value = drug });
            }

        }

        private void SubmitButton(object sender, RoutedEventArgs e)
        {
            examination.Prescription = prescription;

            bool valid = true;

            if (!ValidationPrescription()) { valid = false; }
            if (!PrescriptionDuringTheExaminationPeriod()) { valid = false; }
            if (!PatientIsAllergic()) { valid = false; }


            if (valid)
            {
                examinationController.EditExamination(examination.Id, examination.Appointment, examination.Report, examination.Prescription,
                    examination.Instructions);
                this.Close();
            }
        }

        public bool ValidationPrescription()
        {

            Regex agePattern = new Regex(@"^[1-9][0-9]?$");

            if (agePattern.IsMatch(frequency.Text) == false)
            {
                MessageBox.Show("Frequency must be in numeric format ");
                return false;
            }

            if (agePattern.IsMatch(interval.Text) == false)
            {
                MessageBox.Show("Interval must be in numeric format ");
                return false;
            }

            if (agePattern.IsMatch(duration.Text) == false)
            {
                MessageBox.Show("Duration must be in numeric format ");
                return false;
            }
            return true;
        }

        public bool PrescriptionAfterExaminationPeriod()
        {
            if (DateTime.Now >= examination.Appointment.EndTime)
            {
                return true;
            }
            else
            {
                MessageBox.Show("The prescription can be issuing only after or during the examination!", "Error");
                return false;
            }
        }

        public bool PrescriptionDuringTheExaminationPeriod()
        {
            if ((DateTime.Now >= examination.Appointment.StartTime && DateTime.Now <= examination.Appointment.EndTime))
            {
                return true;
            }
            else
            {
                return PrescriptionAfterExaminationPeriod();
            }
        }

        public bool PatientIsAllergic()
        {
            ComboItem<Drug> drugNameCombo = (ComboItem<Drug>)drug.SelectedItem;
            string drugName = drugNameCombo.Name.ToString();
            List<Ingredient> drugIngredients = drugNameCombo.Ingredients;

            return PatientIsAllergicToTheDrug(drugName, drugIngredients);
        }

        public bool PatientIsAllergicToTheDrug(string drugName, List<Ingredient> drugIngredients)
        {

            foreach (Allergy drugAllergy in examination.Appointment.PatientAccount.DrugAllergies)
            {
                if (drugAllergy.Name.Equals(drugName))
                {
                    MessageBox.Show("The patient is allergic to the prescribed drug!", "Error");
                    return false;

                }
            }

            return PatientIsAllergicToTheIngredientOfDrug(drugIngredients);
        }

        public bool PatientIsAllergicToTheIngredientOfDrug(List<Ingredient> drugIngredients)
        {
            foreach (Ingredient ingredient in examination.Appointment.PatientAccount.IngredientsAllergies)
            {

                if (!FindSameNameIngredients(drugIngredients, ingredient)) { return false; }

            }
            return true;

        }

        public bool FindSameNameIngredients(List<Ingredient> drugIngredients, Ingredient ingredient) 
        {
            foreach (Ingredient ingredient1 in drugIngredients)
            {
                if (ingredient.Name.Equals(ingredient1.Name))
                {
                    MessageBox.Show("The patient is allergic to the ingredient of the prescribed drug!", "Error");
                    return false;

                }
            }
            return true;
        }

        private void CancelButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
