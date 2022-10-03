using ExampleApp.Common.Base;
using ExampleApp.Common.Navigation;
using ExampleApp.Common.Settings;
using ExampleApp.Modules.Login;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ExampleApp.Modules.Loading
{
    public class LoadingViewModel : BaseViewModel
    {
        private INavigationService _navigationService;
        //private IUserPreferences _userPreferences;

        public LoadingViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override Task InitializeAsync(object parameter)
        {
            if (!Preferences.ContainsKey(Constants.SHOWN_ONBOARDING))
            {
                Preferences.Set(Constants.SHOWN_ONBOARDING, true);
                _navigationService.GoToLoginFlow();
                return Task.CompletedTask;
            }

            if (Preferences.ContainsKey(Constants.IS_USER_LOGGED_IN) && Preferences.Get(Constants.IS_USER_LOGGED_IN, false))
            {
                _navigationService.GoToMainFlow();
                return Task.CompletedTask;
            }

            _navigationService.GoToLoginFlow();
            return _navigationService.InsertAsRoot<LoginViewModel>();
        }
    }
}
