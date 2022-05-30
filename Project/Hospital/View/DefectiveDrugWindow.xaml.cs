using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

namespace Hospital.View
{
    /// <summary>
    /// Interaction logic for DefectiveDrugWindow.xaml
    /// </summary>
    public partial class DefectiveDrugWindow : Window
    {
        public ObservableCollection<Drug> drugs;
        private DrugController drugsController;
        public DefectiveDrugWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            App app = Application.Current as App;
            drugsController = app.drugController;
            drugs = new ObservableCollection<Drug>();

            foreach (Drug drug in drugsController.GetAllInvalidDrug()) { drugs.Add(drug); }

            dataGridInvalidDrug.ItemsSource = drugs;
        }

        private void ChangeDrugClick(object sender, RoutedEventArgs e)
        {
            var viewWindow = Application.Current.Windows.OfType<DefectiveDrugWindow>().FirstOrDefault();
            Drug drug = (Drug)viewWindow.dataGridInvalidDrug.SelectedItem;
            if (drug != null)
            {

                new ChangeDrugWindow(drug).Show();
                this.Close();

            }
        }
    }
}
