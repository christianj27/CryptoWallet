using System;
using Xamarin.Forms;
using Autofac;
using System.Reflection;
using ExampleApp.Common.Database;
using ExampleApp.Common.Models;
using ExampleApp.Modules.Loading;
using ExampleApp.Common.Database.Migrations;
using ExampleApp.Common.Extensions;

namespace ExampleApp
{
    public partial class App : Application
    {
        public static IContainer Container;
        public App()
        {
            InitializeComponent();
            
            //class used for registration
            var builder = new ContainerBuilder();

            //scan and register all classes in the assembly
            var dataAccess = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(dataAccess)
                .AsImplementedInterfaces()
                .AsSelf();
            builder.RegisterType<Repository<User>>().As<IRepository<User>>();
            builder.RegisterType<Repository<Transaction>>().As<IRepository<Transaction>>();

            //get container
            Container = builder.Build();

            //run database migrations
            //var migrationService = Container.Resolve<IMigrationService>();
            //migrationService.RunDatabaseMigrations().SafeFireAndForget(false);

            //set first page
            MainPage = Container.Resolve<LoadingView>();
        }
    }
}
