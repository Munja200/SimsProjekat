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
using Hospital.Model;

namespace Hospital.View
{
    /// <summary>
    /// Interaction logic for InvalidityDrug.xaml
    /// </summary>
    public partial class InvalidityDrug : Window
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private DrugController drugController;
        private Drug drug;

        public Drug Drug
        {
            get { return  drug; }
            set
            {
                drug = value;
                OnPropertyChanged(nameof(Drug));
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public InvalidityDrug(Drug drug)
        {
            InitializeComponent();
            this.DataContext = this;
            App app = Application.Current as App;
            var drugW = Application.Current.Windows.OfType<ListDrugs>().FirstOrDefault();
            Drug = drug;
            drugController = app.drugController;

            name.Content = drug.Name;
            usingg.Text = drug.Using;
            isValid.IsChecked = drug.IsValid;
            reason.Text = drug.ReasonForInvalidity;

        }

        private void SubmitButton(object sender, RoutedEventArgs e)
        {
            var drugW = Application.Current.Windows.OfType<ListDrugs>().FirstOrDefault();
            Drug drug = (Drug)drugW.dataGridDrugs.SelectedItem;

            drugController.EditDrug(drug);
            this.Close();
        }

        private void CancelButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
