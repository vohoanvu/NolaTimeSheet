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
using System.Threading.Tasks;
using DevExpress.Xpf.Grid;

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

        //private async void UserOnChange(object sender, SelectionChangedEventArgs e)
        //{
        //    var comboBox = sender as ComboBox;
        //    // Ensure the selected value is not null
        //    if (comboBox!.SelectedItem != null)
        //    {
        //        var selectedUser = comboBox.SelectedItem as UserViewModel;
        //        var mainViewModel = (DataContext as MainViewModel);
        //        await mainViewModel!.FetchEditableTimeEntries(selectedUser!.Id);
        //    }
        //}

        //private void RowValidationHandler(object sender, GridRowValidationEventArgs e)
        //{
        //    var viewModel = (MainViewModel)DataContext;
        //    var timeVm = (TimeViewModel)e.Row;
        //    //Custom row validation logic here...

        //    if (timeVm != null)
        //    {
        //        //viewModel.UpdateTimeEntryCommand.Execute(timeVm);
        //        //e.Handled = true;
        //        e.IsValid = true;
        //    }
        //}

        //private void InvalidRowExceptionHandler(object sender, InvalidRowExceptionEventArgs e)
        //{
        //    e.ExceptionMode = ExceptionMode.NoAction;
        //}
    }
}
