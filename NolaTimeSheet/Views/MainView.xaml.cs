using NolaTimeSheet.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace NolaTimeSheet.Views
{
    /// <summary>
    /// Interaction logic for View1.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();
            DataContext = App.ServiceProvider.GetRequiredService<MainViewModel>();
        }

        private void UserOnChange(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            // Ensure the selected value is not null
            if (comboBox.SelectedItem != null)
            {
                // Cast the selected item back to ProjectViewModel
                var selectedUser = comboBox.SelectedItem as UserViewModel;
                // You can access the values from this selectedProject object.
                Debug.WriteLine($"Selected User Id: {selectedUser.Id}, Name: {selectedUser.UserName}");
            }
        }
    }
}
