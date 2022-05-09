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

        public ObservableCollection<ComboItem<Drug>> Drugs { get; set; }

        public void Load()
        {
            Drugs = new ObservableCollection<ComboItem<Drug>>();
            

            foreach (Drug drug in drugController.GetAll())
            {
                Drugs.Add(new ComboItem<Drug> { Name = drug.Name, Value = drug });
            }

        }


        private void InvalidityDrug(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
    }
}
