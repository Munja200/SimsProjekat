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
using Hospital.Controller;
using Hospital.Model;

namespace Hospital.View
{
    /// <summary>
    /// Interaction logic for ListDrugs.xaml
    /// </summary>
    public partial class ListDrugs : Window
    {
        private DrugController drugController;

        public ListDrugs()
        {
            InitializeComponent();
            this.DataContext = this;
            App app = Application.Current as App;
            drugController = app.drugController;
            var drugW = Application.Current.Windows.OfType<ListDrugs>().FirstOrDefault();
            Load();
        }

        public void Load()
        {
            List<Drug> list = drugController.GetAll();
            ObservableCollection<Drug> collection = new ObservableCollection<Drug>(list);
            dataGridDrugs.ItemsSource = collection;
        }

        private void InvalidityDrug(object sender, RoutedEventArgs e)
        {
            var viewDrugsWindow = Application.Current.Windows.OfType<ListDrugs>().FirstOrDefault();
            Drug drug = (Drug)viewDrugsWindow.dataGridDrugs.SelectedItem;

            if (drug != null)
                new InvalidityDrug(drug).ShowDialog();
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            new HomeDoctor().Show();
            this.Close();
        }

    }
}
