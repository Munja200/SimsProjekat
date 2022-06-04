using Hospital.Controller;
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
    /// Interaction logic for DrugReview.xaml
    /// </summary>
    public partial class DrugReview : Window
    {
        public DrugController drugController;
        ObservableCollection<Drug> Drugs { get; set; }
        public ObservableCollection<Ingredient> Ingredients { get; set; }
        public ObservableCollection<string> Replacements { get; set; }
        public DrugReview()
        {
            InitializeComponent();
            Drugs = new ObservableCollection<Drug>();
            this.DataContext = this;
            App app = Application.Current as App;
            this.Ingredients = new ObservableCollection<Ingredient>();
            this.Replacements = new ObservableCollection<string>();
            drugController = app.drugController;
            foreach (Drug drug in drugController.GetAll())
            {
                Drugs.Add(drug);
            }
            dataGridDrugs.ItemsSource = Drugs;
        }
        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void ShowIngredient(object sender, RoutedEventArgs e)
        {
            var viewDrugWindow = Application.Current.Windows.OfType<DrugReview>().FirstOrDefault();
            Drug drug = (Drug)viewDrugWindow.dataGridDrugs.SelectedItem;
            if (drug != null)
            {
                if (drug.Equipment != null)
                {
                    Ingredients.Clear();
                    Replacements.Clear();
               
                    foreach (Ingredient ingredient in drug.Ingredients) 
                    { 
                                            Ingredients.Add(ingredient); 
                    }
                    foreach (String replacement in drug.Replacements) { Replacements.Add(replacement); }
                    listIngredients.ItemsSource = Ingredients;
                    listReplacements.ItemsSource = Replacements;
                }
                else {
                    Ingredients.Clear();
                    Replacements.Clear();
                }
            }
        }
    }
}
