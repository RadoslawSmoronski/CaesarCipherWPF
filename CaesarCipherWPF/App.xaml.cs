using System;
using System.Configuration;
using System.Data;
using System.Windows;
using CaesarCipher;
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

            var alphabet = new char[]
            {
                'A', 'Ą', 'B', 'C', 'Ć', 'D', 'E', 'Ę', 'F', 'G',
                'H', 'I', 'J', 'K', 'L', 'Ł', 'M', 'N', 'Ń', 'O',
                'Ó', 'P', 'R', 'S', 'Ś', 'T', 'U', 'W', 'Y', 'Z',
                'Ź', 'Ż'
            };

            services.AddSingleton<ICipherService>(provider => new CipherService(alphabet));
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
