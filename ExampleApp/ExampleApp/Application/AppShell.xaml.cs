using Autofac;
using ExampleApp.Modules.AddTransaction;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ExampleApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            BindingContext = App.Container.Resolve<AppShellViewModel>();

            Routing.RegisterRoute("AddTransactionViewModel", typeof(AddTranscationView));
        }
    }
}
