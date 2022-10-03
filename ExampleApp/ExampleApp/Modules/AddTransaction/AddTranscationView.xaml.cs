using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExampleApp.Modules.AddTransaction
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTranscationView : ContentPage
    {
        public AddTranscationView()
        {
            InitializeComponent();
            BindingContext = App.Container.Resolve<AddTransactionViewModel>();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await (BindingContext as AddTransactionViewModel).InitializeAsync(null);
        }
    }
}