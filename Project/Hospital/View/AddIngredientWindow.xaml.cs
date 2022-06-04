using Controller;
using Hospital.Controller;
using Hospital.Model;
using Model;
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
    /// Interaction logic for AddIngredientWindow.xaml
    /// </summary>
    public partial class AddIngredientWindow : Window
    {
        private EquipmentController equipmentController;
        private DrugController drugController;
        public ObservableCollection<Ingredient> Ingredients { get; set; }
        public ObservableCollection<string> Replacements { get; set; }
        public Equipment Equipment { get; set; }
        private RoomController roomController;
        private RoomEquipmentController roomEquipmentController;
        public AddIngredientWindow(Equipment equipment)
        {
            InitializeComponent();
            this.DataContext = this;
            App app = Application.Current as App;
            this.Ingredients = new ObservableCollection<Ingredient>();
            this.Replacements = new ObservableCollection<string>();
            this.equipmentController = app.equipmentController;
            this.drugController = app.drugController;
            this.Equipment = equipment;
            this.roomController = app.roomController;
            this.roomEquipmentController = app.roomEquimpentController;
            listIngredients.ItemsSource = Ingredients;
            listReplacements.ItemsSource = Replacements;
        }

        private void AddingIngredient(object sender, RoutedEventArgs e)
        {
            if (ingredient.Text != "")
            {
                Ingredients.Add(new Ingredient(ingredient.Text));
                ingredient.Text = "";
            }
        }

        private void CreateDrug(object sender, RoutedEventArgs e)
        {
            if (Ingredients.Count > 0)
            {

                int ids = equipmentController.GetAll().Count() == 0 ? 0 : equipmentController.GetAll().Max(Equipment => Equipment.Id);
                Equipment.Id = ++ids;
                if (!equipmentController.Create(Equipment.Id, Equipment.Name, Equipment.Manufacturer, Equipment.Quantity, Equipment.Description))

                Equipment.Id = GenerateEquipmentId();
                if (!equipmentController.Create(Equipment.Id, Equipment.Name, Equipment.Manufacturer, Equipment.Quantity, Equipment.Description, null))

                    return;
                drugController.CreateDrug(new Drug(Ingredients.ToList(), 0, Equipment, Replacements.ToList(), "", true, ""));
                
                Room newRoom = roomController.GetById(1);
                roomEquipmentController.Create(newRoom, Equipment, Equipment.Quantity, 0);
                this.Close();
            }
        }
        private int GenerateEquipmentId() {
            int id = equipmentController.GetAll().Count() == 0 ? 0 : equipmentController.GetAll().Max(Equipment => Equipment.Id);
            return id++;
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
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
    }
}
