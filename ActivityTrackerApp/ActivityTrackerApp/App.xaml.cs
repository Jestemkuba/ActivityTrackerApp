using ActivityTrackerApp.Services;
using Xamarin.Forms;
using Autofac;
using Autofac.Core;
using ActivityTrackerApp.ViewModels;
using Rg.Plugins.Popup.Services;
using Rg.Plugins.Popup.Contracts;
using ActivityTrackerApp.Client;
using ActivityTrackerApp.Popups.ViewModels;
using ActivityTrackerApp.Services.Contracts;

namespace ActivityTrackerApp
{
    public partial class App : Application
    {
        static IContainer container;

        public App()
        {
            InitializeComponent();

            var builder = new ContainerBuilder();

            builder.RegisterType<AuthService>().As<IAuthService>();
            builder.RegisterType<ActivityService>().As<IActivityService>();
            builder.RegisterType<StravaService>().As<IStravaService>();

            builder.RegisterType<ActivityTrackerClient>().SingleInstance();
            builder.RegisterType<StravaClient>().SingleInstance();

            builder.RegisterType<LoginViewModel>();
            builder.RegisterType<RegisterViewModel>();
            builder.RegisterType<StartViewModel>();
            builder.RegisterType<ActivitiesViewModel>();
            builder.RegisterType<StravaViewModel>();
            builder.RegisterType<ActivityDetailsViewModel>();
            builder.RegisterType<AddActivityViewModel>();
            builder.RegisterType<DialogPopupViewModel>();

            builder.RegisterInstance(PopupNavigation.Instance).As<IPopupNavigation>();
            container = builder.Build();

            MainPage = new AppShell();
            Shell.Current.GoToAsync("LoginPage");
        }

        public static T Resolve<T>() => container.Resolve<T>();

        public static T Resolve<T>(params Parameter[] parameters) => container.Resolve<T>(parameters);

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
