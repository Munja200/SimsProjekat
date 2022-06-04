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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Controller;
using Model;

namespace Hospital.View
{
    /// <summary>
    /// Interaction logic for PageOperationDoctor.xaml
    /// </summary>
    public partial class PageOperationDoctor : Page
    {
        private OperationController operationController;

        public PageOperationDoctor()
        {
            InitializeComponent();
            this.DataContext = this;
            App app = Application.Current as App;
            operationController = app.operationController;
            Load();
        }

        public void Load()
        {
            List<Operation> list = operationController.GetAll();
            ObservableCollection<Operation> collection = new ObservableCollection<Operation>(list);
            dataGridOperations.ItemsSource = collection;
        }

        private void Click_Create(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageCreateOperation());
            Load();
        }

        private void Click_Delete(object sender, RoutedEventArgs e)
        {
            Operation operation = dataGridOperations.SelectedItem as Operation;

            if (operation != null)
                operationController.DeleteOperation(operation.Id);
            Load();
        }

        private void Click_Edit(object sender, RoutedEventArgs e)
        {
            Operation operation = dataGridOperations.SelectedItem as Operation;

            if (operation != null)
                NavigationService.Navigate(new PageEditOperation(operation));

        }

    }
}
