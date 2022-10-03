using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExampleApp.Modules.Transactions
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DepositedTransactionsView : ContentPage
    {
        public DepositedTransactionsView()
        {
            InitializeComponent();
            BindingContext = App.Container.Resolve<TransactionViewModel>();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await (BindingContext as TransactionViewModel).InitializeAsync(Constants.TRANSACTION_DEPOSITED);
        }
    }
}