﻿using ExampleApp.Common.Base;
using ExampleApp.Common.Models;
using ExampleApp.Common.Navigation;
using ExampleApp.Modules.Login;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExampleApp.Modules.Onboarding
{
    public class OnboardingViewModel : BaseViewModel
    {
        private INavigationService _navigationService;

        public OnboardingViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public ObservableCollection<OnboardingItem> OnboardingSteps { get; set; } = new ObservableCollection<OnboardingItem>
        {
            new OnboardingItem("welcome.png",
                "Welcome to Ecample App",
                "Manage all your crypto assets! It's simple and easy!"),
            new OnboardingItem("nice.png",
                "Nice and Tidy Crypto Portfolio",
                "Keep BTC, ETH, XRP, and many other tokens."),
            new OnboardingItem("security.png",
                "Your Safety is Our Top Priority",
                "Our top-notch security features will keep you completely safe.")
        };

        public ICommand SkipCommand { get => new Command(async () => await FinishOnboarding()); }

        private async Task FinishOnboarding()
        {
            await _navigationService.InsertAsRoot<LoginViewModel>();
        }
    }
}
