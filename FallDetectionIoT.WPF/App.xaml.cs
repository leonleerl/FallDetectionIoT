﻿using FallDetectionIoT.WPF.Services.Interfaces;
using FallDetectionIoT.WPF.Services;
using FallDetectionIoT.WPF.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;
using FallDetectionIoT.WPF.ViewModels;
using FallDetectionIoT.WPF.Common;

namespace FallDetectionIoT.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider;

        public App()
        {
            var serviceCollection = new ServiceCollection();

            ConfigureServices(serviceCollection);

            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            
            services.AddHttpClient<ISensorDataService, SensorDataService>(client =>
            {
                client.BaseAddress = new Uri("http://localhost:5278");
            });

            
            services.AddSingleton<MainWindow>();
            services.AddSingleton<MainWindowViewModel>();

            services.AddAutoMapper(typeof(MappingProfile));
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }

}
