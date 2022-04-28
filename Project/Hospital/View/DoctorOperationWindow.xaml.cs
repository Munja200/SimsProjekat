using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Controller;
using Model;

namespace Hospital.View
{
    /// <summary>
    /// Interaction logic for DoctorOperationWindow.xaml
    /// </summary>
    public partial class DoctorOperationWindow : Window
    {

        private OperationController operationController;
        public DoctorOperationWindow()
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
            new DoctorAddOperation().ShowDialog();
            Load();
        }

        private void Click_Delete(object sender, RoutedEventArgs e)
        {
            var viewOperationsWindow = Application.Current.Windows.OfType<DoctorOperationWindow>().FirstOrDefault();
            Operation operation = (Operation)viewOperationsWindow.dataGridOperations.SelectedItem;

            if (operation != null)
                operationController.DeleteOperation(operation.Id);
                Load();
        }

        private void Click_Edit(object sender, RoutedEventArgs e)
        {
            var viewOperationsWindow = Application.Current.Windows.OfType<DoctorOperationWindow>().FirstOrDefault();
            Operation operation = (Operation)viewOperationsWindow.dataGridOperations.SelectedItem;

            if (operation != null)
                new DoctorEditOperation(operation).ShowDialog();
        }
    }
}
