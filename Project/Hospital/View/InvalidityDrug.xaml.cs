using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
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

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Drug Drug
        {
            get { return drug; }
            set
            {
                drug = value;
                OnPropertyChanged(nameof(Drug));
            }
        }

        public InvalidityDrug(Drug drug)
        {
            InitializeComponent();
            this.DataContext = this;
            Drug = drug;
            Initialization();

        }
        private void Initialization() {
            App app = Application.Current as App;
            var drugW = Application.Current.Windows.OfType<ListDrugs>().FirstOrDefault();
            drugController = app.drugController;

            name.Content = drug.Equipment.Name;
            usingg.Text = drug.Using;
            isValid.IsChecked = drug.IsNotValid;
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
