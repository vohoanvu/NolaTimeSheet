using DevExpress.Xpf.Core;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NolaTimeSheet.ViewModels;

namespace NolaTimeSheet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ThemedWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            //using var context = new DbContextFactory().CreateDbContext();
            //try
            //{
            //    context.Database.Migrate();  // Ensures that the database and schema is uptodate

            //    // Try to query the first Project from the database.
            //    var firstProject = context.Projects.FirstOrDefault();

            //    if (firstProject != null)
            //        MessageBox.Show("Data connection test successful.");
            //    else
            //        MessageBox.Show("Data connection test successful but the database is empty.");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Data connection test failed: {ex.Message}");
            //}
        }
    }
}
