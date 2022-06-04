using Model;
using System;
using System.Collections.Generic;
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
    public partial class AddDrug : Window
    {
        public AddDrug()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void CloseWindow(object sender, RoutedEventArgs e) { this.Close(); }
        private void AddDrugEquipment(object sender, RoutedEventArgs e)
        {

            String newName = name.Text;
            String newMname = mname.Text;
            String newDescript = descript.Text;
            int quantity;
            try
            {
                quantity = Int32.Parse(quant.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Nije uspelo dodavanje", "Error");
                return;
            }

            new AddIngredientWindow(new Equipment(0, newName, newMname, quantity, newDescript)).Show();
            this.Close();
        }
    }
}
