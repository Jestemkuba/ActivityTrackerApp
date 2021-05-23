using ActivityTrackerApp.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Input;
using Xamarin.Forms;

namespace ActivityTrackerApp.ViewModels
{
    public class StravaViewModel : BaseViewModel
    {
        private const string START_URL = "https://www.strava.com/oauth/authorize?client_id=63072&response_type=code&redirect_uri=https://localhost/exchange_token&approval_prompt=force&scope=activity:read_all";
        private readonly IActivityService _activityService;
        private string _url;
        private bool _browserVisible;
        private bool _isSyncing;
        private bool _synchroniseSucceed;
        private ICommand _showBrowserCommand;

        public StravaViewModel(IActivityService activityService)
        {
            Url = START_URL;
            _activityService = activityService;
        }

        public ICommand ShowBrowserCommand => _showBrowserCommand ??= new Command(() =>
        {
            BrowserVisible = true;
        });

        public string Url 
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
            Url = START_URL;
            return base.Initialize();
        }

        public async void OnWebViewNavigating(object sender, WebNavigatingEventArgs e)
        {
            var url = e.Url;
            if (url.Contains("error=access_denied"))
            {
                BrowserVisible = false;
                SynchroniseSucceed = false;
                (sender as WebView).Source = START_URL;
            }
            if (url.Contains("code=") && BrowserVisible)
            {
                BrowserVisible = false;
                SynchroniseSucceed = false;
                IsSyncing = true;
                var rx = new Regex("&code=(.+)&");
                var match = rx.Match(url);

                var code = match.Groups[1].Value;

                var client = new HttpClient();
                string stravaAccessToken;
                try
                {
                    var builder = new UriBuilder("https://www.strava.com/oauth/token");
                    builder.Port = -1;
                    var query = HttpUtility.ParseQueryString(builder.Query);
                    query["client_id"] = "63072";
                    query["client_secret"] = "563a513fe062b03fa26ad2e9814a5d906826b3be";
                    query["code"] = code;
                    query["grant_type"] = "authorization_code";
                    builder.Query = query.ToString();
                    var requestUrl = builder.ToString();

                    var response = await client.PostAsync(requestUrl, null);
                    var content = await response.Content.ReadAsStringAsync();

                    var jObject = JObject.Parse(content);
                    stravaAccessToken = jObject["access_token"].Value<string>();
                }
                catch (Exception)
                {
                    throw;
                }
                if (!String.IsNullOrEmpty(stravaAccessToken))
                {
                    await _activityService.SyncStravaActivities(stravaAccessToken);
                    SynchroniseSucceed = true;
                }
               
                IsSyncing = false;
                Url = START_URL;
                (sender as WebView).Source = START_URL;
            }           
        }
    }
}
