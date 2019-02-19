using System.Diagnostics;
using System.Threading.Tasks;
using Prism.Navigation;

namespace PrismNavigationDemo.ViewModels
{
    public class SecondPageViewModel : ViewModelBase, INavigatingAsyncAware
    {
        private string _result = "Loading";

        public string Result
        {
            get => _result;
            set => SetProperty(ref _result, value);
        }

        public SecondPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Second Page";
        }

        public async Task OnNavigatingToAsync(INavigationParameters parameters)
        {
            await InitializeAsync(parameters);
        }

        private async Task InitializeAsync(INavigationParameters parameters)
        {
            Debug.WriteLine($"{nameof(FirstPageViewModel)} -> {nameof(OnNavigatingTo)} is invoked.");

            await Task.Delay(1000); // simulate a network activity (data loading)

            Result = "Success";
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            Debug.WriteLine($"{nameof(FirstPageViewModel)} -> {nameof(OnNavigatedTo)} is invoked.");
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            Debug.WriteLine($"{nameof(FirstPageViewModel)} -> {nameof(OnNavigatedFrom)} is invoked.");

            base.OnNavigatedFrom(parameters);
        }
    }
}
