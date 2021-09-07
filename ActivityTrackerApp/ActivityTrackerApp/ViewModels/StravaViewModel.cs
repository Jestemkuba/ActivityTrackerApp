using ActivityTrackerApp.Commands;
using ActivityTrackerApp.Exceptions;
using ActivityTrackerApp.Popups;
using ActivityTrackerApp.Services.Contracts;
using Rg.Plugins.Popup.Contracts;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ActivityTrackerApp.ViewModels
{
    public class StravaViewModel : BaseViewModel
    {
        private const string START_URL = "https://www.strava.com/oauth/authorize?client_id=63072&response_type=code&redirect_uri=https://localhost/exchange_token&approval_prompt=force&scope=activity:read_all";
        private readonly IActivityService _activityService;
        private readonly IStravaService _stravaService;
        private readonly IPopupNavigation _popupNavigation;
        private UrlWebViewSource _url;
        private bool _browserVisible;
        private bool _isSyncing;
        private bool _synchroniseSucceed;
        private ICommand _showBrowserCommand;
        private ICommand _webViewNavigatedCommand;

        public StravaViewModel(
            IActivityService activityService,
            IStravaService stravaService,
            IPopupNavigation popupNavigation)
        {
            _activityService = activityService;
            _stravaService = stravaService;
            _popupNavigation = popupNavigation;
        }

        public ICommand ShowBrowserCommand => _showBrowserCommand ??= new Command(() =>
        {
            BrowserVisible = true;
        });

        public ICommand WebViewNavigatedCommand => _webViewNavigatedCommand ??= new AsyncCommand(OnBrowserNavigated);

        public UrlWebViewSource Url
        {
            get => _url;
            set => SetProperty(ref _url, value);
        }

        public bool BrowserVisible
        {
            get => _browserVisible;
            set => SetProperty(ref _browserVisible, value);
        }

        public bool IsSyncing
        {
            get => _isSyncing;
            set => SetProperty(ref _isSyncing, value);
        }

        public bool SynchroniseSucceed
        {
            get => _synchroniseSucceed;
            set => SetProperty(ref _synchroniseSucceed, value);
        }
        public override Task Initialize()
        {
            Url = new UrlWebViewSource
            {
                Url = START_URL,
            };
            return base.Initialize();
        }

        private async Task OnBrowserNavigated()
        {
            if (Url.Url.Contains("error=access_denied"))
            {
                BrowserVisible = false;
                SynchroniseSucceed = false;
                Url.Url = START_URL;
                return;
            }
            if (Url.Url.Contains("code=") && BrowserVisible)
            {
                BrowserVisible = false;
                SynchroniseSucceed = false;

                string code = ExtractStravaCode(Url.Url);

                async Task synchroniseFailedCallbackAction()
                {
                    await _popupNavigation.PushAsync(new DialogPopupPage("Synchronization failed"));
                }

                try
                {
                    await _popupNavigation.PushAsync(new ProgressIndicatorPopupPage());
                    var response = await _stravaService.GetStravaAccessToken(code);
                    await SynchroniseStravaActivities(response.AccessToken);
                    await _popupNavigation.PopAllAsync();
                    await _popupNavigation.PushAsync(new DialogPopupPage("Strava synchronisation success!"));
                }
                catch (FetchingTokenFailedException)
                {
                    await synchroniseFailedCallbackAction();
                }
                catch (StravaSynchroniseFailedException)
                {
                    await synchroniseFailedCallbackAction();
                }
                finally
                {
                    Url.Url = START_URL;
                };
            }
        }

        private string ExtractStravaCode(string url)
        {
            var rx = new Regex("&code=(.+)&");
            var match = rx.Match(url);

            var code = match.Groups[1].Value;
            return code;
        }

        private async Task SynchroniseStravaActivities(string stravaAccessToken)
        {
            if (string.IsNullOrEmpty(stravaAccessToken))
                return;

            try
            {
                await _activityService.SyncStravaActivities(stravaAccessToken);
                SynchroniseSucceed = true;
            }
            catch (StravaSynchroniseFailedException)
            {
                throw;
            }
        }
    }
}

