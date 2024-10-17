using System;
using System.ComponentModel.Design;
using System.Configuration;
using System.Data;
using System.Resources;
using System.Windows;
using CaesarCipher;
using CaesarCipherWPF.Service;
using Microsoft.Extensions.DependencyInjection;


namespace CaesarCipherWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            var services = new ServiceCollection();

            services.AddSingleton<ICipherService>(provider => new CipherService(AlphabetTypeEnum.Latin));
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddSingleton<MainWindow>();

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }

}
