using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Hospital.View
{
    /// <summary>
    /// Interaction logic for ChangeDrugWindow.xaml
    /// </summary>
    public partial class ChangeDrugWindow : Window,INotifyPropertyChanged
    {
            private Drug drug;
            private String name;
            private String manu;
            private String describe;
            public ObservableCollection<Ingredient> Ingredients;
            public ObservableCollection<String> Replacements;
            private DrugController drugController;
            public event PropertyChangedEventHandler PropertyChanged;

        public ChangeDrugWindow(Drug drug)
            {
                InitializeComponent();
                DataContext = this;
                App app = Application.Current as App;
                drugController = app.drugController;
                this.drug = drug;
                Ingredients = new ObservableCollection<Ingredient>();
                Replacements = new ObservableCollection<String>();
                NewName = this.drug.Equipment.Name;
                Manu = this.drug.Equipment.Manufacturer;
                Describe = this.drug.ReasonForInvalidity;
                foreach (Ingredient ingredient in this.drug.Ingredients) { Ingredients.Add(ingredient); }
                foreach (String newReplacement in this.drug.Replacements) { Replacements.Add(newReplacement); }
                listIngredients.ItemsSource = Ingredients;
                listReplacements.ItemsSource = Replacements;
            }

            public String NewName
            {
                get => name;
                set
                {
                    if (name != value)
                    {
                        name = value;
                        OnPropertyChanged();
                    }
                }
            }
            public String Describe
            {
                get => describe;
                set
                {
                    if (describe != value)
                    {
                        describe = value;
                        OnPropertyChanged();
                    }
                }
            }

            public String Manu
            {
                get => manu;
                set
                {
                    if (manu != value)
                    {
                        manu = value;
                        OnPropertyChanged();
                    }
                }
            }

            private void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }


            private void ChangeDrugClick(object sender, RoutedEventArgs e)
            {
                drug.Equipment.Name = NewName;
                drug.Equipment.Manufacturer = Manu;
                drug.Ingredients = Ingredients.ToList();
                drug.Replacements = Replacements.ToList();
                drug.IsNotValid = false;
                drug.ReasonForInvalidity = "";
                drugController.EditDrug(drug);
                this.Close();
            }

            private void AddingIngredient(object sender, RoutedEventArgs e)
            {
                if (ingredient.Text != "")
                {
                    Ingredients.Add(new Ingredient(ingredient.Text));
                    ingredient.Text = "";
                }
            }

            private void AddReplacement(object sender, RoutedEventArgs e)
            {
                if (replacement.Text != "")
                {
                    Replacements.Add(replacement.Text);
                    replacement.Text = "";
                }
            }

            private void listIngredientsSelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                deleteIngredient.IsEnabled = true;
            }

            private void deleteIngredientClick(object sender, RoutedEventArgs e)
            {
                Ingredient ingredient = (Ingredient)listIngredients.SelectedItem;


                Ingredients.Remove(ingredient);
                deleteIngredient.IsEnabled = false;
            }

            private void Close(object sender, RoutedEventArgs e)
            {
                new DefectiveDrugWindow().Show();
                this.Close();
            }

            private void listReplacementsSelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                deleteReplacement.IsEnabled = true;

            }

            private void deleteReplacementClick(object sender, RoutedEventArgs e)
            {
                String curReplacement = (string)listReplacements.SelectedItem;
                Replacements.Remove(curReplacement);
                deleteReplacement.IsEnabled = false;
            }
        }
}
