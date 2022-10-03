using ExampleApp.Common.Controllers;
using ExampleApp.Common.Models;
using ExampleApp.Common.Navigation;
using ExampleApp.Modules.AddTransaction;
using ExampleApp.Common.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExampleApp.Modules.Transactions
{
    public class TransactionViewModel : BaseViewModel
    {
        private IWalletController _walletController;
        private string _filter = string.Empty;
        private INavigationService _navigationService;

        public TransactionViewModel(IWalletController walletController,
                                    INavigationService navigationService)
        {
            _walletController = walletController;
            _navigationService = navigationService;
            Transactions = new ObservableCollection<Transaction>();
        }

        public override async Task InitializeAsync(object parameter)
        {
            _filter = parameter.ToString();
            await GetTransactions();
        }
        private async Task GetTransactions()
        {
            IsRefreshing = true;
            var transactions = await _walletController.GetTransactions();
            if (!string.IsNullOrEmpty(_filter))
            {
                transactions = transactions.Where(x => x.Status == _filter).ToList();
            }
            Transactions = new ObservableCollection<Transaction>(transactions);
            IsRefreshing = false;
        }


        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set { SetProperty(ref _isRefreshing, value); }
        }

        private ObservableCollection<Transaction> _transactions;
        public ObservableCollection<Transaction> Transactions
        {
            get => _transactions;
            set { SetProperty(ref _transactions, value); }
        }

        private Transaction _selectedTransaction;
        public Transaction SelectedTransaction
        {
            get => _selectedTransaction;
            set { SetProperty(ref _selectedTransaction, value); }
        }
        public ICommand TradeCommand { get => new Command(async () => await PerformNavigation()); }

        public ICommand RefreshTransactionsCommand { get => new Command(async () => await RefreshTransactions()); }

        public ICommand TransactionSelectedCommand { get => new Command(async () => await TransactionSelected()); }

        private async Task TransactionSelected()
        {
            if (SelectedTransaction == null)
            {
                return;
            }
            await _navigationService.PushAsync<AddTransactionViewModel>($"id={SelectedTransaction.Id}");
            SelectedTransaction = null;
        }
        private async Task RefreshTransactions()
        {
            await GetTransactions();
        }
        private async Task PerformNavigation()
        {
            await _navigationService.PushAsync<AddTransactionViewModel>();
        }



    }
}
