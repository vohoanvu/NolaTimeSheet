using Microsoft.Extensions.DependencyInjection;
using NolaTimeSheet.Configuration;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Markup;

namespace NolaTimeSheet
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e); 
            DevExpress.Xpf.Core.ApplicationThemeHelper.ApplicationThemeName = "Win11Dark";
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddServices();
        }
    }
}
