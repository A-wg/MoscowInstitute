using Microsoft.Extensions.DependencyInjection;
using MoscowInstitute.ApplicationServices.GetInstituteListUseCase;
using MoscowInstitute.ApplicationServices.Ports.Cache;
using MoscowInstitute.ApplicationServices.Repositories;
using MoscowInstitute.DesktopClient.InfrastructureServices.ViewModels;
using MoscowInstitute.DomainObjects;
using MoscowInstitute.DomainObjects.Ports;
using MoscowInstitute.InfrastructureServices.Cache;
using MoscowInstitute.InfrastructureServices.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MoscowInstitute.DesktopClient 
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDomainObjectsCache<Institute>, DomainObjectsMemoryCache<Institute>>();
            services.AddSingleton<NetworkInstituteRepository>(
                x => new NetworkInstituteRepository("localhost", 80, useTls: false, x.GetRequiredService<IDomainObjectsCache<Institute>>())
            );
            services.AddSingleton<CachedReadOnlyInstituteRepository>(
                x => new CachedReadOnlyInstituteRepository(
                    x.GetRequiredService<NetworkInstituteRepository>(),
                    x.GetRequiredService<IDomainObjectsCache<Institute>>()
                )
            );
            services.AddSingleton<IReadOnlyInstituteRepository>(x => x.GetRequiredService<CachedReadOnlyInstituteRepository>());
            services.AddSingleton<IGetInstituteListUseCase, GetInstituteListUseCase>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainWindow>();
        }

        private void OnStartup(object sender, StartupEventArgs args)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
